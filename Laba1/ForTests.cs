using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public class ForTests
    {
        public static int getSum(int a, int b)
        {
            int c = a + b;
            return c;
        }

        public static int getDif(int a, int b)
        {
            int c = a - b;
            return c;
        }

        public static float getDiv(int a, int b)
        {
            float c = a/b;
            return c;
        }

        public static int getMult(int a, int b)
        {
            int c = a * b;
            return c;
        }

        public static bool isEqual(string a, string b)
        {
            if (a.Equals(b))
                return true;
            else
                return false;
        }

        public static string concatination(string[] a)
        {
            string b = string.Join("", a);
            return b;
        }

        public static int getForce(int m, int a)
        {
            int F = m * a;
            return F;
        }

        public static double getHypotenuse(int a, int b)
        {
            double c = Math.Sqrt(a * a + b * b);
            return c;
        }
    }
}
