using System;
using Homework2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework2T
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SayHelloTo_InvalidNameProvided_ReturnsArgumentNullExpception()
        {
            try
            {
                IGreetThee greeter = new Greeter();
                greeter.SayHelloTo(null);
                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }
        }
    }
}
