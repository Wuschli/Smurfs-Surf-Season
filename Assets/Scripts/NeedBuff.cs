using System;
using Settings;

public abstract class NeedBuff
{
	public bool IsDone
	{
		get
		{
			return TicksLeft < 0;
		}
	}
	public BuffSettings Settings { get; private set; }
	public int TicksLeft { get; private set; }

	protected NeedBuff(BuffSettings settings)
	{
		Settings = settings;
		TicksLeft = settings.TickDuration;
	}

	public abstract float Apply(float currentValue, float minChange, float maxChange);


	public void Tick()
	{
		TicksLeft--;
	}
}

public class TempBuff : NeedBuff
{
	private float _modifier = 0.2f;

	public TempBuff(BuffSettings settings) : base(settings) { }

	public override float Apply(float currentValue, float minChange, float maxChange)
	{
		var factor = currentValue / Settings.Category.MaxValue;
		return UnityEngine.Random.Range(factor * minChange + _modifier, (1 / factor) * maxChange + _modifier);
	}
}

public class GargamelAlarm : NeedBuff
{
	public GargamelAlarm(BuffSettings settings) : base(settings) { }

	public override float Apply(float currentValue, float minChange, float maxChange)
	{
		if (TicksLeft < 1)
			return UnityEngine.Random.Range(2f, 7f);
		return -currentValue;
	}
}