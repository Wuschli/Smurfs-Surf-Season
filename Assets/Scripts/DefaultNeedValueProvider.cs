using System;
using Zenject;

public class DefaultNeedValueProvider : INeedValueProvider, IWorldTickable
{
	[Inject] public Location Location { get; set; }

	public float Value { get; private set;}

	public DefaultNeedValueProvider(float startValue)
	{
		Value = startValue;
	}

	public void WorldTick()
	{
		Value += UnityEngine.Random.Range(-1, 1);
	}
}
