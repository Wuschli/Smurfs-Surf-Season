using System;
using Settings;
using UnityEngine;
using Zenject;

public class RushNeedValueProvider : INeedValueProvider
{
	[Inject]
	public Location Location { get; set; }
	[Inject]
	public NeedSettings NeedType { get; set; }

	public float Value
	{
		get
		{
			return Mathf.Lerp(10f, 0f, (float)Location.Agents.Count / (float)Location.Size);
		}
	}
}
