using ICPOS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICPOS.EntityFramwork.Model;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmMenuController : AdmBaseController
    {
        // GET: Admin/AdmMenu
        public ActionResult Index()
        {
            return View();
        }

        #region Ajax
        public ActionResult GetMenuBar()
        {
            string sql = "select * from Module";
            IList<Module> menuList = DbHelperSQL.GetList<Module>(sql);
            if (menuList!=null)
            {
                ViewBag.MenuList = menuList;
            }
            return View();
        }
        #endregion
    }
}