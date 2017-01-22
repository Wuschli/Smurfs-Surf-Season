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
				var gargamelSpot = location.GetComponentInChildren<GargamelSpot>();
				if (gargamelSpot != null)
					Container.BindAllInterfacesAndSelf<GargamelSpot>().FromInstance(gargamelSpot);
            }
			Container.BindAllInterfacesAndSelf<AgentSpawnerSink>().FromInstance(Map.GetComponentInChildren<AgentSpawnerSink>());
        }
    }
}
