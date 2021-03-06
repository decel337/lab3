using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab3.UnitTests
{
    [TestClass]
    public class ShuntingYardUnitTests
    {
        Calculator calc = new Calculator();
        OperationsForHelp helper = new OperationsForHelp();

        [TestMethod]
        public void BasicExpressions()
        {
            Assert.AreEqual(14, calc.Calc(helper.SplitOnToken("7+2+5")));
            Assert.AreEqual(36, calc.Calc(helper.SplitOnToken("6*3*2")));
            Assert.AreEqual(1.75f, calc.Calc(helper.SplitOnToken("7/2 / 2")));
        }

        [TestMethod]
        public void PowerBasicExpressions()
        {
            Assert.AreEqual(49, calc.Calc(helper.SplitOnToken("7^2")));
            Assert.AreEqual(0.5, calc.Calc(helper.SplitOnToken("2^(-1)")));
            Assert.AreEqual(512, calc.Calc(helper.SplitOnToken("2^3^2")));
            Assert.AreEqual(1, calc.Calc(helper.SplitOnToken("1^3^(-2)")));
            Assert.AreEqual(4, calc.Calc(helper.SplitOnToken("(-2)^2")));
            Assert.AreEqual(-4, calc.Calc(helper.SplitOnToken("-2^2")));
        }

        [TestMethod]
        public void HarderExpressions()
        {
            Assert.AreEqual(1, calc.Calc(helper.SplitOnToken("7^0")));
            Assert.AreEqual(0, calc.Calc(helper.SplitOnToken("-0^20")));
            Assert.AreEqual(1.5, calc.Calc(helper.SplitOnToken("3 * (3 / 6)")));
        }
    }
}
