using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;
using Zenject;

public class Location : MonoBehaviour, IWorldTickable, IWorldInitializable
{
    [Inject]
    public LocationSettings Settings;
	public float Radius = .5f;

    private Dictionary<NeedSettings, float> _values = new Dictionary<NeedSettings, float>();

	public void WorldTick()
	{
		
	}

    public void WorldInitialize()
    {
        foreach (var need in Settings.Needs)
        {
            _values[need.Need] = UnityEngine.Random.Range(need.Min, need.Max);
        }
    }
}
