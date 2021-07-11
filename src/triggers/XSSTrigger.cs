using System.Text.RegularExpressions;

namespace Nfense.ModWAF {
    public class XSSTrigger {

        private static string PATTERN = @"/<(|\/|[^\/>][^>]+|\/[^>][^>]+)>/g";

        public static bool IsTrigger (string input) {
            return Regex.IsMatch(input, PATTERN);
        }
    }
}