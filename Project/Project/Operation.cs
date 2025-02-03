using System;

namespace Project
{
    /// <summary>
    /// Klasa do przetestowania
    /// </summary>
    public class Operation
    {
        public IAlgorithms Algorithms { get; }
        public ITextStatistics TextStatistics { get; }

        public Operation(IAlgorithms algorithms, ITextStatistics textStatistics)
        {
            Algorithms = algorithms;
            TextStatistics = textStatistics;
        }

        private long Calculate(sbyte firstNumber, short secondNumber)
        {
            if (firstNumber > 20 || firstNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(firstNumber), firstNumber, "Must be in range [0, 20]"); ;
            }

            long firstCalculated = Algorithms.Factorial(firstNumber);
            long secondCalculated = Algorithms.FastPow(secondNumber, 2);

            return Algorithms.Gcd_recursive(firstCalculated, secondCalculated);
        }

        public long CalculateTextStatistic(string text)
        {
            sbyte a;
            short b;

            var lexicalDensity = TextStatistics.GetLexicalDensity(text);
            var lexicalDensityWords = TextStatistics.GetLexicalDensityWithoutStopWords(text);

            if (lexicalDensity >= lexicalDensityWords)
            {
                a = (sbyte)(lexicalDensity / 10);
                b = (short)(lexicalDensityWords / 10);
            }
            else
            {
                a = (sbyte)(lexicalDensityWords / 10);
                b = (short)(lexicalDensity / 10);
            }

            return Calculate(a, b);
        }
    }
}
