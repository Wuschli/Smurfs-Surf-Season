using Settings;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
    public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        public AgentSettings[] AgentSettings;
        public NeedSettings[] NeedSettings;
        public LocationSettings LocationSettings;
		public WorldSettings WorldSettings;

        public override void InstallBindings()
        {
            foreach (var settings in AgentSettings)
                Container.BindInstance(settings);
            foreach (var settings in NeedSettings)
                Container.BindInstance(settings);
            Container.BindInstance(LocationSettings);
			Container.BindInstance(WorldSettings);
        }
    }
}
