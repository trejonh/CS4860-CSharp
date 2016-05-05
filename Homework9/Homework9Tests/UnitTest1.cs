using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Homework9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework9Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StreamParsingWithEventsHappyPath()
        {
            int[] intsToProcess = { 1, 2, 3, 0x11223344 };
            var bytes =
            intsToProcess
            .SelectMany(x => new byte[] { 0x01, 0x04 }
            .Concat(BitConverter.GetBytes(x).Concat(new byte[] { 0x02, 0x00 })))
            .ToArray();
            bytes
            = new byte[] { 0x2, 0x01, 0xFF }.Concat(bytes).ToArray();
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var returnedValues = new List<int>();
            int errors = 0;
            parser.ElementProcessed += returnedValues.Add;
            parser.ErrorEncountered += x => errors++; // x is the element type
            var reporter = parser as IReportStatus;
            parser.ProcessStream();
            Assert.IsTrue(returnedValues.SequenceEqual(intsToProcess));
            Assert.AreEqual(intsToProcess.Length + 1, errors);
            Assert.AreEqual(errors + returnedValues.Count, reporter.RecordsProcessed);
            Assert.AreEqual(bytes.Length, reporter.BytesProcessed);
            Assert.IsTrue(reporter.TotalProcessingTime.Ticks > 0);
        }

        [TestMethod]
        public void StreamParsingWithEvents_Given3Bytyes_ReturnInt()
        {
            var bytes = new byte[] { 0x01, 0x03, 0x02, 0x05, 0x06 };
            var stream = new MemoryStream(bytes);
            var parser = new StreamProcessor(stream);
            var returnedValues = new List<int>();
            parser.ElementProcessed += returnedValues.Add;
            parser.ProcessStream();
            Assert.IsTrue(returnedValues[0] == 394498);
        }

        [TestMethod]
        public void StreamParsingWithEvents_GivenFalseLongLength_ReturnInt()
        {
            var bytes = new byte[] { 0x01, 0x04, 0x02, 0x05, 0x06 };
            var stream = new MemoryStream(bytes);
            var parser = new StreamProcessor(stream);
            var reporter = parser as IReportStatus;
            var returnedValues = new List<int>();
            parser.ElementProcessed += returnedValues.Add;
            parser.ProcessStream();
            Assert.IsTrue(returnedValues[0] == 394498);
            Assert.IsTrue(reporter.BytesProcessed == 6);
        }

        [TestMethod]
        public void StreamParsingWithEvents_GivenFalseShortLength_ReturnInt()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x02, 0x05, 0x06 };
            var stream = new MemoryStream(bytes);
            var parser = new StreamProcessor(stream);
            var reporter = parser as IReportStatus;
            var returnedValues = new List<int>();
            parser.ElementProcessed += returnedValues.Add;
            parser.ProcessStream();
            Assert.AreEqual(returnedValues[0], 1282);
            Assert.IsTrue(reporter.BytesProcessed == 5);
            Assert.IsTrue(reporter.RecordsProcessed == 2);
        }

        [TestMethod]
        public void StreamParsingWithEvents_GivenOneErrorOneInt_ReturnInt()
        {
            var bytes = new byte[] {0x02,0x02,0x01,0x05, 0x01, 0x04, 0x02, 0x05, 0x06, 0x5 };
            var stream = new MemoryStream(bytes);
            var parser = new StreamProcessor(stream);
            var reporter = parser as IReportStatus;
            var returnedValues = new List<int>();
            var errors = 0;
            parser.ElementProcessed += returnedValues.Add;
            parser.ErrorEncountered += x => errors++;
            parser.ProcessStream();
            Assert.AreEqual(84280578,returnedValues[0]);
            Assert.AreEqual(errors, 1);
            Assert.AreEqual(reporter.BytesProcessed, bytes.Length);
            Assert.AreEqual(reporter.RecordsProcessed, 2);
        }

        [TestMethod]
        public void StreamParsingWithEvents_GivenLengthOutOfRange_ReturnNothing()
        {
            var bytes = new byte[] { 0x01, 0x05, 0x02, 0x05, 0x06 ,0x5,0x1};
            var stream = new MemoryStream(bytes);
            var parser = new StreamProcessor(stream);
            var reporter = parser as IReportStatus;
            var returnedValues = new List<int>();
            parser.ElementProcessed += returnedValues.Add;
            parser.ProcessStream();
            Assert.IsTrue(returnedValues.Count==0);
            Assert.AreEqual(reporter.BytesProcessed , bytes.Length);
            Assert.AreEqual(reporter.RecordsProcessed , 1);
        }


        [TestMethod]
        public void StreamParsingWithEvents_GivenString_ReturnJustInt()
        {
            byte[] bytes = { 0x01, 0x04, 0x11, 0x22, 0x33, 0x44, 0x03, 0x05, 0x61, 0x62, 0x63,
0x64, 0x65 };
            var expectedOutput = 1144201745;
            var memStream = new MemoryStream(bytes);
            var parser = new StreamProcessor(memStream);
            var reporter = parser as IReportStatus;
            var returnedValues = new List<int>();
            var errors = 0;
            parser.ElementProcessed += returnedValues.Add;
            parser.ErrorEncountered += x => errors++;
            parser.ProcessStream();
            Assert.IsTrue(returnedValues[0] == expectedOutput);
            Assert.AreEqual(2, reporter.RecordsProcessed);
            Assert.AreEqual(bytes.Length, reporter.BytesProcessed);
            Assert.AreEqual(errors + returnedValues.Count, reporter.RecordsProcessed);
            Assert.IsTrue(reporter.TotalProcessingTime.Ticks > 0);
            Assert.AreEqual(reporter.TotalProcessingTime.Ticks/2,
            reporter.AverageProcessingTime.Ticks);
        }
    }
}
