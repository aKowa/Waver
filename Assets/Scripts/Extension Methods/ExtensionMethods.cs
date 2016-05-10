using UnityEngine;

public static class ExtensionMethods
{
	public static Vector2[] ToVector2 (this Vector3[] vec3 )
	{
		Vector2[] targetVec2 = new Vector2[vec3.Length];
		for (int i =0; i < vec3.Length; i++)
		{
			targetVec2[i] = (Vector2)vec3[i];
		}
		return targetVec2;
	}
}
