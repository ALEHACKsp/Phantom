using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.USpeak
{
	public class USpeakAudioClipConverter
	{
		public static short[] AudioDataToShorts(float[] samples, float gain = 1f)
		{
			short[] @short = USpeakPoolUtils.GetShort(samples.Length);
			for (int i = 0; i < samples.Length; i++)
			{
				float num = samples[i] * 3267f * gain;
				@short[i] = (short)((num >= -3267f) ? ((num <= 3267f) ? num : 3267f) : -3267f);
			}
			return @short;
		}

		public static float[] ShortsToAudioData(short[] data, float gain = 1f)
		{
			float[] @float = USpeakPoolUtils.GetFloat(data.Length);
			for (int i = 0; i < @float.Length; i++)
			{
				float num = (float)data[i] / 3267f * gain;
				@float[i] = ((num >= -1f) ? ((num <= 1f) ? num : 1f) : -1f);
			}
			return @float;
		}

		public static void ApplyGain(float[] data, float gain)
		{
			if (gain == 1f)
				return;

			for (int i = 0; i < data.Length; i++)
			{
				float num = data[i] * gain;
				data[i] = ((num >= -1f) ? ((num <= 1f) ? num : 1f) : -1f);
			}
		}
	}
}
