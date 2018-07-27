using ICPOS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt!=null&&dt.Rows.Count>0)
            {
                ViewBag.MenuList = dt;
            }
            return View();
        }
        #endregion
    }
}