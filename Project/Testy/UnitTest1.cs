using Moq;
using Project;
namespace Testy;

public class UnitTest1
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    [InlineData(5, 120)]
    public void FactorialTest(int a, int expected)
    {
        var algorithms = new Algorithms();
        var result = algorithms.Factorial((short)a);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(0, 0, 1)]
    [InlineData(0, 1, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 1, 1)]
    [InlineData(2, 2, 4)]
    [InlineData(3, 6, 729)]
    [InlineData(4, 4, 256)]
    public void FastPowTest(int a, int exp, int expected)
    {
        var algorithms = new Algorithms();
        var result = algorithms.FastPow((short)a, (short)exp);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FactorialThrows()
    {
        var algorithms = new Algorithms();
        Assert.Throws<ArgumentOutOfRangeException>(() => algorithms.Factorial(-1));
    }
    
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 1, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 1, 1)]
    [InlineData(2, 2, 2)]
    [InlineData(3, 6, 3)]
    [InlineData(4, 24, 4)]
    public void GcdTest(int a, int b, int expected)
    {
        var algorithms = new Algorithms();
        var result = algorithms.Gcd_recursive(a, b);
        Assert.Equal(expected, result);
    }
    
    private class StubAlgorithms(long factorialResult, long fastPowResult, long gcdResult) : IAlgorithms
    {
        public long Factorial(short number) => factorialResult;

        public long FastPow(short a, short exp) => fastPowResult;

        public long Gcd_recursive(long u, long v) => gcdResult;
    }
    private class StubTextStatistics(double lexicalDensity, double lexicalDensityWithoutStopWords, int hardWords)
        : ITextStatistics
    {
        public int GetNumberOfHardWords(string text) => hardWords; 
        public double GetLexicalDensity(string text) => lexicalDensity; 
        public double GetLexicalDensityWithoutStopWords(string text) => lexicalDensityWithoutStopWords;
    }

    [Theory]
    [InlineData("Sample text", 50.0, 40.0, 120, 16, 8)]
    [InlineData("Edge case test", 100.0, 90.0, 720, 81, 9)]
    public void CalculateTextStatisticsValid(
        string text,
        double lexicalDensity,
        double lexicalDensityWords,
        long factorialResult,
        long fastPowResult,
        long gcdResult)
    {
        
        var algorithmsStub = new StubAlgorithms(factorialResult, fastPowResult, gcdResult);
        var textStatisticsStub = new StubTextStatistics(lexicalDensity, lexicalDensityWords, 0);

        var operation = new Operation(algorithmsStub, textStatisticsStub);

        var result = operation.CalculateTextStatistic(text);
        
        Assert.Equal(gcdResult, result);
    }

    [Theory]
    [InlineData("Invalid case", -30.0, -35.0)]
    public void CalculateTextStatisoicThrows(string text, double lexicalDensity, double lexicalDensityWords)
    {
        var algorithmsStub = new StubAlgorithms(0, 0, 0); 
        var textStatisticsStub = new StubTextStatistics(lexicalDensity, lexicalDensityWords, 0);
        
        var operation = new Operation(algorithmsStub, textStatisticsStub);

        Assert.Throws<ArgumentOutOfRangeException>(() => operation.CalculateTextStatistic(text));
    }
    
    [Theory]
    [InlineData("Sample text", -40.0, -35)]
    public void CalculateTextStatisticThrowsReverse(string text, double lexicalDensity, double lexicalDensityWords) {
        var algorithmsStub = new StubAlgorithms(0, 0, 0); 
        var textStatisticsStub = new StubTextStatistics(lexicalDensity, lexicalDensityWords, 0);
        
        var operation = new Operation(algorithmsStub, textStatisticsStub);

        Assert.Throws<ArgumentOutOfRangeException>(() => operation.CalculateTextStatistic(text));
    }
    [Fact]
    public void HardWordsTest()
    {
        var textStatistics = new Moq.Mock<ITextStatistics>();

        textStatistics.Setup(x => x.GetNumberOfHardWords(It.IsAny<string>())).Returns(4);
        
        var result = textStatistics.Object.GetNumberOfHardWords("This is a sample text with hard words like: abracadabra, alakazam, hocus-pocus, prestidigitation, and pseudopseudohypoparathyroidism.");
        Assert.Equal(4, result);
    }
}