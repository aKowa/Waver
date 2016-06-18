using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClipSampler
{
	private AudioClip clip;
	private float[] samples;
	private const int Steps = 1;

	public ClipSampler(AudioClip newClip)
	{
		clip = newClip;
	}

	public float[] Samples
	{
		get
		{
			if (samples.Length != 0) return samples;
			samples = new float[clip.samples];
			clip.GetData(samples, 0);
			return samples;
		}
	}

	public void Reset()
	{
		samples = new float[0];
	}
}
