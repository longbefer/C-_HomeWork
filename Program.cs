using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate calculator = new Calculate();
            calculator.Show();
            Console.ReadLine();
            
        }
    }

    class Calculate
    {
        readonly char[] _opera = { '+', '-', '*', '/' };
        readonly char[] _strOpera = { '+', '-' };
        private int _number1, _number2;
        private string _string1, _string2;
        private char _operator;
        private bool isStr = false;
        public string Str1 { set { _string1 = value; } get { return _string1; } }
        public string Str2 { set { _string2 = value; } get { return _string2; } }
        public int Num1 { set { _number1 = value; } get { return _number1; } }
        public int Num2 { set { _number2 = value; } get { return _number2; } }
        public char Operator
        {
            set
            {
                bool isOpera = false;
                if (isStr)
                {
                    foreach (char Opera in _strOpera)
                        if (Opera == value)
                        {
                            isOpera = true;
                            break;
                        }
                }
                else
                {
                    foreach (char Opera in _opera)
                        if (Opera == value)
                        {
                            isOpera = true;
                            break;
                        }
                }
                if (isOpera)
                    _operator = value;
                else throw new Exception("ISNOTOPERATOR");//抛出不是操作符
            }
            get { return _operator; }
        }
        private int Calculator()
        {
            switch (Operator)
            {
                case '+': return Num1 + Num2;
                case '-': return Num1 - Num2;
                case '*': return Num1 * Num2;
                case '/': return Num1 / Num2;
                default: return int.MaxValue;
            }
        }

        private bool Equals(int Number)
        {
            if (Calculator() == Number)
                return true;
            else return false;
        }

        public bool Show()
        {
            Console.Write("计算器\n请输入一个整数/字符：");
            string getStr="\0";
            //bool isStr = false;
            try
            {
                getStr = Console.ReadLine();
                Num1 = int.Parse(getStr);
                isStr = false;
            }
            catch
            {
                try//非整数
                {
                    Str1 = getStr;
                    isStr = true;
                }
                catch
                {
                    Console.WriteLine("未知错误！");
                    return false;
                }
                //Console.WriteLine("输入的字符有误，请输入整数！");
                //Console.ReadLine();
            }
            Console.Write("请输入操作符：");
            try
            {
                Operator = char.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入非法");
                //Console.ReadLine();
                return false;
            }
            Console.Write("请输入{0}：", (isStr ? "字符" : "整数"));
            try
            {
                if (isStr)
                    Str2 = Console.ReadLine();
                else
                    Num2 = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("请输入整数！");
                //Console.ReadLine();
                return false;
            }
            if (isStr)
                Console.WriteLine("结果是：{0}", Connect());
            else
                Console.WriteLine("结果是：{0}", Calculator());
            
            return true;
        }

        private string Connect()
        {
            string temp = Str1;
            switch(Operator)
            {
                case '+': return Str1 + Str2;
                case '-': return temp.Replace(Str2, "");
            }
            return temp;
        }

    }

}
