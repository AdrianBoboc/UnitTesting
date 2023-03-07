using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting
{
    internal class Prove_a_Bug_is_Re_creatable
    {
        public static int Divide(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentOutOfRangeException("Denominator cannot be 0.");
            }
            return numerator / denominator;

        }
        //Negative testing
        [TestMethod]

        [ExpectedException(typeof(DivideByZeroException))]

        public void BadParameterTest()
        {
            Divide(5, 0);
        }
    }
}
