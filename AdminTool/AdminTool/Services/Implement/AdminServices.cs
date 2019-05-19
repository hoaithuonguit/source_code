using AdminTool.Models.DtoModel;
using AdminTool.Models.Entity;
using AdminTool.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminTool.Services.Implement
{
    public class AdminServices : IAdminServices
    {
        private AdminToolEntities _dbContext { get; set; }
        public AdminServices()
        {
            _dbContext = new AdminToolEntities();
        }
        public List<UserModel> GetListUser()
        {
            using (_dbContext)
            {
                return (from p in _dbContext.Users
                            join d in _dbContext.UserDetails on p.ID equals d.ID
                            join r in _dbContext.MstUserRoles on p.ID equals r.ID
                            where p.ActiveFlag == 1
                            select new UserModel()
                            {
                                FullName = d.FullName,
                                Email = d.Email,
                                PhoneNo = d.PhoneNo,
                                BirthDay = d.BirthDay,
                                UserRole = r.Role,
                                CreatedDt = p.CreatedDt,
                                UpdatedDt = p.UpdatedDt
                            }).ToList();
            }
        }
    }
}