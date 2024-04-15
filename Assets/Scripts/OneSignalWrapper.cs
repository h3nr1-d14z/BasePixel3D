

using System.Collections.Generic;

public class OneSignalWrapper
{
	private static Dictionary<string, object> startParameters;

	private static bool m_request;

	private static string m_userId = string.Empty;

	private static bool s_inited; 

	public static string UserId
	{
		get
		{
			if (OneSignalWrapper.m_userId != string.Empty)
			{
				return OneSignalWrapper.m_userId;
			}
			if (OneSignalWrapper.s_inited && !OneSignalWrapper.m_request)
			{
				OneSignalWrapper.m_request = true;
				OneSignal.IdsAvailable(delegate (string userId, string pushToken)
				{
					OneSignalWrapper.m_request = false;
					OneSignalWrapper.m_userId = userId;
					//DataManager.Instance.SendPushToken(null);
				});
			}
			return string.Empty;
		}
	}

	public static void Init(string appId, string googleProjectId)
	{
		if (!OneSignalWrapper.s_inited)
		{
			OneSignal.StartInit(appId, googleProjectId).HandleNotificationOpened(new OneSignal.NotificationOpened(OneSignalWrapper.NotificationHandler)).EndInit();
			string userId = OneSignalWrapper.UserId;
		}
	}

	private static void NotificationHandler(OSNotificationOpenedResult res)
	{
		try
		{
			if (!res.notification.isAppInFocus)
			{
				OneSignalWrapper.startParameters = res.notification.payload.additionalData;
				string text = string.Empty;
				foreach (KeyValuePair<string, object> additionalDatum in res.notification.payload.additionalData)
				{
					string text2 = text;
					text = text2 + "[" + additionalDatum.Key + "] = " + additionalDatum.Value + "\r\n";
				}
				UnityEngine.Debug.Log("OneSignalNotification: \r\n" + text);
			}
		}
		catch
		{
		}
	}
}


