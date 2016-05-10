using UnityEngine;
using System.Collections;

[System.Serializable]
public class Line
{
	public Vector3[] points = new Vector3[2];

	public Line ()
	{
		Reset ();
	}

	public void Reset ()
	{
		points = new Vector3[2];
		points[0] = Vector3.zero;
		points[1] = Vector3.up;
	}

	public int PointCount
	{
		get
		{
			return points.Length;
		}
	}
}
