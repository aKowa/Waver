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
	}

	void Update()
	{
		SetLine();
	}

	void SetLine()
	{	
		if (Line.points != null)
		{
			lineRenderer.SetVertexCount(Line.points.Length);
			lineRenderer.SetPositions(Line.points);

			Vector2[] temp = new Vector2[Line.points.Length];
			for (int i = 0; i < Line.points.Length; i++)
			{
				temp[i] = (Vector2) Line.points[i];
			}
			edgeCollider.points = temp;
		}
	}
}
