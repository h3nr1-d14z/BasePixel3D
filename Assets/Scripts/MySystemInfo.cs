using UnityEngine;

public class MySystemInfo
{
	private static bool? s_IsTablet;

	public static bool IsTablet
	{
		get
		{
			bool? nullable = MySystemInfo.s_IsTablet;
			if (!nullable.HasValue)
			{
				MySystemInfo.s_IsTablet = (MySystemInfo.DeviceDiagonalSizeInInches() > 6.5f);
			}
			bool? nullable2 = MySystemInfo.s_IsTablet;
			return nullable2.Value;
		}
	}

	private static float DeviceDiagonalSizeInInches()
	{
		float f = (float)Screen.width / Screen.dpi;
		float f2 = (float)Screen.height / Screen.dpi;
		return Mathf.Sqrt(Mathf.Pow(f, 2f) + Mathf.Pow(f2, 2f));
	}
}


