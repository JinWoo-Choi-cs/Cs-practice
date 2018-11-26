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
        static void Main(string[] args)
        {
            TestT tt = new TestT();
            Thread thread = new Thread(new ThreadStart(tt.run));

            thread.Start();
            while (true)
            {
                Console.Write("입력 : ");
                TestT.count = int.Parse( Console.ReadLine());

                if (thread.ThreadState == ThreadState.Aborted && TestT.count == 5)
                    thread.Resume();
            }
        }



    }

    class TestT
    {
        public static int count = 0;
        public void run()
        {

            while (true)
            {
                Console.WriteLine($"run의 카운트 = {count}");
                Thread.Sleep(1000);


                if (count == 3)
                    Thread.CurrentThread.();
            }
        }
    }


}
