using System;
using System.Collections.Generic;

namespace Homework12
{
    public class Badge
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }

    public class Comment
    {
        public int UserId { get; set; }
        public int Score { get; set; }
        public int Chars { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public DateTime LastAccessDate { get; set; }
        public int? Age { get; set; }
        public int Views { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public string Location { get; set; }
    }

    public class Post
    {
        public int UserId { get; set; }
        public int Chars { get; set; }
        public int Score { get; set; }
        public int AnswerCount { get; set; }
        public int CommentCount { get; set; }
    }

    public class StackOverflowSupport
    {

        static public IEnumerable<Post> Posts
        {
            get
            {
                return new List<Post>
                           {
                                new Post{UserId=1013	, Chars=1703	,Score=55	, AnswerCount=29	,CommentCount=3},
                                new Post{UserId=1031	, Chars=586	,Score=25	, AnswerCount=4	,CommentCount=1},
                                new Post{UserId=1042	, Chars=1467	,Score=5	, AnswerCount=3	,CommentCount=2},
                                new Post{UserId=1013	, Chars=575	,Score=1	, AnswerCount=2	,CommentCount=1},
                                new Post{UserId=1030	, Chars=854	,Score=3	, AnswerCount=6	,CommentCount=1},
                                new Post{UserId=1030	, Chars=1428	,Score=29	, AnswerCount=15	,CommentCount=1},
                                new Post{UserId=1036	, Chars=546	,Score=23	, AnswerCount=11	,CommentCount=1},
                                new Post{UserId=1013	, Chars=268	,Score=1	, AnswerCount=10	,CommentCount=3},
                                new Post{UserId=1006	, Chars=491	,Score=8	, AnswerCount=8	,CommentCount=1},
                                new Post{UserId=1013	, Chars=185	,Score=2	, AnswerCount=17	,CommentCount=0},
                                new Post{UserId=1037	, Chars=1509	,Score=6	, AnswerCount=14	,CommentCount=0},
                                new Post{UserId=1043	, Chars=855	,Score=158	, AnswerCount=24	,CommentCount=0},
                                new Post{UserId=1039	, Chars=1055	,Score=5	, AnswerCount=8	,CommentCount=1},
                                new Post{UserId=1044	, Chars=739	,Score=6	, AnswerCount=7	,CommentCount=1},
                                new Post{UserId=1048	, Chars=1249	,Score=6	, AnswerCount=7	,CommentCount=1},
                                new Post{UserId=1037	, Chars=2724	,Score=82	, AnswerCount=20	,CommentCount=2},
                                new Post{UserId=1008	, Chars=270	,Score=12	, AnswerCount=8	,CommentCount=4},
                                new Post{UserId=1008	, Chars=1030	,Score=8	, AnswerCount=8	,CommentCount=1},
                                new Post{UserId=1013	, Chars=90	,Score=4	, AnswerCount=5	,CommentCount=3},
                                new Post{UserId=1048	, Chars=739	,Score=7	, AnswerCount=7	,CommentCount=0},
                                new Post{UserId=1042	, Chars=1020	,Score=12	, AnswerCount=6	,CommentCount=3},
                                new Post{UserId=1043	, Chars=988	,Score=3	, AnswerCount=3	,CommentCount=1},
                                new Post{UserId=1031	, Chars=1006	,Score=59	, AnswerCount=6	,CommentCount=3},
                                new Post{UserId=1048	, Chars=1130	,Score=1	, AnswerCount=2	,CommentCount=1},
                                new Post{UserId=1030	, Chars=506	,Score=4	, AnswerCount=4	,CommentCount=1},
                                new Post{UserId=1048	, Chars=683	,Score=10	, AnswerCount=10	,CommentCount=2},
                                new Post{UserId=1013	, Chars=237	,Score=4	, AnswerCount=3	,CommentCount=1},
                                new Post{UserId=1038	, Chars=979	,Score=28	, AnswerCount=22	,CommentCount=2},
                                new Post{UserId=1006	, Chars=898	,Score=5	, AnswerCount=4	,CommentCount=4},
                                new Post{UserId=1038	, Chars=2937	,Score=3	, AnswerCount=4	,CommentCount=2},
                                new Post{UserId=1025	, Chars=1443	,Score=4	, AnswerCount=2	,CommentCount=3},
                                new Post{UserId=1030	, Chars=880	,Score=1	, AnswerCount=2	,CommentCount=1},
                                new Post{UserId=1043	, Chars=375	,Score=38	, AnswerCount=9	,CommentCount=1},
                                new Post{UserId=1048	, Chars=713	,Score=3	, AnswerCount=4	,CommentCount=5},
                                new Post{UserId=1048	, Chars=1867	,Score=3	, AnswerCount=1	,CommentCount=1},
                                new Post{UserId=1048	, Chars=2623	,Score=7	, AnswerCount=6	,CommentCount=1},
                                new Post{UserId=1030	, Chars=958	,Score=7	, AnswerCount=9	,CommentCount=4},
                                new Post{UserId=1019	, Chars=1079	,Score=15	, AnswerCount=6	,CommentCount=1},
                                new Post{UserId=1019	, Chars=1061	,Score=9	, AnswerCount=9	,CommentCount=0},
                                new Post{UserId=1011	, Chars=876	,Score=11	, AnswerCount=4	,CommentCount=4},
                                new Post{UserId=1011	, Chars=802	,Score=0	, AnswerCount=7	,CommentCount=1},
                                new Post{UserId=1043	, Chars=397	,Score=2	, AnswerCount=3	,CommentCount=1},
                                new Post{UserId=1010	, Chars=1590	,Score=11	, AnswerCount=9	,CommentCount=3},
                                new Post{UserId=1007	, Chars=475	,Score=10	, AnswerCount=17	,CommentCount=10},
                                new Post{UserId=1039	, Chars=1125	,Score=4	, AnswerCount=3	,CommentCount=2},
                                new Post{UserId=1011	, Chars=849	,Score=205	, AnswerCount=10	,CommentCount=7},
                                new Post{UserId=1038	, Chars=1436	,Score=6	, AnswerCount=4	,CommentCount=2},
                                new Post{UserId=1030	, Chars=355	,Score=0	, AnswerCount=1	,CommentCount=3},
                                new Post{UserId=1014	, Chars=413	,Score=55	, AnswerCount=11	,CommentCount=3},
                                new Post{UserId=1043	, Chars=1940	,Score=14	, AnswerCount=11	,CommentCount=4},
                           };
            }
        }

        static public IEnumerable<User> Users
        {
            get
            {
                return new List<User>
                           {
                                new User { UserId=1046, DisplayName="BrianWhitlock", LastAccessDate=DateTime.Parse("9/20/2012 16:18"), Age=45, Views=14, UpVotes=6, DownVotes=0, Location="Bolivia, NC"},
                                new User { UserId=1008, DisplayName="Marius", LastAccessDate=DateTime.Parse("4/12/2013 15:43"), Age=42, Views=185, UpVotes=129, DownVotes=2, Location="United Kingdom"},
                                new User { UserId=1019, DisplayName="JPLemme", LastAccessDate=DateTime.Parse("12/2/2011 4:24"), Age=42, Views=307, UpVotes=297, DownVotes=1, Location="	Rhode Island"},
                                new User { UserId=1031, DisplayName="JoeLudwig", LastAccessDate=DateTime.Parse("4/3/2013 2:26"), Age=42, Views=109, UpVotes=75, DownVotes=3, Location="United States"},
                                new User { UserId=1002, DisplayName="msanders", LastAccessDate=DateTime.Parse("4/12/2013 14:57"), Age=41, Views=172, UpVotes=235, DownVotes=2, Location="United Kingdom"},
                                new User { UserId=1005, DisplayName="AndreaBertani", LastAccessDate=DateTime.Parse("11/22/2012 9:25"), Age=40, Views=93, UpVotes=22, DownVotes=0, Location="Italy"},
                                new User { UserId=1025, DisplayName="JamesMarshall", LastAccessDate=DateTime.Parse("4/10/2013 13:15"), Age=38, Views=48, UpVotes=74, DownVotes=1, Location="	United Kingdom"},
                                new User { UserId=1006, DisplayName="Rob", LastAccessDate=DateTime.Parse("4/13/2013 20:10"), Age=36, Views=57, UpVotes=68, DownVotes=6, Location="United Kingdom"},
                                new User { UserId=1043, DisplayName="AndrewGrant", LastAccessDate=DateTime.Parse("9/24/2011 7:57"), Age=36, Views=1240, UpVotes=546, DownVotes=5, Location="1	Los Angeles, CA"},
                                new User { UserId=1048, DisplayName="KeithSirmons", LastAccessDate=DateTime.Parse("4/12/2013 20:22"), Age=36, Views=311, UpVotes=258, DownVotes=4, Location="Houston, TX"},
                                new User { UserId=1027, DisplayName="MikeRegan", LastAccessDate=DateTime.Parse("4/13/2013 17:50"), Age=35, Views=161, UpVotes=213, DownVotes=1, Location="United States"},
                                new User { UserId=1009, DisplayName="jassuncao", LastAccessDate=DateTime.Parse("4/12/2013 17:00"), Age=34, Views=216, UpVotes=137, DownVotes=1, Location="	Portugal"},
                                new User { UserId=1016, DisplayName="RoryMacLeod", LastAccessDate=DateTime.Parse("4/13/2013 17:21"), Age=34, Views=73, UpVotes=334, DownVotes=1, Location="	Glasgow, United Kingdom"},
                                new User { UserId=1039, DisplayName="d4nt", LastAccessDate=DateTime.Parse("4/13/2013 19:50"), Age=34, Views=196, UpVotes=128, DownVotes=4, Location="Birmingham, United Kingdom"},
                                new User { UserId=1013, DisplayName="ArturCarvalho", LastAccessDate=DateTime.Parse("4/13/2013 22:04"), Age=33, Views=313, UpVotes=1281, DownVotes=1, Location="	Luxembourg"},
                                new User { UserId=1042, DisplayName="AidanRyan", LastAccessDate=DateTime.Parse("4/12/2013 18:34"), Age=33, Views=342, UpVotes=1103, DownVotes=1, Location="3	Alameda, CA"},
                                new User { UserId=1011, DisplayName="yoavf", LastAccessDate=DateTime.Parse("4/11/2013 20:55"), Age=32, Views=190, UpVotes=530, DownVotes=9, Location="Israel"},
                                new User { UserId=1014, DisplayName="Leonardo", LastAccessDate=DateTime.Parse("4/3/2013 23:16"), Age=32, Views=85, UpVotes=183, DownVotes=9, Location="Sydney, Australia"},
                                new User { UserId=1030, DisplayName="ninesided", LastAccessDate=DateTime.Parse("4/13/2013 21:11"), Age=31, Views=439, UpVotes=1087, DownVotes=6, Location="	Edinburgh, United Kingdom"},
                                new User { UserId=1035, DisplayName="GaryF", LastAccessDate=DateTime.Parse("4/13/2013 21:28"), Age=30, Views=310, UpVotes=731, DownVotes=3, Location="	Glasgow, United Kingdom"},
                                new User { UserId=1007, DisplayName="Serge", LastAccessDate=DateTime.Parse("4/12/2013 13:14"), Age=29, Views=208, UpVotes=160, DownVotes=5, Location="France"},
                                new User { UserId=1044, DisplayName="GrégoireCachet", LastAccessDate=DateTime.Parse("6/21/2011 6:22"), Age=29, Views=135, UpVotes=55, DownVotes=2, Location="France"},
                                new User { UserId=1034, DisplayName="bastibe", LastAccessDate=DateTime.Parse("4/13/2013 18:31"), Age=28, Views=231, UpVotes=702, DownVotes=8, Location="Germany"},
                                new User { UserId=1024, DisplayName="Armandas", LastAccessDate=DateTime.Parse("4/7/2013 14:42"), Age=26, Views=94, UpVotes=69, DownVotes=1, Location="United Kingdom"},
                                new User { UserId=1026, DisplayName="Nickolay", LastAccessDate=DateTime.Parse("4/11/2013 21:00"), Age=26, Views=1780, UpVotes=1450, DownVotes=1, Location="2	Moscow, Russia"},
                                new User { UserId=1003, DisplayName="frizz", LastAccessDate=DateTime.Parse("3/8/2011 23:43"), Age=null, Views=66, UpVotes=6, DownVotes=0, Location="Australia"},
                                new User { UserId=1010, DisplayName="DamianHickey", LastAccessDate=DateTime.Parse("4/10/2013 13:42"), Age=null, Views=0, UpVotes=24, DownVotes=3, Location="	6	"},
                                new User { UserId=1012, DisplayName="simonlord", LastAccessDate=DateTime.Parse("4/8/2013 18:45"), Age=null, Views=37, UpVotes=111, DownVotes=0, Location="United Kingdom"},
                                new User { UserId=1023, DisplayName="Gokul", LastAccessDate=DateTime.Parse("4/7/2013 2:35"), Age=null, Views=6, UpVotes=1, DownVotes=0, Location="Indiana"},
                                new User { UserId=1028, DisplayName="DannySmurf", LastAccessDate=DateTime.Parse("8/11/2008 16:03"), Age=null, Views=16, UpVotes=0, DownVotes=0, Location=""},
                                new User { UserId=1036, DisplayName="Judioo", LastAccessDate=DateTime.Parse("4/13/2013 11:31"), Age=null, Views=56, UpVotes=73, DownVotes=2, Location="London, United Kingdom / New York, New York"},
                                new User { UserId=1037, DisplayName="onnodb", LastAccessDate=DateTime.Parse("4/12/2013 12:49"), Age=null, Views=227, UpVotes=1043, DownVotes=7, Location="	Netherlands"},
                                new User { UserId=1038, DisplayName="maerch", LastAccessDate=DateTime.Parse("4/12/2013 8:18"), Age=null, Views=74, UpVotes=102, DownVotes=1, Location="Delaware"},
                                new User { UserId=1047, DisplayName="wordmonger", LastAccessDate=DateTime.Parse("10/19/2012 16:54"), Age=null, Views=12, UpVotes=34, DownVotes=0, Location=""},
                           };
            }
        }

        static public IEnumerable<Comment> Comments
        {
            get
            {
                return new List<Comment>
                           {
                                new Comment {UserId=1007	,Score=1	,Chars=118	,CreationDate=DateTime.Parse("9/11/2008 7:10")},
                                new Comment {UserId=1026	,Score=1	,Chars=118	,CreationDate=DateTime.Parse("9/16/2008 9:44")},
                                new Comment {UserId=1011	,Score=1	,Chars=45	,CreationDate=DateTime.Parse("9/16/2008 14:27")},
                                new Comment {UserId=1007	,Score=1	,Chars=102	,CreationDate=DateTime.Parse("9/19/2008 8:23")},
                                new Comment {UserId=1026	,Score=1	,Chars=114	,CreationDate=DateTime.Parse("10/5/2008 15:08")},
                                new Comment {UserId=1042	,Score=1	,Chars=110	,CreationDate=DateTime.Parse("10/8/2008 19:46")},
                                new Comment {UserId=1030	,Score=1	,Chars=93	,CreationDate=DateTime.Parse("10/9/2008 23:45")},
                                new Comment {UserId=1037	,Score=1	,Chars=127	,CreationDate=DateTime.Parse("10/10/2008 16:20")},
                                new Comment {UserId=1042	,Score=3	,Chars=139	,CreationDate=DateTime.Parse("10/10/2008 22:13")},
                                new Comment {UserId=1042	,Score=2	,Chars=83	,CreationDate=DateTime.Parse("10/14/2008 18:53")},
                                new Comment {UserId=1034	,Score=1	,Chars=95	,CreationDate=DateTime.Parse("10/20/2008 14:10")},
                                new Comment {UserId=1037	,Score=1	,Chars=124	,CreationDate=DateTime.Parse("10/20/2008 16:10")},
                                new Comment {UserId=1030	,Score=6	,Chars=51	,CreationDate=DateTime.Parse("10/20/2008 21:44")},
                                new Comment {UserId=1042	,Score=3	,Chars=119	,CreationDate=DateTime.Parse("10/21/2008 0:40")},
                                new Comment {UserId=1042	,Score=1	,Chars=270	,CreationDate=DateTime.Parse("10/22/2008 2:16")},
                                new Comment {UserId=1037	,Score=2	,Chars=104	,CreationDate=DateTime.Parse("10/29/2008 18:26")},
                                new Comment {UserId=1030	,Score=2	,Chars=61	,CreationDate=DateTime.Parse("10/29/2008 22:40")},
                                new Comment {UserId=1013	,Score=1	,Chars=35	,CreationDate=DateTime.Parse("10/30/2008 21:36")},
                                new Comment {UserId=1002	,Score=1	,Chars=160	,CreationDate=DateTime.Parse("11/3/2008 11:24")},
                                new Comment {UserId=1048	,Score=2	,Chars=131	,CreationDate=DateTime.Parse("11/5/2008 23:07")},
                                new Comment {UserId=1042	,Score=1	,Chars=153	,CreationDate=DateTime.Parse("11/11/2008 0:43")},
                                new Comment {UserId=1030	,Score=1	,Chars=226	,CreationDate=DateTime.Parse("11/13/2008 10:34")},
                                new Comment {UserId=1030	,Score=6	,Chars=60	,CreationDate=DateTime.Parse("11/13/2008 20:42")},
                                new Comment {UserId=1025	,Score=1	,Chars=89	,CreationDate=DateTime.Parse("11/14/2008 10:13")},
                                new Comment {UserId=1030	,Score=1	,Chars=162	,CreationDate=DateTime.Parse("11/20/2008 4:41")},
                                new Comment {UserId=1037	,Score=7	,Chars=211	,CreationDate=DateTime.Parse("11/24/2008 20:38")},
                                new Comment {UserId=1007	,Score=1	,Chars=43	,CreationDate=DateTime.Parse("12/9/2008 8:11")},
                                new Comment {UserId=1037	,Score=3	,Chars=209	,CreationDate=DateTime.Parse("12/10/2008 17:47")},
                                new Comment {UserId=1048	,Score=0	,Chars=66	,CreationDate=DateTime.Parse("12/18/2008 14:56")},
                                new Comment {UserId=1030	,Score=2	,Chars=167	,CreationDate=DateTime.Parse("12/19/2008 22:50")},
                                new Comment {UserId=1043	,Score=11	,Chars=295	,CreationDate=DateTime.Parse("1/2/2009 8:19")},
                                new Comment {UserId=1010	,Score=1	,Chars=108	,CreationDate=DateTime.Parse("1/5/2009 14:41")},
                                new Comment {UserId=1042	,Score=1	,Chars=24	,CreationDate=DateTime.Parse("1/6/2009 12:48")},
                                new Comment {UserId=1002	,Score=5	,Chars=122	,CreationDate=DateTime.Parse("1/7/2009 10:53")},
                                new Comment {UserId=1002	,Score=1	,Chars=112	,CreationDate=DateTime.Parse("1/7/2009 11:15")},
                                new Comment {UserId=1002	,Score=1	,Chars=201	,CreationDate=DateTime.Parse("1/8/2009 11:38")},
                                new Comment {UserId=1048	,Score=2	,Chars=35	,CreationDate=DateTime.Parse("1/9/2009 19:52")},
                                new Comment {UserId=1030	,Score=1	,Chars=128	,CreationDate=DateTime.Parse("1/13/2009 21:36")},
                                new Comment {UserId=1030	,Score=2	,Chars=291	,CreationDate=DateTime.Parse("1/14/2009 3:47")},
                                new Comment {UserId=1035	,Score=1	,Chars=104	,CreationDate=DateTime.Parse("1/23/2009 10:05")},
                                new Comment {UserId=1042	,Score=1	,Chars=207	,CreationDate=DateTime.Parse("1/27/2009 18:52")},
                                new Comment {UserId=1043	,Score=1	,Chars=146	,CreationDate=DateTime.Parse("1/28/2009 0:59")},
                                new Comment {UserId=1011	,Score=1	,Chars=194	,CreationDate=DateTime.Parse("1/28/2009 13:40")},
                                new Comment {UserId=1008	,Score=1	,Chars=67	,CreationDate=DateTime.Parse("2/4/2009 8:57")},
                                new Comment {UserId=1031	,Score=14	,Chars=176	,CreationDate=DateTime.Parse("2/7/2009 2:51")},
                                new Comment {UserId=1011	,Score=1	,Chars=21	,CreationDate=DateTime.Parse("2/8/2009 11:37")},
                                new Comment {UserId=1030	,Score=2	,Chars=139	,CreationDate=DateTime.Parse("2/11/2009 8:43")},
                                new Comment {UserId=1037	,Score=1	,Chars=32	,CreationDate=DateTime.Parse("2/11/2009 15:39")},
                                new Comment {UserId=1009	,Score=1	,Chars=75	,CreationDate=DateTime.Parse("2/12/2009 11:18")},
                                new Comment {UserId=1043	,Score=1	,Chars=102	,CreationDate=DateTime.Parse("2/12/2009 23:56")},
                           };
            }
        }


        static public IEnumerable<Badge> Badges 
        {
            get
            {
                return new List<Badge>
                           {
                               new Badge {UserId = 1048, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1028, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1005, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1044, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1036, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1026, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1030, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1010, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1023, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1007, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1035, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1025, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1011, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1043, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1046, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1039, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1013, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1008, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1014, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1016, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1111, Name = "Hacker",  Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1047, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1111, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1006, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1009, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1037, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1042, Name = "Teacher", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1048, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1003, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1044, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1111, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1036, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1026, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1030, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1019, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1010, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1007, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1035, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1025, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1034, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1011, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1043, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1039, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1013, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1008, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1014, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1016, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1027, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1006, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1037, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                               new Badge {UserId = 1042, Name = "Student", Date = DateTime.Parse("9/15/2008 8:55")},
                           };
            }
        }
    }
}