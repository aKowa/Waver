using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ClipSampleController : MonoBehaviour
{
	private AudioClip clip;
	public AudioClip Clip
	{
		get
		{
			if (clip != null)
			{
				return clip;
			}
			clip = GetComponent<AudioSource>().clip;
			if (clip != null)
			{
				return clip;
			}
			Debug.LogError("No AudioClip assigned to AudioSource.");
			return null;
		}
	}

	private float[] sourceSamples;
	public float[] SourceSamples
	{
		get
		{
			if (sourceSamples != null)
			{
				return sourceSamples;
			}
			sourceSamples = new ClipSampler(Clip).Samples;
			if (sourceSamples != null)
			{
				return sourceSamples;
			}
			Debug.LogError("ClipSampler is null");
			return null;
		}
	}

	public int Position = 0;
	public int ChunkSize = 1024;
	public int Steps = 441;
	public float Scalar = 10f;
	private void Start()
	{
		var borders = GetComponentsInChildren<BorderController>();
		var samplesChunk = GetSampleChunk(SourceSamples, Position);
		borders[0].SetBorder(samplesChunk, ChunkSize);
		borders[1].SetBorder(samplesChunk, ChunkSize);
	}

	private float[] GetSampleChunk( float[] samples, int position )
	{
		var targetChunk = new float[ChunkSize];
		for (var i = 0; i < ChunkSize; i++)
		{
			targetChunk[i] = samples[i * Steps + position] * Scalar;
		}
		return targetChunk;
	}
}
