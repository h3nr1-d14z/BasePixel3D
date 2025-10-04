public class CustomLogger
{
	private static CustomLogger instance;

	public static CustomLogger Instance
	{
		get
		{
			if (CustomLogger.instance == null)
			{
				CustomLogger.instance = new CustomLogger();
			}
			return CustomLogger.instance;
		}
	}

	public void Log(string s)
	{
	}
}


