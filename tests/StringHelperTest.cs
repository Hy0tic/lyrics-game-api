using songDB.Helpers;

namespace tests;

public class StringHelperTest
{
    private StringHelper stringHelper { get; set; }

    public StringHelperTest()
    {
        stringHelper = new StringHelper();
    }
    
    [Fact]
    public void RemoveContentInParentheses_Works()
    {
        var result = stringHelper.RemoveContentInParentheses("Red (Taylor's Version)");
        var expected = "Red";
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void RemoveContentInSquareBrackets_Works()
    {
        var result = stringHelper.RemoveContentInSquareBrackets("Red [Tangerine Version]");
        var expected = "Red";
        Assert.Equal(expected,result);
    }

}