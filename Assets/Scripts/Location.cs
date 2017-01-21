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

	public Dictionary<NeedSettings, float> Values = new Dictionary<NeedSettings, float>();

	public void WorldTick()
	{
		
	}

    public void WorldInitialize()
    {
        foreach (var need in Settings.Needs)
        {
            Values[need.Need] = UnityEngine.Random.Range(need.Min, need.Max);
        }
    }

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, Radius);
	}
}
