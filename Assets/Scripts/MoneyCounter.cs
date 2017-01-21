using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Text))]
public class MoneyCounter : MonoBehaviour
{

	Text _text;
	[Inject] private World _world;

	void Awake()
	{
		_text = GetComponent<Text>();
	}

	void Update()
	{
		_text.text = _world.Money.ToString();
	}
}