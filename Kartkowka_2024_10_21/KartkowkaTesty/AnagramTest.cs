using Library;

namespace KartkowkaTesty;

public class AnagramTest
{
    [Theory]
    [InlineData("abc", "abc", true)]
    [InlineData("chaos", "shaco", true)]
    [InlineData("maokai", "iamoak", true)]
    [InlineData("funny", "notfunny", false)]
    public static void IsAnagramTest(string string_one, string string_two, bool expected)
    {
        Assert.Equal(expected, Anagram.IsAnagram(string_one, string_two));
    }
}