using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DiskSpaceAnalyzer
{
    public class ChartDrawer
    {
        private Graphics g;
        private Form Form;
        public ChartDrawer(Graphics g, Form form) 
        {
            this.g = g;
            Form = form;
        }

        public void DrawLines(float X, float Y, float W, float H, int n, float total)
        {
            float gap = H / n;
            float y = Y + H;
            int i = 0;
            Font font = new Font(Form.Font.Name, 6.2f);
            while (y > Y)
            {
                g.DrawLine(Pens.Black, X, y, X + W, y);
                g.DrawString($"{(i * (total / n)).ToString("0.00")}", font, Brushes.Black, X - 30, y);
                i++;
                y = y - gap;
            }
        }

        public void DrawLogLines(float X, float Y, float W, float H, int n, float total)
        {
            float gap = H / n;
            float y = Y + H;
            int i = 0;
            Font font = new Font(Form.Font.Name, 6.2f);
            while (y > Y)
            {
                g.DrawLine(Pens.Black, X, y, X + W, y);
                g.DrawString($"10^{Math.Log10(i * (total / n) + 1).ToString("0.00")}", font, Brushes.Black, X - 30, y);
                i++;
                y = y - gap;
            }
        }

        public void DrawBarChart(float x, float y, float width, float height, (string ext, float amount)[] data, Color[] colors, float max)
        {
            int length = data.Length;
            if (data.Length == Constants.ChartCategoriesNumber)
                length = Constants.ChartCategoriesNumber - 2;
            float barWidth = (width - (length + 3) * Constants.BarGap) / (length + 1);
            Font font = new Font(Form.Font.Name, 6.2f);
            for (int i = 0; i < length; i++)
            {
                g.DrawString(data[i].ext, font, Brushes.Black, x + i * (barWidth + Constants.BarGap), y + height);
                g.FillRectangle(new SolidBrush(colors[i]), x + i * (barWidth + Constants.BarGap), y + height - ((float)data[i].amount / max) * height, barWidth, ((float)data[i].amount / max) * height);
                g.DrawRectangle(Pens.Black, x + i * (barWidth + Constants.BarGap), y + height - ((float)data[i].amount / max) * height, barWidth, ((float)data[i].amount / max) * height);
            }
            if (length < data.Length)
            {
                float am = max;
                for (int i = 0; i < length; i++)
                {
                    am -= data[i].amount;
                }
                g.DrawString($"other", font, Brushes.Black, x + length * (barWidth + Constants.BarGap), y + height);
                g.FillRectangle(new SolidBrush(colors[length]), x + length * (barWidth + Constants.BarGap), y + height - ((float)am / max) * height, barWidth, ((float)am / max) * height);
                g.DrawRectangle(Pens.Black, x + (length) * (barWidth + Constants.BarGap), y + height - ((float)am / max) * height, barWidth, ((float)am / max) * height);
            }
        }
        public void DrawLogBarChart(float x, float y, float width, float height, (string ext, float amount)[] data, Color[] colors, float max)
        {
            int length = data.Length;
            if (data.Length == Constants.ChartCategoriesNumber)
                length = Constants.ChartCategoriesNumber - 2;
            float barWidth = (width - (length + 3) * Constants.BarGap) / (length + 1);
            Font font = new Font(Form.Font.Name, 6.2f);
            for (int i = 0; i < length; i++)
            {
                g.DrawString(data[i].ext, font, Brushes.Black, x + i * (barWidth + Constants.BarGap), y + height);
                float barH = (float)Math.Log10(data[i].amount / max + 1);

                g.FillRectangle(new SolidBrush(colors[i]), x + i * (barWidth + Constants.BarGap), y + height - barH * height, barWidth, barH * height);
                g.DrawRectangle(Pens.Black, x + i * (barWidth + Constants.BarGap), y + height - barH * height, barWidth, barH * height);
            }
            if (length < data.Length)
            {
                float am = max;
                for (int i = 0; i < length; i++)
                {
                    am -= data[i].amount;
                }
                float barH = (float)Math.Log10(am / max);
                g.DrawString($"other", font, Brushes.Black, x + length * (barWidth + Constants.BarGap), y + height);
                g.FillRectangle(new SolidBrush(colors[length]), x + length * (barWidth + Constants.BarGap), y + height - barH * height, barWidth, barH * height);
                g.DrawRectangle(Pens.Black, x + (length) * (barWidth + Constants.BarGap), y + height - barH * height, barWidth, barH * height);
            }
        }
        public void DrawPieChart(float centerX, float centerY, float radius, (string ext, float amount)[] data, Color[] colors, float max)
        {

            float startAngle = 0;
            float endAngle = 0;
            Pen pen = new Pen(Color.Black);

            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                     radius + radius, radius + radius);
            int length = data.Length;
            if (data.Length == Constants.ChartCategoriesNumber)
                length = Constants.ChartCategoriesNumber - 2;
            for (int i = 0; i < length; i++)
            {
                Brush brush = new SolidBrush(colors[i]);
                startAngle = endAngle;
                endAngle = endAngle + PercentToAngle(data[i].amount, max);
                g.FillPie(brush, centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, endAngle - startAngle);
                g.DrawPie(Pens.Black, centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, endAngle - startAngle);
            }
            if (length != data.Length)
            {
                startAngle = endAngle;
                g.FillPie(new SolidBrush(colors[Constants.ChartCategoriesNumber - 1]), centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, 360 - startAngle);
                g.DrawPie(Pens.Black, centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, 360 - startAngle);

            }
        }

        public void DrawLegend(float centerX, float centerY, float radius, (string ext, float amount)[] data, Color[] colors, float max)
        {
            int length = data.Length;
            if (data.Length == Constants.ChartCategoriesNumber)
                length = Constants.ChartCategoriesNumber - 2;

            for (int i = 0; i < length; i++)
            {
                g.FillRectangle(new SolidBrush(colors[i]), centerX + radius + Constants.ChartMargin,
                    centerY - radius + Constants.LegendLineHeight * i + (Constants.LegendColorRectHeight / 2),
                    Constants.LegendColorRectWidth, Constants.LegendColorRectHeight);
                g.DrawString($"{data[i].ext} - {data[i].amount}", Form.Font, Brushes.Black,
                    centerX + radius + Constants.ChartMargin + Constants.LegendColorRectWidth, centerY - radius + Constants.LegendLineHeight * i);
            }
            if (length != data.Length)
            {
                float am = max;
                for (int i = 0; i < length; i++)
                {
                    am -= data[i].amount;
                }
                g.FillRectangle(new SolidBrush(colors[Constants.ChartCategoriesNumber - 1]), centerX + radius + Constants.ChartMargin, centerY - radius + Constants.LegendLineHeight * (Constants.ChartCategoriesNumber - 2) + (Constants.LegendColorRectHeight / 2),
                    Constants.LegendColorRectWidth, Constants.LegendColorRectHeight);
                g.DrawString($"other - {am}", Form.Font, Brushes.Black, centerX + radius + Constants.ChartMargin + Constants.LegendColorRectWidth, centerY - radius + Constants.LegendLineHeight * (Constants.ChartCategoriesNumber - 2));
            }
        }
        private float PercentToAngle(float p, float max)
        {
            return ((float)p / max) * 360;
        }
    }
}
