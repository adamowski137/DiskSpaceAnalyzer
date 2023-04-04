using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DiskSpaceAnalyzer
{
    public partial class MainWindow : Form
    {
        private string selectedOption = "";
        private string selectedNode = "/";
        private Dictionary<string, int> extensions = new Dictionary<string, int>();
        private int total;
        public MainWindow()
        {

            this.MinimumSize = new Size(Constants.MainWindowWidth, Constants.MainWindowHeight);
            InitializeComponent();
            FileCounterProgresBar.Visible = true;
            FileCounterProgresBar.Minimum = 0;
            FileCounterProgresBar.Maximum = 100;
        }

        private void handleDialogWindow()
        {
            DialogWindow dialogWindow = new DialogWindow();
            DialogResult result = dialogWindow.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                selectedOption =  dialogWindow.SelectedOption;
            }

            if (selectedOption == "") return;
            FolderTree.BeginUpdate();
            FolderTree.Nodes.Clear();
            FolderTree.Nodes.Add(selectedOption);
            foreach(var dir in Directory.GetDirectories(selectedOption))
                FolderTree.Nodes[0].Nodes.Add(dir);
            var files = Directory.GetFiles(selectedOption);
            if (files.Length < Constants.FileNodeMin)
                foreach (var file in files)
                    FolderTree.Nodes[0].Nodes.Add(file);
            else
                FolderTree.Nodes[0].Nodes.Add(Constants.FileNodeName);
            FolderTree.EndUpdate();
            selectedNode = selectedOption;
            FileCounter.CancelAsync();
            while (FileCounter.IsBusy)
            {
                Application.DoEvents();
            }
            FileCounter.RunWorkerAsync();

        }

        private void FolderTree_AfterExpand(Object sender, TreeViewEventArgs e)
        {
            FolderTree.BeginUpdate();
            foreach (TreeNode node in e.Node.Nodes)
            {
                try 
                { 
                    if (node.Text == Constants.FileNodeName)
                        foreach (var file in Directory.GetFiles(e.Node.Text))
                            node.Nodes.Add(file);
                    else
                    {
                        foreach(var dir in Directory.GetDirectories(node.Text))
                            node.Nodes.Add(dir); 
                        var files = Directory.GetFiles(node.Text);
                            if (files.Length < Constants.FileNodeMin)
                                foreach (var file in files)
                                    node.Nodes.Add(file);
                            else
                                node.Nodes.Add(Constants.FileNodeName);
                    }
                }
                catch { }
            }    
            FolderTree.EndUpdate();
        }

        private void selectMenuItem_Click(object sender, EventArgs e)
        {
            handleDialogWindow();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            handleDialogWindow();
            
        }

        private void FileCounter_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            var ans = WalkDirectoryTree(selectedNode, 0, backgroundWorker, e);
            e.Result = ans.files.ToString() + "," +
                ans.size.ToString() + "," +
                ans.subdirectories.ToString() + "," +
                Directory.GetLastAccessTimeUtc(selectedNode).ToString() + "," + 
                (ans.files + ans.subdirectories).ToString();
        }
        (int files, int size, int subdirectories) WalkDirectoryTree(string root, int level, BackgroundWorker worker, DoWorkEventArgs e)
        {

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return (0, 0, 0);
            }

            if(!Directory.Exists(root) && !File.Exists(root)) return(0, 0, 0);

            int files = 0;
            int size = 0;
            int subdirectories = 0;
            string[] dirs;
            
            if(File.Exists(root))
            {
                FileInfo fi = new FileInfo(root);
                return (1, (int) fi.Length, 0); 
            }

            try
            {
                dirs = Directory.GetDirectories(root);
                int j = 0;
                foreach (var dir in dirs)
                {
                    subdirectories++;
                    (int t1, int t2, int t3) = WalkDirectoryTree(dir, level + 1, worker, e);
                    j++;
                    files += t1;
                    size += t2;
                    subdirectories += t3;
                    if (level == 0)
                    {
                        worker.ReportProgress((int)(100 * ((double) j / dirs.Length)));
                    }
                }
            }
            catch { }
            try
            {
                foreach (var file in Directory.GetFiles(root))
                {
                    files++;
                    FileInfo fi = new FileInfo(file);
                    size += (int) fi.Length;
                    extensions[fi.Extension]++;
                }
            }
            catch{ }

            
            return (files, size, subdirectories);

        }

        private void FileCounter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            extensions = new Dictionary<string, int>();
            if(!e.Cancelled)
            {
                
                var ans = e.Result.ToString().Split(',');
                FilesLabel.Text = ans[0];
                SizeLabel.Text = (Double.Parse(ans[1])/(Constants.BiteToKilo)).ToString("0.00") + "KB";
                SubdirsLabel.Text = ans[2];
                LastChangeLabel.Text = ans[3];
                ItemsLabel.Text = ans[4];
                pathLabel.Text = selectedNode;

                total = int.Parse(ans[0]);
            }
        }

        private void FileCounter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FileCounterProgresBar.Value = e.ProgressPercentage;
        }

        private void FolderTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (FolderTree.SelectedNode.Text != Constants.FileNodeName)
                selectedNode = FolderTree.SelectedNode.Text;
            FileCounter.CancelAsync();
            while (FileCounter.IsBusy)
            {
                Application.DoEvents();
            }
            FileCounter.RunWorkerAsync();
        }

        private void cancelMenuItem_Click(object sender, EventArgs e)
        {
            FileCounter.CancelAsync();
        }


        private void ChartsTab_Paint(object sender, PaintEventArgs e)
        {
            //int[] data = { 25, 25, 20, 25, 5, 20, 5 };
            int[] data = extensions.Select(x => (int)((double) (x.Value) / total) * 100 ).OrderByDescending(x => x).Take(10).ToArray();
            if (data.Length == 0)
                return;
            Graphics g = e.Graphics;
            DrawPieChart(g,      ChartsTab.Width/4, ChartsTab.Height/2, (ChartsTab.Width / 4) - Constants.ChartPieMargin, data);
            DrawPieChart(g,  3 * ChartsTab.Width / 4, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.ChartPieMargin, data);

        }
        private void DrawPieChart(Graphics g, float centerX, float centerY, float radius, int[] data)
        {

            Random rnd = new Random();
            float startAngle = 0;
            float endAngle = PercentToAngle(data[0]);
            Brush brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
            Pen pen = new Pen(Color.Black);


            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                     radius + radius, radius + radius);
            for (int i = 1; i < data.Length; i++)
            {
                endAngle = startAngle + PercentToAngle(data[i]);
                g.FillPie(brush, centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, endAngle - startAngle);
                startAngle = endAngle;
                brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
            }
        }
        private float PercentToAngle(int p)
        {
            return ((float) p / 100) * 360;
        }

    }
}
