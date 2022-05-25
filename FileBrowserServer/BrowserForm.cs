using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using NanoCore;

namespace FileBrowserServer
{
	public partial class BrowserForm : Form
	{
		private IClient Client;

		public BrowserForm(IClient _client)
		{
			this.Client = _client;
			this.InitializeComponent();
		}

		private string EnumerateLocalFiles(string path)
		{
			string result;

			this.lvLocal.Items.Clear();
			this.lvLocal.BeginUpdate();

			try
			{
				string fullName = new DirectoryInfo(path).FullName;
				this.lvLocal.Items.Add(new ListViewItem(new string[]
				{
					"..",
					"File folder",
					""
				})
				{
					StateImageIndex = 0
				});
				string[] directories = Directory.GetDirectories(path);
				foreach (string path2 in directories)
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(path2);
					string[] items = new string[]
					{
						directoryInfo.Name,
						"File folder",
						string.Empty
					};
					ListViewItem value = new ListViewItem(items)
					{
						StateImageIndex = 0
					};
					this.lvLocal.Items.Add(value);
				}
				string[] files = Directory.GetFiles(path);
				foreach (string fileName in files)
				{
					FileInfo fileInfo = new FileInfo(fileName);
					string[] items2 = new string[]
					{
						fileInfo.Name,
						this.ParseTypeName(fileInfo.Extension),
						string.Format("{0} KB", Math.Ceiling((double)fileInfo.Length / 1024.0))
					};
					ListViewItem value2 = new ListViewItem(items2)
					{
						StateImageIndex = 1
					};
					this.lvLocal.Items.Add(value2);
				}
				result = fullName;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Access is denied.", "NanoCore");
				result = this.EnumerateLocalFiles(path.Remove(path.LastIndexOf(Path.DirectorySeparatorChar)));
			}

			this.lvLocal.EndUpdate();

			return result;
		}

