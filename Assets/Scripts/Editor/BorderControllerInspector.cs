using UnityEngine;
using UnityEditor;

[CustomEditor ( typeof ( BorderController ) )]
public class BorderControllerInspector : Editor
{
	BorderController borderController;

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();
		borderController = target as BorderController;
		if (GUILayout.Button ( "Reset Line" ))
		{
			Undo.RecordObject ( borderController, "Reset Line" );
			borderController.line.Reset ();
			EditorUtility.SetDirty ( borderController );
		}
		if (GUILayout.Button ( "Update Line" ))
		{
			Undo.RecordObject ( borderController, "Update Line" );
			borderController.UpdateLine ();
			borderController.GenerateBorder ();
			EditorUtility.SetDirty ( borderController );
		}
	}

	private void OnSceneGUI ()
	{
		if (borderController != null)
		{
			//ShowLine ();
		}
	}

	private void ShowLine ()
	{
		Handles.color = Color.red;
		for (int i = 0; i < borderController.line.PointCount - 1; i++)
		{
			Vector3 p0 = borderController.line.points[i];
			Vector3 p1 = borderController.line.points[i + 1];
			Handles.DrawLine ( p0, p1 );
		}
	}
}
