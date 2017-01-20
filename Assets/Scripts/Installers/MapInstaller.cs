using Zenject;

namespace Installers
{
    public class MapInstaller : MonoInstaller
    {
        public Map Map;

        public override void InstallBindings()
        {
            Container.BindAllInterfacesAndSelf<Map>().FromInstance(Map);
            foreach (var location in Map.GetComponentsInChildren<Location>())
            {
                Container.BindAllInterfacesAndSelf<Location>().FromInstance(location);
            }
            foreach (var agentSpawnerSink in Map.GetComponentsInChildren<AgentSpawnerSink>())
                Container.BindAllInterfacesAndSelf<AgentSpawnerSink>().FromInstance(agentSpawnerSink);
        }
    }
}
