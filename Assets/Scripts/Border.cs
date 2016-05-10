using UnityEngine;

public class Border
{
	private LineRenderer lineRenderer;
	private EdgeCollider2D edge;

	public LineRenderer LineRend
	{
		get
		{
			return lineRenderer;
		}
		set
		{
			lineRenderer = value;
		}
	}

	public EdgeCollider2D Edge
	{
		get
		{
			return edge;
		}
		set
		{
			edge = value;
		}
	}
}
