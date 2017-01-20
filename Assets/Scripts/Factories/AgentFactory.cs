using System.Collections.Generic;
using System.Linq;
using Settings;
using Zenject;

namespace Factories
{
    public class AgentFactory : Factory<Agent>
    {

    }

    public class CustomAgentFactory : IFactory<Agent>
    {
        private readonly DiContainer _container;
        private readonly List<AgentSettings> _settings;
        private readonly float _probabilitySum;

        public CustomAgentFactory(DiContainer container, List<AgentSettings> settings)
        {
            _container = container;
            _settings = settings;
            _probabilitySum = _settings.Sum(s => s.Propability);
        }

        public Agent Create()
        {
            float random = UnityEngine.Random.value;
            AgentSettings settings = null;
            float r = 0f;
            foreach (var s in _settings)
            {
                r += s.Propability / _probabilitySum;
                if (r > random)
                {
                    settings = s;
                    break;
                }
            }

            if (settings == null)
                settings = _settings.First();

            var result = _container.InstantiatePrefabForComponent<Agent>(settings.Prefab);
            foreach (var range in settings.NeedRanges)
                result.Multipliers[range.Need] = UnityEngine.Random.Range(range.Min, range.Max);
            return result;
        }
    }
}
