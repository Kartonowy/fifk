using System;

namespace Project
{
    public class Algorithms : IAlgorithms
    {
        /// <inheritdoc/>
        public long Factorial(short number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), number, "Must be zero or a positive number.");

            var accumulator = 1L;
            for (long factor = 1L; factor <= number; factor++)
            {
                accumulator *= factor;
            }
            return accumulator;
        }

        /// <inheritdoc/>
        public long FastPow(short a, short exp)
        {
            if (exp == 0)
                return 1;
            else if (exp == 1)
                return a;
            else
            {
                long temp = FastPow(a, (short)(exp / 2));
                if (exp % 2 == 0)
                    return temp * temp;
                else
                    return a * temp * temp;
            }
        }

        /// <inheritdoc/>
        public long Gcd_recursive(long u, long v)
        {
            return (v != 0) ? Gcd_recursive(v, u % v) : u;
        }
    }
}
