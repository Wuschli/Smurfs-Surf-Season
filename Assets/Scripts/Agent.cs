using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Agent : MonoBehaviour, ITickable
{
    public Location CurrentTarget;

	[Inject]
	public Map Map;

	[Inject]
	public IList<NeedSettings> Needs;

	public Dictionary<NeedSettings, float> Multipliers = new Dictionary<NeedSettings, float>();

	public void Tick()
	{
		
	}
}
