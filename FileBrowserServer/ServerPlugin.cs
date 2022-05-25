using NanoCore;
using NanoCore.ServerPlugin;
using NanoCore.ServerPluginHost;

namespace FileBrowserServer
{
    public class ServerPlugin : IServerNetwork
	{
		public ServerPlugin(IServerLoggingHost _loggingHost, IServerNetworkHost _networkHost, IServerUIHost _uiHost)
		{
			ServerMain.UIHost = _uiHost;
			ServerMain.NetworkHost = _networkHost;
			ServerMain.LoggingHost = _loggingHost;
			ServerMain.InitializePlugin();
		}

		public void ClientPipeClosed(IClient client, string pipeName)
		{
		}

		public void ClientPipeCreated(IClient client, string pipeName)
		{
		}

		public void ClientReadPacket(IClient client, string pipeName, object[] @params)
		{
			switch ((CommandTypes)@params[0])
			{
				case CommandTypes.MachineName:
					CommandHandler.HandleMachineName(@params);
					break;
				case CommandTypes.Drives:
					CommandHandler.HandleRemoteDrives(@params);
					break;
				case CommandTypes.Files:
					CommandHandler.HandleRemoteFiles(@params);
					break;
				case CommandTypes.GetCurrentDirectory:
					CommandHandler.HandleCurrentDirectory(@params);
					break;
				case CommandTypes.Download:
					CommandHandler.HandleDownloadFile(@params);
					break;
			}
		}

		public void ClientStateChanged(IClient client, bool connected)
		{
		}

		public void ListenerAdded(IListener listener)
		{
		}

		public void ListenerFailed(IListener listener)
		{
		}

		public void ListenerRemoved(IListener listener)
		{
		}

		public void ListenerStateChanged(IListener listener)
		{
		}
	}
}