using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BorderMusicController : MonoBehaviour
{
	private AudioSource source;
	private Vector3[] points;

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
		GetSource().clip.GetData(samples, 0);
		Debug.Log("Sample Count: " + GetSource().clip.samples);
	}

	public Vector3[] GetPoints()
	{
		points = new Vector3[4] {	new Vector3(0,0,0),
									new Vector3(0,10,0),
									new Vector3(0,20,0),
									new Vector3(0,30,0) };
		return points;
	}

	public AudioSource GetSource()
	{
		if (source != null)
		{

			return source;
		}
		return GetComponent<AudioSource> ();
	}
}
