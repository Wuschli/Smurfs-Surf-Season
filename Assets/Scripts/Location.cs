using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using Factories;
using UnityEngine;
using Zenject;
using System.Linq;

public class Location : MonoBehaviour, IWorldTickable, IWorldInitializable
{
    [Inject] public LocationSettings Settings;
	[Inject] private NeedValueProviderFactory _needValueProviderFactory;
	[Inject] private World _world;
	public float Radius = .5f;
	public int Size = 15;
	public NeedBuff CurrentBuff = null;

	public Dictionary<NeedSettings, INeedValueProvider> Values = new Dictionary<NeedSettings, INeedValueProvider>();
	public HashSet<Agent> Agents = new HashSet<Agent>();

	private IEnumerable<BuildingSpot> _buildingSpots;

	public bool HasFreeBuildingSpot
	{
		get
		{
			return _buildingSpots.Any(spot => spot.Building == null);
		}
	}

	public void WorldTick()
	{
		if (CurrentBuff != null)
		{
			CurrentBuff.Tick();
			if (CurrentBuff.IsDone)
				CurrentBuff = null;
		}
		_world.Money += _buildingSpots.Where(spot => spot.Building != null).Sum(spot => spot.Building.Income) * Agents.Count;
		_world.Money -= _buildingSpots.Where(spot => spot.Building != null).Sum(spot => spot.Building.MaintenanceCost);
	}

    public void WorldInitialize()
    {
		_buildingSpots = GetComponentsInChildren<BuildingSpot>();
        foreach (var need in Settings.Needs)
        {
			Values[need.Need] = _needValueProviderFactory.Create(need, this);
        }
    }

	public void AddBuilding(BuildingSettings building)
	{
		if (!HasFreeBuildingSpot)
			return;
		if (_world.Money >= building.Cost)
		{
			_buildingSpots.First(spot => spot.Building == null).Building = building;
			_world.Money -= building.Cost;
		}
	}

	public void TriggerBuff(BuffSettings buff){
		if (_world.Money >= buff.Cost)
		{
			CurrentBuff = new TempBuff(buff);
			_world.Money -= buff.Cost;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, Radius);
	}
}
