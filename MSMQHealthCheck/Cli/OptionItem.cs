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

        public OptionItem(OptionsEnum optionsEnum, string shortName, string alias, bool shouldHaveValue)
        {
            OptionsEnum = optionsEnum;
            Name = optionsEnum.ToString().ToCamelCase();
            ShortName = shortName;
            Alias = alias;
            ShouldHaveValue = shouldHaveValue;
        }

        public bool Match(string optionArg)
        {
            if (optionArg.StartsWith(NamePrefix))
            {
                return Name.Equals(optionArg.Substring(NamePrefix.Length));
            }

            if (optionArg.StartsWith(ShortNamePrefix))
            {
                return ShortName.Equals(optionArg.Substring(ShortNamePrefix.Length));
            }

            if (optionArg.StartsWith(AliasPrefix))
            {
                return Alias.Equals(optionArg.Substring(AliasPrefix.Length));
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

        public override string ToString()
        {
            return $"{Name}: {(ShouldHaveValue ? Value : Exist.ToString())}";
        }
    }
}