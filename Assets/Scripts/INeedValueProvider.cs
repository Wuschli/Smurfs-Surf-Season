using System;
using Settings;

public interface INeedValueProvider
{
	float Value { get; }
	//NeedSettings NeedType { get; set; }
	Location Location { get; set; }
}
