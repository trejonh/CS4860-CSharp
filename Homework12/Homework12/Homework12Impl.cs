using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework12
{
    public static class Homework12Impl
    {
        public static User FindUserById(int userId)
        {
            return StackOverflowSupport.Users.FirstOrDefault(usr=>usr.UserId == userId);
        }

        public static DateTime FindMostRecentLogin()
        {
            return StackOverflowSupport.Users.OrderBy(user => user.LastAccessDate).Last().LastAccessDate;
        }

        public static Comment FindLongestComment()
        {
            return StackOverflowSupport.Comments.OrderBy(comment => comment.Chars).Last();
        }

        public static int NumberOfUsersWithBadge(string name)
        {
            return
                StackOverflowSupport.Badges.GroupBy(x => x.UserId)
                    .Select(y => y.Last())
                    .Count(badge => badge.Name == name);
        }

        public static IEnumerable<Post> PageOfPostsSortedByUserIdFollowedByScore(int pageNumber, int pageSize)
        {
            return
                StackOverflowSupport.Posts.SkipWhile(post => post.UserId < pageNumber && post.Chars < pageSize)
                    .AsEnumerable();
        }
    }
}
