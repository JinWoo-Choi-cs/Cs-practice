using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudy
{
    class Program
    {
        delegate void DelegateChains();

        static void Print1()
        {
            Console.WriteLine("Welcome");
        }
        static void Print2()
        {
            Console.WriteLine("To");
        }
        static void Print3()
        {
            Console.WriteLine("C#");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==체인 연결==");
            DelegateChains chaincall = new DelegateChains(Print1);
            chaincall += Print2;
            chaincall += Print3;
            chaincall();

            Console.WriteLine("== 체인 끊기 ==");
            chaincall -= Print1;
            chaincall -= Print3;
            chaincall +=
                delegate ()
                {
                    Console.WriteLine("Anonymous Method call");
                };
            chaincall();

        }
    }
}

