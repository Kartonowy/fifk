using System.Collections;

namespace Calc
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(int.MaxValue, 1, int.MinValue)]
        [InlineData(-5, 8, 3)]
        [InlineData(-2, 2, 0)]
        [InlineData(34, 36, 70)]
        [ClassData(typeof(UnitTest2))]
        [MemberData(nameof(UnitTest3))]
        public void ShouldAdd(int x, int y, int expected)
        {
            int result = Calculator.Add(x, y);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void ShouldAddFact()
        {
            int result = Calculator.Add(34, 35);

            Assert.Equal(69, result);
        }

        public static IEnumerable<object[]> UnitTest3() {
            var test = new List<object[]>
            {
                new object[] { 3, 3, 6 },
                new object[] { 4, 4, 8 },
                new object[] { 3, 4, 7 },
                new object[] { 3, 6, 9 },
                new object[] { 3, 7, 10 },
                new object[] { 3, 8, 11 },
            };
            return test;
            // or
            // yield return new object[] { 1, 2, 3 };
        }
    }
    public class UnitTest2 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 2 , 2, 4 };
            yield return new object[] { 34, 35, 69 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}