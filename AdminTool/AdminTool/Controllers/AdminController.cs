using AdminTool.Services.Interface;
using System.Web.Mvc;

namespace AdminTool.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminServices _adminServices;
        public AdminController(IAdminServices services)
        {
            this._adminServices = services;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}