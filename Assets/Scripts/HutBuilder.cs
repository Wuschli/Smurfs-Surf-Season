using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class HutBuilder : MonoBehaviour {

	[Inject] World _world;

	public Location Location;
	public BuildingSettings Building;

	Button _button;


	void Awake()
	{
		_button = GetComponent<Button>();
	}

	void Update()
	{
		if (Location == null || _world == null)
			return;
		_button.interactable = Location.HasFreeBuildingSpot && _world.Money >= Building.Cost;
	}

	public void OnClick()
	{
		Debug.Log("Build Hut");
		Location.AddBuilding(Building);
	}
}
