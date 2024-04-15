using System;
public class DebugLogger
{
	public static bool IsDevelopmentBuild = true;

	public static void Log(object message)
	{
		if (DebugLogger.IsDevelopmentBuild)
		{
			UnityEngine.Debug.Log(message);
		}
	}

	public static void Log(object message, UnityEngine.Object obj)
	{
		if (DebugLogger.IsDevelopmentBuild)
		{
			UnityEngine.Debug.Log(message, obj);
		}
	}

	public static void LogWarning(object message)
	{
		if (DebugLogger.IsDevelopmentBuild)
		{
			UnityEngine.Debug.LogWarning(message);
		}
	}

	public static void LogWarning(object message, UnityEngine.Object obj)
	{
		if (DebugLogger.IsDevelopmentBuild)
		{
			UnityEngine.Debug.LogWarning(message, obj);
		}
	}

	public static void LogError(object message)
	{
		if (DebugLogger.IsDevelopmentBuild)
		{
			UnityEngine.Debug.LogError(message);
		}
	}

	public static void LogError(object message, UnityEngine.Object obj)
	{
		if (DebugLogger.IsDevelopmentBuild)
		{
			UnityEngine.Debug.LogError(message, obj);
		}
	}

	public static void LogException(Exception exception)
	{
		if (DebugLogger.IsDevelopmentBuild)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public static void LogException(Exception exception, UnityEngine.Object obj)
	{
		if (DebugLogger.IsDevelopmentBuild)
		{
			UnityEngine.Debug.LogException(exception, obj);
		}
	}
}
