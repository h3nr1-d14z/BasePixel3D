using UnityEngine;
using UnityEditor;
using System.IO;

public class ClearData
{
	private static int imageIndex = 1;
	[MenuItem("Tools/Clear Data")]
	private static void NewMenuOption()
	{
		PlayerPrefs.DeleteAll();
	}

	[MenuItem("Tools/Take Screenshot")]
	private static void TakeScreenshot()
	{
		ScreenCapture.CaptureScreenshot("Screenshots/" + (imageIndex++) + ".png");
	}

	[MenuItem("Tools/Clear All Screenshots")]
	private static void ClearAllScreenshots()
	{
		foreach(var file in Directory.GetFiles("Screenshots"))
		{
			File.Delete(file);
		}
		imageIndex = 1;
	}
}