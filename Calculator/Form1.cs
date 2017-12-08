using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.IO;
using System.Threading;
namespace Calculator
{
    public partial class Form1 : Form
    {
        string TextNobes = "计算器";//记录上一次选中
        double g = 6.67408 * Math.Pow(10, -11);//引力常数
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (TabPage c in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(c);
            }
        }//程序加载时隐藏所有计算器
        private void button0a1_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new Form_button0a1())).Start();
        }//小计算器
        private void button0a2_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new Form_button0a2())).Start();
        }//单位转换
        private void button0a3_Click(object sender, EventArgs e)
        {
            new Thread(() => Application.Run(new Form_button0a3())).Start();
        }//绘图
        private void treeView1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.IsExpanded)
            {
                treeView1.SelectedNode.Collapse();
            }
            else
            {
                treeView1.SelectedNode.Expand();
            }
        }//展开折叠节点
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TextNobes != treeView1.SelectedNode.Name)
            {
                tabControl1.Visible = true;
                RemoveTabPage(TextNobes);
                TextNobes = treeView1.SelectedNode.Text;
                AddTabPage(treeView1.SelectedNode.Text);
                
            }
        }//显示选中
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (TextNobes == treeView1.SelectedNode.Text && tabControl1.Visible)
            {
                tabControl1.Visible = false;
            }
            else
            {
                tabControl1.Visible = true;
            }
        }//第二次点击隐藏
        private void RemoveTabPage(string TextNobes)
        {
            foreach (TabPage c in tabControl1.TabPages)
            {
                if (c.Name == TextNobes)
                {
                    tabControl1.TabPages.Remove(c);
                }
            }
        }//隐藏函数
        private void Clear_Click(object sender, EventArgs e)
        {
            foreach (Control c in tabControl1.SelectedTab.Controls[0].Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).Text = "";
                }
            }
            textBox2a30a2.Text = Convert.ToString(299792.458);//爱因斯坦质能方程的光速
        }//清除函数
        private void AddTabPage(string TextNobes)
        {
            switch (TextNobes)
            {
                case "位移速度时间": tabControl1.TabPages.Add(位移速度时间); break;
                case "牛顿第二定律": tabControl1.TabPages.Add(牛顿第二定律); break;
                case "物理做功": tabControl1.TabPages.Add(物理做功); break;
                case "动能定理做功": tabControl1.TabPages.Add(动能定理做功); break;
                case "功除时间": tabControl1.TabPages.Add(功除时间); break;
                case "物体做功": tabControl1.TabPages.Add(物体做功); break;
                case "瞬时功率": tabControl1.TabPages.Add(瞬时功率); break;
                case "动能定理": tabControl1.TabPages.Add(动能定理); break;
                case "重力势能": tabControl1.TabPages.Add(重力势能); break;
                case "向心加速度": tabControl1.TabPages.Add(向心加速度); break;
                case "向心力": tabControl1.TabPages.Add(向心力); break;
                case "圆周运行线速度": tabControl1.TabPages.Add(圆周运行线速度); break;
                case "加速度": tabControl1.TabPages.Add(加速度); break;
                case "平均速度": tabControl1.TabPages.Add(平均速度); break;
                case "动摩擦力": tabControl1.TabPages.Add(动摩擦力); break;
                case "静摩擦力": tabControl1.TabPages.Add(静摩擦力); break;
                case "牛顿万有引力定律": tabControl1.TabPages.Add(牛顿万有引力定律); break;
                case "开普勒第三定律": tabControl1.TabPages.Add(开普勒第三定律); break;
                case "行星重力加速度": tabControl1.TabPages.Add(行星重力加速度); break;
                case "逃逸速度": tabControl1.TabPages.Add(逃逸速度); break;
                case "胡克定律": tabControl1.TabPages.Add(胡克定律); break;
                case "弹性势能": tabControl1.TabPages.Add(弹性势能); break;
                case "冲量定理1": tabControl1.TabPages.Add(冲量定理1); break;
                case "冲量定理2": tabControl1.TabPages.Add(冲量定理2); break;
                case "动量定理1": tabControl1.TabPages.Add(动量定理1); break;
                case "动量定理2": tabControl1.TabPages.Add(动量定理2); break;
                case "力矩": tabControl1.TabPages.Add(力矩); break;
                case "单摆": tabControl1.TabPages.Add(单摆); break;
                case "复摆": tabControl1.TabPages.Add(复摆); break;
                case "扭矩": tabControl1.TabPages.Add(扭矩); break;
                case "密度": tabControl1.TabPages.Add(密度); break;
                case "爱因斯坦质能方程": tabControl1.TabPages.Add(爱因斯坦质能方程); break;
                case "压强": tabControl1.TabPages.Add(压强); break;
                case "杨氏模量": tabControl1.TabPages.Add(杨氏模量); break;
                case "竖直上抛速度": tabControl1.TabPages.Add(竖直上抛速度); break;
                case "竖直上抛运动位移": tabControl1.TabPages.Add(竖直上抛运动位移); break;
                case "平抛运动水平位移": tabControl1.TabPages.Add(平抛运动水平位移); break;
                case "斜抛运动水平位移": tabControl1.TabPages.Add(斜抛运动水平位移); break;
                case "声压级": tabControl1.TabPages.Add(声压级); break;
                case "声强级": tabControl1.TabPages.Add(声强级); break;
                default: break;
            }
        }//显示函数
        private void button2a1_Click(object sender, EventArgs e)
        {
            try
            {
                double v = 0, t = 0, s = 0;
                int count = 3;
                if (textBox2a1a1.Text != "")
                {
                    v = Convert.ToDouble(textBox2a1a1.Text);
                    count--;
                }
                if (textBox2a1a2.Text != "")
                {
                    t = Convert.ToDouble(textBox2a1a2.Text);
                    count--;
                }
                if (textBox2a1a3.Text != "")
                {
                    s = Convert.ToDouble(textBox2a1a3.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a1a1.Text == "")
                    {
                        double temp = s / t;
                        textBox2a1a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a1a2.Text == "")
                    {
                        double temp = s / v;
                        textBox2a1a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a1a3.Text == "")
                    {
                        double temp = v * t;
                        textBox2a1a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//位移速度距离计算
        private void button2a2_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, a = 0, F = 0;
                int count = 3;
                if (textBox2a2a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a2a1.Text);
                    count--;
                }
                if (textBox2a2a2.Text != "")
                {
                    a = Convert.ToDouble(textBox2a2a2.Text);
                    count--;
                }
                if (textBox2a2a3.Text != "")
                {
                    F = Convert.ToDouble(textBox2a2a3.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a2a1.Text == "")
                    {
                        double temp = F / a;
                        textBox2a2a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a2a2.Text == "")
                    {
                        double temp = F / m;
                        textBox2a2a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a2a3.Text == "")
                    {
                        double temp = m * a;
                        textBox2a2a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//牛顿第二定律计算
        private void button2a3_Click(object sender, EventArgs e)
        {
            try
            {
                double F = 0, S = 0, W = 0;
                int count = 3;
                if (textBox2a3a1.Text != "")
                {
                    F = Convert.ToDouble(textBox2a3a1.Text);
                    count--;
                }
                if (textBox2a3a2.Text != "")
                {
                    S = Convert.ToDouble(textBox2a3a2.Text);
                    count--;
                }
                if (textBox2a3a3.Text != "")
                {
                    W = Convert.ToDouble(textBox2a3a3.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a3a1.Text == "")
                    {
                        double temp = W / S;
                        textBox2a3a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a3a2.Text == "")
                    {
                        double temp = W / F;
                        textBox2a3a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a3a3.Text == "")
                    {
                        double temp = F * S;
                        textBox2a3a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//物理做功计算
        private void button2a4_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, vi = 0, vf = 0, WT = 0;
                int count = 4;
                if (textBox2a4a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a4a1.Text);
                    count--;
                }
                if (textBox2a4a2.Text != "")
                {
                    vi = Convert.ToDouble(textBox2a4a2.Text);
                    count--;
                }
                if (textBox2a4a3.Text != "")
                {
                    vf = Convert.ToDouble(textBox2a4a3.Text);
                    count--;
                }
                if (textBox2a4a4.Text != "")
                {
                    WT = Convert.ToDouble(textBox2a4a4.Text);
                    count--;
                }
                if (m < 0 || vi < 0 || vf < 0 || WT < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a4a1.Text == "")
                    {
                        double a = vi * vi - vf * vf;
                        double temp = Math.Abs( 2 * WT / a);
                        textBox2a4a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a4a2.Text == "")
                    {
                        double a = WT * 2 / m;
                        double b = vf * vf;
                        double temp = Math.Sqrt(Math.Abs(a - b));
                        textBox2a4a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a4a3.Text == "")
                    {
                        double a = WT * 2 / m;
                        double b = vf * vf;
                        double temp = Math.Pow(Math.Abs(a - b), 0.5);
                        textBox2a4a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a4a4.Text == "")
                    {
                        double temp = Math.Abs(m * ((vi * vi) - (vf * vf)) * 0.5);
                        textBox2a4a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//动能定理做功
        private void button2a5a1_Click(object sender, EventArgs e)
        {
            try
            {
                double W = 0, T = 0, P = 0;
                int count = 3;
                if (textBox2a5a11.Text != "")
                {
                    W = Convert.ToDouble(textBox2a5a11.Text);
                    count--;
                }
                if (textBox2a5a12.Text != "")
                {
                    T = Convert.ToDouble(textBox2a5a12.Text);
                    count--;
                }
                if (textBox2a5a13.Text != "")
                {
                    P = Convert.ToDouble(textBox2a5a13.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a5a11.Text == "")
                    {
                        double temp = P * T; 
                        textBox2a5a11.Text = temp.ToString("G8");
                    }
                    if (textBox2a5a12.Text == "")
                    {
                        double temp = W / P;
                        textBox2a5a12.Text = temp.ToString("G8");
                    }
                    if (textBox2a5a13.Text == "")
                    {
                        double temp = W / T;
                        textBox2a5a13.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//功除时间
        private void button2a5a2_Click(object sender, EventArgs e)
        {
            try
            {
                double F = 0, D = 0, T = 0, P = 0;
                int count = 4;
                if (textBox2a5a21.Text != "")
                {
                    F = Convert.ToDouble(textBox2a5a21.Text);
                    count--;
                }
                if (textBox2a5a22.Text != "")
                {
                    D = Convert.ToDouble(textBox2a5a22.Text);
                    count--;
                }
                if (textBox2a5a23.Text != "")
                {
                    T = Convert.ToDouble(textBox2a5a23.Text);
                    count--;
                }
                if (textBox2a5a24.Text != "")
                {
                    P = Convert.ToDouble(textBox2a5a24.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a5a21.Text == "")
                    {
                        double temp = P * T / D;
                        textBox2a5a21.Text = temp.ToString("G8");
                    }
                    if (textBox2a5a22.Text == "")
                    {
                        double temp = P * T / F;
                        textBox2a5a22.Text = temp.ToString("G8");
                    }
                    if (textBox2a5a23.Text == "")
                    {
                        double temp = F * D / P;
                        textBox2a5a23.Text = temp.ToString("G8");
                    }
                    if (textBox2a5a24.Text == "")
                    {
                        double temp = F * D / T;
                        textBox2a5a24.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//物体做功
        private void button2a5a3_Click(object sender, EventArgs e)
        {
            try
            {
                double F = 0, V = 0, P = 0;
                int count = 3;
                if (textBox2a5a31.Text != "")
                {
                    F = Convert.ToDouble(textBox2a5a31.Text);
                    count--;
                }
                if (textBox2a5a32.Text != "")
                {
                    V = Convert.ToDouble(textBox2a5a32.Text);
                    count--;
                }
                if (textBox2a5a33.Text != "")
                {
                    P = Convert.ToDouble(textBox2a5a33.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a5a31.Text == "")
                    {
                        double temp = P / V;
                        textBox2a5a31.Text = temp.ToString("G8");
                    }
                    if (textBox2a5a32.Text == "")
                    {
                        double temp = P / F;
                        textBox2a5a32.Text = temp.ToString("G8");
                    }
                    if (textBox2a5a33.Text == "")
                    {
                        double temp = F * V;
                        textBox2a5a33.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//瞬时功率
        private void button2a6_Click(object sender, EventArgs e)
        {
            try
            {
                double M = 0, V = 0, E = 0;
                int count = 3;
                if (textBox2a6a1.Text != "")
                {
                    M = Convert.ToDouble(textBox2a6a1.Text);
                    count--;
                }
                if (textBox2a6a2.Text != "")
                {
                    V = Convert.ToDouble(textBox2a6a2.Text);
                    count--;
                }
                if (textBox2a6a3.Text != "")
                {
                    E = Convert.ToDouble(textBox2a6a3.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a6a1.Text == "")
                    {
                        double temp = 2 * E / ( V * V);
                        textBox2a6a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a6a2.Text == "")
                    {
                        double temp = Math.Pow(2 * E / M, 0.5);
                        textBox2a6a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a6a3.Text == "")
                    {
                        double temp = 0.5 * M * (V * V);
                        textBox2a6a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//动能定理
        private void button2a7_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, g = 0, h = 0, Ep = 0;
                int count = 4;
                if (textBox2a7a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a7a1.Text);
                    count--;
                }
                if (textBox2a7a2.Text != "")
                {
                    g = Convert.ToDouble(textBox2a7a2.Text);
                    count--;
                }
                if (textBox2a7a3.Text != "")
                {
                    h = Convert.ToDouble(textBox2a7a3.Text);
                    count--;
                }
                if (textBox2a7a4.Text != "")
                {
                    Ep = Convert.ToDouble(textBox2a7a4.Text);
                    count--;
                }
                if (m < 0 || g < 0 || h < 0 || Ep < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a7a1.Text == "")
                    {
                        double temp = Ep / g / h;
                        textBox2a7a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a7a2.Text == "")
                    {
                        double temp = Ep / m / h;
                        textBox2a7a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a7a3.Text == "")
                    {
                        double temp = Ep / m / g;
                        textBox2a7a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a7a4.Text == "")
                    {
                        double temp = m * g * h;
                        textBox2a7a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//重力势能
        private void button2a8_Click(object sender, EventArgs e)
        {
            try
            {
                double r = 0, v = 0, a = 0;
                int count = 3;
                if (textBox2a8a1.Text != "")
                {
                    r = Convert.ToDouble(textBox2a8a1.Text);
                    count--;
                }
                if (textBox2a8a2.Text != "")
                {
                    v = Convert.ToDouble(textBox2a8a2.Text);
                    count--;
                }
                if (textBox2a8a3.Text != "")
                {
                    a = Convert.ToDouble(textBox2a8a3.Text);
                    count--;
                }
                if (r < 0 || v < 0 || a < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a8a1.Text == "")
                    {
                        double temp = v * v / a;
                        textBox2a8a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a8a2.Text == "")
                    {
                        double temp = Math.Sqrt(a * r);
                        textBox2a8a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a8a3.Text == "")
                    {
                        double temp = v * v / r;
                        textBox2a8a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//向心加速度
        private void button2a9_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, r = 0, v = 0, f = 0;
                int count = 4;
                if (textBox2a9a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a9a1.Text);
                    count--;
                }
                if (textBox2a9a2.Text != "")
                {
                    r = Convert.ToDouble(textBox2a9a2.Text);
                    count--;
                }
                if (textBox2a9a3.Text != "")
                {
                    v = Convert.ToDouble(textBox2a9a3.Text);
                    count--;
                }
                if (textBox2a9a4.Text != "")
                {
                    f = Convert.ToDouble(textBox2a9a4.Text);
                    count--;
                }
                if (m < 0 || r < 0 || v < 0 || f < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a9a1.Text == "")
                    {
                        double temp = f * r / (v * v);
                        textBox2a9a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a9a2.Text == "")
                    {
                        double temp = f / m / (v * v);
                        textBox2a9a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a9a3.Text == "")
                    {
                        double temp = Math.Sqrt(f * r / m);
                        textBox2a9a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a9a4.Text == "")
                    {
                        double temp = m * v * v / r;
                        textBox2a9a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//向心力
        private void button2a10_Click(object sender, EventArgs e)
        {
            try
            {
                double r = 0, T = 0, v = 0;
                int count = 3;
                if (textBox2a10a1.Text != "")
                {
                    r = Convert.ToDouble(textBox2a10a1.Text);
                    count--;
                }
                if (textBox2a10a2.Text != "")
                {
                    T = Convert.ToDouble(textBox2a10a2.Text);
                    count--;
                }
                if (textBox2a10a3.Text != "")
                {
                    v = Convert.ToDouble(textBox2a10a3.Text);
                    count--;
                }
                if (r < 0 || T < 0 || v < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a10a1.Text == "")
                    {
                        double temp = v * T * 0.5 / Math.PI;
                        textBox2a10a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a10a2.Text == "")
                    {
                        double temp = 2 * Math.PI * r / v;
                        textBox2a10a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a10a3.Text == "")
                    {
                        double temp = 2 * Math.PI * r / T;
                        textBox2a10a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//圆周运行线速度
        private void button2a11_Click(object sender, EventArgs e)
        {
            try
            {
                double v0 = 0, v = 0, t = 0, a = 0;
                int count = 4;
                if (textBox2a11a1.Text != "")
                {
                    v0 = Convert.ToDouble(textBox2a11a1.Text);
                    count--;
                }
                if (textBox2a11a2.Text != "")
                {
                    v = Convert.ToDouble(textBox2a11a2.Text);
                    count--;
                }
                if (textBox2a11a3.Text != "")
                {
                    t = Convert.ToDouble(textBox2a11a3.Text);
                    count--;
                }
                if (textBox2a11a4.Text != "")
                {
                    a = Convert.ToDouble(textBox2a11a4.Text);
                    count--;
                }
                if (v0 < 0 || v < 0 || t < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a11a1.Text == "")
                    {
                        double temp = v - a * t;
                        textBox2a11a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a11a2.Text == "")
                    {
                        double temp = a * t + v0;
                        textBox2a11a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a11a3.Text == "")
                    {
                        double temp = (v - v0) / a;
                        textBox2a11a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a11a4.Text == "")
                    {
                        if (t == 0)
                        {
                            MessageBox.Show("时间T，输入必须大于0");
                            return;
                        }
                        double temp = (v - v0) / t;
                        textBox2a11a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//加速度
        private void button2a12_Click(object sender, EventArgs e)
        {
            try
            {
                double v0 = 0, v = 0, va = 0;
                int count = 3;
                if (textBox2a12a1.Text != "")
                {
                    v0 = Convert.ToDouble(textBox2a12a1.Text);
                    count--;
                }
                if (textBox2a12a2.Text != "")
                {
                    v = Convert.ToDouble(textBox2a12a2.Text);
                    count--;
                }
                if (textBox2a12a3.Text != "")
                {
                    va = Convert.ToDouble(textBox2a12a3.Text);
                    count--;
                }
                if (v0 < 0 || v < 0 || va < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a12a1.Text == "")
                    {
                        double temp = 2 * va - v;
                        textBox2a12a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a12a2.Text == "")
                    {
                        double temp = 2 * va - v0;
                        textBox2a12a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a12a3.Text == "")
                    {
                        double temp = (v + v0) * 0.5;
                        textBox2a12a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//平均速度
        private void button2a13_Click(object sender, EventArgs e)
        {
            try
            {
                double uk = 0, N = 0, Fk = 0;
                int count = 3;
                if (textBox2a13a1.Text != "")
                {
                    uk = Convert.ToDouble(textBox2a13a1.Text);
                    count--;
                }
                if (textBox2a13a2.Text != "")
                {
                    N = Convert.ToDouble(textBox2a13a2.Text);
                    count--;
                }
                if (textBox2a13a3.Text != "")
                {
                    Fk = Convert.ToDouble(textBox2a13a3.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a13a1.Text == "")
                    {
                        if (N == 0)
                        {
                            MessageBox.Show("正常力，不能为0");
                            return;
                        }
                        double temp = Fk / N;
                        textBox2a13a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a13a2.Text == "")
                    {
                        if (uk == 0)
                        {
                            MessageBox.Show("动摩擦因数，不能为0");
                            return;
                        }
                        double temp = Fk / uk;
                        textBox2a13a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a13a3.Text == "")
                    {
                        double temp = uk * N;
                        textBox2a13a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//动摩擦力
        private void button2a14_Click(object sender, EventArgs e)
        {
            try
            {
                double uk = 0, N = 0, Fk = 0;
                int count = 3;
                if (textBox2a14a1.Text != "")
                {
                    uk = Convert.ToDouble(textBox2a14a1.Text);
                    count--;
                }
                if (textBox2a14a2.Text != "")
                {
                    N = Convert.ToDouble(textBox2a14a2.Text);
                    count--;
                }
                if (textBox2a14a3.Text != "")
                {
                    Fk = Convert.ToDouble(textBox2a14a3.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a14a1.Text == "")
                    {
                        if (N == 0)
                        {
                            MessageBox.Show("正常力，不能为0");
                            return;
                        }
                        double temp = Fk / N;
                        textBox2a14a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a14a2.Text == "")
                    {
                        if (uk == 0)
                        {
                            MessageBox.Show("动摩擦因数，不能为0");
                            return;
                        }
                        double temp = Fk / uk;
                        textBox2a14a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a14a3.Text == "")
                    {
                        double temp = uk * N;
                        textBox2a14a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//静摩擦力
        private void button2a15_Click(object sender, EventArgs e)
        {
            try
            {
                double m1 = 0, m2 = 0, r = 0, f = 0;
                int count = 4;
                
                if (textBox2a15a1.Text != "")
                {
                    m1 = Convert.ToDouble(textBox2a15a1.Text);
                    count--;
                }
                if (textBox2a15a2.Text != "")
                {
                    m2 = Convert.ToDouble(textBox2a15a2.Text);
                    count--;
                }
                if (textBox2a15a3.Text != "")
                {
                    r = Convert.ToDouble(textBox2a15a3.Text);
                    count--;
                }
                if (textBox2a15a4.Text != "")
                {
                    f = Convert.ToDouble(textBox2a15a4.Text);
                    count--;
                }
                if (m1 < 0 || m2 < 0 || r < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a15a1.Text == "")
                    {
                        double temp = f * r * r / m2 / g;
                        textBox2a15a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a15a2.Text == "")
                    {
                        double temp = f * r * r / m1 / g;
                        textBox2a15a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a15a3.Text == "")
                    {
                        double temp = Math.Sqrt(f / m1 / m2 / g);
                        textBox2a15a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a15a4.Text == "")
                    {
                        double temp = g * m1 * m2 / (r * r);
                        textBox2a15a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//牛顿万有引力定律
        private void button2a16_Click(object sender, EventArgs e)
        {
            try
            {
                double r = 0, m = 0, t = 0;
                int count = 3;
                
                if (textBox2a16a1.Text != "")
                {
                    r = Convert.ToDouble(textBox2a16a1.Text);
                    count--;
                }
                if (textBox2a16a2.Text != "")
                {
                    m = Convert.ToDouble(textBox2a16a2.Text);
                    count--;
                }
                if (textBox2a16a3.Text != "")
                {
                    t = Convert.ToDouble(textBox2a16a3.Text);
                    count--;
                }
                if (r < 0 || m < 0 || t < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a16a1.Text == "")
                    {
                        double temp = Math.Pow(t * t * g * m / (4 * Math.PI * Math.PI), 3);
                        textBox2a16a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a16a2.Text == "")
                    {
                        double temp = t * t * g / (4 * Math.PI * Math.PI * r * r * r);
                        textBox2a16a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a16a3.Text == "")
                    {
                        double temp = Math.Sqrt(4 * Math.PI * Math.PI * r * r * r / g / m);
                        textBox2a16a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//开普勒第三定律
        private void button2a17_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    double m = 0, r = 0, a = 0;
                    int count = 3;
                    
                    if (textBox2a17a1.Text != "")
                    {
                        m = Convert.ToDouble(textBox2a17a1.Text);
                        count--;
                    }
                    if (textBox2a17a2.Text != "")
                    {
                        r = Convert.ToDouble(textBox2a17a2.Text);
                        count--;
                    }
                    if (textBox2a17a3.Text != "")
                    {
                        a = Convert.ToDouble(textBox2a17a3.Text);
                        count--;
                    }
                    if (m < 0 || r < 0 || a < 0)
                    {
                        MessageBox.Show("输入必须为正数");
                        return;
                    }
                    if (count != 1)
                    {
                        MessageBox.Show("输入错误");
                    }
                    else
                    {
                        if (textBox2a17a1.Text == "")
                        {
                            double temp = a * r * r / g;
                            textBox2a17a1.Text = temp.ToString("G8");
                        }
                        if (textBox2a17a2.Text == "")
                        {
                            double temp = Math.Sqrt(g * m / a);
                            textBox2a17a2.Text = temp.ToString("G8");
                        }
                        if (textBox2a17a3.Text == "")
                        {
                            double temp = g * m / r / r;
                            textBox2a17a3.Text = temp.ToString("G8");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("代码错误");
                }
            }
        }//行星重力加速度
        private void button2a18_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, r = 0, v = 0;
                int count = 3;
                
                if (textBox2a18a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a18a1.Text);
                    count--;
                }
                if (textBox2a18a2.Text != "")
                {
                    r = Convert.ToDouble(textBox2a18a2.Text);
                    count--;
                }
                if (textBox2a18a3.Text != "")
                {
                    v = Convert.ToDouble(textBox2a18a3.Text);
                    count--;
                }
                if (m < 0 || r < 0 || v < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a18a1.Text == "")
                    {
                        double temp = v * v * r / (2 * g);
                        textBox2a18a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a18a2.Text == "")
                    {
                        double temp = 2 * g * m / v / v;
                        textBox2a18a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a18a3.Text == "")
                    {
                        double temp = Math.Sqrt(2 * g * m / r);
                        textBox2a18a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//逃逸速度
        private void button2a19_Click(object sender, EventArgs e)
        {
            try
            {
                double k = 0, x0 = 0, x = 0, f = 0;
                int count = 4;
                
                if (textBox2a19a1.Text != "")
                {
                    k = Convert.ToDouble(textBox2a19a1.Text);
                    count--;
                }
                if (textBox2a19a2.Text != "")
                {
                    x0 = Convert.ToDouble(textBox2a19a2.Text);
                    count--;
                }
                if (textBox2a19a3.Text != "")
                {
                    x = Convert.ToDouble(textBox2a19a3.Text);
                    count--;
                }
                if (textBox2a19a4.Text != "")
                {
                    f = Convert.ToDouble(textBox2a19a4.Text);
                    count--;
                }
                if (k < 0 || x0 < 0 || x < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a19a1.Text == "")
                    {
                        double temp = Math.Abs(f / (x - x0));
                        textBox2a15a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a19a2.Text == "")
                    {
                        double temp = x - f / k;
                        textBox2a19a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a19a3.Text == "")
                    {
                        double temp = f / k + x0;
                        textBox2a19a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a19a4.Text == "")
                    {
                        double temp = k * (x - x0);
                        textBox2a19a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//胡克定律
        private void button2a20_Click(object sender, EventArgs e)
        {
            try
            {
                double k = 0, x = 0, u = 0;
                int count = 3;
                
                if (textBox2a20a1.Text != "")
                {
                    k = Convert.ToDouble(textBox2a20a1.Text);
                    count--;
                }
                if (textBox2a20a2.Text != "")
                {
                    x = Convert.ToDouble(textBox2a20a2.Text);
                    count--;
                }
                if (textBox2a20a3.Text != "")
                {
                    u = Convert.ToDouble(textBox2a20a3.Text);
                    count--;
                }
                if (k < 0 || x < 0 || u < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a20a1.Text == "")
                    {
                        double temp = 2 * u / x / x;
                        textBox2a20a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a20a2.Text == "")
                    {
                        double temp = Math.Sqrt(2 * u / k);
                        textBox2a20a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a20a3.Text == "")
                    {
                        double temp = 0.5 * k * x * x;
                        textBox2a20a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//弹性势能
        private void button2a21_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, v = 0, I = 0;
                int count = 3;
                
                if (textBox2a21a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a21a1.Text);
                    count--;
                }
                if (textBox2a21a2.Text != "")
                {
                    v = Convert.ToDouble(textBox2a21a2.Text);
                    count--;
                }
                if (textBox2a21a3.Text != "")
                {
                    I = Convert.ToDouble(textBox2a21a3.Text);
                    count--;
                }
                if (m < 0 || v < 0 || I < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a21a1.Text == "")
                    {
                        double temp = I / v;
                        textBox2a21a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a21a2.Text == "")
                    {
                        double temp = I / m;
                        textBox2a21a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a21a3.Text == "")
                    {
                        double temp = m * v;
                        textBox2a21a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//冲量定理1
        private void button2a22_Click(object sender, EventArgs e)
        {
            try
            {
                double f = 0, t = 0, I = 0;
                int count = 3;
                
                if (textBox2a22a1.Text != "")
                {
                    f = Convert.ToDouble(textBox2a22a1.Text);
                    count--;
                }
                if (textBox2a22a2.Text != "")
                {
                    t = Convert.ToDouble(textBox2a22a2.Text);
                    count--;
                }
                if (textBox2a22a3.Text != "")
                {
                    I = Convert.ToDouble(textBox2a22a3.Text);
                    count--;
                }
                if (f < 0 || t < 0 || I < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a22a1.Text == "")
                    {
                        double temp = I / t;
                        textBox2a22a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a22a2.Text == "")
                    {
                        double temp = I / f;
                        textBox2a22a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a22a3.Text == "")
                    {
                        double temp = f * t;
                        textBox2a22a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//冲量定理2
        private void button2a23_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, v = 0, I = 0;
                int count = 3;
                
                if (textBox2a23a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a23a1.Text);
                    count--;
                }
                if (textBox2a23a2.Text != "")
                {
                    v = Convert.ToDouble(textBox2a23a2.Text);
                    count--;
                }
                if (textBox2a23a3.Text != "")
                {
                    I = Convert.ToDouble(textBox2a23a3.Text);
                    count--;
                }
                if (m < 0 || v < 0 || I < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a23a1.Text == "")
                    {
                        double temp = I / v;
                        textBox2a23a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a23a2.Text == "")
                    {
                        double temp = I / m;
                        textBox2a23a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a23a3.Text == "")
                    {
                        double temp = m * v;
                        textBox2a23a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//动量定理1
        private void button2a24_Click(object sender, EventArgs e)
        {
            try
            {
                double f = 0, t = 0, I = 0;
                int count = 3;
                
                if (textBox2a24a1.Text != "")
                {
                    f = Convert.ToDouble(textBox2a24a1.Text);
                    count--;
                }
                if (textBox2a24a2.Text != "")
                {
                    t = Convert.ToDouble(textBox2a24a2.Text);
                    count--;
                }
                if (textBox2a24a3.Text != "")
                {
                    I = Convert.ToDouble(textBox2a24a3.Text);
                    count--;
                }
                if (f < 0 || t < 0 || I < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a24a1.Text == "")
                    {
                        double temp = I / t;
                        textBox2a24a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a24a2.Text == "")
                    {
                        double temp = I / f;
                        textBox2a24a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a24a3.Text == "")
                    {
                        double temp = f * t;
                        textBox2a24a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//动量定理2
        private void button2a25_Click(object sender, EventArgs e)
        {
            try
            {
                double f = 0, t = 0, I = 0;
                int count = 3;
                
                if (textBox2a25a1.Text != "")
                {
                    f = Convert.ToDouble(textBox2a25a1.Text);
                    count--;
                }
                if (textBox2a25a2.Text != "")
                {
                    t = Convert.ToDouble(textBox2a25a2.Text);
                    count--;
                }
                if (textBox2a25a3.Text != "")
                {
                    I = Convert.ToDouble(textBox2a25a3.Text);
                    count--;
                }
                if (f < 0 || t < 0 || I < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a25a1.Text == "")
                    {
                        double temp = I / t;
                        textBox2a25a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a25a2.Text == "")
                    {
                        double temp = I / f;
                        textBox2a25a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a25a3.Text == "")
                    {
                        double temp = f * t;
                        textBox2a25a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//力矩
        private void button2a26_Click(object sender, EventArgs e)
        {
            try
            {
                double l = 0, g = 0, t = 0;
                int count = 3;
                if (textBox2a26a1.Text != "")
                {
                    l = Convert.ToDouble(textBox2a26a1.Text);
                    count--;
                }
                if (textBox2a26a2.Text != "")
                {
                    g = Convert.ToDouble(textBox2a26a2.Text);
                    count--;
                }
                if (textBox2a26a3.Text != "")
                {
                    t = Convert.ToDouble(textBox2a26a3.Text);
                    count--;
                }
                if (l < 0 || g < 0 || t < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a26a1.Text == "")
                    {
                        double temp = g * t * t / (4 * Math.PI * Math.PI);
                        textBox2a26a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a26a2.Text == "")
                    {
                        double temp = 4 * Math.PI * Math.PI * l / t / t;
                        textBox2a26a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a26a3.Text == "")
                    {
                        double temp = 2 * Math.PI * Math.Sqrt(l / g);
                        textBox2a26a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//单摆
        private void button2a27_Click(object sender, EventArgs e)
        {
            try
            {
                double i = 0, m = 0, g = 0, d = 0, t = 0;
                int count = 5;
                if (textBox2a27a1.Text != "")
                {
                   i  = Convert.ToDouble(textBox2a27a1.Text);
                    count--;
                }
                if (textBox2a27a2.Text != "")
                {
                    m = Convert.ToDouble(textBox2a27a2.Text);
                    count--;
                }
                if (textBox2a27a3.Text != "")
                {
                    g = Convert.ToDouble(textBox2a27a3.Text);
                    count--;
                }
                if (textBox2a27a4.Text != "")
                {
                    d = Convert.ToDouble(textBox2a27a4.Text);
                    count--;
                }
                if (textBox2a27a5.Text != "")
                {
                    t = Convert.ToDouble(textBox2a27a5.Text);
                    count--;
                }
                if (i < 0 || m < 0 || g < 0 || d < 0 || t < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a27a1.Text == "")
                    {
                        double temp = m * d * g * t * t / (4 * Math.PI * Math.PI);
                        textBox2a27a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a27a2.Text == "")
                    {
                        double temp = 4 * Math.PI * Math.PI * i / (d * g * t * t);
                        textBox2a27a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a27a3.Text == "")
                    {
                        double temp = 4 * Math.PI * Math.PI * i / (m * d * t * t);
                        textBox2a27a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a27a4.Text == "")
                    {
                        double temp = 4 * Math.PI * Math.PI * i / (m * g * t * t);
                        textBox2a27a4.Text = temp.ToString("G8");
                    }
                    if (textBox2a27a5.Text == "")
                    {
                        double temp = 2 * Math.PI * Math.Sqrt(i / (m * g * d));
                        textBox2a27a5.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//复摆
        private void button2a28_Click(object sender, EventArgs e)
        {
            try
            {
                double f = 0, t = 0, I = 0;
                int count = 3;
                
                if (textBox2a28a1.Text != "")
                {
                    f = Convert.ToDouble(textBox2a28a1.Text);
                    count--;
                }
                if (textBox2a28a2.Text != "")
                {
                    t = Convert.ToDouble(textBox2a28a2.Text);
                    count--;
                }
                if (textBox2a28a3.Text != "")
                {
                    I = Convert.ToDouble(textBox2a28a3.Text);
                    count--;
                }
                if (f < 0 || t < 0 || I < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a28a1.Text == "")
                    {
                        double temp = I / t;
                        textBox2a28a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a28a2.Text == "")
                    {
                        double temp = I / f;
                        textBox2a28a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a28a3.Text == "")
                    {
                        double temp = f * t;
                        textBox2a28a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//扭矩
        private void button2a29_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, v = 0, d = 0;
                int count = 3;
                
                if (textBox2a29a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a29a1.Text);
                    count--;
                }
                if (textBox2a29a2.Text != "")
                {
                    v = Convert.ToDouble(textBox2a29a2.Text);
                    count--;
                }
                if (textBox2a29a3.Text != "")
                {
                    d = Convert.ToDouble(textBox2a29a3.Text);
                    count--;
                }
                if (m < 0 || v < 0 || d < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a29a1.Text == "")
                    {
                        double temp = v * d;
                        textBox2a29a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a29a2.Text == "")
                    {
                        double temp = m / d;
                        textBox2a29a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a29a3.Text == "")
                    {
                        double temp = m / v;
                        textBox2a29a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//密度
        private void button2a30_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, c = 299792.458, E = 0;
                int count = 3;
                if (textBox2a30a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a30a1.Text);
                    count--;
                }
                if (textBox2a30a2.Text != "")
                {
                    c = Convert.ToDouble(textBox2a30a2.Text);
                    count--;
                }
                if (textBox2a30a3.Text != "")
                {
                    E = Convert.ToDouble(textBox2a30a3.Text);
                    count--;
                }
                if (m < 0 || c < 0 || E < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a30a1.Text == "")
                    {
                        double temp = E / c / c;
                        textBox2a30a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a30a2.Text == "")
                    {
                        double temp = Math.Sqrt(E / m);
                        textBox2a30a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a30a3.Text == "")
                    {
                        double temp = m * c * c;
                        textBox2a30a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//爱因斯坦质能方程
        private void button2a31_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, v = 0, d = 0;
                int count = 3;
                if (textBox2a31a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a31a1.Text);
                    count--;
                }
                if (textBox2a31a2.Text != "")
                {
                    v = Convert.ToDouble(textBox2a31a2.Text);
                    count--;
                }
                if (textBox2a31a3.Text != "")
                {
                    d = Convert.ToDouble(textBox2a31a3.Text);
                    count--;
                }
                if (m < 0 || v < 0 || d < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a31a1.Text == "")
                    {
                        double temp = v * d;
                        textBox2a31a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a31a2.Text == "")
                    {
                        double temp = m / d;
                        textBox2a31a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a31a3.Text == "")
                    {
                        double temp = m / v;
                        textBox2a31a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//压强
        private void button2a32_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, v = 0, d = 0;
                int count = 3;
                if (textBox2a32a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a32a1.Text);
                    count--;
                }
                if (textBox2a32a2.Text != "")
                {
                    v = Convert.ToDouble(textBox2a32a2.Text);
                    count--;
                }
                if (textBox2a32a3.Text != "")
                {
                    d = Convert.ToDouble(textBox2a32a3.Text);
                    count--;
                }
                if (m < 0 || v < 0 || d < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a32a1.Text == "")
                    {
                        double temp = v * d;
                        textBox2a32a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a32a2.Text == "")
                    {
                        double temp = m / d;
                        textBox2a32a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a32a3.Text == "")
                    {
                        double temp = m / v;
                        textBox2a32a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//杨氏模量
        private void button2a33_Click(object sender, EventArgs e)
        {
            try
            {
                double m = 0, g = 0, h = 0, Ep = 0;
                int count = 4;
                if (textBox2a33a1.Text != "")
                {
                    m = Convert.ToDouble(textBox2a33a1.Text);
                    count--;
                }
                if (textBox2a33a2.Text != "")
                {
                    g = Convert.ToDouble(textBox2a33a2.Text);
                    count--;
                }
                if (textBox2a33a3.Text != "")
                {
                    h = Convert.ToDouble(textBox2a33a3.Text);
                    count--;
                }
                if (textBox2a33a4.Text != "")
                {
                    Ep = Convert.ToDouble(textBox2a33a4.Text);
                    count--;
                }
                if (m < 0 || g < 0 || h < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a33a1.Text == "")
                    {
                        double temp = Ep + g * h;
                        textBox2a33a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a33a2.Text == "")
                    {
                        double temp = (m - Ep) / h;
                        textBox2a33a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a33a3.Text == "")
                    {
                        double temp = (m - Ep) / g;
                        textBox2a33a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a33a4.Text == "")
                    {
                        double temp = m - g * h;
                        textBox2a33a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//竖直上抛速度
        private void button2a34_Click(object sender, EventArgs e)
        {
            try
            {
                double v = 0, g = 0, t = 0, h = 0;
                int count = 4;
                if (textBox2a34a1.Text != "")
                {
                    v = Convert.ToDouble(textBox2a34a1.Text);
                    count--;
                }
                if (textBox2a34a2.Text != "")
                {
                    g = Convert.ToDouble(textBox2a34a2.Text);
                    count--;
                }
                if (textBox2a34a3.Text != "")
                {
                    t = Convert.ToDouble(textBox2a34a3.Text);
                    count--;
                }
                if (textBox2a34a4.Text != "")
                {
                    h = Convert.ToDouble(textBox2a34a4.Text);
                    count--;
                }
                if (v < 0 || g < 0 || t < 0 || h < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a34a1.Text == "")
                    {
                        double temp = (h + 0.5 * g * t * t) / t;
                        textBox2a34a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a34a2.Text == "")
                    {
                        double temp = 2 * (v * t - h) / (t * t);
                        textBox2a34a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a34a3.Text == "")
                    {
                        double temp = Math.Abs(-v + Math.Sqrt(v * v - 2 * g * h)) / 2;
                        textBox2a34a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a34a4.Text == "")
                    {
                        double temp = v * t - 0.5 * g * t * t;
                        textBox2a34a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//竖直上抛运动位移
        private void button2a35_Click(object sender, EventArgs e)
        {
            try
            {
                double v = 0, t = 0, s = 0;
                int count = 3;
                if (textBox2a35a1.Text != "")
                {
                    v = Convert.ToDouble(textBox2a35a1.Text);
                    count--;
                }
                if (textBox2a35a2.Text != "")
                {
                    t = Convert.ToDouble(textBox2a35a2.Text);
                    count--;
                }
                if (textBox2a35a3.Text != "")
                {
                    s = Convert.ToDouble(textBox2a35a3.Text);
                    count--;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a35a1.Text == "")
                    {
                        double temp = s / t;
                        textBox2a35a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a35a2.Text == "")
                    {
                        double temp = s / v;
                        textBox2a35a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a35a3.Text == "")
                    {
                        double temp = v * t;
                        textBox2a35a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//平抛运动水平位移
        private void button2a36_Click(object sender, EventArgs e)
        {
            try
            {
                double v = 0, g = 0, t = 0, h = 0;
                int count = 4;
                if (textBox2a36a1.Text != "")
                {
                    v = Convert.ToDouble(textBox2a36a1.Text);
                    count--;
                }
                if (textBox2a36a2.Text != "")
                {
                    g = Convert.ToDouble(textBox2a36a2.Text);
                    count--;
                }
                if (textBox2a36a3.Text != "")
                {
                    t = Convert.ToDouble(textBox2a36a3.Text);
                    t = t / 180 * Math.PI;
                    count--;
                }
                if (textBox2a36a4.Text != "")
                {
                    h = Convert.ToDouble(textBox2a36a4.Text);
                    count--;
                }
                if (v < 0 || g < 0 || t < 0 || h < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a36a1.Text == "")
                    {
                        double temp = Math.Sqrt(h * g / Math.Sin(2 * t));
                        textBox2a36a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a36a2.Text == "")
                    {
                        double temp = v * v * Math.Sin(2 * t) / h;
                        textBox2a36a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a36a3.Text == "")
                    {
                        double temp = Math.Asin(g * h / v / v) / Math.PI * 180 / 2;
                        textBox2a36a3.Text = temp.ToString("G8");
                    }
                    if (textBox2a36a4.Text == "")
                    {
                        double temp = v * v * Math.Sin(2 * t) / g;
                        textBox2a36a4.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//斜抛运动水平位移
        private void button2a37_Click(object sender, EventArgs e)
        {
            try
            {
                double p1 = 0, p2 = 0, s = 0;
                int count = 3;
                if (textBox2a37a1.Text != "")
                {
                    p1 = Convert.ToDouble(textBox2a37a1.Text);
                    count--;
                }
                if (textBox2a37a2.Text != "")
                {
                    p2 = Convert.ToDouble(textBox2a37a2.Text);
                    count--;
                }
                if (textBox2a37a3.Text != "")
                {
                    s = Convert.ToDouble(textBox2a37a3.Text);
                    count--;
                }
                if (p1 < 0 || p2 < 0 || s < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a37a1.Text == "")
                    {
                        double temp = p2 * Math.Pow(10, s / 20);
                        textBox2a37a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a37a2.Text == "")
                    {
                        double temp = p1 / Math.Pow(10, s / 20);
                        textBox2a37a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a37a3.Text == "")
                    {
                        double temp = 20 * Math.Log10(p1 / p2);
                        textBox2a37a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//声压级
        private void button2a38_Click(object sender, EventArgs e)
        {
            try
            {
                double p1 = 0, p2 = 0, s = 0;
                int count = 3;
                if (textBox2a38a1.Text != "")
                {
                    p1 = Convert.ToDouble(textBox2a38a1.Text);
                    count--;
                }
                if (textBox2a38a2.Text != "")
                {
                    p2 = Convert.ToDouble(textBox2a38a2.Text);
                    count--;
                }
                if (textBox2a38a3.Text != "")
                {
                    s = Convert.ToDouble(textBox2a38a3.Text);
                    count--;
                }
                if (p1 < 0 || p2 < 0 || s < 0)
                {
                    MessageBox.Show("输入必须为正数");
                    return;
                }
                if (count != 1)
                {
                    MessageBox.Show("输入错误");
                }
                else
                {
                    if (textBox2a38a1.Text == "")
                    {
                        double temp = p2 * Math.Pow(10, s / 10);
                        textBox2a38a1.Text = temp.ToString("G8");
                    }
                    if (textBox2a38a2.Text == "")
                    {
                        double temp = p1 / Math.Pow(10, s / 10);
                        textBox2a38a2.Text = temp.ToString("G8");
                    }
                    if (textBox2a38a3.Text == "")
                    {
                        double temp = 10 * Math.Log10(p1 / p2);
                        textBox2a38a3.Text = temp.ToString("G8");
                    }
                }
            }
            catch
            {
                MessageBox.Show("代码错误");
            }
        }//声强级
    }
}
