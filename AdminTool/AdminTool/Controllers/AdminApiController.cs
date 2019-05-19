using AdminTool.Models.JsonModel;
using AdminTool.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
//using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace AdminTool.Controllers
{
    public class AdminApiController : Controller
    {
        private readonly IAdminServices _service;
        public AdminApiController(IAdminServices services)
        {
            this._service = services;
        }
        
        public ActionResult ListAllUser()
        {
            var result = _service.GetListUser();
            int totalData = result.Count;
            if (totalData > 0)
            {
                var model = new UserJsonModel
                {
                    Have_Data = true,
                    Total_Data = totalData
                };
                List<UserModel> list = new List<UserModel>();
                UserModel _user;
                int index = 0;
                foreach (var item in result)
                {
                    index++;
                    _user = new UserModel
                    {
                        No = index,
                        FullName = item.FullName,
                        Email = item.Email,
                        PhoneNo = item.PhoneNo,
                        Role = item.UserRole
                    };
                    list.Add(_user);
                }
                model.Data = list;
                var jsonResult = new JsonResult
                {
                    Data = model,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}
