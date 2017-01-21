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

	public void WorldInitialize()
	{
		for (int i = 0; i < 10; i++)
		{
			SpawnAgent();
		}
	}

	public void WorldTick()
	{
		SpawnAgent();
	}

	private void SpawnAgent()
    {
        var agent = _agentAgentFactory.Create();
        agent.transform.position = transform.position;
		_world.Register(agent);
    }
}
