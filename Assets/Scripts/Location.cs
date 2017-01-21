using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using Factories;
using UnityEngine;
using Zenject;

public class Location : MonoBehaviour, IWorldTickable, IWorldInitializable
{
    [Inject] public LocationSettings Settings;
	[Inject] private NeedValueProviderFactory _needValueProviderFactory;
	public float Radius = .5f;

	public Dictionary<NeedSettings, INeedValueProvider> Values = new Dictionary<NeedSettings, INeedValueProvider>();

	public void WorldTick()
	{
		
	}

    public void WorldInitialize()
    {
        foreach (var need in Settings.Needs)
        {
            //Values[need.Need] = UnityEngine.Random.Range(need.Min, need.Max);
			Values[need.Need] = _needValueProviderFactory.Create(need, this);
        }
    }

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, Radius);
	}
}
