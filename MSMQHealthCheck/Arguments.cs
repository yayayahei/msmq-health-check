using System;
using System.Text;

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
                if (_pathNameOptionName.Equals(currentArg))
                {
                    PathName = args[++index];
                }

                if (_logLevelOptionName.Equals(currentArg))
                {
                    LogLevel logLevel;
                    if (Enum.TryParse(args[++index], true, out logLevel))
                    {
                        LogLevel = logLevel;
                    }
                }
            }

            if (LogLevel.Debug.Equals(LogLevel))
            {
                Console.WriteLine(ToString());
            }
        }

        private string _pathNameOptionName = "--pathName";
        private string _logLevelOptionName = "--logLevel";
        public string PathName { get; set; }
        public LogLevel LogLevel { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Args:");
            stringBuilder.AppendLine($"{_pathNameOptionName}: {PathName}");
            stringBuilder.AppendLine($"{_logLevelOptionName}: {LogLevel}");
            return stringBuilder.ToString();
        }
    }
}