using GPInteraction._Scripts.mrstruijk;
using UnityEditor;
using UnityEngine;


namespace GPInteraction._Scripts
{
	[CustomEditor(typeof (EventSO), true)] public class EventEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			GUI.enabled = Application.isPlaying;

			var e = target as EventSO;

			if (GUILayout.Button("Raise"))
			{
				e.Raise();
			}
		}
	}
}