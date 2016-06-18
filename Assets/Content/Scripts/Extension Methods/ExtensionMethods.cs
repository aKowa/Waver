using UnityEngine;

public static class ExtensionMethods
{
	public static Vector2[] ToVector2 (this Vector3[] vec3 )
	{
		var vec2 = new Vector2[vec3.Length];
		for (var i =0; i < vec3.Length; i++)
		{
			vec2[i] = vec3[i];
		}
		return vec2;
	}

	public static Vector3[] ToVector3(this Vector2[] vec2)
	{
		var vec3 = new Vector3[vec2.Length];
		for(var i = 0; i < vec2.Length; i++)
		{
			vec3[i] = vec2[i];
		}
		return vec3;
	}
}
