using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using MSMQHealthCheck.Extensions;

namespace MSMQHealthCheck.Cli
{
    public class OptionItem
    {
        public static readonly string NamePrefix = "--";
        public static readonly string ShortNamePrefix = "-";
        public static readonly string AliasPrefix = "/";

        public OptionItem()
        {
        }

        public OptionItem(OptionsEnum optionsEnum, string shortName, string alias, bool shouldHaveValue,
            string description)
        {
            OptionsEnum = optionsEnum;
            Name = optionsEnum.ToString().ToCamelCase();
            ShortName = shortName;
            Alias = alias;
            ShouldHaveValue = shouldHaveValue;
            Description = description;
        }

        public bool Match(string optionArg)
        {
            if (optionArg.StartsWith(NamePrefix))
            {
                return optionArg.Substring(NamePrefix.Length).Equals(Name);
            }

            if (optionArg.StartsWith(ShortNamePrefix))
            {
                return optionArg.Substring(ShortNamePrefix.Length).Equals(ShortName);
            }

            if (optionArg.StartsWith(AliasPrefix))
            {
                return optionArg.Substring(AliasPrefix.Length).Equals(Alias);
            }

            return false;
        }

        public OptionsEnum OptionsEnum { get; set; }

        /// <summary>
        /// --Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// flag to express that this option should have value
        /// </summary>
        public bool ShouldHaveValue { get; set; }

        /// <summary>
        /// -ShortName
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// /Alias
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// dose this option exist in the cli options
        /// </summary>
        public bool Exist { get; set; }

        /// <summary>
        /// value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// help description
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name}: {(ShouldHaveValue ? Value : Exist.ToString())}";
        }

        public string ToHelp()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{NamePrefix}{Name}");
            if (!string.IsNullOrWhiteSpace(ShortName))
            {
                stringBuilder.Append($", {ShortNamePrefix}{ShortName}");
            }

            if (!string.IsNullOrWhiteSpace(Alias))
            {
                stringBuilder.Append($", {AliasPrefix}{Alias}");
            }

            stringBuilder.Append("\t");
            stringBuilder.Append(Description);
            return stringBuilder.ToString();
        }
    }
}