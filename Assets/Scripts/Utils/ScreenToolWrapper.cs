using UnityEngine;

public class ScreenToolWrapper
{
	// private static float s_density = -1f;

	public static float Density
	{
		get
		{
            var num = Mathf.Floor(Screen.dpi/96f + 0.5f);//Screen.dpi;
            return num;
		}
	}

	public static float IphoneXExtraPixels
	{
		get
		{
			return 0f;
		}
	}

	public static float IphoneXExtraBottomPixels
	{
		get
		{
			return 0f;
		}
	}

	public static bool IsIphoneX
	{
		get
		{
			return false;
		}
	}
}


