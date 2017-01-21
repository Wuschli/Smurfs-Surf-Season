using Zenject;

namespace Installers
{
    public class WorldInstaller : MonoInstaller
    {
        public Map Map;

        public override void InstallBindings()
        {
			Container.BindAllInterfacesAndSelf<World>().To<World>().AsSingle();
            Container.BindAllInterfacesAndSelf<Map>().FromInstance(Map);
            foreach (var location in Map.GetComponentsInChildren<Location>())
            {
                Container.BindAllInterfacesAndSelf<Location>().FromInstance(location);
            }
			Container.BindAllInterfacesAndSelf<AgentSpawnerSink>().FromInstance(Map.GetComponentInChildren<AgentSpawnerSink>());
        }
    }
}
