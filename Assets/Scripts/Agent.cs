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
		var newTarget = CalculatePreferedLocation();
		if (_idleTimer > 0)
			return;
		if (newTarget != CurrentTarget)
		{
			_idleTimer = Settings.idleTicks;
			CurrentTarget = newTarget;
		}
		else {
			_idleTimer = Settings.sameLocationIdleTicks;
		}
		var offset = UnityEngine.Random.insideUnitCircle * CurrentTarget.Radius;
		var targetPosition = CurrentTarget.transform.position;
		targetPosition.x += offset.x;
		targetPosition.y += offset.y;
		_activeTween = transform.DOMove(targetPosition, (targetPosition - transform.position).magnitude / Settings.movementSpeed);
		_activeTween.OnComplete(() => _activeTween = null);
		_activeTween.SetEase(Ease.Linear);
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
