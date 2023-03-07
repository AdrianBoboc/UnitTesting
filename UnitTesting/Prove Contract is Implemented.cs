using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    class Prove_Contract_is_Implemented
    {
        public static int Divide(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentOutOfRangeException("Denominator cannot be 0.");
            }
            return numerator / denominator;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BadParameterTest()
        {
            Divide(5, 0);
        }
    }
}
