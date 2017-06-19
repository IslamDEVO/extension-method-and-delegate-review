using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Csharp_Sheet_6
{
    #region Model app

    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }
    //}

    #endregion
    
    // Exam

    #region Hello World Timer app
    
    //// First Method
    ///*class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        while (true)
    //        {
    //            System.Threading.Thread.Sleep(1000);
    //            Console.WriteLine("hello world");
    //        }
    //    }
    //}*/

    //// Second Method
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Timer tick = new Timer();
    //        tick.Interval = 1000;
    //        tick.Elapsed += (O, e) => { Console.WriteLine("Hello Worled"); };
    //        tick.Enabled = true;
    //        Console.Read();
    //    }
    //}

    #endregion

    #region Max & Min Extention app

    //static class Extention
    //{
    //    public static void Max<T>(this List<T> list1)
    //    {
    //        list1.Sort();
    //        Console.WriteLine(list1[list1.Count - 1]);
    //    }

    //    public static void Min<T>(this List<T> list1)
    //    {
    //        list1.Sort();
    //        Console.WriteLine(list1[0]);
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        /*List<int> list = new List<int>();
    //        list.Add(5);
    //        list.Add(1);
    //        list.Add(7);
    //        list.Add(0);*/

    //        List<string> list = new List<string>();
    //        list.Add("A");
    //        list.Add("D");
    //        list.Add("B");
    //        list.Add("C");

    //        list.Max();
    //        list.Min();
            
    //    }
    //}

    #endregion

    // End Exam

    #region Alarm Clock app

    //class Program
    //{
    //    public event EventHandler<EventArgs> alarm;

    //    public void Clock_Alarm(object sender, EventArgs e)
    //    {
    //        Console.SetCursorPosition(25, 5);
    //        Console.WriteLine("the time now is : {0:T}", DateTime.Now);
    //    }

    //    public void Fire()
    //    {
    //        if (alarm != null)
    //            alarm(this, EventArgs.Empty);
    //    }

    //    static void Main(string[] args)
    //    {
    //        Program p = new Program();

    //        //  using EventHendler<EventArgs>
    //        //p.alarm += new EventHandler<EventArgs>(p.Clock_Alarm);

    //        //  using Lambda Expression
    //        p.alarm += (o, e) =>
    //        {
    //            Console.SetCursorPosition(25, 5);
    //            Console.WriteLine("the time now is : {0:T}", DateTime.Now);
    //        };
    //        Timer tick = new Timer();
    //        tick.Interval = 1000;
    //        tick.Enabled = true;
    //        tick.Elapsed += (o, e) => p.Fire();
    //        //p.Fire();
    //        Console.ReadLine();
    //    }
    //}

    #endregion

    //  the last ex in sheet 6
    #region UNAUTHORIZED ACCESS app

    public class CountDownClockEventArgs : EventArgs
    {
        public string message;
        public CountDownClockEventArgs(string message)
        {
            this.message = message;
        }
    }

    public class CountDownClock
    {
        private int seconds;
        private string message;
        public CountDownClock(string message, int seconds)
        {
            this.message = message;
            this.seconds = seconds;
        }
        public delegate void TimesUpEventHandler(object countDownClock,
            CountDownClockEventArgs alarmInFormation);

        public event TimesUpEventHandler TimeExpired;
        public void Run()
        {
            System.Threading.Thread.Sleep(3 * 1000);
            if (TimeExpired != null)
            {
                CountDownClockEventArgs e = new CountDownClockEventArgs(this.message);
                TimeExpired(this, e);
            }
        }

    }

    public class CountDownTimerDisplay
    {
        CountDownClock.TimesUpEventHandler myHandler;
        public CountDownTimerDisplay (CountDownClock cdc)
        {
            myHandler = new CountDownClock.TimesUpEventHandler(HeardIt);
            cdc.TimeExpired += myHandler;
            myHandler = new CountDownClock.TimesUpEventHandler(HeardIt1);
            cdc.TimeExpired += myHandler;
        }
        void HeardIt(object sender, CountDownClockEventArgs e)
        {
            Console.WriteLine("1-you requested to receive this message : {0}", e.message);
        }
        void HeardIt1(object sender, CountDownClockEventArgs e)
        {
            Console.WriteLine("1-you requested to receive this message : {0}", e.message);
        }
    }

    public class CountDownTimerDisplay1
    {
        public CountDownTimerDisplay1(CountDownClock cdc)
        {
            cdc.TimeExpired += delegate(object s, CountDownClockEventArgs e)
            {
                Console.WriteLine("2-you requested to recive this message : {0}", e.message);
            };
        }
    }

    public class CountDownTimerDisplay2
    {

        public CountDownTimerDisplay2(CountDownClock cdc)
        {
            cdc.TimeExpired += (sender, e) =>
            {
                Console.WriteLine("3-you requested to recive this message : {0}", e.message);
            };
        }

    }

    public class Tester
    {
        static void Main()
        {
            Console.WriteLine("enter your message");
            string message = Console.ReadLine();
            Console.WriteLine("how many second to wait");
            int seconds = Convert.ToInt32(Console.ReadLine());
            CountDownClock cdc = new CountDownClock(message, seconds);
            CountDownTimerDisplay display = new CountDownTimerDisplay(cdc);
            CountDownTimerDisplay1 display1 = new CountDownTimerDisplay1(cdc);
            CountDownTimerDisplay2 display2 = new CountDownTimerDisplay2(cdc);
            cdc.Run();
            Console.ReadLine();
        }
    }

    #endregion

    // end the last ex in sheet 6

    // the two Ex in ch 4 XP

    // end the two Ex in ch 4 XP

}
