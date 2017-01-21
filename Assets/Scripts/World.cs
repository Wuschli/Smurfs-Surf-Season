using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;
using Zenject;

public class World: ITickable
{
	public readonly HashSet<Agent> Agents = new HashSet<Agent>();

	[Inject] private WorldSettings _settings;
	[Inject] private List<IWorldTickable> _tickables;
	[Inject] private List<IWorldInitializable> _initializables;
	private float _tickTimer = 0f;

	public void Register(object obj)
	{
		if (obj is IWorldInitializable)
			_initializables.Add(obj as IWorldInitializable);
		else if (obj is IWorldTickable)
			_tickables.Add(obj as IWorldTickable);
	}

	public void Tick()
	{
		_tickTimer += Time.deltaTime;
		if (_tickTimer < _settings.TickLength)
			return;
		_tickTimer = 0f;

		Profiler.BeginSample("WorldTick");

		while (_initializables.Count > 0)
		{
			var initializable = _initializables.First();
			_initializables.RemoveAt(0);
			initializable.WorldInitialize();
			if (initializable is IWorldTickable && !_tickables.Contains(initializable as IWorldTickable))
				_tickables.Add(initializable as IWorldTickable);
		}

		foreach (var tickable in _tickables)
			tickable.WorldTick();
		Profiler.EndSample();
	}
}
