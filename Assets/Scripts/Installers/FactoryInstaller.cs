using Factories;
using Zenject;

namespace Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<Agent, AgentFactory>().FromFactory<CustomAgentFactory>();
        }
    }
}
