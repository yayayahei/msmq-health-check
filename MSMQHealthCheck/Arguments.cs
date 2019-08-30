using System;
using System.Text;

namespace MSMQHealthCheck
{
    public class Arguments
    {
        private readonly string[] _args;
        private string _pathNameOptionName = "--pathName";
        private string _formatNameOptionName = "--formatName";
        private string _logLevelOptionName = "--logLevel";
        private string _sendHello = "--sendHello";

        public string PathName { get; set; }
        public string FormatName { get; set; }
        public LogLevel LogLevel { get; set; }

        public bool SendHello { get; set; }

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

                if (_formatNameOptionName.Equals(currentArg))
                {
                    FormatName = _args[++index];
                }

                if (_logLevelOptionName.Equals(currentArg))
                {
                    LogLevel logLevel;
                    if (Enum.TryParse(_args[++index], true, out logLevel))
                    {
                        LogLevel = logLevel;
                    }
                }

                if (_sendHello.Equals(currentArg))
                {
                    SendHello = true;
                }
            }

            if (LogLevel.Debug.Equals(LogLevel))
            {
                Console.WriteLine(ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Args:");
            stringBuilder.AppendLine($"{_pathNameOptionName}: {PathName}");
            stringBuilder.AppendLine($"{_formatNameOptionName}: {FormatName}");
            stringBuilder.AppendLine($"{_logLevelOptionName}: {LogLevel}");
            stringBuilder.AppendLine($"{_sendHello}: {SendHello}");
            return stringBuilder.ToString();
        }
    }
}