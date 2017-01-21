using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class HutBuilder : MonoBehaviour
{

	[Inject]
	World _world;

	public Location Location;
	public BuildingSettings Building;

	Button _button;

	Button Button
	{
		get
		{
			if (_button == null)
				_button = GetComponent<Button>();
			return _button;
		}
	}

	void Update()
	{
		var costs = Building.Cost;
		var freeSpots = Location.HasFreeBuildingSpot;
		var enoughMoney = _world.Money >= costs;
		Button.interactable = freeSpots && enoughMoney;
	}

	public void OnClick()
	{
		Location.AddBuilding(Building);
	}
}