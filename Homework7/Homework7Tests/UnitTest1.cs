using System.Collections.Generic;
using System.IO;
using System.Linq;
using Homework7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework7Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StreamParsingWithInterfaceHappyPath()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x02, 0x04, 0x44, 0x33, 0x22,
                                0x11, 0x03, 0x05, 0x61, 0x62, 0x63, 0x64, 0x65 };
            var expectedOutput = new List<string> { "1144201745", "1144201745", "abcde" };
            Stream memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var reporter = parser as IReportStatus;
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
            Assert.AreEqual(3, reporter.RecordsProcessed);
            Assert.AreEqual(bytes.Length, reporter.BytesProcessed);
            Assert.IsTrue(reporter.TotalProcessingTime.Ticks > 0);
            Assert.AreEqual(reporter.TotalProcessingTime.Ticks / 3,
            reporter.AverageProcessingTime.Ticks);
        }        [TestMethod]
        public void StreamParsingStringHasFalseLength()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x02, 0x04, 0x44, 0x33, 0x22,
                                0x11, 0x03, 0x05, 0x61, 0x62, 0x63, 0x64 };
            var expectedOutput = new List<string> { "1144201745", "1144201745" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var reporter = parser as IReportStatus;
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
            Assert.AreEqual(2,reporter.RecordsProcessed);
            Assert.AreEqual(bytes.Length,reporter.BytesProcessed);
        }        [TestMethod]
        public void StreamParsingInvalidTypeGiven()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x02, 0x04, 0x44, 0x33, 0x22,
                                0x11, 0x03, 0x05, 0x61, 0x62, 0x63, 0x64 ,0x65,0x6};
            var expectedOutput = new List<string> { "1144201745", "1144201745","abcde" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var reporter = parser as IReportStatus;
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
            Assert.AreEqual(3, reporter.RecordsProcessed);
            Assert.AreEqual(bytes.Length, reporter.BytesProcessed);
        }



        [TestMethod]
        public void StreamParsingAcceptNull()
        {
            var parser = new StreamProcessor(null);
            var reporter = parser as IReportStatus;
            var parseddata = parser.ProcessStream();
            Assert.IsNull(parseddata);
            Assert.AreEqual(0, reporter.TotalProcessingTime.Ticks);
            Assert.AreEqual(0, reporter.AverageProcessingTime.Ticks);
            Assert.AreEqual(0, reporter.BytesProcessed);
            Assert.AreEqual(0, reporter.RecordsProcessed);
        }

        [TestMethod]
        public void StreamParsingAcceptZeroLegth()
        {
            var bytes = new byte[0];
            var expectedOutput = new List<string> { "" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var reporter = parser as IReportStatus;
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
            Assert.AreEqual(0, reporter.TotalProcessingTime.Ticks);
            Assert.AreEqual(0, reporter.AverageProcessingTime.Ticks);
            Assert.AreEqual(0, reporter.BytesProcessed);
            Assert.AreEqual(0, reporter.RecordsProcessed);
        }
    }
}
