using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Settings;
using UnityEngine;
using Zenject;

public class Agent : MonoBehaviour, IInitializable
{
    public Location CurrentTarget;

    [Inject] private Map _map;
    [Inject] private List<Location> _locations;

    public Dictionary<NeedSettings, float> Multipliers = new Dictionary<NeedSettings, float>();

    [Inject]
    public void Initialize()
    {
        SelectNewTarget();
    }

    private void SelectNewTarget()
    {
        CurrentTarget = _locations[UnityEngine.Random.Range(0, _locations.Count)];
        transform.DOMove(CurrentTarget.transform.position, 2).OnComplete(SelectNewTarget);
    }
}
