using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D) )]
public class BorderController : MonoBehaviour
{
	private LineRenderer line;
	public LineRenderer Line
	{
		get
		{
			if (line != null)
			{
				return line;
			}
			return line = GetComponent<LineRenderer>();

		}
	}

	private EdgeCollider2D edge;
	public EdgeCollider2D Edge
	{
		get
		{
			if (edge != null)
			{
				return edge;
			}
			return edge = GetComponent<EdgeCollider2D>();
		}
	}
	
	public void SetBorder(float[] samples, int size)
	{
		var points = GetPoints(samples, 0, size);
		Edge.points = points;
		Line.SetVertexCount(size);
		Line.SetPositions(points.ToVector3());
	}
	
	private Vector2[] GetPoints ( float[] samples, int position, int size )
	{
		var points = new Vector2[samples.Length];
		for (var i = 0; i < points.Length; i++)
		{
			points[i].x = samples[i] + transform.localPosition.x;
			points[i].y = (position + i) * 0.5f;
		}
		return points;
	}
}
