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
        private string[] selectedOption;
        private string selectedNode = "/";
        private SortedDictionary<string, int> extensionsCount;
        private SortedDictionary<string, float> extensionsFloat;
        private int FileCount;
        private float FileSize;
        private Color[] colors;
        public MainWindow()
        {
            extensionsCount = new SortedDictionary<string, int>();
            extensionsFloat = new SortedDictionary<string, float>();
            Random rnd = new Random();

            colors = new Color[Constants.ChartCategoriesNumber];
            for (int i = 0; i < Constants.ChartCategoriesNumber; i++)
            {
                colors[i] = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            }

            this.MinimumSize = new Size(Constants.MainWindowWidth, Constants.MainWindowHeight);
            InitializeComponent();

            FileCounterProgresBar.Visible = true;
            FileCounterProgresBar.Minimum = 0;
            FileCounterProgresBar.Maximum = 100;
            FileCounterProgresBar.Value = 0;
            UpdateTree();
            try
            {

                selectedOption = Directory.GetLogicalDrives();
            }
            catch
            {}
            selectedNode = selectedOption[0];
            RestartCounter();
        }

        private void handleDialogWindow()
        {
            DialogWindow dialogWindow = new DialogWindow();
            DialogResult result = dialogWindow.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                selectedOption =  dialogWindow.SelectedOption;
            }

            UpdateTree();
            selectedNode = selectedOption[0];
            RestartCounter();

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
                        {
                            node.Nodes.Add(file);
                        }
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
            e.Result = 
                ans.files.ToString() + "," +
                ans.size.ToString() + "," +
                ans.subdirectories.ToString() + "," +
                Directory.GetLastAccessTimeUtc(selectedNode).ToString() + "," + 
                (ans.files + ans.subdirectories).ToString();
        }
        (int files, long size, int subdirectories) WalkDirectoryTree(string root, int level, BackgroundWorker worker, DoWorkEventArgs e)
        {

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return (0, 0, 0);
            }

            if(!Directory.Exists(root) && !File.Exists(root)) return(0, 0, 0);

            int files = 0;
            long size = 0;
            int subdirectories = 0;
            string[] dirs;
            
            if(File.Exists(root))
            {
                FileInfo fi = new FileInfo(root);
                return (1, fi.Length, 0); 
            }

            try
            {
                dirs = Directory.GetDirectories(root);
                int j = 0;
                foreach (var dir in dirs)
                {
                    subdirectories++;
                    (int t1, long t2, int t3) = WalkDirectoryTree(dir, level + 1, worker, e);
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
                    if (extensionsFloat.ContainsKey(fi.Extension))
                        extensionsFloat[fi.Extension] += fi.Length / (Constants.BiteToKilo);
                    else
                        extensionsFloat[fi.Extension] = fi.Length / (Constants.BiteToKilo);

                    if (extensionsCount.ContainsKey(fi.Extension))
                        extensionsCount[fi.Extension] += 1;
                    else
                        extensionsCount[fi.Extension] = 1;

                }
            }
            catch{ }

            
            return (files, size, subdirectories);

        }

        private void FileCounter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                
                var ans = e.Result.ToString().Split(',');
                FilesLabel.Text = ans[0];
                SizeLabel.Text = (Double.Parse(ans[1])/(Constants.BiteToKilo)).ToString("0.00") + "KB";
                SubdirsLabel.Text = ans[2];
                LastChangeLabel.Text = ans[3];
                ItemsLabel.Text = ans[4];
                pathLabel.Text = selectedNode;

                FileCount = int.Parse(ans[0]);
                FileSize = float.Parse(ans[1])/(Constants.BiteToKilo);
                FileCounterProgresBar.Value = 0;
                ChartsTab.Refresh();
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
            extensionsCount.Clear();
            extensionsFloat.Clear();
            FileCounterProgresBar.Value = 0;
            FileCounter.RunWorkerAsync();
        }

        private void cancelMenuItem_Click(object sender, EventArgs e)
        {
            RestartCounter();
            FileCounter.CancelAsync();
        }


        private void ChartsTab_Paint(object sender, PaintEventArgs e)
        {
            while(FileCounter.IsBusy)
            {
                Application.DoEvents();
            }
            (string, float)[] data = extensionsCount.Select(x => (x.Key, (float) x.Value)).OrderByDescending(x => x.Item2).Take(Constants.ChartCategoriesNumber).ToArray();
            (string, float)[] data2 = extensionsFloat.Select(x => (x.Key, x.Value)).OrderByDescending(x => x.Value).Take(Constants.ChartCategoriesNumber).ToArray();

            if (data.Length == 0)
                return;

            Graphics g = e.Graphics;
            

            ChartDrawer chartDrawer = new ChartDrawer(g, this);
            
            if (SelectChartBox.SelectedIndex == 0)
            {
                chartDrawer.DrawPieChart(ChartsTab.Width / 4 - Constants.LegendWidth, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth - Constants.LeftLegenConstant, data, colors, FileCount);
                chartDrawer.DrawLegend(ChartsTab.Width / 4 - Constants.LegendWidth - Constants.LeftLegenConstant, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth, data, colors, FileCount);
                chartDrawer.DrawPieChart(3 * ChartsTab.Width / 4 - Constants.LegendWidth - Constants.LeftLegenConstant, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth - Constants.LeftLegenConstant, data2, colors, FileSize);
                chartDrawer.DrawPieChart(3 * ChartsTab.Width / 4 - Constants.LegendWidth - Constants.LeftLegenConstant, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth - Constants.LeftLegenConstant, data2, colors, FileSize);
                chartDrawer.DrawLegend(3 * ChartsTab.Width / 4 - Constants.LegendWidth - Constants.LeftLegenConstant, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth, data2, colors, FileSize);
            }
            if (SelectChartBox.SelectedIndex == 1)
            {
                float X = 2 * Constants.ChartMargin;
                float Y = Constants.ChartMargin + Constants.TopMargin;
                float W = (ChartsTab.Width / 2) - 2 * X;
                float H = (ChartsTab.Height) - 2 * Y + Constants.TopMargin;
                Rectangle chartRect1 = new Rectangle((int)X, (int)Y, (int)W, (int)H);
                Rectangle chartRect2 = new Rectangle((int)((ChartsTab.Width / 2) + X), (int)Y, (int)W, (int)H);

                g.FillRectangle(Brushes.LightGray, chartRect1);
                g.FillRectangle(Brushes.LightGray, chartRect2);

                chartDrawer.DrawLines(X, Y, W, H, Constants.LinesNumber, FileCount);
                chartDrawer.DrawLines(chartRect2.X, chartRect2.Y, W, H, Constants.LinesNumber, FileSize);

                chartDrawer.DrawBarChart(X + Constants.BarGap, Y, W, H, data, colors, FileCount);
                chartDrawer.DrawBarChart(ChartsTab.Width / 2 + X + Constants.BarGap, Y, W, H, data2, colors, FileSize);
            }
            if (SelectChartBox.SelectedIndex == 2)
            {
                float X = 2 * Constants.ChartMargin;
                float Y = Constants.ChartMargin + Constants.TopMargin;
                float W = (ChartsTab.Width / 2) - 2 * X;
                float H = (ChartsTab.Height) - 2 * Y + Constants.TopMargin;
                Rectangle chartRect1 = new Rectangle((int)X, (int)Y, (int)W, (int)H);
                Rectangle chartRect2 = new Rectangle((int)((ChartsTab.Width / 2) + X), (int)Y, (int)W, (int)H);

                g.FillRectangle(Brushes.LightGray, chartRect1);
                g.FillRectangle(Brushes.LightGray, chartRect2);

                chartDrawer.DrawLogLines(X, Y, W, H, Constants.LinesNumber, FileCount);
                chartDrawer.DrawLogLines(chartRect2.X, chartRect2.Y, W, H, Constants.LinesNumber, FileSize);

                chartDrawer.DrawLogBarChart(X + Constants.BarGap, Y, W, H, data, colors,(float) FileCount);
                chartDrawer.DrawLogBarChart(ChartsTab.Width / 2 + X + Constants.BarGap, Y, W, H, data2, colors, FileSize);
            }

        }
        private void SelectChartBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartsTab.Refresh();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void UpdateTree()
        {
            if (selectedOption == null) return;
            if (selectedOption.Length == 0) return;

            FolderTree.BeginUpdate();
            FolderTree.Nodes.Clear();
            for(int i = 0; i < selectedOption.Length; i++)
            {
                FolderTree.Nodes.Add(selectedOption[i]);
                foreach (var dir in Directory.GetDirectories(selectedOption[i]))
                    FolderTree.Nodes[0].Nodes.Add(dir);
                var files = Directory.GetFiles(selectedOption[i]);
                if (files.Length < Constants.FileNodeMin)
                    foreach (var file in files)
                        FolderTree.Nodes[i].Nodes.Add(file);
                else
                    FolderTree.Nodes[i].Nodes.Add(Constants.FileNodeName);

            }
            FolderTree.EndUpdate();
        }

        private void RestartCounter()
        {
            FileCounter.CancelAsync();
            while (FileCounter.IsBusy)
            {
                Application.DoEvents();
            }
            FileCounter.RunWorkerAsync();
        }
    }
}
