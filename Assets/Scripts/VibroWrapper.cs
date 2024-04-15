using UnityEngine;

public class VibroWrapper
{
	public static void PlayVibro()
	{
		if (!AppData.VibroRightEnabled && !AppData.VibroWrongEnabled)
		{
			return;
		}
		Handheld.Vibrate();
	}

	public static void PlayVibroRight()
	{
		if (AppData.VibroRightEnabled)
		{
			Handheld.Vibrate();
		}
	}

	public static void PlayVibroWrong()
	{
		if (AppData.VibroWrongEnabled)
		{
			Handheld.Vibrate();
		}
	}

	public static bool IsVibroAvailable()
	{
		return true;
	}
}


