using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class StreamTest : MonoBehaviour
{
	private AudioSource source;

	private void Start ()
	{
		source = GetComponent<AudioSource>();
		if (source.clip != null)
		{
			source.Play();
		}
	}
}
