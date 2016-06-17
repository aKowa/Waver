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
		borderMusicController = target as BorderMusicController;

		if (borderMusicController == null) return;

		if (GUILayout.Button("Set Points"))
		{
			borderMusicController.SetPoints();
		}

		if (GUILayout.Button("Reset Points"))
		{
			borderMusicController.ResetPoints();
		}

		DrawDefaultInspector ();
	}

	private void OnSceneGUI()
	{
		if (borderMusicController != null)
		{
			Handles.color = Color.red;
			var points = borderMusicController.GetPoints ();
			for (var i = 0; i < points.Length - 1; i++)
			{
				Handles.DrawLine ( points[i], points[i + 1] );
			}
		}
	}
}
