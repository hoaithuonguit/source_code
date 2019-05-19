using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminTool.Models.DtoModel
{
    public class UserModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public bool ActivedFlag { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public DateTime? BirthDay { get; set; }
        public string UserRole { get; set; }
        public string PhoneNo { get; set; }
    }
}