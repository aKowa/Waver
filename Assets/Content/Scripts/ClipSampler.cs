using UnityEngine;

public class ClipSampler
{
	private AudioClip clip;
	private float[] samples;

	public ClipSampler(AudioClip newClip)
	{
		Debug.Log("Clip Samples: " + newClip.samples + " Frequency: " + newClip.frequency);
		clip = newClip;
	}

	public float[] Samples
	{
		get
		{
			if (samples != null)
			{
				return samples;
			}
			samples = new float[clip.samples];
			clip.GetData(samples, 0);
			bool allZero = true;
			for(int i = 0; i < samples.Length; i++)
			{
				if (samples[i] != 0)
				{
					allZero = false;
					break;
				}
			}
			Debug.Log("All Zero in Sample: " + allZero);
			return samples;
		}
	}

	public void Reset()
	{
		samples = new float[0];
	}
}
