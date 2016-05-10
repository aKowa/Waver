using UnityEngine;
using UnityEditor;

[CustomEditor ( typeof ( BorderController ) )]
public class BorderControllerInspector : Editor
{
	BorderController controller;

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();
		controller = target as BorderController;
		if (GUILayout.Button ( "Reset Line" ))
		{
			Undo.RecordObject ( controller, "Reset Line" );
			controller.line.Reset ();
			EditorUtility.SetDirty ( controller );
		}
		if (GUILayout.Button ( "Update Line" ))
		{
			Undo.RecordObject ( controller, "Update Line" );
			controller.UpdateLine ();
			controller.GenerateBorder ();
			EditorUtility.SetDirty ( controller );
		}
	}

	private void OnSceneGUI ()
	{
		if (controller.line != null)
		{
			//ShowLine ();
		}
	}

	private void ShowLine ()
	{
		Handles.color = Color.red;
		for (int i = 0; i < controller.line.PointCount - 1; i++)
		{
			Vector3 p0 = controller.line.points[i];
			Vector3 p1 = controller.line.points[i + 1];
			Handles.DrawLine ( p0, p1 );
		}
	}
}
