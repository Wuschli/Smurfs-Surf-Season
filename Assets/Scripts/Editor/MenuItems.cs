using UnityEditor;
using Settings;

namespace Editor
{
    public static class MenuItems
    {
        [MenuItem("Assets/Create/Settings/NeedSettings")]
        public static void CreateNeedSettings()
        {
            ScriptableObjectUtility.CreateAsset<NeedSettings>();
        }

        [MenuItem("Assets/Create/Settings/AgentSettings")]
        public static void CreateAgentSettings()
        {
            ScriptableObjectUtility.CreateAsset<AgentSettings>();
        }

		[MenuItem("Assets/Create/Settings/LocationSettings")]
		public static void CreateLocationSettings()
		{
			ScriptableObjectUtility.CreateAsset<LocationSettings>();
		}

		[MenuItem("Assets/Create/Settings/WorldSettings")]
		public static void CreateWorldSettings()
		{
			ScriptableObjectUtility.CreateAsset<WorldSettings>();
		}
    }
}
