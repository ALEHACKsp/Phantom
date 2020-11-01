using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.USpeak
{
    public static class USpeakPoolUtils
    {
		public static float[] GetFloat(int length)
		{
			for (int i = 0; i < USpeakPoolUtils.FloatPool.Count; i++)
			{
				if (USpeakPoolUtils.FloatPool[i].Length == length)
				{
					float[] result = USpeakPoolUtils.FloatPool[i];
					USpeakPoolUtils.FloatPool.RemoveAt(i);
					return result;
				}
			}
			return new float[length];
		}

		public static short[] GetShort(int length)
		{
			for (int i = 0; i < USpeakPoolUtils.ShortPool.Count; i++)
			{
				if (USpeakPoolUtils.ShortPool[i].Length == length)
				{
					short[] result = USpeakPoolUtils.ShortPool[i];
					USpeakPoolUtils.ShortPool.RemoveAt(i);
					return result;
				}
			}
			return new short[length];
		}

		public static int[] GetInt(int length)
		{
			for (int i = 0; i < USpeakPoolUtils.IntPool.Count; i++)
			{
				if (USpeakPoolUtils.IntPool[i].Length == length)
				{
					int[] result = USpeakPoolUtils.IntPool[i];
					USpeakPoolUtils.IntPool.RemoveAt(i);
					return result;
				}
			}
			return new int[length];
		}

		public static byte[] GetByte(int length)
		{
			for (int i = 0; i < USpeakPoolUtils.BytePool.Count; i++)
			{
				if (USpeakPoolUtils.BytePool[i].Length == length)
				{
					byte[] result = USpeakPoolUtils.BytePool[i];
					USpeakPoolUtils.BytePool.RemoveAt(i);
					return result;
				}
			}
			return new byte[length];
		}

		public static void Return(float[] d) =>
			USpeakPoolUtils.FloatPool.Add(d);

		public static void Return(byte[] d) =>
			USpeakPoolUtils.BytePool.Add(d);

		public static void Return(short[] d) =>
			USpeakPoolUtils.ShortPool.Add(d);

		public static void Return(int[] d) =>
			USpeakPoolUtils.IntPool.Add(d);

		private static List<byte[]> BytePool = new List<byte[]>();

		private static List<short[]> ShortPool = new List<short[]>();

		private static List<int[]> IntPool = new List<int[]>();

		private static List<float[]> FloatPool = new List<float[]>();
	}
}
