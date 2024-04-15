using System.Collections.Generic;

public class TestAnalyticsPlatform : AnalyticsPlatform
{
	public override void Init()
	{
		base.Init();
	}

	protected override void SendEventInternal(AnalyticsEvents eventType)
	{
		base.Log(eventType, null);
	}

	protected override void SendEventInternal(AnalyticsEvents eventType, Dictionary<string, object> parameters)
	{
		base.Log(eventType, parameters);
	}
}


