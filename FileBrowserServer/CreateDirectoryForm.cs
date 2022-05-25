using System;
using System.Windows.Forms;

namespace FileBrowserServer
{
    public partial class CreateDirectoryForm : Form
	{
		public CreateDirectoryForm()
		{
			InitializeComponent();
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
			Close();
		}

        private void btnContinue_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.OK;
			Text = textBox1.Text;
			Close();
		}
    }
}
