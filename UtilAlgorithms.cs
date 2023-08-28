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

        public static string FindSum(string str1, string str2)
        {
            // Before proceeding further, make sure length of
            // str2 is larger
            if (str1.Length > str2.Length)
            {
                string temp = str1;
                str1 = str2;
                str2 = temp;
            }
            // Stores the result
            string str = "";

            // Calculate length of both string
            int n1 = str1.Length;
            int n2 = str2.Length;

            // Reverse both of strings
            str1 = new string(str1.Reverse().ToArray());
            str2 = new string(str2.Reverse().ToArray());

            int carry = 0;
            for (int i = 0; i < n1; i++)
            {

                // Find the sum of the current digits and carry
                int sum = ((str1[i] - '0') + (str2[i] - '0')
                           + carry);
                str += (char)(sum % 10 + '0');

                // Calculate carry for next step
                carry = sum / 10;
            }

            // Add remaining digits of larger number
            for (int i = n1; i < n2; i++)
            {
                int sum = ((str2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            // Add remaining carry
            if (carry != 0)
                str += (char)(carry + '0');

            // Reverse resultant string
            return new string(str.Reverse().ToArray());
        }

        // Function to find difference of larger
        // numbers represented as strings
        static string FindDiff(string str1, string str2)
        {
            // Stores the result of difference
            string str = "";

            // Calculate length of both string
            int n1 = str1.Length, n2 = str2.Length;

            // Reverse both of strings
            str1 = new string(str1.Reverse().ToArray());
            str2 = new string(str2.Reverse().ToArray());

            int carry = 0;

            // Run loop till small string length
            // and subtract digit of str1 to str2
            for (int i = 0; i < n2; i++)
            {

                // Compute difference of the
                // current digits
                int sub = ((str1[i] - '0') - (str2[i] - '0')
                           - carry);

                // If subtraction < 0 then add 10
                // into sub and take carry as 1
                if (sub < 0)
                {
                    sub = sub + 10;
                    carry = 1;
                }
                else
                    carry = 0;

                str += sub;
            }

            // Subtract the remaining digits of
            // larger number
            for (int i = n2; i < n1; i++)
            {
                int sub = ((str1[i] - '0') - carry);

                // If the sub value is -ve,
                // then make it positive
                if (sub < 0)
                {
                    sub = sub + 10;
                    carry = 1;
                }
                else
                    carry = 0;
                str += sub;
            }

            return new string(str.Reverse().ToArray());
        }

        // Function to remove all leading 0s
        // from a given string
        public static string RemoveLeadingZeros(string input)
        {
            int i = 0;
            while (i < input.Length && input[i] == '0')
            {
                i++;
            }

            return i == input.Length ? "0" : input.Substring(i);
        }

        // Function to multiply two numbers
        // using Karatsuba algorithm
        public static string Multiply(string A, string B)
        {
            if (A.Length > B.Length)
            {
                string temp = A;
                A = B;
                B = temp;
            }

            // Make both numbers to have
            // same digits
            int n1 = A.Length, n2 = B.Length;
            while (n2 > n1)
            {
                A = "0" + A;
                n1++;
            }

            // Base case
            if (n1 == 1)
            {

                // If the length of strings is 1,
                // then return their product
                return Convert.ToString(BigInteger.Parse(A) * BigInteger.Parse(B));
            }

            // Add zeros in the beginning of
            // the strings when length is odd
            if (n1 % 2 == 1)
            {
                n1++;
                A = "0" + A;
                B = "0" + B;
            }

            string Al = "", Ar = "", Bl = "", Br = "";

            // Find the values of Al, Ar,
            // Bl, and Br.
            for (int i = 0; i < n1 / 2; ++i)
            {
                Al += A[i];
                Bl += B[i];
                Ar += A[n1 / 2 + i];
                Br += B[n1 / 2 + i];
            }

            // Recursively call the function
            // to compute smaller product

            // Stores the value of Al * Bl
            string p = Multiply(Al, Bl);

            // Stores the value of Ar * Br
            string q = Multiply(Ar, Br);

            // Stores value of ((Al + Ar)*(Bl + Br)
            // - Al*Bl - Ar*Br)
            string r = FindDiff(
              Multiply(FindSum(Al, Ar), FindSum(Bl, Br)),
              FindSum(p, q));

            // Multiply p by 10^n
            for (int i = 0; i < n1; ++i)
                p = p + "0";

            // Multiply s by 10^(n/2)
            for (int i = 0; i < n1 / 2; ++i)
                r = r + "0";

            // Calculate final answer p + r + s
            string ans = FindSum(p, FindSum(q, r));

            // Remove leading zeroes from ans
            ans = RemoveLeadingZeros(ans);

            // Return Answer
            return ans;
        }
    }
}
