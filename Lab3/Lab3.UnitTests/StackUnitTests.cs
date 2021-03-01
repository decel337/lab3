using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab3.UnitTests
{
    [TestClass]
    public class StackUnitTests
    {

        [TestMethod]
        public void PushPopTest()
        {
            Stack<int> stackInt = new Stack<int>();
            Stack<string> stackString = new Stack<string>();
            Stack<bool> stackBool = new Stack<bool>();

            stackInt.Push(1);
            Assert.AreEqual(1, stackInt.Pop());
            stackString.Push("Hello World");
            Assert.AreEqual("Hello World", stackString.Pop());
            stackBool.Push(true);
            Assert.AreEqual(true, stackBool.Pop());
        }

        [TestMethod]
        public void PeekPopEmptyTest()
        {
            Stack<int> stackInt = new Stack<int>();

            Assert.ThrowsException<InvalidOperationException>(() => stackInt.Pop());
            Assert.ThrowsException<InvalidOperationException>(() => stackInt.Peek());
        }

        [TestMethod]
        public void ExceedDefaultSizeTest()
        {
            int defaultSize = 32;
            Stack<int> stackInt = new Stack<int>();

            int i = 0;
            for (; i < defaultSize * 32; i++)
            {
                stackInt.Push(i);
            }
            Assert.AreEqual(i - 1, stackInt.Pop());
        }

        [TestMethod]
        public void ClearTest()
        {
            Stack<int> stackInt = new Stack<int>();

            int i = 0;
            for (; i < 10; i++)
            {
                stackInt.Push(i);
            }
            Assert.AreEqual(i - 1, stackInt.Pop());
            stackInt.Clear();
            Assert.ThrowsException<InvalidOperationException>(() => stackInt.Pop());
        }

        [TestMethod]
        public void LengthTest()
        {
            Stack<int> stackInt = new Stack<int>();
            int desiredLength = 10;
            for (int i = 0; i < desiredLength; i++)
            {
                stackInt.Push(i);
            }
            Assert.AreEqual(desiredLength, stackInt.Length);
        }

        [TestMethod]
        public void PeekTest()
        {
            Stack<int> stackInt = new Stack<int>();
            int desiredLength = 10;
            int i = 0;
            for (; i < desiredLength; i++)
            {
                stackInt.Push(i);
            }
            Assert.AreEqual(desiredLength, stackInt.Length);
            Assert.AreEqual(i - 1, stackInt.Peek());
            Assert.AreEqual(i - 1, stackInt.Peek());
            Assert.AreEqual(desiredLength, stackInt.Length);
        }
    }
}
