using UnityEngine;
using System.Collections;

public class BorderController : MonoBehaviour
{
	public Line line = new Line();
	public int size = 2;
	public int steps = 1;
	public float randomX = 1f;
	public bool randomizeOnStart = false;

	private Border leftBorder = new Border();
	private Border rightBorder = new Border();

	private void Start()
	{
		AssignEdgeRanderer();
		if (randomizeOnStart)
		{
			UpdateLine();
		}
		GenerateBorder();
	}

	public void UpdateLine()
	{
		line.points = new Vector3[size];
		Vector3 v = Vector3.zero;
		for (int i = 0; i < line.PointCount; i++)
		{
			v.y += steps;
			v.x += Random.Range(-randomX, randomX);
			line.points[i] = v;
		}
	}

	public void GenerateBorder()
	{
		AssignEdgeRanderer();
		leftBorder.LineRend = LineToLineRenderer(line.points, leftBorder.LineRend);
		rightBorder.LineRend = LineToLineRenderer(line.points, rightBorder.LineRend);
		leftBorder.Edge = LineToEdge(line.points, leftBorder.Edge);
		rightBorder.Edge = LineToEdge(line.points, rightBorder.Edge);
	}

	public LineRenderer LineToLineRenderer(Vector3[] points, LineRenderer render)
	{
		render.SetVertexCount(points.Length);
		render.SetPositions(points);
		return render;
	}

	public EdgeCollider2D LineToEdge(Vector3[] points, EdgeCollider2D edge)
	{
		edge.points = points.ToVector2();
		return edge;
	}

	private void AssignEdgeRanderer()
	{
		Transform left = this.transform.FindChild("LeftLine");
		Transform right = this.transform.FindChild("RightLine");
		leftBorder.LineRend = left.GetComponent<LineRenderer>();
		rightBorder.LineRend = right.GetComponent<LineRenderer>();
		leftBorder.Edge = left.GetComponent<EdgeCollider2D>();
		rightBorder.Edge = right.GetComponent<EdgeCollider2D>();
	}
}
