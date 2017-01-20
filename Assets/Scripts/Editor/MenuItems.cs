using Settings;
using UnityEditor;

namespace Editor
{
    public static class MenuItems
    {
        [MenuItem("Assets/Create/NeedSettings")]
        public static void CreateNeedSettings()
        {
            ScriptableObjectUtility.CreateAsset<NeedSettings>();
        }

        [MenuItem("Assets/Create/AgentSettings")]
        public static void CreateAgentSettings()
        {
            ScriptableObjectUtility.CreateAsset<AgentSettings>();
        }

        [MenuItem("Assets/Create/LocationSettings")]
        public static void CreateLocationSettings()
        {
            ScriptableObjectUtility.CreateAsset<LocationSettings>();
        }
    }
}
