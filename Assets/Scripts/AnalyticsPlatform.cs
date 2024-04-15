using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class AnalyticsPlatform : MonoBehaviour
{
	protected List<AnalyticsEvents> PlatformEvents { get; set; }

	public virtual void Init()
	{
		this.PlatformEvents = Enum.GetValues(typeof(AnalyticsEvents)).OfType<AnalyticsEvents>().ToList();
	}

	public void SendEvent(AnalyticsEvents eventType)
	{
		if (this.PlatformEvents != null)
		{
			if (this.PlatformEvents.Contains(eventType))
			{
				this.SendEventInternal(eventType);
			}
		}
	}

	public void SendEvent(AnalyticsEvents eventType, Dictionary<string, object> parameters)
	{
		if (PlatformEvents != null && this.PlatformEvents.Contains(eventType))
		{
			this.SendEventInternal(eventType, parameters);
		}
	}

	protected void Log(AnalyticsEvents eventType, Dictionary<string, object> parameters)
	{
		if (AnalyticsHelper.IsTestDevice())
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[Analytics] eventName : ").Append(eventType.ToString());
			if (parameters != null)
			{
				foreach (KeyValuePair<string, object> parameter in parameters)
				{
					stringBuilder.Append("\nparam[").Append(parameter.Key).Append("] = ")
						.Append(parameter.Value);
				}
			}
			UnityEngine.Debug.Log(stringBuilder.ToString());
			CustomLogger.Instance.Log(stringBuilder.ToString());
		}
	}

	protected abstract void SendEventInternal(AnalyticsEvents eventType);

	protected abstract void SendEventInternal(AnalyticsEvents eventType, Dictionary<string, object> parameters);
}


