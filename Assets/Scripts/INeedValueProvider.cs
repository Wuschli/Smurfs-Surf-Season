using System;
using Settings;
using Zenject;

public interface INeedValueProvider
{
	float Value { get; }
	[Inject] NeedSettings NeedType { get; set; }
	[Inject] Location Location { get; set; }
}
