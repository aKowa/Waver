using UnityEngine;
using System.Collections;

public class BorderController : MonoBehaviour
{
	public Line line;
	public int size = 2;
	public int steps = 1;
	public float randomX = 1f;

	private Border leftBorder;
	private Border rightBorder;

	 private void Start ()
	{
		AssignLineRenderer ();
		GenerateBorder ();
	}

	public void UpdateLine ()
	{
		line.points = new Vector3[size];
		Vector3 v = Vector3.zero;
		for ( int i=0; i < line.PointCount; i++ )
		{
			v.y += steps;
			v.x += Random.Range ( -randomX, randomX );
			line.points[i] = v;
		}
	}

	public void GenerateBorder ()
	{
		AssignLineRenderer ();
		leftBorder.lineRenderer = LineToLineRenderer ( line.points, leftBorder.lineRenderer );
		rightBorder.lineRenderer = LineToLineRenderer ( line.points, rightBorder.lineRenderer );
		leftBorder.edge = LineToEdge ( line.points, leftBorder.edge );
		rightBorder.edge = LineToEdge ( line.points, rightBorder.edge );
	}

	public LineRenderer LineToLineRenderer ( Vector3[] points, LineRenderer render )
	{
		render.SetVertexCount ( points.Length );
		render.SetPositions ( points );
		return render;
	}

	public EdgeCollider2D LineToEdge ( Vector3[] points, EdgeCollider2D edge )
	{
		return edge;
	}

	private void AssignLineRenderer ()
	{
		leftBorder.lineRenderer = this.transform.FindChild ( "LeftLine" ).GetComponent<LineRenderer> ();
		rightBorder.lineRenderer = this.transform.FindChild ( "RightLine" ).GetComponent<LineRenderer> ();
		leftBorder.edge = leftBorder.lineRenderer.transform.GetComponent<EdgeCollider2D> ();
		rightBorder.edge = rightBorder.lineRenderer.transform.GetComponent<EdgeCollider2D> ();
	}
}
