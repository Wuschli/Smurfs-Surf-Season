using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
		var currentDay = (int)(TickCounter / _world.Settings.TicksPerDay) + 1;
		GetComponent<Text>().text = currentDay + "/" + _world.Settings.DayLimit;
		if (currentDay >= _world.Settings.DayLimit)
			SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
}