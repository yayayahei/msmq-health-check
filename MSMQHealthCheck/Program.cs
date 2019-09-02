using System;

namespace MSMQHealthCheck
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arguments = new Arguments(args);
            var queueManager = new QueueManager(arguments.PathName, arguments.FormatName);
            if (!string.IsNullOrWhiteSpace(arguments.PathName))
            {
                if (queueManager.Exist())
                {
                    Console.WriteLine($"{arguments.PathName} exists");
                }
            }

            if (!string.IsNullOrWhiteSpace(arguments.FormatName))
            {
                Console.WriteLine($"{arguments.FormatName} CanWrite? {queueManager.CanWrite()}");
                Console.WriteLine($"{arguments.FormatName} CanRead? {queueManager.CanRead()}");
            }

            if (arguments.SendHello)
            {
                queueManager.SendHello();
            }

            if (arguments.GetMessage)
            {
                var message = queueManager.GetMessage();
                Console.WriteLine($"Get message result: {message?.Body}");
            }
        }
    }
}