		private void EnumerateLocalDrives()
		{
			this.lvDrivesLocal.Items.Clear();
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo driveInfo in drives)
			{
				if (driveInfo.IsReady)
				{
					int stateImageIndex = (driveInfo.DriveType == DriveType.Fixed) ? 2 : 3;
					string[] items = new string[]
					{
						driveInfo.RootDirectory.Name.Split(new char[]
						{
							Path.DirectorySeparatorChar
						})[0] + Convert.ToString(Path.DirectorySeparatorChar)
					};
					ListViewItem value = new ListViewItem(items)
					{
						StateImageIndex = stateImageIndex
					};
					this.lvDrivesLocal.Items.Add(value);
				}
			}
		}

		public string ParseTypeName(string text)
		{
			text = text.Replace(".", string.Empty).ToLower();
			string left = text.ToLower();
			switch(left)
            {
				case "exe":
					return "Application";
				case "txt":
					return "Text Document";
				case "dll":
					return "Application library";
				case "zip":
					return "Archive";
				case "rar":
					return "Archive";
				case "lnk":
					return "Shortcut";
				case "appref-ms":
					return "Application Reference";
				case "sys":
					return "System file";
				case "msi":
					return "Windows Installer Package";
				case "inf":
					return "Setup Information";
				case "ini":
					return "Configuration settings";
				case "htm":
					return "HTML Document";
				case "html":
					return "HTML Document";
				default:
					return string.Format("{0} File", text.ToUpper());
					break;
			}
		}

		private void BrowserForm_Load(object sender, EventArgs e)
		{
			this.txtLocalDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			this.EnumerateLocalDrives();
			this.EnumerateLocalFiles(this.txtLocalDir.Text);

			CommandHandler.SendGetMachineName(this.Client);
			CommandHandler.SendGetRemoteDrives(this.Client);
			CommandHandler.SendGetCurrentDirectory(this.Client);
			CommandHandler.SendGetRemoteFiles(this.Client);
		}

		private void btnRefreshLocal_Click(object sender, EventArgs e)
		{
			this.EnumerateLocalFiles(this.txtLocalDir.Text);
		}

		private void lvDrivesLocal_DoubleClick(object sender, EventArgs e)
		{
			if (this.lvDrivesLocal.SelectedIndices.Count == 0)
			{
				return;
			}
			this.txtLocalDir.Text = this.lvDrivesLocal.Items[this.lvDrivesLocal.SelectedIndices[0]].Text;
			try
			{
				this.EnumerateLocalFiles(this.txtLocalDir.Text);
			}
			catch (Exception ex)
			{
			}
		}

		private void lvLocal_DoubleClick(object sender, EventArgs e)
		{
			if (this.lvLocal.SelectedIndices.Count == 0)
			{
				return;
			}
			if (this.lvLocal.SelectedItems[0].StateImageIndex == 0)
			{
				if (this.lvLocal.SelectedIndices.Count == 0)
				{
					return;
				}
				TextBox txtLocalDir = this.txtLocalDir;
				txtLocalDir.Text = txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvLocal.Items[this.lvLocal.SelectedIndices[0]].Text;
				this.txtLocalDir.Text = this.EnumerateLocalFiles(this.txtLocalDir.Text);
			}
			else
			{
				this.cmiOpenLocal_Click(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}

		private void cmiOpenLocal_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (object obj in this.lvLocal.SelectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (listViewItem.SubItems[0].Text == "File folder")
						break;
					Process.Start(this.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + listViewItem.Text);
				}
			}
			finally
			{

			}
		}

		private void cmiUploadLocal_Click(object sender, EventArgs e)
		{
			if (this.lvLocal.SelectedIndices.Count == 0)
			{
				return;
			}
			if (this.lvLocal.SelectedItems[0].StateImageIndex != 1)
			{
				return;
			}
			if (int.Parse(this.lvLocal.SelectedItems[0].SubItems[2].Text.Replace(" KB", string.Empty).Trim().ToLower()) > 4096)
			{
				MessageBox.Show("File is larger than 4 MB. Cannot upload file.");
				return;
			}
			CommandHandler.SendUploadFile(this.Client);
		}

		private void cmiRenameLocal_Click(object sender, EventArgs e)
		{
			RenameFileForm renameFileForm = new RenameFileForm();
			renameFileForm.textBox1.Text = this.lvLocal.SelectedItems[0].Text;
			if (renameFileForm.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (this.lvLocal.SelectedItems[0].StateImageIndex == 0)
					{
						string text = this.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvLocal.SelectedItems[0].Text;
						text = text.Remove(text.LastIndexOf(Path.DirectorySeparatorChar)) + Convert.ToString(Path.DirectorySeparatorChar) + renameFileForm.Text;
						Functions.LogMessage(string.Format("Renaming '{0}' to '{1}..", this.lvLocal.SelectedItems[0].Text, renameFileForm.Text));
						Directory.Move(this.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvLocal.SelectedItems[0].Text, text);
						this.EnumerateLocalFiles(this.txtLocalDir.Text);
					}
					else
					{
						string text2 = this.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvLocal.SelectedItems[0].Text;
						text2 = text2.Remove(text2.LastIndexOf(Path.DirectorySeparatorChar)) + Convert.ToString(Path.DirectorySeparatorChar) + renameFileForm.Text;
						Functions.LogMessage(string.Format("Renaming '{0}' to '{1}..", this.lvLocal.SelectedItems[0].Text, renameFileForm.Text));
						File.Move(this.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvLocal.SelectedItems[0].Text, text2);
						this.EnumerateLocalFiles(this.txtLocalDir.Text);
					}
				}
				catch (Exception ex)
				{
					ServerMain.LoggingHost.LogServerException(ex, "cmiRenameLocal_Click");
				}
			}
		}

		private void cmiDeleteLocal_Click(object sender, EventArgs e)
		{
			try
			{
				File.Delete(this.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvLocal.SelectedItems[0].Text);
			}
			catch (Exception ex)
			{
			}
			this.EnumerateLocalFiles(this.txtLocalDir.Text);
		}

		private void cmiCreateLocal_Click(object sender, EventArgs e)
		{
			CreateDirectoryForm createDirectoryForm = new CreateDirectoryForm();
			if (createDirectoryForm.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string text = this.txtLocalDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + createDirectoryForm.Text;
					Functions.LogMessage(string.Format("Creating directory '{0}'..", text));
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					this.EnumerateLocalFiles(this.txtLocalDir.Text);
				}
				catch (Exception ex)
				{
					ServerMain.LoggingHost.LogServerException(ex, "cmiCreateLocal_Click");
				}
			}
		}

		private void btnRefreshRemote_Click(object sender, EventArgs e)
		{
			CommandHandler.SendGetRemoteFiles(this.Client);
		}

		private void lvDrivesRemote_DoubleClick(object sender, EventArgs e)
		{
			if (this.lvDrivesRemote.SelectedIndices.Count == 0)
			{
				return;
			}
			this.lvRemote.Items.Clear();
			this.txtRemoteDir.Text = this.lvDrivesRemote.SelectedItems[0].Text;
			CommandHandler.SendSetCurrentDirectory(this.Client, this.txtRemoteDir.Text);
			CommandHandler.SendGetRemoteFiles(this.Client);
		}

		private void lvRemote_DoubleClick(object sender, EventArgs e)
		{
			if (this.lvRemote.SelectedIndices.Count == 0)
			{
				return;
			}
			string text = this.lvRemote.Items[this.lvRemote.SelectedIndices[0]].Text;
			if (this.lvRemote.SelectedItems[0].StateImageIndex == 0)
			{
				TextBox txtRemoteDir = this.txtRemoteDir;
				txtRemoteDir.Text = txtRemoteDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvRemote.Items[this.lvRemote.SelectedIndices[0]].Text;
				this.txtRemoteDir.Text = this.txtRemoteDir.Text.Replace("\\..", string.Empty);
				if (text == ".." && this.txtRemoteDir.Text.Contains("\\"))
				{
					this.txtRemoteDir.Text = this.txtRemoteDir.Text.Remove(this.txtRemoteDir.Text.LastIndexOf("\\"));
				}
				CommandHandler.SendSetCurrentDirectory(this.Client, this.txtRemoteDir.Text);
				CommandHandler.SendGetRemoteFiles(this.Client);
			}
			else
			{
				this.cmiOpenLocal_Click(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}

		private void cmiOpenRemote_Click(object sender, EventArgs e)
		{
			if (this.lvRemote.SelectedIndices.Count == 0)
			{
				return;
			}
			if (this.lvRemote.SelectedItems[0].StateImageIndex != 1)
			{
				return;
			}
			CommandHandler.SendOpenFile(this.Client, this.txtRemoteDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + ServerMain.FileManager.lvRemote.SelectedItems[0].Text);
		}

		private void cmiDownloadRemote_Click(object sender, EventArgs e)
		{
			if (this.lvRemote.SelectedIndices.Count == 0)
			{
				return;
			}
			if (this.lvRemote.SelectedItems[0].StateImageIndex != 1)
			{
				return;
			}
			if (int.Parse(this.lvRemote.SelectedItems[0].SubItems[2].Text.Replace(" KB", string.Empty).Trim().ToLower()) > 4096)
			{
				MessageBox.Show("File is larger than 4 MB. Cannot download file.");
				return;
			}
			CommandHandler.SendDownloadFile(this.Client, this.txtRemoteDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvRemote.SelectedItems[0].Text);
			this.EnumerateLocalFiles(this.txtLocalDir.Text);
		}

		private void cmiRenameRemote_Click(object sender, EventArgs e)
		{
			RenameFileForm renameFileForm = new RenameFileForm();
			renameFileForm.textBox1.Text = this.lvRemote.SelectedItems[0].Text;
			if (renameFileForm.ShowDialog() == DialogResult.OK)
			{
				try
				{
					bool isDirectory = this.lvRemote.SelectedItems[0].StateImageIndex == 0;
					string text = this.txtRemoteDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + this.lvRemote.SelectedItems[0].Text;
					string newFile = text.Remove(text.LastIndexOf(Path.DirectorySeparatorChar)) + Convert.ToString(Path.DirectorySeparatorChar) + renameFileForm.Text;
					CommandHandler.SendRename(this.Client, text, newFile, isDirectory);
				}
				catch (Exception ex)
				{
					ServerMain.LoggingHost.LogServerException(ex, "cmiRenameRemote_Click");
				}
			}
		}

		private void cmiDeleteRemote_Click(object sender, EventArgs e)
		{
			if (this.lvRemote.SelectedIndices.Count == 0)
			{
				return;
			}
			CommandHandler.SendDeleteFile(this.Client, this.lvRemote.SelectedItems[0].StateImageIndex == 0);
		}

		private void cmiCreateRemote_Click(object sender, EventArgs e)
		{
			CreateDirectoryForm createDirectoryForm = new CreateDirectoryForm();
			if (createDirectoryForm.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string directoryName = this.txtRemoteDir.Text + Convert.ToString(Path.DirectorySeparatorChar) + createDirectoryForm.Text;
					CommandHandler.SendCreateDirectory(this.Client, directoryName);
				}
				catch (Exception ex)
				{
					ServerMain.LoggingHost.LogServerException(ex, "cmiCreateRemote_Click");
				}
			}
		}
	}
}
