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
        private SortedDictionary<string, int> extensions;
        private int total;
        public MainWindow()
        {
            extensions = new SortedDictionary<string, int>();
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
                    if(extensions.ContainsKey(fi.Extension))
                        extensions[fi.Extension] += 1;
                    else
                        extensions[fi.Extension] = 1;

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
            extensions.Clear();
            FileCounter.RunWorkerAsync();
        }

        private void cancelMenuItem_Click(object sender, EventArgs e)
        {
            FileCounter.CancelAsync();
        }


        private void ChartsTab_Paint(object sender, PaintEventArgs e)
        {
            while(FileCounter.IsBusy)
            {
                Application.DoEvents();
            }
            (string, int)[] data = extensions.Select(x => (x.Key, x.Value)).OrderByDescending(x => x.Value).Take(Constants.ChartCategoriesNumber).ToArray();
            if (data.Length == 0)
                return;
            Random rnd = new Random();
            Graphics g = e.Graphics;
            Color[] colors = new Color[Constants.ChartCategoriesNumber];
            for (int i = 0; i < Constants.ChartCategoriesNumber; i++)
            {
                colors[i] = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            }
            DrawBarChart(g, Constants.ChartMargin, Constants.ChartMargin, ChartsTab.Height - 2 * Constants.ChartMargin, (ChartsTab.Width - 2 * Constants.ChartMargin)/2, data, colors);
            if(SelectChartBox.SelectedIndex == 0)
            {
                DrawPieChart(g,     ChartsTab.Width / 4 - Constants.LegendWidth, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth, data, colors);
                DrawLegend(g,       ChartsTab.Width / 4 - Constants.LegendWidth, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth, data, colors);
                DrawPieChart(g, 3 * ChartsTab.Width / 4 - Constants.LegendWidth, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth, data, colors);
                DrawLegend(g, 3 *   ChartsTab.Width / 4 - Constants.LegendWidth, ChartsTab.Height / 2, (ChartsTab.Width / 4) - Constants.LegendWidth, data, colors);
            }

        }
        private void DrawBarChart(Graphics g, float x, float y, float height, float width, (string ext, int amount)[] data, Color[] colors)
        {
            int length = data.Length;
            if (data.Length == Constants.ChartCategoriesNumber)
                length = Constants.ChartCategoriesNumber - 2;
            for (int i = 0; i < length; i++)
            {
                g.DrawString(data[i].ext, DefaultFont, Brushes.Black, x + i * (width / (length + 1) + 3), y + height);
                g.FillRectangle(new SolidBrush(colors[i]), x + i * (width / (length + 1) + 3),  y + height - ((float)data[i].amount / total) * height, width / (length + 1), ((float)data[i].amount / total) * height);
                g.DrawRectangle(Pens.Black,x + i * (width / (length + 1) + 3),  y + height - ((float)data[i].amount / total) * height , width / (length + 1), ((float)data[i].amount / total) * height);
            }
        }
        private void DrawPieChart(Graphics g, float centerX, float centerY, float radius, (string ext, int amount)[] data, Color[] colors)
        {

            float startAngle = 0;
            float endAngle = 0;
            Pen pen = new Pen(Color.Black);

            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                     radius + radius, radius + radius);
            int length = data.Length;
            if(data.Length == Constants.ChartCategoriesNumber)
                length = Constants.ChartCategoriesNumber - 2;
            for (int i = 0; i < length; i++)
            {
                Brush brush = new SolidBrush(colors[i]);
                startAngle = endAngle;
                endAngle = endAngle + PercentToAngle(data[i].amount);
                g.FillPie(brush, centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, endAngle - startAngle);
                g.DrawPie(Pens.Black, centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, endAngle - startAngle);
            }
            if(length != data.Length)
            {
                startAngle = endAngle;
                g.FillPie(new SolidBrush(colors[Constants.ChartCategoriesNumber - 1]), centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, 360 - startAngle);
                g.DrawPie(Pens.Black, centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, 360 - startAngle);

            }
        }

        private void DrawLegend(Graphics g, float centerX, float centerY, float radius, (string ext, int amount)[] data, Color[] colors)
        {
            int length = data.Length;
            if (data.Length == Constants.ChartCategoriesNumber)
                length = Constants.ChartCategoriesNumber - 2;

            for (int i = 0; i < length; i++)
            {
                g.FillRectangle(new SolidBrush(colors[i]), centerX + radius + Constants.ChartMargin,
                    centerY - radius + Constants.LegendLineHeight * i + (Constants.LegendColorRectHeight / 2),
                    Constants.LegendColorRectWidth, Constants.LegendColorRectHeight);
                g.DrawString($"{data[i].ext} {data[i].amount}", DefaultFont, Brushes.Black,
                    centerX + radius + Constants.ChartMargin + Constants.LegendColorRectWidth, centerY - radius + Constants.LegendLineHeight * i);
            }
            if (length != data.Length)
            {
                g.FillRectangle(new SolidBrush(colors[Constants.ChartCategoriesNumber - 1]), centerX + radius + Constants.ChartMargin, centerY - radius + Constants.LegendLineHeight * (Constants.ChartCategoriesNumber - 2) + (Constants.LegendColorRectHeight / 2),
                    Constants.LegendColorRectWidth, Constants.LegendColorRectHeight);
                g.DrawString($"other", DefaultFont, Brushes.Black, centerX + radius + Constants.ChartMargin + Constants.LegendColorRectWidth, centerY - radius + Constants.LegendLineHeight * (Constants.ChartCategoriesNumber - 2));
            }
        }


        private float PercentToAngle(int p)
        {
            return ((float) p / total) * 360;
        }
    }
}
