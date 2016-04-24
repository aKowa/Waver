using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineSystem : MonoBehaviour 
{
	public float distanceToPlayer = 5F;
	public int linePointAmount = 10;
	private List<Vector3> linePointsList = new List<Vector3>();

	void Awake()
	{
//		InitilizeLinePoints();
	}

	void Update()
	{
		SetLinePoints();
	}

	void InitilizeLinePoints()
	{
		for (int i=0; i < linePointAmount; i++)
		{
			Vector3 vec = Vector3.up * i;
			linePointsList.Add(vec);
		}
		Line.points = linePointsList.ToArray();
	}

	void SetLinePoints()
	{
		Vector3[] targetPoints = new Vector3[linePointAmount];

		for (int i=0; i < linePointAmount; i++)
		{
			targetPoints[i] = Vector3.up * (Mathf.Lerp(Player.position.y, Player.position.y + distanceToPlayer, i/linePointAmount));
		}
		Line.points = targetPoints;
	}
}
