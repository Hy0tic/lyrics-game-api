using songDB.Helpers;

namespace tests;

public class StringHelperTest
{
    private StringHelper stringHelper { get; set; }

    public StringHelperTest()
    {
        stringHelper = new StringHelper();
    }
    
    [Theory]
    [InlineData("1989 (Tangerine Edition)", "1989")]
    [InlineData("Red (Deluxe Edition)", "Red")]
    [InlineData("No Brackets", "No Brackets")]
    public void RemoveContentInParentheses_Works(string input, string expected)
    {
        var result = stringHelper.RemoveContentInParentheses(input);
        Assert.Equal(expected,result);
    }
    
    [Theory]
    [InlineData("1989 [Tangerine Edition]", "1989")]
    [InlineData("Red [Deluxe Edition]", "Red")]
    [InlineData("No Brackets", "No Brackets")]
    public void RemoveContentInSquareBrackets_Works(string input, string expected)
    {
        var result = stringHelper.RemoveContentInSquareBrackets(input);
        Assert.Equal(expected,result);
    }

}