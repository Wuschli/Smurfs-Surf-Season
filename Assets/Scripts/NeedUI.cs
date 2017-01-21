using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Settings;

[RequireComponent(typeof(Image))]
public class NeedUI : MonoBehaviour {
	public NeedSettings NeedType;
	public Location Location;
	private Image _target;

	void Awake()
	{
		_target = GetComponent<Image>();
	}

	void Update()
	{
		if (!Location.Values.ContainsKey(NeedType))
			return;
		Sprite sprite = NeedType.LowIcon;
		if (Location.Values[NeedType].Value >= 8f)
			sprite = NeedType.HighIcon;
		else if (Location.Values[NeedType].Value >= 3f)
			sprite = NeedType.MediumIcon;
		if (_target.sprite != sprite)
		{
			_target.sprite = sprite;
			_target.SetNativeSize();
		}
	}
}
