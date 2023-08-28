using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DataStructures
{
    public class UtilAlgorithms
    {
        public static BigInteger Karatsuba(string input1, string input2)
        {
            var n1 = input1.Length;
            var n2 = input2.Length;

            if (n1 == 1 || n2 == 1)
            {
                return int.Parse(input1) * int.Parse(input2);
            }

            int halfLength1 = input1.Length / 2;
            int halfLength2 = input2.Length / 2;

            string bigA = input1.Substring(0, halfLength1);
            string bigB = input1.Substring(halfLength1);
            string bigC = input2.Substring(0, halfLength2);
            string bigD = input2.Substring(halfLength2);

            BigInteger a = BigInteger.Parse(bigA);
            BigInteger b = BigInteger.Parse(bigB);
            BigInteger c = BigInteger.Parse(bigC);
            BigInteger d = BigInteger.Parse(bigD);

            var ac = Karatsuba(bigA, bigC);
            var bd = Karatsuba(bigB, bigD);
            var third = Karatsuba((a + b).ToString(), (c + d).ToString());

            var subtract = third - bd - ac;

            var result = (BigInteger.Pow(10,n1) * ac) + (BigInteger.Pow(10,n1/2) * subtract) + bd;

            return result;
        }
    }
}
