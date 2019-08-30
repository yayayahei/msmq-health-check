using System;
using System.Text;

namespace MSMQHealthCheck
{
    public class Arguments
    {
        private readonly string[] _args;

        public Arguments(string[] args)
        {
            _args = args;
            Init();
        }

        private void Init()
        {
            string currentArg = null;
            for (int index = 0; index < _args.Length; index++)
            {
                currentArg = _args[index];
                if (_pathNameOptionName.Equals(currentArg))
                {
                    PathName = _args[++index];
                }

                if (_logLevelOptionName.Equals(currentArg))
                {
                    LogLevel logLevel;
                    if (Enum.TryParse(_args[++index], true, out logLevel))
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