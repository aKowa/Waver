using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ChunkController : MonoBehaviour
{
	public int ChunkSize = 1024;
	public float YScale = 0.5f;
	public int SampleSteps = 2;
	public float SampleScale = 10f;

	private float[] samples;
	private float[] chunk;

	/// <summary>
	/// Initialize borders at game start.
	/// </summary>
	private void Start()
	{
		var borders = GetComponentsInChildren<BorderController> ();
		foreach (var b in borders)
		{
			b.SetLinevertexCount(ChunkSize);
			b.SetBorder(GetChunkAt(0), 0, YScale);
		}
	}

	/// <summary>
	/// Fills chunk with samples and iterates through the samples by the given position.
	/// </summary>
	/// <param name="position">The position from which to get the next samples from.</param>
	/// <returns>Float array of sample values as a chunk.</returns>
	private float[] GetChunkAt ( int position )
	{
		if (chunk == null)
		{
			samples = new ClipSampler ( GetComponent<AudioSource> ().clip ).Samples;
			chunk = new float[ChunkSize];
			for (int i = 0, s = 0; i < ChunkSize; i++, s += SampleSteps)
			{
				chunk[i] = samples[s] * SampleScale;
			}
			return chunk;
		}

		for (var i = 0; i < ChunkSize - 1; i++)
		{
			chunk[i] = chunk[i + 1];
		}
		chunk[ChunkSize - 1] = samples[position + ChunkSize - 1 + SampleSteps] * SampleScale;
		return chunk;
	}
}

