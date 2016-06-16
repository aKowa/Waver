using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(BorderMusicController))]
public class BorderMusicControllerInspector : Editor
{
	private BorderMusicController borderMusicController;

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		borderMusicController = target as BorderMusicController;
		if (GUILayout.Button("Set Border"))
		{
			
		}
	}

	private void OnSceneGUI()
	{
		if (borderMusicController != null)
		{
			Handles.color = Color.red;
			Handles.DrawLines(borderMusicController.GetPoints());
		}
	}
}
