using UnityEngine;

public class BorderMusicController : MonoBehaviour
{
	private AudioSource source;

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
		var allZeros = true;
		foreach (var s in samples)
		{
			if (s != 0)
			{
				allZeros = false;
			}
		}
		Debug.Log( "All Zeros: " + allZeros );
	}
}
