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
    [InlineData("(Tangerine edition)", "")]
    [InlineData("()", "")]
    [InlineData("", "")]
    public void RemoveContentInParentheses_Works(string input, string expected)
    {
        var result = stringHelper.RemoveContentInParentheses(input);

        Assert.Equal(expected,result);
    }
    
    [Theory]
    [InlineData("1989 (Tangerine Edition)", "1989")]
    [InlineData("Red (Deluxe Edition)", "Red")]
    [InlineData("No Brackets", "No Brackets")]
    [InlineData("(Tangerine edition)", "")]
    [InlineData("()", "")]
    [InlineData("", "")]
    public void RemoveContentInParentheses_Result_DoesNotContainParenthesis(string input, string expected)
    {
        var result = stringHelper.RemoveContentInParentheses(input);
        
        Assert.DoesNotContain("(",result);
        Assert.DoesNotContain(")",result);
    }
    
    [Theory]
    [InlineData("1989 [Tangerine Edition]", "1989")]
    [InlineData("Red [Deluxe Edition]", "Red")]
    [InlineData("No Brackets", "No Brackets")]
    [InlineData("[Tangerine edition]", "")]
    [InlineData("[]", "")]
    [InlineData("", "")]
    public void RemoveContentInSquareBrackets_Works(string input, string expected)
    {
        var result = stringHelper.RemoveContentInSquareBrackets(input);
        Assert.Equal(expected,result);
        Assert.DoesNotContain("[",result);
        Assert.DoesNotContain("]",result);
    }
    
    [Theory]
    [InlineData("1989 [Tangerine Edition]", "1989")]
    [InlineData("Red [Deluxe Edition]", "Red")]
    [InlineData("No Brackets", "No Brackets")]
    [InlineData("[Tangerine edition]", "")]
    [InlineData("[]", "")]
    [InlineData("", "")]
    public void RemoveContentInSquareBrackets_Result_DoesNotContainBrackets(string input, string expected)
    {
        var result = stringHelper.RemoveContentInSquareBrackets(input);
        Assert.DoesNotContain("[",result);
        Assert.DoesNotContain("]",result);
    }

    [Theory]
    [InlineData("1989 [Tangerine Edition]")]
    [InlineData("Red [Deluxe Edition]")]
    [InlineData("No Brackets")]
    [InlineData("[Tangerine edition]")]
    [InlineData("[]")]
    [InlineData("")]
    public void RemoveContentInSquareBrackets_Returns_String(string input)
    {
        var result = stringHelper.RemoveContentInSquareBrackets(input);
        Assert.IsType<string>(result);
    }
    
    [Theory]
    [InlineData("1989 (Tangerine Edition)")]
    [InlineData("Red (Deluxe Edition)")]
    [InlineData("No Brackets")]
    [InlineData("(Tangerine edition)")]
    [InlineData("()")]
    [InlineData("")]
    public void RemoveContentInParentheses_Returns_String(string input)
    {
        var result = stringHelper.RemoveContentInParentheses(input);
        Assert.IsType<string>(result);
    }
    
    [Theory]
    [InlineData("1989 [Tangerine Edition]")]
    [InlineData("Red [Deluxe Edition]")]
    [InlineData("No Brackets")]
    [InlineData("[Tangerine edition]")]
    [InlineData("[]")]
    [InlineData("")]
    public void RemoveContentInSquareBrackets_IsNotNull(string input)
    {
        var result = stringHelper.RemoveContentInSquareBrackets(input);
        Assert.NotNull(result);
    }
    
    [Theory]
    [InlineData("1989 (Tangerine Edition)")]
    [InlineData("Red (Deluxe Edition)")]
    [InlineData("No Brackets")]
    [InlineData("(Tangerine edition)")]
    [InlineData("()")]
    [InlineData("")]
    public void RemoveContentInParentheses_IsNotNull(string input)
    {
        var result = stringHelper.RemoveContentInParentheses(input);
        Assert.NotNull(result);
    }

}