using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeApp_Test.Models.Account
{
    public class Account
    {
       public Int32 UserId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public Int32 InsertUserId { get; set; }
        public Int32 UnitID { get; set; }
        public Int32 IsActive { get; set; }

    }
    public class DashBoard
    {
       
        public String EntryDate { get; set; }
        public String Ajbapur { get; set; }
        public String Rupapur { get; set; }
        public String Hariawan { get; set; }
        public String Loni { get; set; }
       

    }
}