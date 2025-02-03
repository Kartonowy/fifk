namespace Project
{
    /// <summary>
    /// Ten interfejs prawdopodobnie potrzebuje Mock'a/Stub'a
    /// https://www.usingenglish.com/resources/text-statistics/
    /// </summary>
    public interface ITextStatistics
    {
        int GetNumberOfHardWords(string text);

        double GetLexicalDensity(string text);

        double GetLexicalDensityWithoutStopWords(string text);
    }
}
