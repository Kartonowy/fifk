namespace Project
{
    /// <summary>
    /// Istnieje prawdopodobieństwo większe od 0, że ten interfejs w PEWNYCH przypadkach będzie potrzebował Mock'a/Stub'a
    /// </summary>
    public interface IAlgorithms
    {
        /// <summary>
        /// Silnia
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        long Factorial(short number);

        /// <summary>
        /// Szybkie potęgowanie
        /// </summary>
        /// <param name="a"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        long FastPow(short a, short exp);

        /// <summary>
        /// NWD
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        long Gcd_recursive(long u, long v);
    }
}
