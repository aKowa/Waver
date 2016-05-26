using UnityEngine;

public class Border
{
	private LineRenderer _lineRenderer;
	private EdgeCollider2D _edge;
	
	public LineRenderer LineRend
	{
		get
		{
			return LineRenderer;
		}
		set
		{
			LineRenderer = value;
		}
	}

	public EdgeCollider2D Edge
	{
		get
		{
			return Edge1;
		}
		set
		{
			Edge1 = value;
		}
	}

	public LineRenderer LineRenderer
	{
		get
		{
			return _lineRenderer;
		}

		set
		{
			this._lineRenderer = value;
		}
	}

	public EdgeCollider2D Edge1
	{
		get
		{
			return _edge;
		}

		set
		{
			this._edge = value;
		}
	}
}
