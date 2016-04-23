using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour 
{
	private LineRenderer lineRenderer;
	private EdgeCollider2D edgeCollider;

	void Start()
	{
		lineRenderer = this.GetComponent<LineRenderer>();
		edgeCollider = this.GetComponent<EdgeCollider2D>();
		SetLine();
	}

	void SetLine()
	{
		lineRenderer.SetVertexCount(Line.Points.Length);
		lineRenderer.SetPositions(Line.Points);

		Vector2[] temp = new Vector2[Line.Points.Length];
		for (int i = 0; i < Line.Points.Length; i++)
		{
			temp[i] = (Vector2) Line.Points[i];
		}
		edgeCollider.points = temp;
	}
}
