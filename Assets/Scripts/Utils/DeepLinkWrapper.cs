using System;
using System.Collections.Generic;

public class DeepLinkWrapper
{
	public static string DeepLink { get; private set; }

	public static void Init()
	{
	}

	public static Dictionary<string, string> Parse(string par)
	{
		UnityEngine.Debug.Log(par);
		if (!string.IsNullOrEmpty(par))
		{
			Uri uri = new Uri(par);
			if (uri.Host == "main")
			{
				string text = uri.Query.Replace("?", string.Empty);
				string[] array = text.Split('&');
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("host", uri.Host);
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					string[] array3 = text2.Split('=');
					dictionary.Add(array3[0], array3[1]);
				}
				return dictionary;
			}
		}
		return null;
	}
}


