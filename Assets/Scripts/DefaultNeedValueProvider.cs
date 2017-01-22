using System;
using Settings;
using UnityEngine;
using Zenject;

public class DefaultNeedValueProvider : INeedValueProvider, IWorldTickable
{
	[Inject]
	public Location Location { get; set; }
	[Inject]
	public NeedSettings NeedType { get; set; }

	public float Value { get; private set; }

	public DefaultNeedValueProvider(float startValue)
	{
		Value = startValue;
	}

	public void WorldTick()
	{
		if (Location.CurrentBuff != null && (Location.CurrentBuff.Settings.Category == NeedType || Location.CurrentBuff.Settings.Category == null))
			Value += Location.CurrentBuff.Apply(Value, -NeedType.MaxChange / 2f, NeedType.MaxChange / 2f);
		else
			Value += UnityEngine.Random.Range(-NeedType.MaxChange / 2f, NeedType.MaxChange / 2f);
		Value = Mathf.Clamp(Value, NeedType.MinValue, NeedType.MaxValue);
	}
}