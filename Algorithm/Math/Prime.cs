using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithm.Math
{
    public class Prime
    {
        public static bool IsPrime(dynamic num)
        {
            if(num <= 1) return false;

            int sqrt = (int)(System.Math.Sqrt(num) + 1e-6);
            for(int i=2;i<=sqrt;i++)
            {
                if(num%i == 0) return false;
            }
            return true;
        }

        // Is prime from 0 to num in O(n)
        public static bool[] ArePrimes(int num)
        {
            var arePrimes = new bool[num + 1];
            
            for(int i=2;i<=num;i++) arePrimes[i] = true;

            for(int i=2;i<=num;i++)
            {
                if(!arePrimes[i]) continue;

                var from = i * i;
                if(from > num || from < 0) break;

                for(int j=from;j<=num;j+=i)
                {
                    arePrimes[j] = false;
                }
            }

            return arePrimes;
        }

        // Get prime nums from 0 to num
        public static IEnumerable<int> GetPrimes(int num)
        {
            var arePrimes = ArePrimes(num);

            for(int i=2;i<=num;i++)
            {
                if(arePrimes[i]) yield return i;
            }
        }
    }
}
