using System;
using System.Collections;
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
    public partial class Form_button0a1 : Form
    {
        int formHeight = 300;//窗体高
        int formWidth = 350;//窗体宽
        int hideHeight = 2;//悬挂宽
        int richtextCount = 1;//记录计算结果
        public Form_button0a1()
        {
            InitializeComponent();
        }
        private void Form_button0a1_LocationChanged(object sender, EventArgs e)
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
                this.FormBorderStyle = FormBorderStyle.None;
                this.Height = hideHeight;
            }
        }//悬挂定时器
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    switch (textBox1.Text[i])
                    {
                        case '0': break;
                        case '1': break;
                        case '2': break;
                        case '3': break;
                        case '4': break;
                        case '5': break;
                        case '6': break;
                        case '7': break;
                        case '8': break;
                        case '9': break;
                        case '+': break;
                        case '-': break;
                        case '*': break;
                        case '/': break;
                        case '(': break;
                        case ')': break;
                        case '.': break;
                        default: MessageBox.Show("非法字符！"); break;
                    }
                }
            }//非法字符
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;//关闭回车声音
                Stack fuhao = new Stack();//辅助栈
                string[] newtext = new string[textBox1.Text.Length];//新表达式
                int st = 0;//计算新表达式的个数
                int left = 0, right;//left第一位数字，right=字符位
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (textBox1.Text[i] == '+' || textBox1.Text[i] == '-' || textBox1.Text[i] == '*' || textBox1.Text[i] == '/' || textBox1.Text[i] == '(' || textBox1.Text[i] == ')')
                    {
                        right = i;
                        char[] temp = new char[right - left];
                        int te = 0;
                        for (int j = left; j < right; j++)
                        {
                            temp[te++] = textBox1.Text[j];
                        }
                        string str = new string(temp);
                        if (str != "")
                        {
                            newtext[st++] = new string(temp);
                        }
                        newtext[st++] = Convert.ToString(textBox1.Text[right]);
                        left = right + 1;
                    }
                    else if (i == textBox1.Text.Length - 1)//最后一个字符是数字
                    {
                        right = textBox1.Text.Length;
                        char[] temp = new char[right - left];
                        int te = 0;
                        for (int j = left; j < right; j++)
                        {
                            temp[te++] = textBox1.Text[j];
                        }
                        newtext[st++] = new string(temp);
                    }
                }//将两位数字合成两位数
                string[] num = new string[st];//后序遍历后储存表达式的数组
                int count = 0;
                for (int i = 0; i < st; i++)
                {
                    if (newtext[i] == "+" || newtext[i] == "-" || newtext[i] == "*" || newtext[i] == "/" || newtext[i] == "(" || newtext[i] == ")")
                    {
                        string str = newtext[i];
                        if (fuhao.Count < 1)
                        {
                            fuhao.Push(str);
                            continue;
                        }
                        else if (newtext[i] == ")")
                        {

                            while (Convert.ToString(fuhao.Peek()) != "(")
                            {
                                str = Convert.ToString(fuhao.Peek());
                                fuhao.Pop();
                                while (fhyouxianji(str) < fhyouxianji(Convert.ToString(fuhao.Peek())))
                                {
                                    string temp = str;
                                    str = Convert.ToString(fuhao.Peek());
                                    fuhao.Push(temp);
                                    num[count++] = Convert.ToString(fuhao.Pop());
                                }
                                if (fhyouxianji(str) >= fhyouxianji(Convert.ToString(fuhao.Peek())))
                                {
                                    num[count++] = str;
                                }
                            }
                            fuhao.Pop();
                        }
                        else if (newtext[i] == "(")
                        {
                            fuhao.Push(str);
                        }
                        else
                        {
                            if (fhyouxianji(str) <= fhyouxianji(Convert.ToString(fuhao.Peek())))
                            {
                                num[count++] = Convert.ToString(fuhao.Pop());
                                fuhao.Push(str);
                            }
                            else
                            {
                                fuhao.Push(str);
                            }

                        }

                    }
                    else
                    {
                        num[count++] = newtext[i];
                    }
                    if (i == st - 1 && fuhao.Count > 0)
                    {
                        int Count = fuhao.Count;
                        for (int a = 0; a < Count; a++)
                        {
                            num[count++] = Convert.ToString(fuhao.Pop());
                        }
                    }
                }//对表达式进行后序遍历
                double[] numtemp = new double[num.Length];//用于计算的辅助数组
                int ncount = 0;
                for (int i = 0; i < count; i++)
                {
                    if (num[i] != "+" && num[i] != "-" && num[i] != "*" && num[i] != "/")
                    {
                        numtemp[ncount++] = Convert.ToDouble(num[i]);
                    }
                    else
                    {
                        ncount = ncount - 1;
                        double t2 = numtemp[ncount];
                        ncount = ncount - 1;
                        double t1 = numtemp[ncount];
                        double sum = 0;
                        switch (num[i])
                        {
                            case "+": sum = t1 + t2; break;
                            case "-": sum = t1 - t2; break;
                            case "*": sum = t1 * t2; break;
                            case "/": sum = t1 / t2; break;
                            default:
                                break;
                        }
                        numtemp[ncount++] = sum;
                    }
                }//计算函数，遇到字符弹出两个数计算后再放进辅助数组
                string text = "第" + richtextCount + "条：" + textBox1.Text + " = " + Convert.ToString(numtemp[0]) + "\n";
                richtextCount++;
                richTextBox1.Text = richTextBox1.Text.Insert(0, text);//记录表达式和结果
                textBox1.Text = Convert.ToString(numtemp[0]);//输出结果
                textBox1.SelectionStart = textBox1.Text.Length;//光标在后面
            }//回车执行计算
        }//按回车计算表达式
        private int fhyouxianji(string str)
        {
            int y = 0;
            switch (str)
            {
                case "+": y = 1; break;
                case "-": y = 1; break;
                case "*": y = 2; break;
                case "/": y = 2; break;
                case "(": y = 0; break;
                case ")": y = 0; break;
                default:
                    break;
            }
            return y;
        }//返回优先级，（）为0，+-为1， */为3
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            richtextCount = 1;
        }//清除
    }
}
