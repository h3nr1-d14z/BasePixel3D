using UnityEngine;

public class RateUsTool
{
	public static void OpenRateUs()
	{
		Application.OpenURL("market://details?id=" + Application.identifier);
	}
}


