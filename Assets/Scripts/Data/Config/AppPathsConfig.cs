using System;
using System.IO;
using System.Text;
using UnityEngine;

public static class AppPathsConfig
{
	public static string TermsUrl = "http://inotechvn.com/pixelart/terms.html";

	public static string PrivacyUrl = "http://inotechvn.com/pixelart/policy.html";

	public static string SavesPath { get; private set; }

	public static string PhotosPath { get; private set; }

	public static string SavedImagesPath { get; private set; }

	public static string DownloadsPath { get; private set; }

	public static string StreamingAssetsPath { get; private set; }

	public static string ImagesFile { get; private set; }   

	public static string PhotoFileList { get; private set; }

	public static string Host { get; private set; } 
    public static void InitOnline()
    {
        if (DataManager.Instance.onlineEnabled)
        {
            AppPathsConfig.Host = "https://inotechvn.com/pixelart/";
        }
    }
	public static void Init()
	{
		Debug.Log("Application.persistentDataPath = " + Application.persistentDataPath);
		AppPathsConfig.Host = ""; 
		AppPathsConfig.SavesPath = Application.persistentDataPath + "/Worked/";
		AppPathsConfig.PhotosPath = Application.persistentDataPath + "/MyArt/";
		AppPathsConfig.SavedImagesPath = Application.persistentDataPath + "/Images/";
		AppPathsConfig.DownloadsPath = Application.persistentDataPath + "/Downloaded/";
		AppPathsConfig.StreamingAssetsPath = Application.streamingAssetsPath + "/";
		AppPathsConfig.ImagesFile = "images.xml"; 
		AppPathsConfig.PhotoFileList = "myphotos.bin";
		if (!Directory.Exists(AppPathsConfig.SavesPath))
		{
			Directory.CreateDirectory(AppPathsConfig.SavesPath);
		}
		if (!Directory.Exists(AppPathsConfig.PhotosPath))
		{
			Directory.CreateDirectory(AppPathsConfig.PhotosPath);
		}
		if (!Directory.Exists(AppPathsConfig.SavedImagesPath))
		{
			Directory.CreateDirectory(AppPathsConfig.SavedImagesPath);
		}
		if (!Directory.Exists(AppPathsConfig.DownloadsPath))
		{
			Directory.CreateDirectory(AppPathsConfig.DownloadsPath);
		}
		AppPathsConfig.ClearCache();
	}

	public static void SetHost(string host)
	{
		AppPathsConfig.Host = host; 
	}

	private static void ClearCache()
	{
		try
		{
			var stringBuilder = new StringBuilder();
			string[] files = Directory.GetFiles(Application.temporaryCachePath);
			string[] array = files;
			foreach (string text in array)
			{
				stringBuilder.Append(text).Append("\n");
				File.Delete(text);
			}
			files = Directory.GetFiles(Application.temporaryCachePath);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("ClearCacheError: " + ex.Message);
		}
	}
}


