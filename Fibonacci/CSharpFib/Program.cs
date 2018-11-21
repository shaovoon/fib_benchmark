using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpFib
{
    class timer
    {
        private string _text = null;
        private Stopwatch _stopWatch = null;

        public timer()
        {
            
        }
        public void start(string text)
        {
            _text = text;
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }
        public void stop()
        {
            _stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = _stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}.{1:000}", ts.Seconds, ts.Milliseconds);
            Console.WriteLine(_text + " timing:" + elapsedTime);
        }
    }
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            timer stopwatch = new timer();

            stopwatch.start("recursive_fib");
            Console.WriteLine("recursive_fib(42) result:{0}",  recursive_fib(42));
            stopwatch.stop();

            stopwatch.start("tail_recursion_fib");
            Console.WriteLine("tail_recursion_fib(42) result:{0}", tail_recursion_fib(42));
            stopwatch.stop();
            
            stopwatch.start("iterative_fib");
            Console.WriteLine("iterative_fib(42) result:{0}", iterative_fib(42));
            stopwatch.stop();

            recursive_fib_with_count(8);
            Console.WriteLine("recursive_fib(8) total number of recursive calls:{0}", count);
        }

        static int recursive_fib(int n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                return recursive_fib(n - 2) + recursive_fib(n - 1);
            }
        }

        static int recursive_fib_with_count(int n)
        {
            ++count;
            if (n < 2)
            {
                return n;
            }
            else
            {
                return recursive_fib_with_count(n - 2) + recursive_fib_with_count(n - 1);
            }
        }

        static int iterative_fib(int n)
        {
            if (n < 2)
                return n;

            int second_fib = 0, first_fib = 1, current_fib = 0;
            for (int i = 2; i <= n; i++)
            {
                current_fib = second_fib + first_fib;
                second_fib = first_fib;
                first_fib = current_fib;
            }
            return current_fib;
        }
        
        static int tail_recursion_fib(int n, int a = 0, int b = 1)
        {
            if (n == 0)
                return a;
            if (n == 1)
                return b;
            return tail_recursion_fib(n - 1, b, a + b);
        }

    }
}
