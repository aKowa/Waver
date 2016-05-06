using UnityEngine;
using System.Collections;

public class BordeController : MonoBehaviour
{
	public int lineSteps = 10; 
	private LineRenderer leftLine;
	private LineRenderer rightLine;
	private BezierSpline spline;

	void Start ()
	{
		this.leftLine = this.transform.FindChild ( "LeftLine" ).GetComponent<LineRenderer> ();
		this.rightLine = this.transform.FindChild ( "RightLine" ).GetComponent<LineRenderer> ();
		this.spline = this.transform.FindChild ( "Spline" ).GetComponent<BezierSpline> ();

		Vector3[] splinePositions = new Vector3[this.spline.ControlPointCount * lineSteps];

		for (int i=0; i < splinePositions.Length; i++)
		{

		}
	}
}
