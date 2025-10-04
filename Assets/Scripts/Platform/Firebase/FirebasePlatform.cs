/*using Firebase;
using Firebase.Analytics;
using System.Collections.Generic;
using UnityEngine;

public class FirebasePlatform : AnalyticsPlatform
{
	DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
	public override void Init()
	{
		FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
			dependencyStatus = task.Result;
			if (dependencyStatus == DependencyStatus.Available)
			{
				InitializeFirebase();
			}
			else
			{
				Debug.LogError(
				  "Could not resolve all Firebase dependencies: " + dependencyStatus);
			}
		});
	}

	// Handle initialization of the necessary firebase modules:
	void InitializeFirebase()
	{
		DebugLog("Enabling data collection.");
		FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

		DebugLog("Set user properties.");
		// Set the user's sign up method.
		FirebaseAnalytics.SetUserProperty(FirebaseAnalytics.UserPropertySignUpMethod, "Google");
		// Set the user ID.
		FirebaseAnalytics.SetUserId("pixel_art_user");
	}

	protected override void SendEventInternal(AnalyticsEvents eventType)
	{
		FirebaseAnalytics.LogEvent(eventType.ToString());
	}

	protected override void SendEventInternal(AnalyticsEvents eventType, Dictionary<string, object> parameters)
	{
		var p = new List<Parameter>();
		foreach(var kv in parameters)
		{
			p.Add(new Parameter(kv.Key, kv.Value.ToString()));
		}
		FirebaseAnalytics.LogEvent(eventType.ToString(), p.ToArray());
	}
	// Output text to the debug log text field, as well as the console.
	public void DebugLog(string s)
	{
		Debug.Log(s);
	}
}


*/