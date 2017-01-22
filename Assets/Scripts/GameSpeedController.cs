using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public class GameSpeedController : MonoBehaviour 
{
	public GameSpeed[] Speeds;

	private Image _image;
	private int _currentIndex = 0;
	[Inject] private World _world;

	public void Start()
	{
		_image = GetComponent<Image>();
		UpdateSpeed();
	}

	public void ToggleSpeed()
	{
		_currentIndex = (_currentIndex + 1) % Speeds.Length;
		UpdateSpeed();
	}

	void UpdateSpeed()
	{
		_world.TimeScale = Speeds[_currentIndex].Speed;
		_image.sprite = Speeds[_currentIndex].Image;
	}

	[Serializable]
	public class GameSpeed
	{
		public Sprite Image;
		public float Speed;
	}
}
