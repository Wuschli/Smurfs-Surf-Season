using System;
using Settings;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BuildingSpot : MonoBehaviour
{
	public BuildingSettings Building
	{
		get
		{
			return _building;
		}
		set
		{
			_building = value;
			Renderer.sprite = _building.Icon;
		}
	}

	SpriteRenderer _renderer;

	private SpriteRenderer Renderer
	{
		get
		{
			if (_renderer == null)
				_renderer = GetComponent<SpriteRenderer>();
			return _renderer;
		}
	}

	private BuildingSettings _building;
}