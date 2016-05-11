using System;
using System.Linq;
using Homework12;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework12Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindUserById()
        {
            Assert.AreEqual("AidanRyan", Homework12Impl.FindUserById(1042).DisplayName);
            Assert.IsNull(Homework12Impl.FindUserById(-9999));
        }
        [TestMethod]
        public void FindMostRecentLogin()
        {
            Assert.AreEqual(new DateTime(2013, 4, 13, 22, 4, 0), Homework12Impl.FindMostRecentLogin());
        }
        [TestMethod]
        public void FindLongestComment()
        {
            Assert.AreEqual(295, Homework12Impl.FindLongestComment().Chars);
        }

        [TestMethod]
        public void NumberOfUsersWithBadge()
        {
            Assert.AreEqual(23, Homework12Impl.NumberOfUsersWithBadge("Student")); // Yes, 23 – User must exist
        }
        [TestMethod]
        public void PageOfPostsSortedByUserIdFollowedByScore()
        {
            int pageSize = 4, pageNumber = 1;
            var thePage = Homework12Impl.PageOfPostsSortedByUserIdFollowedByScore(pageNumber, pageSize).ToList();
            Assert.AreEqual(pageSize, thePage.Count());
            Assert.AreEqual(1006, thePage[0].UserId);
            Assert.AreEqual(1008, thePage[3].UserId);
            pageSize = 2;
            pageNumber = 3;
            thePage = Homework12Impl.PageOfPostsSortedByUserIdFollowedByScore(pageNumber, pageSize).ToList();
            Assert.AreEqual(pageSize, thePage.Count);
            Assert.AreEqual(pageSize, thePage.Count());
            Assert.AreEqual(1008, thePage[0].UserId);
            Assert.AreEqual(1010, thePage[1].UserId);
        }
    }
}
