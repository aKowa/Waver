using UnityEngine;

public class BorderMusicController : MonoBehaviour
{
	private AudioSource source;
	private Vector3[] points;

	public void Start ()
	{
		source = this.GetComponent<AudioSource>();
		CreateBorder();
	}

	/// <summary>
	/// Sets the borders by setting the line renderer and edge collider to the calculated points from the music.
	/// </summary>
	public void CreateBorder()
	{
		var samples = new float[source.clip.samples];
		source.clip.GetData(samples, 0);
		Debug.Log("Sample Count: " + source.clip.samples);
	}

	public Vector3[] GetPoints()
	{
		points = new Vector3[4] {	new Vector3(0,0,0),
									new Vector3(0,10,0),
									new Vector3(0,20,0),
									new Vector3(0,30,0) };
		return points;
	}
}
