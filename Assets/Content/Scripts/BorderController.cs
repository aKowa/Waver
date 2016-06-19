using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D) )]
public class BorderController : MonoBehaviour
{
	private LineRenderer line;
	private LineRenderer Line
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

	/// <summary>
	/// Sets the LineRenderers vertex count to the given size.
	/// </summary>
	public void SetLinevertexCount( int size )
	{
		Line.SetVertexCount ( size );
	}

	/// <summary>
	/// Sets the games border (LineRenderer and EdgeCollider).
	/// </summary>
	/// <param name="sampleChunk">The chunk of samples to calculate the points from.</param>
	/// <param name="position">The position in to calculate the points y position from.</param>
	/// <param name="yScalar">Scales the y distance between points.</param>
	public void SetBorder(float[] sampleChunk, int position, float yScalar )
	{
		var points = new Vector2[sampleChunk.Length];
		for (var i = 0; i < points.Length; i++)
		{
			points[i].x = sampleChunk[i] + transform.localPosition.x;
			points[i].y = (position + i) * yScalar;
		}
		Edge.points = points;
		Line.SetPositions(points.ToVector3());
	}
}
