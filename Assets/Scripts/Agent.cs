using System;
using System.Collections;
using System.Collections.Generic;
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
        CurrentTarget = _locations[UnityEngine.Random.Range(0, _locations.Count)];
		var offset = UnityEngine.Random.insideUnitCircle * CurrentTarget.Radius;
		var targetPosition = CurrentTarget.transform.position;
		targetPosition.x += offset.x;
		targetPosition.y += offset.y;
		_activeTween = transform.DOMove(targetPosition, 2);
		_activeTween.OnComplete(() => _activeTween = null);
		_activeTween.SetEase(Ease.Linear);
		_idleTimer = Settings.idleTicks;
    }

	public void WorldTick()
	{
		if (_idleTimer > 0)
		{
			_idleTimer--;
			return;
		}
		if (_activeTween == null)
		{
			SelectNewTarget();
		}
	}
}
