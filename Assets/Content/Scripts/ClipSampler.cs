using UnityEngine;

public class ClipSampler
{
	private AudioClip clip;

	public ClipSampler(AudioClip newClip)
	{
		Debug.Log("Clip Samples: " + newClip.samples + " Frequency: " + newClip.frequency);
		clip = newClip;
	}

	private float[] samples;
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
			foreach (float t in samples)
			{
				if (t != 0)
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
