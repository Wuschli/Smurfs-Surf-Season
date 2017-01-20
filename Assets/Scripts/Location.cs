using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;
using Zenject;

public class Location : MonoBehaviour, ITickable, IInitializable
{
    [Inject]
    public LocationSettings Settings;

    private Dictionary<NeedSettings, float> _values = new Dictionary<NeedSettings, float>();

	public void Tick()
	{
		
	}

    public void Initialize()
    {
        foreach (var need in Settings.Needs)
        {
            _values[need.Need] = UnityEngine.Random.Range(need.Min, need.Max);
        }
    }
}
