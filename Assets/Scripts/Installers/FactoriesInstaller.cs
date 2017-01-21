using Factories;
using Settings;
using Zenject;

namespace Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
			Container.BindFactory<Agent, AgentFactory>().FromFactory<CustomAgentFactory>();
			Container.BindFactory<NeedRange, Location, INeedValueProvider, NeedValueProviderFactory>().FromFactory<CustomNeedValueProviderFactory>();
        }
    }
}
