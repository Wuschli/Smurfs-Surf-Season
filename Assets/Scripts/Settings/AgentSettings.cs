using UnityEngine;

namespace Settings
{
    public class AgentSettings : ScriptableObject
    {
        public Agent Prefab;
        public NeedRange[] NeedRanges;
        public float Propability;
		public int idleTicks = 5;
    }
}
