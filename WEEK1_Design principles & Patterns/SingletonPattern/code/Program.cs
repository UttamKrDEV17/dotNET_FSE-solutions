// File: Program.cs
using System;

namespace SingletonPatternExample
{
    public class Logger
    {
        private static Logger instance = null;
        private static readonly object padlock = new object();

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }

        // Example logging method
        public void Log(string message)
        {
            Console.WriteLine($"Log entry: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            logger1.Log("First log message.");
            logger2.Log("Second log message.");

            if (object.ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("Both logger1 and logger2 refer to the same instance.");
            }
            else
            {
                Console.WriteLine("Different instances exist!");
            }
        }
    }
}
