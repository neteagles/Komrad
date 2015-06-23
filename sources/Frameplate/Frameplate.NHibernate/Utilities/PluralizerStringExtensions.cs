namespace Frameplate.NHibernate.Utilities
{
    using System;
    using System.Linq;

    public static class PluralizerStringExtensions
    {
        public static string ToPlural(this string input)
        {                       
            if (input.Count(x => x == ' ') > 0)
                throw new ArgumentException("Could not pluralize: input string contains multiple words", "input");

            if (input.Length < 3)
                throw new ArgumentException("Could not pluralize: input string is too short", "input");

            var lastCharIndex = input.Length - 1;
            var lastChar = input[lastCharIndex];

            switch (lastChar)
            {
                case 'h':
                case 's':
                    return string.Format("{0}es", input);
                case 'y':
                    return string.Format("{0}ies", input.Remove(lastCharIndex, 1));
                default:
                    return string.Format("{0}s", input);
            }
        }
    }
}