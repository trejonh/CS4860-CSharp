using System.Collections.Generic;
using System.IO;
using System.Linq;
using Homework8;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework8Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StreamParsingWithInterfaceHappyPath()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x03, 0x05, 0x61, 0x62, 0x63,
0x64, 0x65 };
            var expectedOutput = new List<string> { "1144201745", "abcde" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var reporter = parser as IReportStatus;
            var parsedData = parser.ProcessStream();
            Assert.IsTrue(parsedData.SequenceEqual(expectedOutput));
            Assert.AreEqual(2, reporter.RecordsProcessed);
            Assert.AreEqual(bytes.Length, reporter.BytesProcessed);
            Assert.IsTrue(reporter.TotalProcessingTime.Ticks > 0);
            Assert.AreEqual(reporter.TotalProcessingTime.Ticks / 2,
            reporter.AverageProcessingTime.Ticks);
        }
        [TestMethod]
        public void IntegerParsingHappyPath()
        {
            byte[] bytes = { 0x11, 0x22, 0x33, 0x44 };
            var intParser = (IParse<int>)new StreamProcessor();
            Assert.AreEqual(0x44332211, intParser.Parse(bytes));
            bytes = new byte[] { 0x11 };
            Assert.AreEqual(0x11, intParser.Parse(bytes));
        }
        [TestMethod]
        public void StringParsingHappyPath()
        {
            byte[] bytes = { 0x61, 0x62, 0x63, 0x64 };
            var intParser = (IParse<string>)new StreamProcessor();
            Assert.AreEqual("abcd", intParser.Parse(bytes));
            bytes = new byte[] { 0x63 };
            Assert.AreEqual("c", intParser.Parse(bytes));
        }
        [TestMethod]
        public void IntParsingReturn0GivenNull()
        {
            var intParser = (IParse<int>)new StreamProcessor();
            Assert.AreEqual(0, intParser.Parse(null));
        }

        [TestMethod]
        public void StringParsingReturnNullGivenNull()
        {
            var intParser = (IParse<string>)new StreamProcessor();
            Assert.AreEqual(null, intParser.Parse(null));
        }

        [TestMethod]
        public void IntegerParsing_GivenTwoByte_Return8721()
        {
            var bytes = new byte[] { 0x11 , 0x22};
            var intParser = (IParse<int>)new StreamProcessor();
            Assert.AreEqual(0x2211, intParser.Parse(bytes));
        }
    }
}
