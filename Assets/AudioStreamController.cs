using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioStreamController : MonoBehaviour
{
	public AudioClip Clip;
	public int SamplePosition = 0;
	public float[] SamplesChunk;
	private float[] clipData;
	private AudioSource source;

	private void Start ()
	{
		SetAudio();
	}

	private void SetAudio()
	{
		clipData = new float[Clip.samples];
		Clip.GetData ( clipData, 0 );

		bool allZero = true;
		foreach (var t in clipData)
		{
			if (t != 0)
				allZero = false;
		}
		Debug.Log("ClipData all zero: " + allZero);

		var testClip = AudioClip.Create(Clip.name + "Stream", Clip.samples, 1, Clip.frequency, true, OnAudioRead,
			OnAudioSetPosition);
		source = GetComponent<AudioSource>();
		source.clip = testClip;
		source.Play();
	}

	private void OnAudioRead(float[] data)
	{
		var allZero = true;
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = clipData[SamplePosition + i];
			SamplesChunk = data;

			if (data[i] != 0)
			{
				allZero = false;
			}
		}
		//Debug.Log("All Zero: " + allZero);

		SamplePosition += data.Length;

		if (SamplesChunk.Length == 0)
			SamplesChunk = data;
	}
	
	private void OnAudioSetPosition(int newPosition)
	{
		SamplePosition = newPosition;
	}
}
