namespace DiskSpaceAnalyzer
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileCounterProgresBar = new System.Windows.Forms.ProgressBar();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.SelectButton = new System.Windows.Forms.Button();
            this.FolderTree = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DetailsTab = new System.Windows.Forms.TabPage();
            this.LastChangeLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SubdirsLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.FilesLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ItemsLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChartsTab = new System.Windows.Forms.TabPage();
            this.FileCounter = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectChartBox = new System.Windows.Forms.ComboBox();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.DetailsTab.SuspendLayout();
            this.ChartsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileCounterProgresBar
            // 
            this.FileCounterProgresBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FileCounterProgresBar.Location = new System.Drawing.Point(0, 427);
            this.FileCounterProgresBar.Name = "FileCounterProgresBar";
            this.FileCounterProgresBar.Size = new System.Drawing.Size(800, 23);
            this.FileCounterProgresBar.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectMenuItem,
            this.cancelMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // selectMenuItem
            // 
            this.selectMenuItem.Name = "selectMenuItem";
            this.selectMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectMenuItem.Text = "Select";
            this.selectMenuItem.Click += new System.EventHandler(this.selectMenuItem_Click);
            // 
            // cancelMenuItem
            // 
            this.cancelMenuItem.Name = "cancelMenuItem";
            this.cancelMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cancelMenuItem.Text = "Cancel";
            this.cancelMenuItem.Click += new System.EventHandler(this.cancelMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "Exit";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMenuItem.Text = "About";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 403);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.SelectButton);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.FolderTree);
            this.splitContainer2.Size = new System.Drawing.Size(266, 403);
            this.splitContainer2.SplitterDistance = 27;
            this.splitContainer2.TabIndex = 0;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(188, 1);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 0;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // FolderTree
            // 
            this.FolderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderTree.Location = new System.Drawing.Point(0, 0);
            this.FolderTree.Name = "FolderTree";
            this.FolderTree.Size = new System.Drawing.Size(266, 372);
            this.FolderTree.TabIndex = 0;
            this.FolderTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.FolderTree_AfterExpand);
            this.FolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTree_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.DetailsTab);
            this.tabControl1.Controls.Add(this.ChartsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(530, 403);
            this.tabControl1.TabIndex = 0;
            // 
            // DetailsTab
            // 
            this.DetailsTab.Controls.Add(this.LastChangeLabel);
            this.DetailsTab.Controls.Add(this.label10);
            this.DetailsTab.Controls.Add(this.SubdirsLabel);
            this.DetailsTab.Controls.Add(this.label12);
            this.DetailsTab.Controls.Add(this.FilesLabel);
            this.DetailsTab.Controls.Add(this.label6);
            this.DetailsTab.Controls.Add(this.ItemsLabel);
            this.DetailsTab.Controls.Add(this.label8);
            this.DetailsTab.Controls.Add(this.SizeLabel);
            this.DetailsTab.Controls.Add(this.label3);
            this.DetailsTab.Controls.Add(this.pathLabel);
            this.DetailsTab.Controls.Add(this.label1);
            this.DetailsTab.Location = new System.Drawing.Point(4, 22);
            this.DetailsTab.Name = "DetailsTab";
            this.DetailsTab.Padding = new System.Windows.Forms.Padding(3);
            this.DetailsTab.Size = new System.Drawing.Size(522, 377);
            this.DetailsTab.TabIndex = 0;
            this.DetailsTab.Text = "Details";
            this.DetailsTab.UseVisualStyleBackColor = true;
            // 
            // LastChangeLabel
            // 
            this.LastChangeLabel.AutoSize = true;
            this.LastChangeLabel.Location = new System.Drawing.Point(98, 169);
            this.LastChangeLabel.Name = "LastChangeLabel";
            this.LastChangeLabel.Size = new System.Drawing.Size(0, 13);
            this.LastChangeLabel.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Last Change:";
            // 
            // SubdirsLabel
            // 
            this.SubdirsLabel.AutoSize = true;
            this.SubdirsLabel.Location = new System.Drawing.Point(98, 137);
            this.SubdirsLabel.Name = "SubdirsLabel";
            this.SubdirsLabel.Size = new System.Drawing.Size(0, 13);
            this.SubdirsLabel.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Subdirs:";
            // 
            // FilesLabel
            // 
            this.FilesLabel.AutoSize = true;
            this.FilesLabel.Location = new System.Drawing.Point(98, 109);
            this.FilesLabel.Name = "FilesLabel";
            this.FilesLabel.Size = new System.Drawing.Size(0, 13);
            this.FilesLabel.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Files:";
            // 
            // ItemsLabel
            // 
            this.ItemsLabel.AutoSize = true;
            this.ItemsLabel.Location = new System.Drawing.Point(98, 81);
            this.ItemsLabel.Name = "ItemsLabel";
            this.ItemsLabel.Size = new System.Drawing.Size(0, 13);
            this.ItemsLabel.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Items:";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(98, 57);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(0, 13);
            this.SizeLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Size:";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(98, 27);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(0, 13);
            this.pathLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Path:";
            // 
            // ChartsTab
            // 
            this.ChartsTab.Controls.Add(this.SelectChartBox);
            this.ChartsTab.Controls.Add(this.label2);
            this.ChartsTab.Location = new System.Drawing.Point(4, 22);
            this.ChartsTab.Name = "ChartsTab";
            this.ChartsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ChartsTab.Size = new System.Drawing.Size(522, 377);
            this.ChartsTab.TabIndex = 1;
            this.ChartsTab.Text = "Charts";
            this.ChartsTab.UseVisualStyleBackColor = true;
            this.ChartsTab.Paint += new System.Windows.Forms.PaintEventHandler(this.ChartsTab_Paint);
            // 
            // FileCounter
            // 
            this.FileCounter.WorkerReportsProgress = true;
            this.FileCounter.WorkerSupportsCancellation = true;
            this.FileCounter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileCounter_DoWork);
            this.FileCounter.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FileCounter_ProgressChanged);
            this.FileCounter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileCounter_RunWorkerCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chart type:";
            // 
            // SelectChartBox
            // 
            this.SelectChartBox.BackColor = System.Drawing.SystemColors.Window;
            this.SelectChartBox.Items.AddRange(new object[] {
            "Pie chart",
            "Bar chart",
            "Log bar chart"});
            this.SelectChartBox.Location = new System.Drawing.Point(93, 25);
            this.SelectChartBox.Name = "SelectChartBox";
            this.SelectChartBox.Size = new System.Drawing.Size(121, 21);
            this.SelectChartBox.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.FileCounterProgresBar);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.DetailsTab.ResumeLayout(false);
            this.DetailsTab.PerformLayout();
            this.ChartsTab.ResumeLayout(false);
            this.ChartsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar FileCounterProgresBar;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView FolderTree;
        private System.Windows.Forms.Button SelectButton;
        private System.ComponentModel.BackgroundWorker FileCounter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DetailsTab;
        private System.Windows.Forms.Label LastChangeLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label SubdirsLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label FilesLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ItemsLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage ChartsTab;
        private System.Windows.Forms.ComboBox SelectChartBox;
        private System.Windows.Forms.Label label2;
    }
}

