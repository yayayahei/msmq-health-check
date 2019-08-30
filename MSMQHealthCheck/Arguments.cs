using System;

namespace MSMQHealthCheck
{
    public class Arguments
    {
        public Arguments(string[] args)
        {
            string currentArg = null;
            for (int index = 0; index < args.Length; index++)
            {
                currentArg = args[index];
                if ("--pathName".Equals(currentArg))
                {
                    pathName = args[++index];
                }

                Console.WriteLine($"{currentArg}:{pathName}");
            }
        }

        public string pathName { get; set; }
    }
}