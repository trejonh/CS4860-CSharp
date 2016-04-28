using Homework4;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework4Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StreamParsingHappyPath()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x02, 0x04, 0x44, 0x33, 0x22,
0x11, 0x03, 0x05, 0x61, 0x62, 0x63, 0x64, 0x65 };
            var expectedOutput = new List<string> { "1144201745", "1144201745", "abcde" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
        }

        [TestMethod]
        public void StreamParsingAcceptNull()
        {
            var parser = new StreamProcessor(null);
            var parseddata = parser.ProcessStream();
            Assert.IsNull(parseddata);
        }

        [TestMethod]
        public void StreamParsingAcceptZeroLegth()
        {
            byte[] bytes = new byte[0];
            var expectedOutput = new List<string> { "" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
        }

        [TestMethod]
        public void StreamParsingAcceptInvalidType()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x02, 0x04, 0x44, 0x33, 0x22,
0x11, 0x03, 0x05, 0x61, 0x62, 0x63, 0x64, 0x65, 0x06 };
            var expectedOutput = new List<string> { "1144201745", "1144201745", "abcde" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
        }

        [TestMethod]
        public void StreamParsingMismatchLength()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x02, 0x04, 0x44, 0x33, 0x22,
0x11, 0x03, 0x05, 0x61, 0x62, 0x63, 0x64 };
            var expectedOutput = new List<string> { "1144201745", "1144201745" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
        }

        [TestMethod]
        public void StreamParsinAcceptIntWithMisMatchLength()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x02, 0x04, 0x44, 0x33, 0x22, 0x03, 0x05, 0x61, 0x62, 0x63, 0x64, 0x65 };
            var expectedOutput = new List<string> { "1144201745", "1442017208", "abcde" };
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var parseddata = parser.ProcessStream();
            Assert.IsTrue(parseddata.SequenceEqual(expectedOutput));
        }
    }
}
