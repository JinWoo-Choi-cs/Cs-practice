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
        volatile int a;
        static Thread thread1;
        static void Main(string[] args)
        {
            int count = 0;
            TestT tt1 = new TestT();
            thread1 = new Thread(tt1.State_test);

            Thread thread2 = new Thread(tt1.State_test);
            while (true)
            {
                Console.WriteLine(thread1.ThreadState.ToString());
                Thread.Sleep(100);
                if (count == 10)
                    thread1.Start();
                count++;

                thread1.Interrupt();

                if (thread1.ThreadState == ThreadState.Stopped)
                {
                    Console.WriteLine("끝");
                    break;
                }
            }
        }
        
    }

    class TestT
    {
        public static int count = 0;

        

        public void State_test()
        {
            int count = 0;
            while (true)
            {
                try
                {
                    Thread.Sleep(1);
                    //count++;
                    //if (count == 50)
                    //    Thread.CurrentThread.Abort();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n"+e.ToString()+"\n");

                    Thread.ResetAbort();
                    
                }
            }
        }


    }


}
