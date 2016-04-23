using UnityEngine;
//using System.Collections;

public static class Line
{
	private static Vector3[] points = new Vector3[2];

	public static Vector3[] Points
	{
		get
		{
			points = new Vector3[5];

			for(int i = 0; i < points.Length; i++)
			{
				points[i] = new Vector3(i/2, i, 0);
			}
			return points;
		}

		set
		{
			points = value;
		}
	}
}
