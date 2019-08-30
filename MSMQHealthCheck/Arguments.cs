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
                    PathName = args[++index];
                }

                Console.WriteLine($"{currentArg}:{PathName}");
            }
        }

        public string PathName { get; set; }
    }
}