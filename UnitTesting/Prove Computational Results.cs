using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    //Data reduction
    class Prove_Computational_Results
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
        public void VerifyDivisionTest()
        {
            Assert.IsTrue(Divide(6, 2) == 3, "6/2 should equal 3!");
        }
        //Data transformation
        public static double[] ConvertToPolarCoordinates(double x, double y)
        {
            double dist = Math.Sqrt(x * x + y * y);
            double angle = Math.Atan2(y, x);
            return new double[] { dist, angle };
        }
        [TestMethod]
        public void ConvertToPolarCoordinatesTest()
        {
            double[] pcoord = ConvertToPolarCoordinates(3, 4);
            Assert.IsTrue(pcoord[0] == 5, "Expected distance to equal 5");
            Assert.IsTrue(pcoord[1] == 0.92729521800161219, "Expected angle to be 53.130 degrees");
        }

        //###################################################################
        //List transformations
        public struct Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public List<string> ConcatNames(List<Name> names)
        {
            List<string> concatenatedNames = new List<string>();
            foreach (Name name in names)
            {
                concatenatedNames.Add(name.LastName + ", " + name.FirstName);
            }
            return concatenatedNames;
        }
        [TestMethod]
        public void NameConcatenationTest()
        {
            List<Name> names = new List<Name>()
        {
            new Name() { FirstName="John", LastName="Travolta"},
            new Name() {FirstName="Allen", LastName="Nancy" }
        };
            List<string> newNames = ConcatNames(names);
            Assert.IsTrue(newNames[0] == "Travolta, John");
            Assert.IsTrue(newNames[1] == "Nancy, Allen");
        }

        //##########The next conte should be the same but better because separate the data reduction from the data transformation#################
        public string Concat(Name name)
        {
            return name.LastName + ", " + name.FirstName;
        }
        [TestMethod]
        public void ContactNameTest()
        {
            Name name = new Name() { FirstName = "John", LastName = "Travolta" };
            string concatenatedName = Concat(name);
            Assert.IsTrue(concatenatedName == "Travolta, John");
        }

        //###################################################################################
        //Lambda Expressions and Unit Tests
        /*public List<string> ConcatNamesWithLinq(List<Name> names)
        {
            return names.Select(t => t.LastName + ", " + t.FirstName).ToList();
        }*/

        // OR

        public List<string> ConcatNamesWithLinq(List<Name> names)
        {
            return names.Select(t => Concat(t)).ToList();
        }
    }
}
