using System.Collections.Generic;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class BuffBuilder : MonoBehaviour
{

	[Inject]
	World _world;

	public Location Location;
	public BuffSettings Buff;

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
		var costs = Buff.Cost;
		var enoughMoney = _world.Money >= costs;
		Button.interactable = enoughMoney;
	}

	public void OnClick()
	{
		Location.TriggerBuff(Buff);
	}
}