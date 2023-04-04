using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DiskSpaceAnalyzer
{
    public partial class DialogWindow : Form
    {
        public string SelectedOption { get; private set; }
        public DialogWindow()
        {
            this.MinimumSize = new Size(Constants.DialogWindowWidth, Constants.DialogWindowHeight);
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            FolderTextBox.AutoCompleteSource = AutoCompleteSource.FileSystem;
            FolderTextBox.AutoCompleteMode= AutoCompleteMode.Suggest;

            CreateListView();
        }

        private void CreateListView()
        {
            DrivesInfoListView.View = View.Details;
            DrivesInfoListView.UseCompatibleStateImageBehavior = false;
            DrivesInfoListView.FullRowSelect = true;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                ListViewItem item = new ListViewItem();
                float totalSpace = ((float)drive.TotalSize / (1024 * 1024 * 1024));
                float freeSpace = ((float)drive.TotalFreeSpace / (1024 * 1024 * 1024));
                float usedSpace = totalSpace - freeSpace;

                item.Text = drive.Name;
                item.SubItems.Add(totalSpace.ToString("0.0") + "GB");
                item.SubItems.Add(freeSpace.ToString("0.0") + "GB");
                item.SubItems.Add((usedSpace / totalSpace).ToString());
                item.SubItems.Add((usedSpace / totalSpace * 100).ToString("0.00") + "%");

                DrivesInfoListView.Items.Add(item);
            }
        }

        private void HandleFolderInput()
        {
            if(!Directory.Exists(FolderTextBox.Text))
                FolderTextBox.ForeColor = Color.Red;
            else
            {
                FolderTextBox.ForeColor = Color.Black;

            }
        }   

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (IndividualDrivesButton.Checked == true && DrivesInfoListView.SelectedItems.Count > 0)
                SelectedOption = DrivesInfoListView.SelectedItems[0].Text;
            else if (AllLocalButton.Checked == true)
                SelectedOption = "/";
            else if (FolderButton.Checked == true && FolderTextBox.Text != "")
                SelectedOption = FolderTextBox.Text;
            else SelectedOption = "";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            
            this.Close();
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                FolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void DrivesInfoListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void DrivesInfoListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if(e.ColumnIndex == Constants.ProgressBarId)
            {
                double percent = double.Parse(e.SubItem.Text);
                int rectWidth = e.SubItem.Bounds.Width - 4;
                int rectHeight = e.SubItem.Bounds.Height - 4;
                int rectX = e.SubItem.Bounds.X + 2;
                int rectY = e.SubItem.Bounds.Y + 2;
                int colored =(int) (percent * rectWidth);

                Brush brush = new SolidBrush(Color.Green);
                
                e.Graphics.FillRectangle(brush, rectX, rectY, colored, rectHeight);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void FolderTextBox_TextChanged(object sender, EventArgs e)
        {
            HandleFolderInput();
        }
    }
}
