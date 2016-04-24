using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public AudioClip clip;
	private AudioSource source;

	void Start()
	{
		source = Camera.main.GetComponent<AudioSource>();
		if (clip != null)
		{
			source.clip = clip;
			source.Play();
		}
		else
		{
			Debug.LogError("No AudioClip assigned to " + this.name);
		}
	}
}
