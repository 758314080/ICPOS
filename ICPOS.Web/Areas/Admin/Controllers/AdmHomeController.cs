using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICPOS.Common;
using ICPOS.EntityFramwork.Model;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmHomeController : AdmBaseController
    {
        // GET: Admin/AdmHome
        public ActionResult Index()
        {
            string sql = "select * from Module";
            IList<Module> menuList = DbHelperSQL.GetList<Module>(sql);
            if (menuList != null)
            {
                ViewBag.MenuList = menuList;
            }
            return View();
        }
    }
}