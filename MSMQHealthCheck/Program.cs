using System;

namespace MSMQHealthCheck
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arguments = new Arguments(args);
            var queueManager = new QueueManager(arguments.PathName);
            if (queueManager.Exist())
            {
                Console.WriteLine($"{arguments.PathName} exists");
            }
        }
    }
}