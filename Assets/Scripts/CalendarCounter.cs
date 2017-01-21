using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Text))]
public class CalendarCounter : MonoBehaviour, IWorldTickable
{

	Text _text;
	[Inject] private World _world;
	int TickCounter = 0;

	public void WorldTick()
	{
		TickCounter++;
		GetComponent<Text>().text = (int)(TickCounter / _world.Settings.TicksPerDay) + 1 + "/" + _world.Settings.DayLimit;
	}
}