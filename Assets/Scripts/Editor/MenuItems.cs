using System;
using UnityEditor;

namespace AssemblyCSharp
{
	public class MenuItems
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
	}
}
