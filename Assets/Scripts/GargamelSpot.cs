using System;
using UnityEngine;
using Zenject;

public class GargamelSpot : MonoBehaviour, IWorldTickable
{
	public Location Location;
	public GameObject Target;

	public bool IsActive
	{
		get
		{
			return _active;
		}
		set
		{
			_active = value;
			_timer = _worldSettings.GargamelDuration;
			Target.SetActive(value);
		}
	}

	[Inject] private WorldSettings _worldSettings;
	private int _timer;
	private bool _active;

	public void WorldTick()
	{
		if (IsActive)
			Location.EatSmurfs();
		_timer--;
		if (_timer <= 0)
			IsActive = false;
	}
}