using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityPlatform : AnalyticsPlatform
{ 
	public override void Init()
	{
		Analytics.enabled = true;
	} 

	protected override void SendEventInternal(AnalyticsEvents eventType)
	{
		Analytics.CustomEvent(eventType.ToString());
	}

	protected override void SendEventInternal(AnalyticsEvents eventType, Dictionary<string, object> parameters)
	{
		Analytics.CustomEvent(eventType.ToString(), parameters); 
	} 
}
