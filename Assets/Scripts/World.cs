using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Profiling;
using Zenject;

public class World: ITickable, IInitializable
{
	public static int Score;

	public readonly HashSet<Agent> Agents = new HashSet<Agent>();
	public int Money;
	public float TimeScale
	{
		get
		{
			return _timeScale;
		}
		set
		{
			_timeScale = value;
			DOTween.timeScale = value;
		}
	}

	[Inject] public WorldSettings Settings;
	[Inject] private List<IWorldTickable> _tickables;
	[Inject] private List<IWorldInitializable> _initializables;
	[Inject] private List<GargamelSpot> _gargamelSpots;
	private float _tickTimer = 0f;
	private int _gargamelTimer;
	private float _timeScale = 1f;

	public void Register(object obj)
	{
		if (obj is IWorldInitializable)
			_initializables.Add(obj as IWorldInitializable);
		else if (obj is IWorldTickable)
			_tickables.Add(obj as IWorldTickable);
	}

	public void Deregister(object obj)
	{
		if (obj is IWorldInitializable)
			_initializables.Remove(obj as IWorldInitializable);
		else if (obj is IWorldTickable)
			_tickables.Remove(obj as IWorldTickable);
	}

	public void Tick()
	{
		_tickTimer -= Time.deltaTime * TimeScale;
		if (_tickTimer > 0)
			return;
		_tickTimer = Settings.TickLength;

		Profiler.BeginSample("WorldTick");

		while (_initializables.Count > 0)
		{
			var initializable = _initializables.First();
			_initializables.RemoveAt(0);
			initializable.WorldInitialize();
			if (initializable is IWorldTickable && !_tickables.Contains(initializable as IWorldTickable))
				_tickables.Add(initializable as IWorldTickable);
		}

		_tickables.RemoveAll((obj) => obj == null || (obj is UnityEngine.Object && (obj as UnityEngine.Object) == null));

		foreach (var tickable in _tickables)
			tickable.WorldTick();
		Profiler.EndSample();

		CalcGargamel();

		Money = Math.Max(0, Money);
		Score = Money;
	}

	public void Initialize()
	{
		Money = Settings.StartingMoney;
		_gargamelTimer = Settings.GargamelTimeout;
	}

	void CalcGargamel()
	{
		_gargamelTimer--;
		if (_gargamelTimer > 0)
			return;
		float r = UnityEngine.Random.value;
		if (r > Settings.GargamelProbability)
			return;
		var spot = _gargamelSpots[UnityEngine.Random.Range(0, _gargamelSpots.Count - 1)];
		spot.IsActive = true;
		_gargamelTimer = Settings.GargamelTimeout;
	}
}
