using UnityEngine;
using System.Collections;

public class RandomBorderController : MonoBehaviour
{
	public Line line = new Line();
	public int size = 2;
	public int steps = 1;
	public float randomX = 1f;
	public bool randomizeOnStart = false;

	private RandomBorder leftRandomBorder = new RandomBorder();
	private RandomBorder rightRandomBorder = new RandomBorder();

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
		leftRandomBorder.LineRend = LineToLineRenderer(line.points, leftRandomBorder.LineRend);
		rightRandomBorder.LineRend = LineToLineRenderer(line.points, rightRandomBorder.LineRend);
		leftRandomBorder.Edge = LineToEdge(line.points, leftRandomBorder.Edge);
		rightRandomBorder.Edge = LineToEdge(line.points, rightRandomBorder.Edge);
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
		leftRandomBorder.LineRend = left.GetComponent<LineRenderer>();
		rightRandomBorder.LineRend = right.GetComponent<LineRenderer>();
		leftRandomBorder.Edge = left.GetComponent<EdgeCollider2D>();
		rightRandomBorder.Edge = right.GetComponent<EdgeCollider2D>();
	}
}
