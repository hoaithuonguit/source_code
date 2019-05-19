using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminTool.Models.JsonModel
{
    public class UserJsonModel
    {
        public bool Have_Data { get; set; }
        public int Page { get; set; }
        public int Total_Data { get; set; }
        public List<UserModel> Data { get; set; }
    }
    public class UserModel
    {
        public int No { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}