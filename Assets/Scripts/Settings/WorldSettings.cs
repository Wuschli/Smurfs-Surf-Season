using System;
using UnityEngine;

public class WorldSettings : ScriptableObject
{
	public float TickLength = 1f;
	public AnimationCurve SpawnRate = AnimationCurve.Linear(0, 1, 200, 0);
}
