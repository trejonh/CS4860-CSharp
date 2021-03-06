﻿using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Homework2Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SayHelloTo_InvalidNameProvided_ReturnsArgumentNullExpception()
        {
            try
            {
                Greeter greeter = new Greeter();
                Assert.Fail();
            }
            catch (ArgumentNullException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void SayHelloTo_InvalidNameProvided_ReturnsArgumentException()
        {
            IGreetThee greeter = new Greeter();
            int name = 0;
            Assert.ThrowsException<ArugmentException>()
        }
    }
}
