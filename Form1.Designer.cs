
namespace AudirvanaPlaylistSorter {
    partial class Form1 {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.clsPlaylists = new System.Windows.Forms.CheckedListBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.txtPathDatabase = new System.Windows.Forms.TextBox();
            this.btnSelectDatabasePath = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clsPlaylists
            // 
            this.clsPlaylists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clsPlaylists.CheckOnClick = true;
            this.clsPlaylists.FormattingEnabled = true;
            this.clsPlaylists.Location = new System.Drawing.Point(12, 12);
            this.clsPlaylists.Name = "clsPlaylists";
            this.clsPlaylists.Size = new System.Drawing.Size(236, 184);
            this.clsPlaylists.Sorted = true;
            this.clsPlaylists.TabIndex = 0;
            // 
            // btnSort
            // 
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSort.Location = new System.Drawing.Point(12, 202);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 1;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(93, 202);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select all";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 231);
            this.progressBar1.MarqueeAnimationSpeed = 25;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(236, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectNone.Location = new System.Drawing.Point(174, 202);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNone.TabIndex = 4;
            this.btnSelectNone.Text = "Select none";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // txtPathDatabase
            // 
            this.txtPathDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathDatabase.Location = new System.Drawing.Point(12, 260);
            this.txtPathDatabase.Name = "txtPathDatabase";
            this.txtPathDatabase.ReadOnly = true;
            this.txtPathDatabase.Size = new System.Drawing.Size(209, 20);
            this.txtPathDatabase.TabIndex = 5;
            // 
            // btnSelectDatabasePath
            // 
            this.btnSelectDatabasePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDatabasePath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectDatabasePath.BackgroundImage")));
            this.btnSelectDatabasePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectDatabasePath.Location = new System.Drawing.Point(225, 258);
            this.btnSelectDatabasePath.Name = "btnSelectDatabasePath";
            this.btnSelectDatabasePath.Size = new System.Drawing.Size(23, 23);
            this.btnSelectDatabasePath.TabIndex = 6;
            this.btnSelectDatabasePath.UseVisualStyleBackColor = true;
            this.btnSelectDatabasePath.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 291);
            this.Controls.Add(this.btnSelectDatabasePath);
            this.Controls.Add(this.txtPathDatabase);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.clsPlaylists);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(277, 330);
            this.Name = "Form1";
            this.Text = "Audirvana Playlist Sorter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clsPlaylists;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.TextBox txtPathDatabase;
        private System.Windows.Forms.Button btnSelectDatabasePath;
        private System.Windows.Forms.Button btnCancel;
    }
}

