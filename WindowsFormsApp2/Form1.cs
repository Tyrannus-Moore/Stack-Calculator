using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string input = "";

        void Input(char c)
        {
            input += c;
        }

        void Flush()
        {
            tbScreen.Text = input;
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            Input('1');
            Flush();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            Input('2');
            Flush();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            Input('3');
            Flush();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            Input('4');
            Flush();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            Input('5');
            Flush();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            Input('6');
            Flush();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            Input('7');
            Flush();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            Input('8');
            Flush();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            Input('9');
            Flush();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            Input('0');
            Flush();
        }

        private void btdot_Click(object sender, EventArgs e)
        {
            Input('.');
            Flush();
        }

        private void bteq_Click(object sender, EventArgs e)
        {
            OPND.Clear();
            OPTR.Clear();//必须要把栈清空别忘了那两个#
            Process();
            Flush();
        }

        private void btdv_Click(object sender, EventArgs e)
        {
            Input('/');
            Flush();
        }

        private void btmu_Click(object sender, EventArgs e)
        {
            Input('*');
            Flush();
        }

        private void btsb_Click(object sender, EventArgs e)
        {
            Input('-');
            Flush();
        }

        private void btad_Click(object sender, EventArgs e)
        {
            Input('+');
            Flush();
        }


        public static Stack<string> OPTR = new Stack<string>();
        public static Stack<double> OPND = new Stack<double>();

        public static void AddHash(ref string Info)
        {
            Info = "#" + Info;
            Info += "#";
        }

        public static int Rank(char s)
        {
            switch (s)
            {
                case '#': return 0;
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: Console.WriteLine("输入错误！\n"); return -1; ;
            }
        }

        public static double Operate(double a, double b, char c)
        {
            switch (c)
            {
                case '+': return (b + a);
                case '-': return (b - a);
                case '*': return (b * a);
                case '/': return (b / a);
                default: return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="OPTR">操作符栈</param>
        /// <param name="OPND">操作数栈</param>
        /// <param name="num">扫描表达式的"指针"位置</param>
        /// <param name="t">接收运算符间的数字</param>
        /// <param name="r">接收运算符的优先级程度</param>
        /// <param name="o">接收经OPERATE运算后的结果</param>
        /// <param name="d">存储最终运算结果</param>
        /// <param name="mark">小数前后标记</param>
        /// <param name="deci">暂时接收的小数</param>
        /// <returns></returns>
        public static double Scan(string s, Stack<string> OPTR, Stack<double> OPND)
        {
            int num = 0, r = 0;
            double t = 0.0, d = 0.0, o = 0.0;

            while (s.Length != num)
            {
                //括号
                t = 0;//接收数字 && 清空t旧值
                if (s[num] >= '0' && s[num] <= '9')//1.如果是数字直接压栈 
                {
                    int mark = 1, power = -1;
                    double deci = 0.0;
                    while (s[num] >= '0' && s[num] <= '9' || s[num] == '.')
                    {
                        if (s[num] != '.' && mark == 1)
                        {
                            t *= 10;
                            t += s[num] - 48;//不-48得到的ASCII码 
                            num++;
                        }
                        else if (s[num] == '.')
                        {
                            mark = 0;
                            num++;
                        }
                        else if (mark == 0)
                        {
                            deci += (s[num] - 48) * System.Math.Pow(10, power);
                            power--;
                            num++;
                        }
                    }
                    t += deci;
                    OPND.Push(t);
                    num--;//多推进一位	
                }
                //以上，通过

                else//1.如果不是数字判断优先级 
                {
                    r = Rank(s[num]);
                    while (OPTR.Count() != 0)
                    {
                        if ((r > Rank(Convert.ToChar(OPTR.Peek())))) OPTR.Push(Convert.ToString(s[num]));//2.C1>C2
                        else if (0 == Rank(Convert.ToChar(OPTR.Peek())))
                        {//4.C1=C2 &&OVER
                            num++;//起到了两次POP OPTR的作用
                            d = OPND.Pop();
                        }

                        else if (r < Rank(Convert.ToChar(OPTR.Peek())) || (r == Rank(Convert.ToChar(OPTR.Peek()))))
                        {//3.C1<C2 ||C1=C2
                            while ((r < Rank(Convert.ToChar(OPTR.Peek())) || (r == Rank(Convert.ToChar(OPTR.Peek())))) && Rank(Convert.ToChar(OPTR.Peek())) != 0)
                            {
                                o = Operate(OPND.Pop(), OPND.Pop(), Convert.ToChar(OPTR.Pop()));
                                OPND.Push(o);
                            }
                            if ((s[num]) != '#') OPTR.Push(Convert.ToString(s[num])); //'人工判断'如果当前字符为#不准推入 
                            else OPTR.Push(Convert.ToString(s[num]));
                        }
                        break;
                    }

                    if (OPTR.Count() == 0) OPTR.Push(Convert.ToString(s[num]));//栈为空时直接推入 
                }

                if (num < s.Length - 1) num++;//文本推进 
            }

            return d;

        }


        static void Process()
        {
            string Info = input;
            double Result = 0;
            if (PreProcess() == 1)
            {
                AddHash(ref Info);
                Result = Scan(Info, OPTR, OPND);
                input = Convert.ToString(Result);
            }
            else input = "你在玩我呢？";
        }

        static private int PreProcess()
        {
            int mark=0;
            for (int i = 0; i < input.Length; i++)
            {
                if (mark == 0)
                {
                    if (input[i] == '+' || input[i] == '-' || input[i] == '/' || input[i] == '*')
                    {
                        mark = 1;
                    }
                    else if (input[i] >= '0' && input[i] <= '9'||input[i]=='.')
                    {
                        mark = 0;
                    }
                    else mark = -1;
                }
                else if (mark == 1)
                {
                    if (input[i] == '+' || input[i] == '-' || input[i] == '/' || input[i] == '*')
                    {
                        mark = -1;
                    }
                    else if ((input[i] >= '0' && input[i] <= '9') ||input[i]=='.')
                    {
                        mark = 0;
                    }
                    else mark = -1;
                }
                if (mark == -1) break;
            }
            if (mark != 0)
            {
                return 0;
            }
            else return 1;
        }

        private void btc_Click(object sender, EventArgs e)
        {
            if (input != "")
            {
                input = input.Substring(0, input.Length - 1);
                Flush();
            }
            else Flush();
        }


        private void sbsp_Click(object sender, EventArgs e)
        {
            tbScreen.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = "";
            Flush();
        }
    }
}
