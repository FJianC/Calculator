using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Calculator
{
    public partial class Form_button0a3 : Form
    {
        double xMum = 5;//x最大值
        double yMum = 5;//y最大值
        int flag = 0;//函数编号
        int[] used = new int[20];//锁
        bool clear = true;//true重新画，false是清空
        double a = 1;
        double b = 1;
        double c = 1;
        public Form_button0a3()
        {
            InitializeComponent();
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Thread InvokeThread = new Thread(new ThreadStart(InvokeMethod));
            InvokeThread.SetApartmentState(ApartmentState.STA);
            InvokeThread.Start();
            InvokeThread.Join();
        }//需要新建线程保存
        private void InvokeMethod()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请选择要保存的文件路径";//设置保存文件对话框的标题
            
            sfd.InitialDirectory = Application.StartupPath;//初始化保存目录，默认exe文件目录
            //设置保存文件的类型
            sfd.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|SVG (*.svg)|*.svg|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)//设置图片文件格式format
            {
                ChartImageFormat format = ChartImageFormat.Bmp;

                if (sfd.FileName.EndsWith("bmp"))
                {
                    format = ChartImageFormat.Bmp;
                }
                else if (sfd.FileName.EndsWith("jpg"))
                {
                    format = ChartImageFormat.Jpeg;
                }
                else if (sfd.FileName.EndsWith("emf"))
                {
                    format = ChartImageFormat.Emf;
                }
                else if (sfd.FileName.EndsWith("gif"))
                {
                    format = ChartImageFormat.Gif;
                }
                else if (sfd.FileName.EndsWith("png"))
                {
                    format = ChartImageFormat.Png;
                }
                else if (sfd.FileName.EndsWith("tif"))
                {
                    format = ChartImageFormat.Tiff;
                }
                string filePath = sfd.FileName;//获得保存文件的路径
                chart1.SaveImage(sfd.FileName, format);//保存

            }
        }//保存函数
        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double Max;
            if (xMum > yMum)
                Max = yMum;
            else
                Max = xMum;
            if (Max < 100000)
            {
                if (Max >= 100)
                {
                    xMum *= 10;
                    yMum *= 10;
                    chart1.ChartAreas[0].AxisX.Maximum = xMum;
                    chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                    chart1.ChartAreas[0].AxisY.Maximum = yMum;
                    chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
                }
                else if (Max >= 10)
                {
                    xMum += 10;
                    yMum += 10;
                    chart1.ChartAreas[0].AxisX.Maximum = xMum;
                    chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                    chart1.ChartAreas[0].AxisY.Maximum = yMum;
                    chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
                }
                else if (Max > 1)
                {
                    xMum += 1;
                    yMum += 1;
                    chart1.ChartAreas[0].AxisX.Maximum = xMum;
                    chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                    chart1.ChartAreas[0].AxisY.Maximum = yMum;
                    chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
                }
                else if (Max > 0)
                {
                    xMum += 0.1;
                    yMum += 0.1;
                    chart1.ChartAreas[0].AxisX.Maximum = xMum;
                    chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                    chart1.ChartAreas[0].AxisY.Maximum = yMum;
                    chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
                }
            }
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == 1)
                    bianli(i);
            }
        }
        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double Max;
            if (xMum > yMum)
                Max = yMum;
            else
                Max = xMum;
            if (Max >= 100)
            {
                xMum /= 10;
                yMum /= 10;
                chart1.ChartAreas[0].AxisX.Maximum = xMum;
                chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                chart1.ChartAreas[0].AxisY.Maximum = yMum;
                chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
            }
            else if (Max > 10)
            {
                xMum -= 10;
                yMum -= 10;
                chart1.ChartAreas[0].AxisX.Maximum = xMum;
                chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                chart1.ChartAreas[0].AxisY.Maximum = yMum;
                chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
            }
            else if (Max >= 2)
            {
                xMum -= 1;
                yMum -= 1;
                chart1.ChartAreas[0].AxisX.Maximum = xMum;
                chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                chart1.ChartAreas[0].AxisY.Maximum = yMum;
                chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
            }
            else if (Max > 0.3)
            {
                xMum -= 0.1;
                yMum -= 0.1;
                chart1.ChartAreas[0].AxisX.Maximum = xMum;
                chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                chart1.ChartAreas[0].AxisY.Maximum = yMum;
                chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
            }
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                xMum = Convert.ToDouble(xText.Text);
                yMum = Convert.ToDouble(yText.Text);
                chart1.ChartAreas[0].AxisX.Maximum = xMum;
                chart1.ChartAreas[0].AxisX.Minimum = -1 * xMum;
                chart1.ChartAreas[0].AxisY.Maximum = yMum;
                chart1.ChartAreas[0].AxisY.Minimum = -1 * yMum;
                bianli(flag);
            }
            catch
            {
                MessageBox.Show("输入错误");
            }
        }
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear = false;
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == 1)
                    bianli(i);
            }
            clear = true;
            flag = 0;
        }
        private void bianli(int flag)
        {
            switch (flag)
            {
                case 1: Sin(); break;
                case 2: Cos(); break;
                case 3: Tan(); break;
                case 4: erci(); break;
                case 5: Circle(); break;
                case 6: zhishu(); break;
                case 7: duishu(); break;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter) && textBox1.Text != "" && flag > 0)
                {
                    e.Handled = true;//关闭回车声音
                    double x = Convert.ToDouble(textBox1.Text);
                    double y = 0;
                    switch (flag)
                    {
                        case 1: y = a * Math.Sin(b * x) + c; break;
                        case 2: y = a * Math.Cos(b * x) + c; break;
                        case 3: y = a * Math.Tan(b * x) + c; break;
                        case 4: y = a * x * x + b * x + c; break;
                        case 5: y = a * Math.Pow(x, b) + c; break;
                        case 6: y = a * Math.Pow(b, x) + c; break;
                        case 7: y = a * Math.Log(b, x) + c; break;
                    }
                    textBox2.Text = y.ToString("F2");
                    XY(x, y);
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter) && textBox1.Text == "")
                {
                    textBox2.Text = "";
                    foreach (Series ser in chart1.Series)
                        if (ser.Name == "X")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                    foreach (Series ser in chart1.Series)
                        if (ser.Name == "Y")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                }
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//输入x计算y
        private void XY(double x, double y)
        {
            try
            {
                foreach (Series ser in chart1.Series)
                    if (ser.Name == "X")
                    {
                        chart1.Series.Remove(ser);
                        break;
                    }
                foreach (Series ser in chart1.Series)
                    if (ser.Name == "Y")
                    {
                        chart1.Series.Remove(ser);
                        break;
                    }
                Series X = new Series();
                Series Y = new Series();
                for (float i = (float)chart1.ChartAreas[0].AxisY.Minimum; i <= chart1.ChartAreas[0].AxisX.Maximum; i += 0.01f)
                    X.Points.AddXY(i, y);
                for (float i = (float)chart1.ChartAreas[0].AxisY.Minimum; i <= chart1.ChartAreas[0].AxisY.Maximum; i += 0.01f)
                    Y.Points.AddXY(x, i);
                X.Name = "X";
                Y.Name = "Y";
                X.Color = Color.Black;
                Y.Color = Color.Black;
                X.ChartType = SeriesChartType.Spline;
                Y.ChartType = SeriesChartType.Spline;
                chart1.Series.Add(X);
                chart1.Series.Add(Y);
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }
        private void SinEnter_Click(object sender, EventArgs e)
        {
            Sin();
            textBox3.Text = "a:" + a.ToString() + ", b:" + b.ToString() + ", c:" + c.ToString() + ", y = " + toolSin.Text;
        }//Sin
        private void Sin()
        {
            try
            {
                flag = 1;
                if (used[flag] == 1)
                {
                    used[flag] = 0;//解锁
                    foreach (Series ser in chart1.Series)
                    {
                        if (ser.Name == "Sin")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                    }
                }
                if (clear)
                {
                    a = 1; b = 1; c = 0;
                    if (Sina.Text != "")
                        a = Convert.ToDouble(Sina.Text);
                    if (Sinb.Text != "")
                        b = Convert.ToDouble(Sinb.Text);
                    if (Sinc.Text != "")
                        c = Convert.ToDouble(Sinc.Text);
                    Series s = new Series();
                    for (float i = (float)chart1.ChartAreas[0].AxisX.Minimum; i <= chart1.ChartAreas[0].AxisX.Maximum; i += 0.01f)
                        s.Points.AddXY(i, a * Math.Sin(b * i) + c);
                    s.Name = "Sin";
                    s.ChartType = SeriesChartType.Spline;
                    chart1.Series.Add(s);
                    used[flag] = 1;//已经绘制
                }
            }
            catch
            {
                MessageBox.Show("输入错误！1");
            }
        }
        private void CosEnter_Click(object sender, EventArgs e)
        {
            Cos();
            textBox3.Text = "a:" + a.ToString() + ", b:" + b.ToString() + ", c:" + c.ToString() + ", y = " + toolCos.Text;
        }//Cos
        private void Cos()
        {
            try
            {
                flag = 2;
                if (used[flag] == 1)
                {
                    used[flag] = 0;//解锁
                    foreach (Series ser in chart1.Series)
                    {
                        if (ser.Name == "Cos")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                    }
                }
                if (clear)
                {
                    a = 1; b = 1; c = 0;
                    if (Cosa.Text != "")
                        a = Convert.ToDouble(Cosa.Text);
                    if (Cosb.Text != "")
                        b = Convert.ToDouble(Cosb.Text);
                    if (Cosc.Text != "")
                        c = Convert.ToDouble(Cosc.Text);
                    Series s = new Series();
                    for (float i = (float)chart1.ChartAreas[0].AxisX.Minimum; i <= chart1.ChartAreas[0].AxisX.Maximum; i += 0.01f)
                        s.Points.AddXY(i, a * Math.Cos(b * i) + c);
                    s.Name = "Cos";
                    s.ChartType = SeriesChartType.Spline;
                    chart1.Series.Add(s);
                    used[flag] = 1;//已经绘制
                }
            }
            catch
            {
                MessageBox.Show("输入错误！2");
            }
        }
        private void TanEnter_Click(object sender, EventArgs e)
        {
            Tan();
            textBox3.Text = "a:" + a.ToString() + ", b:" + b.ToString() + ", c:" + c.ToString() + ", y = " + toolTan.Text;
        }//Tan
        private void Tan()
        {
            try
            {
                flag = 3;
                if (used[flag] == 1)
                {
                    used[flag] = 0;//解锁
                    foreach (Series ser in chart1.Series)
                    {
                        if (ser.Name == "Tan")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                    }
                }
                if (clear)
                {
                    a = 1; b = 1; c = 0;
                    if (Tana.Text != "")
                        a = Convert.ToDouble(Tana.Text);
                    if (Tanb.Text != "")
                        b = Convert.ToDouble(Tanb.Text);
                    if (Tanc.Text != "")
                        c = Convert.ToDouble(Tanc.Text);
                    Series s = new Series();
                    for (float i = (float)chart1.ChartAreas[0].AxisX.Minimum; i <= chart1.ChartAreas[0].AxisX.Maximum; i += 0.01f)
                        s.Points.AddXY(i, a * Math.Tan(b * i) + c);
                    s.Name = "Tan";
                    s.ChartType = SeriesChartType.Spline;
                    chart1.Series.Add(s);
                    used[flag] = 1;//已经绘制
                }
            }
            catch
            {
                MessageBox.Show("输入错误！3");
            }
        }
        private void erciEnter_Click(object sender, EventArgs e)
        {
            erci();
            textBox3.Text = "a:" + a.ToString() + ", b:" + b.ToString() + ", c:" + c.ToString() + ", y = " + toolerci.Text;
        }//一元二次方程
        private void erci()
        {
            try
            {
                flag = 4;
                if (used[flag] == 1)
                {
                    used[flag] = 0;//解锁
                    foreach (Series ser in chart1.Series)
                    {
                        if (ser.Name == "erci")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                    }
                }
                if (clear)
                {
                    a = 1; b = 0; c = 0;
                    if (ercia.Text != "")
                        a = Convert.ToDouble(ercia.Text);
                    if (ercib.Text != "")
                        b = Convert.ToDouble(ercib.Text);
                    if (ercic.Text != "")
                        c = Convert.ToDouble(ercic.Text);
                    Series s = new Series();
                    for (float i = (float)chart1.ChartAreas[0].AxisX.Minimum; i <= chart1.ChartAreas[0].AxisX.Maximum; i += 0.01f)
                        s.Points.AddXY(i, a * i * i + b * i + c);
                    s.Name = "erci";
                    s.ChartType = SeriesChartType.Spline;
                    chart1.Series.Add(s);
                    used[flag] = 1;//已经绘制
                }
            }
            catch
            {
                MessageBox.Show("输入错误！4");
            }
        }
        private void CircleEnter_Click(object sender, EventArgs e)
        {
            Circle();
            textBox3.Text = "a:" + a.ToString() + ", b:" + b.ToString() + ", c:" + c.ToString() + ", y = " + toolCircle.Text;
        }//幂函数
        private void Circle()
        {
            try
            {
                flag = 5;
                if (used[flag] == 1)
                {
                    used[flag] = 0;//解锁
                    foreach (Series ser in chart1.Series)
                    {
                        if (ser.Name == "mihanshu")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                    }
                }
                if (clear)
                {
                    a = 1; b = 1; c = 0;
                    if (Circlea.Text != "")
                        a = Convert.ToDouble(Circlea.Text);
                    if (Circleb.Text != "")
                        b = Convert.ToDouble(Circleb.Text);
                    if (Circlec.Text != "")
                        c = Convert.ToDouble(Circlec.Text);
                    Series s = new Series();
                    for (float i = (float)chart1.ChartAreas[0].AxisX.Minimum; i <= chart1.ChartAreas[0].AxisX.Maximum; i += 0.01f)
                        s.Points.AddXY(i, a * Math.Pow(i, b) + c);
                    s.Name = "mihanshu";
                    s.ChartType = SeriesChartType.Spline;
                    chart1.Series.Add(s);
                    used[flag] = 1;//已经绘制
                }
            }
            catch
            {
                MessageBox.Show("输入错误！5");
            }
        }
        private void zhishuEnter_Click(object sender, EventArgs e)
        {
            zhishu();
            textBox3.Text = "a:" + a.ToString() + ", b:" + b.ToString() + ", c:" + c.ToString() + ", y = " + toolzhishu.Text;
        }//指数函数
        private void zhishu()
        {
            try
            {
                flag = 6;
                if (used[flag] == 1)
                {
                    used[flag] = 0;//解锁
                    foreach (Series ser in chart1.Series)
                    {
                        if (ser.Name == "zhishu")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                    }
                }
                if (clear)
                {
                    a = 1; b = 1; c = 0;
                    if (zhishua.Text != "")
                        a = Convert.ToDouble(zhishua.Text);
                    if (zhishub.Text != "")
                        b = Convert.ToDouble(zhishub.Text);
                    if (zhishuc.Text != "")
                        c = Convert.ToDouble(zhishuc.Text);
                    Series s = new Series();
                    for (float i = (float)chart1.ChartAreas[0].AxisX.Minimum; i <= chart1.ChartAreas[0].AxisX.Maximum; i += 0.01f)
                        s.Points.AddXY(i, a * Math.Pow(b, i) + c);
                    s.Name = "zhishu";
                    s.ChartType = SeriesChartType.Spline;
                    chart1.Series.Add(s);
                    used[flag] = 1;//已经绘制
                }
            }
            catch
            {
                MessageBox.Show("输入错误！6");
            }
        }
        private void duishuEnter_Click(object sender, EventArgs e)
        {
            duishu();
            textBox3.Text = "a:" + a.ToString() + ", b:" + b.ToString() + ", c:" + c.ToString() + ", y = " + toolduishu.Text;
        }//对数函数
        private void duishu()
        {
            try
            {
                flag = 7;
                if (used[flag] == 1)
                {
                    used[flag] = 0;//解锁
                    foreach (Series ser in chart1.Series)
                    {
                        if (ser.Name == "duishu")
                        {
                            chart1.Series.Remove(ser);
                            break;
                        }
                    }
                }
                if (clear)
                {
                    a = 1; b = 2; c = 0;
                    if (duishua.Text != "")
                        a = Convert.ToDouble(duishua.Text);
                    if (duishub.Text != "")
                        b = Convert.ToDouble(duishub.Text);
                    if (duishuc.Text != "")
                        c = Convert.ToDouble(duishuc.Text);
                    Series s = new Series();
                    for (float i = (float)chart1.ChartAreas[0].AxisX.Minimum; i <= chart1.ChartAreas[0].AxisX.Maximum; i += 0.01f)
                        s.Points.AddXY(i, a * Math.Log(b, i) + c);
                    s.Name = "duishu";
                    s.ChartType = SeriesChartType.Spline;
                    chart1.Series.Add(s);
                    used[flag] = 1;//已经绘制
                }
            }
            catch
            {
                MessageBox.Show("输入错误！7");
            }
        }
    }
}

