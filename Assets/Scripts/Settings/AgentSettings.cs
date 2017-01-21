using UnityEngine;

namespace Settings
{
    public class AgentSettings : ScriptableObject
    {
        public Agent Prefab;
        public NeedRange[] NeedRanges;
        public float Propability;
		public int idleTicks = 5;
		public int sameLocationIdleTicks = 3;
		public float movementSpeed = 1f;
		public float minNeedSum = 25f;
    }
}
