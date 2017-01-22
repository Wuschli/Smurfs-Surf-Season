using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Factories;
using UnityEngine;
using Zenject;

public class AgentSpawnerSink : MonoBehaviour, IWorldTickable, IWorldInitializable
{
    [Inject] private AgentFactory _agentAgentFactory;
	[Inject] private World _world;
	[Inject] private WorldSettings _worldSettings;

	public void WorldInitialize()
	{
		for (int i = 0; i < _world.Settings.StartingPopulation; i++)
		{
			SpawnAgent();
		}
	}

	public void WorldTick()
	{
		if (_worldSettings.SpawnRate.Evaluate(_world.Agents.Count) > UnityEngine.Random.value)
			SpawnAgent();
	}

	private void SpawnAgent()
    {
        var agent = _agentAgentFactory.Create();
        agent.transform.position = transform.position;
		_world.Register(agent);
		_world.Agents.Add(agent);
    }
}
