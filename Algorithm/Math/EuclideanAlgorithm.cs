using System;

namespace Algorithm.Math
{
    public static class EuclideanAlgorithm
    {
        // https://en.wikipedia.org/wiki/Euclidean_algorithm
        public static dynamic GreatestCommonDivisor(dynamic x, dynamic y)
        {
            if(y == 0) return x;
            return GreatestCommonDivisor(y, x%y);
        }

        public static dynamic LeastCommonMultiple(dynamic x, dynamic y)
        {
            var gcd = GreatestCommonDivisor(x,y);
            if(gcd == 0) return 0;
            return x/gcd*y;
        }

        // https://en.wikipedia.org/wiki/Extended_Euclidean_algorithm
        // a * x + b * y = gcd
        // Return values are x, y, gcd
        public static (dynamic, dynamic, dynamic) ExtendedGreatestCommonDivisor(dynamic a, dynamic b)
        {
            if(b == 0)
            {
                return (1, 0, a);
            }

            var res = ExtendedGreatestCommonDivisor(b, a%b);
            return (res.Item2, res.Item1 - a / b * res.Item2, res.Item3);
        }
    }
}
