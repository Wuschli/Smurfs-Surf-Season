using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Factories;
using UnityEngine;
using Zenject;

public class AgentSpawnerSink : MonoBehaviour, IInitializable
{
    [Inject] private AgentFactory _agentAgentFactory;

    public void Initialize()
    {
        StartCoroutine(AgentSpawner());
    }

    private IEnumerator AgentSpawner()
    {
        while (true)
        {
            SpawnAgent();
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    private void SpawnAgent()
    {
        var agent = _agentAgentFactory.Create();
        agent.transform.position = transform.position;
    }
}
