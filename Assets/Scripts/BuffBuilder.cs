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
	public Sprite AvailableSprite;
	public Sprite ActiveSprite;
	public Sprite DisabledSprite;

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
		var interactable = enoughMoney && Location.CurrentBuff == null;
		if (!interactable)
		{
			var state = Button.spriteState;
			if (Location.CurrentBuff != null && Location.CurrentBuff.Settings == Buff)
				state.disabledSprite = ActiveSprite;
			else
				state.disabledSprite = DisabledSprite;
			Button.spriteState = state;
		}
		Button.interactable = interactable;
		//Button.spriteState.highlightedSprite
	}

	public void OnClick()
	{
		Location.TriggerBuff(Buff);
	}
}