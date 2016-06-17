using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BorderMusicController : MonoBehaviour
{
	private AudioSource source;
	public Vector2[] Points;
	private const int Steps = 10000;
	private const float XScalar = 3f;
	private const float YScalar = 1.5f;

	public void Start ()
	{
		SetPoints();
	}


	/// <summary>
	/// Sets the borders by setting the line renderer and edge collider to the calculated points from the music.
	/// </summary>
	public void SetPoints()
	{
		var samples = new float[GetSource().clip.samples];
		GetSource().clip.GetData ( samples, 0 );
		Points = new Vector2[samples.Length / Steps];
		Debug.Log( "Sample Length: " + samples.Length + " Points Length " + Points.Length);

		for (var i = 0; i < Points.Length; i++)
		{
			Points[i] = (Vector2.right * samples[i * Steps] * XScalar) + (Vector2.up * i * YScalar);
		}
	}


	/// <summary>
	/// Returns the points for the border line.
	/// </summary>
	public Vector2[] GetPoints()
	{
		return Points;
	}


	public void ResetPoints()
	{
		Points = new Vector2[2] { Vector2.zero, Vector2.up };
	}

	/// <summary>
	/// Returns the AudioSource.
	/// </summary>
	public AudioSource GetSource()
	{
		if (source != null)
		{

			return source;
		}
		return source = GetComponent<AudioSource> ();
	}
}
