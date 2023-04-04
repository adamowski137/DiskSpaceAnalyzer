namespace DiskSpaceAnalyzer
{
    partial class DialogWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AllLocalButton = new System.Windows.Forms.RadioButton();
            this.IndividualDrivesButton = new System.Windows.Forms.RadioButton();
            this.FolderButton = new System.Windows.Forms.RadioButton();
            this.DrivesInfoListView = new System.Windows.Forms.ListView();
            this.RadioButtonsGroupBox = new System.Windows.Forms.GroupBox();
            this.FolderTextBox = new System.Windows.Forms.TextBox();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FreeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PercentHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PercentHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RadioButtonsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllLocalButton
            // 
            this.AllLocalButton.AutoSize = true;
            this.AllLocalButton.Location = new System.Drawing.Point(6, 19);
            this.AllLocalButton.Name = "AllLocalButton";
            this.AllLocalButton.Size = new System.Drawing.Size(98, 17);
            this.AllLocalButton.TabIndex = 1;
            this.AllLocalButton.TabStop = true;
            this.AllLocalButton.Text = "All Local Drives";
            this.AllLocalButton.UseVisualStyleBackColor = true;
            // 
            // IndividualDrivesButton
            // 
            this.IndividualDrivesButton.AutoSize = true;
            this.IndividualDrivesButton.Location = new System.Drawing.Point(6, 42);
            this.IndividualDrivesButton.Name = "IndividualDrivesButton";
            this.IndividualDrivesButton.Size = new System.Drawing.Size(103, 17);
            this.IndividualDrivesButton.TabIndex = 2;
            this.IndividualDrivesButton.TabStop = true;
            this.IndividualDrivesButton.Text = "Individual Drives";
            this.IndividualDrivesButton.UseVisualStyleBackColor = true;
            // 
            // FolderButton
            // 
            this.FolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FolderButton.AutoSize = true;
            this.FolderButton.Location = new System.Drawing.Point(6, 175);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(64, 17);
            this.FolderButton.TabIndex = 3;
            this.FolderButton.TabStop = true;
            this.FolderButton.Text = "A Folder";
            this.FolderButton.UseVisualStyleBackColor = true;
            // 
            // DrivesInfoListView
            // 
            this.DrivesInfoListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrivesInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.TotalHeader,
            this.FreeHeader,
            this.PercentHeader,
            this.PercentHeader2});
            this.DrivesInfoListView.HideSelection = false;
            this.DrivesInfoListView.Location = new System.Drawing.Point(6, 65);
            this.DrivesInfoListView.Name = "DrivesInfoListView";
            this.DrivesInfoListView.OwnerDraw = true;
            this.DrivesInfoListView.Size = new System.Drawing.Size(466, 97);
            this.DrivesInfoListView.TabIndex = 4;
            this.DrivesInfoListView.UseCompatibleStateImageBehavior = false;
            this.DrivesInfoListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.DrivesInfoListView_DrawColumnHeader);
            this.DrivesInfoListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.DrivesInfoListView_DrawSubItem);
            // 
            // RadioButtonsGroupBox
            // 
            this.RadioButtonsGroupBox.Controls.Add(this.CancelButton);
            this.RadioButtonsGroupBox.Controls.Add(this.OKButton);
            this.RadioButtonsGroupBox.Controls.Add(this.SelectFolderButton);
            this.RadioButtonsGroupBox.Controls.Add(this.FolderTextBox);
            this.RadioButtonsGroupBox.Controls.Add(this.DrivesInfoListView);
            this.RadioButtonsGroupBox.Controls.Add(this.AllLocalButton);
            this.RadioButtonsGroupBox.Controls.Add(this.IndividualDrivesButton);
            this.RadioButtonsGroupBox.Controls.Add(this.FolderButton);
            this.RadioButtonsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioButtonsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RadioButtonsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.RadioButtonsGroupBox.Name = "RadioButtonsGroupBox";
            this.RadioButtonsGroupBox.Size = new System.Drawing.Size(484, 261);
            this.RadioButtonsGroupBox.TabIndex = 5;
            this.RadioButtonsGroupBox.TabStop = false;
            // 
            // FolderTextBox
            // 
            this.FolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderTextBox.Location = new System.Drawing.Point(6, 198);
            this.FolderTextBox.Name = "FolderTextBox";
            this.FolderTextBox.Size = new System.Drawing.Size(385, 20);
            this.FolderTextBox.TabIndex = 5;
            this.FolderTextBox.TextChanged += new System.EventHandler(this.FolderTextBox_TextChanged);
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFolderButton.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelectFolderButton.Location = new System.Drawing.Point(397, 198);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(75, 20);
            this.SelectFolderButton.TabIndex = 6;
            this.SelectFolderButton.Text = "...";
            this.SelectFolderButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(302, 229);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 20);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(397, 229);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 20);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            // 
            // TotalHeader
            // 
            this.TotalHeader.Text = "Total";
            // 
            // FreeHeader
            // 
            this.FreeHeader.Text = "Free";
            // 
            // PercentHeader
            // 
            this.PercentHeader.Text = "Used/Total";
            this.PercentHeader.Width = 100;
            // 
            // PercentHeader2
            // 
            this.PercentHeader2.Text = "Used/Total";
            this.PercentHeader2.Width = 200;
            // 
            // DialogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.RadioButtonsGroupBox);
            this.Name = "DialogWindow";
            this.Text = "Select Disk or Folder";
            this.RadioButtonsGroupBox.ResumeLayout(false);
            this.RadioButtonsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton AllLocalButton;
        private System.Windows.Forms.RadioButton IndividualDrivesButton;
        private System.Windows.Forms.RadioButton FolderButton;
        private System.Windows.Forms.ListView DrivesInfoListView;
        private System.Windows.Forms.GroupBox RadioButtonsGroupBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button SelectFolderButton;
        private System.Windows.Forms.TextBox FolderTextBox;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader TotalHeader;
        private System.Windows.Forms.ColumnHeader FreeHeader;
        private System.Windows.Forms.ColumnHeader PercentHeader;
        private System.Windows.Forms.ColumnHeader PercentHeader2;
    }
}