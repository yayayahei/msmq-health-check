using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSMQHealthCheck.Cli
{
    public class Arguments
    {
        private readonly string[] _args;
        private static readonly ICollection<OptionItem> OptionsDic;

        static Arguments()
        {
            OptionsDic = new List<OptionItem>()
            {
                new OptionItem(OptionsEnum.PathName, null, null, true, "path name of the queue"),
                new OptionItem(OptionsEnum.FormatName, null, null, true, " format name of the queue"),
                new OptionItem(OptionsEnum.LogLevel, null, null, true, "log level"),
                new OptionItem(OptionsEnum.SendHello, null, null, false,
                    "flag to send hello to pathName or formatName"),
                new OptionItem(OptionsEnum.GetMessage, null, null, false,
                    "flag to get message from pathName or formatName"),
                new OptionItem(OptionsEnum.Help, "h", "h", false, "flag to show help"),
            };
        }

        public Arguments(string[] args)
        {
            _args = args;
            Init();
        }

        public bool NoArg
        {
            get
            {
                return _args == null || _args.Length == 0;
            }
        }

        public string PathName
        {
            get { return OptionsDic.FirstOrDefault(o => o.OptionsEnum.Equals(OptionsEnum.PathName))?.Value; }
        }

        public string FormatName
        {
            get { return OptionsDic.FirstOrDefault(o => o.OptionsEnum.Equals(OptionsEnum.FormatName))?.Value; }
        }

        public LogLevel LogLevel
        {
            get
            {
                OptionItem option = OptionsDic.FirstOrDefault(o => o.OptionsEnum.Equals(OptionsEnum.LogLevel));
                if (Enum.TryParse(option?.Value, true, out LogLevel logLevel))
                {
                    return logLevel;
                }

                return LogLevel.Info;
            }
        }

        public bool SendHello
        {
            get
            {
                OptionItem option = OptionsDic.FirstOrDefault(o => o.OptionsEnum.Equals(OptionsEnum.SendHello));
                return option?.Exist ?? false;
            }
        }

        public bool GetMessage
        {
            get
            {
                OptionItem option = OptionsDic.FirstOrDefault(o => o.OptionsEnum.Equals(OptionsEnum.GetMessage));
                return option?.Exist ?? false;
            }
        }

        public bool Help
        {
            get
            {
                OptionItem option = OptionsDic.FirstOrDefault(o => o.OptionsEnum.Equals(OptionsEnum.Help));
                return option?.Exist ?? false;
            }
        }

        private void Init()
        {
            string currentArg = null;
            OptionItem currentOptionItem = null;
            for (int index = 0; index < _args.Length; index++)
            {
                currentArg = _args[index];
                currentOptionItem = OptionsDic.FirstOrDefault(o => o.Match(currentArg));
                if (currentOptionItem == null) continue;
                if (currentOptionItem.ShouldHaveValue)
                {
                    currentOptionItem.Value = _args[++index];
                }
                else
                {
                    currentOptionItem.Exist = true;
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
            foreach (OptionItem optionItem in OptionsDic)
            {
                stringBuilder.AppendLine(optionItem.ToString());
            }

            return stringBuilder.ToString();
        }

        public string ToHelpString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Options:");
            foreach (OptionItem optionItem in OptionsDic)
            {
                stringBuilder.AppendLine($"\t{optionItem.ToHelp()}");
            }

            return stringBuilder.ToString();
        }
    }
}