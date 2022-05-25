namespace FileBrowserServer
{
    public partial class BrowserForm : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && this.components != null)
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.lvLocal = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiOpenLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiUploadLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiRenameLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDeleteLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCreateLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            this.txtLocalDir = new System.Windows.Forms.TextBox();
            this.txtRemoteDir = new System.Windows.Forms.TextBox();
            this.lvRemote = new System.Windows.Forms.ListView();
            this.chNameRem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTypeRem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSizeRem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsRemote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiOpenRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDownloadRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiRenameRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDeleteRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCreateRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.lvDrivesLocal = new System.Windows.Forms.ListView();
            this.lvDrivesRemote = new System.Windows.Forms.ListView();
            this.btnRefreshRemote = new System.Windows.Forms.Button();
            this.btnRefreshLocal = new System.Windows.Forms.Button();
            this.cmsLocal.SuspendLayout();
            this.cmsRemote.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLocal
            // 
            this.lvLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chType,
            this.chSize});
            this.lvLocal.ContextMenuStrip = this.cmsLocal;
            this.lvLocal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLocal.FullRowSelect = true;
            this.lvLocal.HideSelection = false;
            this.lvLocal.Location = new System.Drawing.Point(156, 43);
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(636, 194);
            this.lvLocal.StateImageList = this.ilIcons;
            this.lvLocal.TabIndex = 0;
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.View = System.Windows.Forms.View.Details;
            this.lvLocal.DoubleClick += new System.EventHandler(this.lvLocal_DoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "File Name";
            this.chName.Width = 198;
            // 
            // chType
            // 
            this.chType.Text = "File Type";
            this.chType.Width = 198;
            // 
            // chSize
            // 
            this.chSize.Text = "File Size";
            this.chSize.Width = 198;
            // 
            // cmsLocal
            // 
            this.cmsLocal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiOpenLocal,
            this.cmiUploadLocal,
            this.cmiRenameLocal,
            this.cmiDeleteLocal,
            this.cmiCreateLocal});
            this.cmsLocal.Name = "cmsLocal";
            this.cmsLocal.Size = new System.Drawing.Size(130, 114);
            // 
            // cmiOpenLocal
            // 
            this.cmiOpenLocal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmiOpenLocal.Image = global::FileBrowserServer.Properties.Resources.page_go;
            this.cmiOpenLocal.Name = "cmiOpenLocal";
            this.cmiOpenLocal.Size = new System.Drawing.Size(129, 22);
            this.cmiOpenLocal.Text = "Open..";
            this.cmiOpenLocal.Click += new System.EventHandler(this.cmiOpenLocal_Click);
            // 
            // cmiUploadLocal
            // 
            this.cmiUploadLocal.Image = global::FileBrowserServer.Properties.Resources.page_add;
            this.cmiUploadLocal.Name = "cmiUploadLocal";
            this.cmiUploadLocal.Size = new System.Drawing.Size(129, 22);
            this.cmiUploadLocal.Text = "Upload..";
            this.cmiUploadLocal.Click += new System.EventHandler(this.cmiUploadLocal_Click);
            // 
            // cmiRenameLocal
            // 
            this.cmiRenameLocal.Image = global::FileBrowserServer.Properties.Resources.page_edit;
            this.cmiRenameLocal.Name = "cmiRenameLocal";
            this.cmiRenameLocal.Size = new System.Drawing.Size(129, 22);
            this.cmiRenameLocal.Text = "Rename..";
            this.cmiRenameLocal.Click += new System.EventHandler(this.cmiRenameLocal_Click);
            // 
            // cmiDeleteLocal
            // 
            this.cmiDeleteLocal.Image = global::FileBrowserServer.Properties.Resources.page_delete;
            this.cmiDeleteLocal.Name = "cmiDeleteLocal";
            this.cmiDeleteLocal.Size = new System.Drawing.Size(129, 22);
            this.cmiDeleteLocal.Text = "Delete..";
            this.cmiDeleteLocal.Click += new System.EventHandler(this.cmiDeleteLocal_Click);
            // 
            // cmiCreateLocal
            // 
            this.cmiCreateLocal.Image = global::FileBrowserServer.Properties.Resources.folder_add;
            this.cmiCreateLocal.Name = "cmiCreateLocal";
            this.cmiCreateLocal.Size = new System.Drawing.Size(129, 22);
            this.cmiCreateLocal.Text = "Create..";
            this.cmiCreateLocal.Click += new System.EventHandler(this.cmiCreateLocal_Click);
            // 
            // ilIcons
            // 
            this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcons.Images.SetKeyName(0, "folder.png");
            this.ilIcons.Images.SetKeyName(1, "page.png");
            this.ilIcons.Images.SetKeyName(2, "drive.png");
            this.ilIcons.Images.SetKeyName(3, "drive_cd.png");
            // 
            // txtLocalDir
            // 
            this.txtLocalDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalDir.BackColor = System.Drawing.SystemColors.Window;
            this.txtLocalDir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalDir.Location = new System.Drawing.Point(12, 15);
            this.txtLocalDir.Name = "txtLocalDir";
            this.txtLocalDir.ReadOnly = true;
            this.txtLocalDir.Size = new System.Drawing.Size(749, 21);
            this.txtLocalDir.TabIndex = 2;
            // 
            // txtRemoteDir
            // 
            this.txtRemoteDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteDir.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemoteDir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemoteDir.Location = new System.Drawing.Point(12, 246);
            this.txtRemoteDir.Name = "txtRemoteDir";
            this.txtRemoteDir.ReadOnly = true;
            this.txtRemoteDir.Size = new System.Drawing.Size(749, 21);
            this.txtRemoteDir.TabIndex = 8;
            // 
            // lvRemote
            // 
            this.lvRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNameRem,
            this.chTypeRem,
            this.chSizeRem});
            this.lvRemote.ContextMenuStrip = this.cmsRemote;
            this.lvRemote.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRemote.FullRowSelect = true;
            this.lvRemote.HideSelection = false;
            this.lvRemote.Location = new System.Drawing.Point(156, 274);
            this.lvRemote.Name = "lvRemote";
            this.lvRemote.Size = new System.Drawing.Size(636, 223);
            this.lvRemote.StateImageList = this.ilIcons;
            this.lvRemote.TabIndex = 3;
            this.lvRemote.UseCompatibleStateImageBehavior = false;
            this.lvRemote.View = System.Windows.Forms.View.Details;
            this.lvRemote.DoubleClick += new System.EventHandler(this.lvRemote_DoubleClick);
            // 
            // chNameRem
            // 
            this.chNameRem.Text = "File Name";
            this.chNameRem.Width = 198;
            // 
            // chTypeRem
            // 
            this.chTypeRem.Text = "File Type";
            this.chTypeRem.Width = 198;
            // 
            // chSizeRem
            // 
            this.chSizeRem.Text = "File Size";
            this.chSizeRem.Width = 198;
            // 
            // cmsRemote
            // 
            this.cmsRemote.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsRemote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiOpenRemote,
            this.cmiDownloadRemote,
            this.cmiRenameRemote,
            this.cmiDeleteRemote,
            this.cmiCreateRemote});
            this.cmsRemote.Name = "cmsRemote";
            this.cmsRemote.Size = new System.Drawing.Size(181, 136);
            // 
            // cmiOpenRemote
            // 
            this.cmiOpenRemote.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmiOpenRemote.Image = global::FileBrowserServer.Properties.Resources.page_go;
            this.cmiOpenRemote.Name = "cmiOpenRemote";
            this.cmiOpenRemote.Size = new System.Drawing.Size(138, 22);
            this.cmiOpenRemote.Text = "Open..";
            this.cmiOpenRemote.Click += new System.EventHandler(this.cmiOpenRemote_Click);
            // 
            // cmiDownloadRemote
            // 
            this.cmiDownloadRemote.Image = global::FileBrowserServer.Properties.Resources.page_save;
            this.cmiDownloadRemote.Name = "cmiDownloadRemote";
            this.cmiDownloadRemote.Size = new System.Drawing.Size(138, 22);
            this.cmiDownloadRemote.Text = "Download..";
            this.cmiDownloadRemote.Click += new System.EventHandler(this.cmiDownloadRemote_Click);
            // 
            // cmiRenameRemote
            // 
            this.cmiRenameRemote.Image = global::FileBrowserServer.Properties.Resources.page_edit;
            this.cmiRenameRemote.Name = "cmiRenameRemote";
            this.cmiRenameRemote.Size = new System.Drawing.Size(138, 22);
            this.cmiRenameRemote.Text = "Rename..";
            this.cmiRenameRemote.Click += new System.EventHandler(this.cmiRenameRemote_Click);
            // 
            // cmiDeleteRemote
            // 
            this.cmiDeleteRemote.Image = global::FileBrowserServer.Properties.Resources.page_delete;
            this.cmiDeleteRemote.Name = "cmiDeleteRemote";
            this.cmiDeleteRemote.Size = new System.Drawing.Size(138, 22);
            this.cmiDeleteRemote.Text = "Delete..";
            this.cmiDeleteRemote.Click += new System.EventHandler(this.cmiDeleteRemote_Click);
            // 
            // cmiCreateRemote
            // 
            this.cmiCreateRemote.Image = global::FileBrowserServer.Properties.Resources.folder_add;
            this.cmiCreateRemote.Name = "cmiCreateRemote";
            this.cmiCreateRemote.Size = new System.Drawing.Size(180, 22);
            this.cmiCreateRemote.Text = "Create..";
            this.cmiCreateRemote.Click += new System.EventHandler(this.cmiCreateRemote_Click);
            // 
            // lvDrivesLocal
            // 
            this.lvDrivesLocal.HideSelection = false;
            this.lvDrivesLocal.Location = new System.Drawing.Point(12, 43);
            this.lvDrivesLocal.MultiSelect = false;
            this.lvDrivesLocal.Name = "lvDrivesLocal";
            this.lvDrivesLocal.Size = new System.Drawing.Size(138, 194);
            this.lvDrivesLocal.StateImageList = this.ilIcons;
            this.lvDrivesLocal.TabIndex = 12;
            this.lvDrivesLocal.UseCompatibleStateImageBehavior = false;
            this.lvDrivesLocal.View = System.Windows.Forms.View.List;
            this.lvDrivesLocal.DoubleClick += new System.EventHandler(this.lvDrivesLocal_DoubleClick);
            // 
            // lvDrivesRemote
            // 
            this.lvDrivesRemote.HideSelection = false;
            this.lvDrivesRemote.Location = new System.Drawing.Point(12, 274);
            this.lvDrivesRemote.MultiSelect = false;
            this.lvDrivesRemote.Name = "lvDrivesRemote";
            this.lvDrivesRemote.Size = new System.Drawing.Size(138, 223);
            this.lvDrivesRemote.StateImageList = this.ilIcons;
            this.lvDrivesRemote.TabIndex = 12;
            this.lvDrivesRemote.UseCompatibleStateImageBehavior = false;
            this.lvDrivesRemote.View = System.Windows.Forms.View.List;
            this.lvDrivesRemote.DoubleClick += new System.EventHandler(this.lvDrivesRemote_DoubleClick);
            // 
            // btnRefreshRemote
            // 
            this.btnRefreshRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshRemote.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshRemote.Image = global::FileBrowserServer.Properties.Resources.arrow_refresh;
            this.btnRefreshRemote.Location = new System.Drawing.Point(767, 243);
            this.btnRefreshRemote.Name = "btnRefreshRemote";
            this.btnRefreshRemote.Size = new System.Drawing.Size(25, 25);
            this.btnRefreshRemote.TabIndex = 6;
            this.btnRefreshRemote.UseVisualStyleBackColor = true;
            this.btnRefreshRemote.Click += new System.EventHandler(this.btnRefreshRemote_Click);
            // 
            // btnRefreshLocal
            // 
            this.btnRefreshLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshLocal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshLocal.Image = global::FileBrowserServer.Properties.Resources.arrow_refresh;
            this.btnRefreshLocal.Location = new System.Drawing.Point(767, 12);
            this.btnRefreshLocal.Name = "btnRefreshLocal";
            this.btnRefreshLocal.Size = new System.Drawing.Size(25, 25);
            this.btnRefreshLocal.TabIndex = 1;
            this.btnRefreshLocal.UseVisualStyleBackColor = true;
            this.btnRefreshLocal.Click += new System.EventHandler(this.btnRefreshLocal_Click);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 509);
            this.Controls.Add(this.lvDrivesRemote);
            this.Controls.Add(this.lvDrivesLocal);
            this.Controls.Add(this.txtRemoteDir);
            this.Controls.Add(this.btnRefreshRemote);
            this.Controls.Add(this.lvRemote);
            this.Controls.Add(this.txtLocalDir);
            this.Controls.Add(this.btnRefreshLocal);
            this.Controls.Add(this.lvLocal);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrowserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Browser - {0}";
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.cmsLocal.ResumeLayout(false);
            this.cmsRemote.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.ListView lvLocal;
        public System.Windows.Forms.TextBox txtLocalDir;
        public System.Windows.Forms.Button btnRefreshLocal;
        public System.Windows.Forms.TextBox txtRemoteDir;
        private System.Windows.Forms.Button btnRefreshRemote;
        public System.Windows.Forms.ListView lvRemote;
        private System.Windows.Forms.ContextMenuStrip cmsRemote;
        private System.Windows.Forms.ToolStripMenuItem cmiOpenRemote;
        private System.Windows.Forms.ContextMenuStrip cmsLocal;
        private System.Windows.Forms.ToolStripMenuItem cmiOpenLocal;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chNameRem;
        private System.Windows.Forms.ColumnHeader chTypeRem;
        private System.Windows.Forms.ColumnHeader chSizeRem;
        private System.Windows.Forms.ImageList ilIcons;
        private System.Windows.Forms.ListView lvDrivesLocal;
        public System.Windows.Forms.ListView lvDrivesRemote;
        private System.Windows.Forms.ToolStripMenuItem cmiDownloadRemote;
        private System.Windows.Forms.ToolStripMenuItem cmiUploadLocal;
        private System.Windows.Forms.ToolStripMenuItem cmiDeleteLocal;
        private System.Windows.Forms.ToolStripMenuItem cmiDeleteRemote;
        private System.Windows.Forms.ToolStripMenuItem cmiCreateRemote;
        private System.Windows.Forms.ToolStripMenuItem cmiRenameRemote;
        private System.Windows.Forms.ToolStripMenuItem cmiRenameLocal;
        private System.Windows.Forms.ToolStripMenuItem cmiCreateLocal;
    }
}
