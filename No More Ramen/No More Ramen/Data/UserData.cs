using System;
namespace No_More_Ramen.Data
{
    public class UserData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string College { get; set; }
        public string Gender { get; set; }
    }
}
