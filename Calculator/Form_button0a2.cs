using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Calculator
{
    public partial class Form_button0a2 : Form
    {
        int formHeight = 275;//窗体高
        int formWidth = 310;//窗体宽
        int hideHeight = 2;//悬挂宽
        public Form_button0a2()
        {
            InitializeComponent();
        }
        private void Form_button0a2_Load(object sender, EventArgs e)
        {
            SelectedAllControl(this);//设置显示第一项
        }
        private void SelectedAllControl(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is ComboBox)
                    (c as ComboBox).SelectedIndex = 0;
                SelectedAllControl(c);
            }
        }//递归遍历控件，层层深入
        private void Form_button0a2_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.Y <= 0)
            {
                timer1.Enabled = true;
                this.TopMost = true;
            }
            else
            {
                timer1.Enabled = false;
                this.TopMost = false;
            }
        }//位置到顶部时启动定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Control.MousePosition.X <= this.Location.X + formWidth && System.Windows.Forms.Control.MousePosition.Y <= this.Location.Y + formHeight && System.Windows.Forms.Control.MousePosition.X >= this.Location.X && this.FormBorderStyle == FormBorderStyle.FixedDialog)
            { }   
            else if (System.Windows.Forms.Control.MousePosition.X <= this.Location.X + formWidth && System.Windows.Forms.Control.MousePosition.Y <= this.Location.Y + hideHeight && System.Windows.Forms.Control.MousePosition.X >= this.Location.X && this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.FixedDialog;//有标题栏
                this.Height = formHeight;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;//无标题栏
                this.Height = hideHeight;
            }
        }//悬挂定时器
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, 0.001, 10, 100, 1000, 1000000, 1000000000, 1000000000000,
                    1.0570 * Math.Pow(10, -16), 6.6846 * Math.Pow(10, -12),
                    39.3700787, 3.2808399, 1.0936133, 0.0006214, 0.00054,
                    0.5468066, 0.004971, 0.002, 0.3, 3, 30, 300, 3000, 30000 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//长度
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, Math.Pow(10, -6), 0.0001, 0.01, 100, 10000, 1000000,
                    0.0002471, 3.8610 * Math.Pow(10, -7), 1.19599, 10.7639104,
                    1550.0031, 0.0395369, 0.000015, 0.0015, 0.015, 9, 900 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//面积
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                
                double[] temp = { 1, 1000, 1000000, 1000000000, 1000, 10000, 1000000,
                    100000, 10, 1000000000, 35.3147248, 61023.8445022, 1.3079528,
                    0.0008107, 219.9691573, 264.1720524, 35198.873636, 34164.6737274 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//体积
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                
                double[] temp = { 1, 1000, 1000000, 1000000000, 0.001, 0.01, 5000, 500000,
                    2.2046226, 35.2739619, 15432.3583529, 0.0009842, 0.0011023,
                    0.0196841, 0.0220462, 0.157473, 564.3833912, 0.02, 2, 20, 200 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//质量
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, 33.8, 274.15, 493.47, 0.8 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//温度
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                
                double[] temp = { 1, Math.Pow(10, -6), 0.001, 0.01, 9.8692 * Math.Pow(10, -6),
                    0.0075006, 0.0002953, 0.00001, 0.01, 0.0208854, 0.000145,
                    0.101972, 0.0000102, 0.1019716 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//压力
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, 0.001, 0.001341, 0.0013596, 0.1019716, 0.000239, 0.0009478,
                    0.7375621, 1, 1 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//功率
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                
                double[] temp = { 1, 0.102, 3.7767 * Math.Pow(10, -7), 3.7251 * Math.Pow(10, -7),
                    2.7778 * Math.Pow(10, -7), 2.7778 * Math.Pow(10, -7), 0.2389, 0.0002389,
                    0.0009478, 0.7376, 0.001};//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//功/能/热
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, Math.Pow(10, -6), 0.001, 0.001, 1, 1000 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//密度
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, 0.001, 0.1019716, 101.971621, 0.000102,
                    0.2248089, 0.0002248, 100000 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//力
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, 3.1710 * Math.Pow(10, -8), 1.6534 * Math.Pow(10, -6),
                    0.0000116, 0.0002778, 0.0166667, 1000, 1000000, 1000000000 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//时间
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, 0.001, 3.6, 3.3356 * Math.Pow(10, -9),
                    0.0029386, 2.236936, 39.370079 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//速度
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                
                double[] temp = { 1, 8, 0.0009766, 9.5367 * Math.Pow(10, -7),
                    9.3132 * Math.Pow(10, -10), 9.0949 * Math.Pow(10, -13),
                    8.8818 * Math.Pow(10, -16), 8.6736 * Math.Pow(10, -19) };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//数据储存
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox com1 = new ComboBox();
                ComboBox com2 = new ComboBox();
                TextBox text = new TextBox();
                Label lab = new Label();
                bool flag = false;
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (flag)
                            com1 = c as ComboBox;
                        else
                            com2 = c as ComboBox; flag = true;
                    }
                    if (c is TextBox)
                        text = c as TextBox;
                    if (c is Label)
                        lab = c as Label;
                }
                double t = 0;
                if (text.Text != "")
                    t = Convert.ToDouble(text.Text);
                double te = 0;
                double[] temp = { 1, 0.0027778, 0.0111111, 1.111111, 60,
                    3600, 0.0174533, 17.453293 };//转换比例
                te = t * temp[com2.SelectedIndex] / temp[com1.SelectedIndex];
                lab.Text = Convert.ToString(t) + com1.Text + " = " + Convert.ToString(te) + com2.Text;
            }
            catch
            {
                MessageBox.Show("输入错误！");
            }
        }//角度
    }
}
