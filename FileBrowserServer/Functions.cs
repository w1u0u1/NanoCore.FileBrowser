namespace FileBrowserServer
{
	internal sealed class Functions
	{
		public static void LogMessage(string message)
		{
			ServerMain.LoggingHost.LogServerMessage(0, string.Format("[NanoBrowser]: {0}", message));
		}
	}
}