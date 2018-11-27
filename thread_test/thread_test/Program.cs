using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace thread_test
{
    class MyClass
    {
        private static int counter = 10;

        // lock문에 사용될 객체(
        private static object lockObject = new object();

        public static void Main()
        {
            // 10개의 쓰레드가 동일 메서드 실행
            for (int i = 0; i < 10; i++)
            {
                new Thread(SafeCalc).Start();
            }
        }

        // Thread-Safe하지 않은 메서드 
        private static void SafeCalc()
        {
            Console.WriteLine($"들어감 : {counter}");
            // 한번에 한 쓰레드만 lock블럭 실행

            Monitor.Enter(lockObject);

            try
            {

                // 필드값 변경


                // 가정 : 다른 복잡한 일을 한다
                for (int i = 0; i < 10 - counter; i++)
                    for (int j = 0; j < 10 - counter; j++)
                        Thread.Sleep(1);
                lock (lockObject)
                {
                    
                }
            }
            finally
            {
                Console.WriteLine($"끝남 : {counter}");
                Monitor.Exit(lockObject);
                counter = counter - 10;
            }
        }
    }





#if false //==================================

    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => testfunc(1));
            t1.Start();
        }

        static void testfunc(int a)
        {
            Console.WriteLine($"{a}");
        }
    }

#endif //====================


#if false //==================================

    class Program
    {
        static Thread thread1;
        static void Main(string[] args)
        {
            int count = 0;
            TestT tt1 = new TestT();
            Thread t2;
            while (true)
            {
                if (thread1 == null || thread1.ThreadState == ThreadState.Stopped)
                {
                    thread1 = new Thread(() => tt1.State_test(count));
                    thread1.Start();
                    Console.WriteLine("{0} . 시작", count);
                }

                count++;

                //while (thread1.ThreadState != ThreadState.WaitSleepJoin) ;
                Thread.Sleep(1000);
                Console.WriteLine("1상태 : {0}", thread1.ThreadState);

                thread1.Interrupt();

                Console.WriteLine("2상태 : {0}", thread1.ThreadState);
                Console.WriteLine("{0} . 끝", count);
                break;

            }
        }
    }

    class TestT
    {
        public static int count = 0;

        public void State_test(int c)
        {
            Thread.CurrentThread.Suspend();
            return;
        }
    }

#endif //====================


#if false //==================================

    class Program
    {
        static Thread thread1;
        static void Main(string[] args)
        {
            int count = 0;
            TestT tt1 = new TestT();
            Thread t2;
            while (true)
            {
                if (thread1 == null || thread1.ThreadState == ThreadState.Stopped)
                {
                    thread1 = new Thread(() => tt1.State_test(count));
                    thread1.Start();
                    Console.WriteLine("{0} . 시작", count);
                }

                count++;

                while (thread1.ThreadState != ThreadState.WaitSleepJoin) Console.WriteLine("1");
                    thread1.Interrupt();

                Console.WriteLine("{0} . 끝", count);
                break;
                
            }
        }
    }

    class TestT
    {
        public static int count = 0;

        public void State_test(int c)
        {
            int count = 0;
            while (true)
            {

                    if (count == 100000000)
                        Thread.Sleep(10);
                    count++;
            }
        }
    }

#endif //====================




#if false

    class Program
    {
        static Thread thread1;
        static void Main(string[] args)
        {
            int count = 0;
            TestT tt1 = new TestT();
            Thread t2;
            while (true)
            {
                if (thread1 == null || thread1.ThreadState == ThreadState.Stopped)
                {

                    thread1 = new Thread(() => tt1.State_test(count));
                    thread1.Start();
                    Console.WriteLine("{0} . 시작", count);
                }

                
                Console.WriteLine("{0} . 끝", count);
                count++;

                thread1.Interrupt();
                Console.WriteLine("abort하고 살아있는가 ?  {0}", thread1.IsAlive);
                Console.WriteLine("abort하고 상태는어떰 ?  {0}", thread1.ThreadState.ToString());
                thread1.Start();
            }
        }
    }

    class TestT
    {
        public static int count = 0;

        public void State_test(int c)
        {
            int count = 0;
            while (true)
            {
                try
                {
                    if (count == 3)
                    {
                        break;
                    }
                    Console.WriteLine("{0}번째 쓰레드  카운트= {1}", c, count);
                    count++;
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException)
                {
                    Console.WriteLine("인터럽트");
                }
            }
        }
    }

#endif

#if false
    class Program
    {
        volatile int a;
        static Thread thread1;
        static void Main(string[] args)
        {
            int count = 0;
            TestT tt1 = new TestT();

            while (true)
            {
                if (thread1 == null || thread1.ThreadState == ThreadState.Stopped)
                {
                    thread1 = new Thread(() => tt1.State_test(count));
                    Console.WriteLine("생성후 살아있는가 ?  {0}", thread1.IsAlive);
                    thread1.Start();
                    Console.WriteLine("시작후 살아있는가 ?  {0}", thread1.IsAlive);
                    Console.WriteLine("{0} . 시작", count);
                }


                thread1.Join();
                Console.WriteLine("{0} . 끝", count);
                count++;

                Console.WriteLine("끝에서 살아있는가 ?  {0}", thread1.IsAlive);
            }
        }

    }

    class TestT
    {
        public static int count = 0;

        public void State_test(int c)
        {
            int count = 0;
            while (true)
            {
                if (count == 5)
                {
                    break;   
                }
                Console.WriteLine("{0}번째 쓰레드  카운트= {1}", c, count);
                count++;
                Thread.Sleep(1000);
            }
        }
    }







#endif




#if false
    class Program
        {
            volatile int a;
            static Thread thread1;
            static void Main(string[] args)
            {
                int count = 0;
                TestT tt1 = new TestT();
                thread1 = new Thread(tt1.State_test);

                thread1.Start();

                while (true)
                {
                    Console.WriteLine(thread1.ThreadState.ToString());
                    Thread.Sleep(100);

                    if (count == 50)
                    {
                        thread1.Suspend();
                        Console.WriteLine("suspend");
                    }

                    if (count == 100)
                    {
                        thread1.Resume();
                        Console.WriteLine("resume");
                        count = 0;
                    }
                    count++;

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
                        if (count == 99999999)
                        {
                            Console.WriteLine("ee");
                            Thread.Sleep(10);
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n"+e.ToString()+"\n");
                    }
                }
            }


        }


#endif


}