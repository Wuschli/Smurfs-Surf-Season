using System;
using UnityEditor;
using UnityEngine;

namespace Editor{
	[CustomEditor(typeof(Location))]
	public class LocationEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			if (EditorApplication.isPlaying)
				EditorUtility.SetDirty(target);
			Location targetLocation = (Location) target;
			DrawDefaultInspector ();
			foreach (var val in targetLocation.Values)
			{
				EditorGUILayout.LabelField(val.Key.name, val.Value.Value.ToString());
			}
			EditorGUILayout.LabelField("Agents", targetLocation.Agents.Count.ToString());
		}
	}
}