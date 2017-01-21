﻿using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Settings;
using UnityEngine;
using Zenject;

public class Agent : MonoBehaviour, IWorldInitializable, IWorldTickable
{
    public Location CurrentTarget;
	public AgentSettings Settings;

    [Inject] private Map _map;
    [Inject] private List<Location> _locations;

    public Dictionary<NeedSettings, float> Multipliers = new Dictionary<NeedSettings, float>();
	private Tweener _activeTween;
	private int _idleTimer;


    public void WorldInitialize()
    {
        SelectNewTarget();
    }

    private void SelectNewTarget()
    {
		var newTarget = CalculatePreferedLocation();
		if (_idleTimer > 0)
			return;
		var offset = UnityEngine.Random.insideUnitCircle * newTarget.Radius;
		var targetPosition = newTarget.transform.position;
		targetPosition.x += offset.x;
		targetPosition.y += offset.y;
		_activeTween = transform.DOMove(targetPosition, (targetPosition - transform.position).magnitude / Settings.movementSpeed);
		_activeTween.OnComplete(() =>
		{
			_activeTween = null;
			newTarget.Agents.Add(this);
		});
		_activeTween.SetEase(Ease.Linear);
		if (newTarget != CurrentTarget)
		{
			_idleTimer = Settings.idleTicks;
			if (CurrentTarget != null)
				CurrentTarget.Agents.Remove(this);
			CurrentTarget = newTarget;
		}
		else {
			_idleTimer = Settings.sameLocationIdleTicks;
		}
    }

	public void WorldTick()
	{
		if (_activeTween != null)
			return;
		_idleTimer--;
		SelectNewTarget();
	}

	private Location CalculatePreferedLocation()
	{
		return _locations.OrderByDescending(loc =>
		{
			return loc.Values.Sum(val => val.Value.Value * Multipliers[val.Key]);
		}).First();
	}
}
