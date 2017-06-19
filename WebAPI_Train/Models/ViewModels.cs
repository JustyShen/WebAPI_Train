using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Train.Models
{
    public class User
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }

    public class Login
    { 
        public string uid { get; set; } 
        public string pwd { get; set; } 
    }

    public class Group
    {
        public int id { get; set; }
        public string groupName { get; set; }
        public List<User> gUsers { get; set; }
    }

    public class Chat
    {
        public int id { get; set; }
        public int groupId { get; set; }
        public User cUser { get; set; }
        public string message { get; set; } 
        public DateTime creatDate { get; set; }
    } 

}