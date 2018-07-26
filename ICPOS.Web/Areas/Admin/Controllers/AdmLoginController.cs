using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICPOS.Common;
using ICPOS.EntityFramwork.BLL;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmLoginController : Controller
    {
        // GET: Admin/AdmLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        #region ajax
        [HttpPost]
        public string Login(string loginname, string password)
        {
            string o = null;
            if (!string.IsNullOrEmpty(loginname) &&!string.IsNullOrEmpty(password))
            {
                string sql = "select Top 1 GUID from Users where LoginName='" + loginname + "' and Password='" + password + "'";
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if (dt!=null&&dt.Rows.Count>0)
                {
                    Session["UserGUID"] = dt.Rows[0]["GUID"].ToString();
                    o = dt.Rows[0]["GUID"].ToString();
                }
            }
            return o == null ? "123" : o;
        }
        #endregion
    }
}