using System.Text.RegularExpressions;

namespace songDB.Helpers;

public class StringHelper
{
    public string RemoveContentInParentheses(string input)
    {
        return Regex.Replace(input, @"\([^)]*\)", "").Trim();
    }
    
    public string RemoveContentInSquareBrackets(string input)
    {
        return Regex.Replace(input, @"\[[^\]]*\]", "").Trim();
    }
}