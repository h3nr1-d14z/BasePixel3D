using System;
using UnityEngine;

public class SystemToolsWrapper
{
	private static AndroidJavaObject systemTool;

	public static void Minimize()
	{
		AndroidJavaObject s = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
		s.Call<bool>("moveTaskToBack", new object[1] {
			true
		});
	}

	public static bool CheckWritePermission()
	{
		return UniAndroidPermission.IsPermitted(AndroidPermission.WRITE_EXTERNAL_STORAGE);
	}

	public static void RequestWritePermission()
	{
		UniAndroidPermission.RequestPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE);

	}

	public static void TestCrash()
	{
		//Crashlytics.ThrowNonFatal();
	}

	public static string GetUid()
	{
		return SystemInfo.deviceUniqueIdentifier;
	}

	public static string GetInstanceId()
	{
		return SystemInfo.deviceUniqueIdentifier;
	}

	public static string GetAndroidId()
	{
		return SystemInfo.deviceUniqueIdentifier;
	}

	public static DateTime GetInstallDate()
	{
		return DateTime.Now;
	}

	public static string GetLocale()
	{
		return "en-US";
	}
}


