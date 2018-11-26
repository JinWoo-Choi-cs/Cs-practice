using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace thread_test
{
    class Program
    {
        static Thread thread1;
        static void Main(string[] args)
        {
            
            TestT tt1 = new TestT();
            thread1 = new Thread(tt1.state_test);

            thread1.Start();
        }

        

    }

    class TestT
    {
        public static int count = 0;

        

        public void state_test()
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.CurrentUICulture.Name.ToString());
                Thread.Sleep(2000);

            }
        }
    }


}
