using UnityEngine;

public class InternetConnection
{
	public static bool IsAvailable
	{
		get
		{
			return Application.internetReachability != NetworkReachability.NotReachable;
		}
	}
}


