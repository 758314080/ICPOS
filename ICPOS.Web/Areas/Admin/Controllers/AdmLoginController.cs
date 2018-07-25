using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmLoginController : Controller
    {
        // GET: Admin/AdmLogin
        public ActionResult Index()
        {
            return View();
        }



        #region ajax
        [HttpPost]
        public void CheckLogin()
        {
            if (string.IsNullOrEmpty(Request["username"].ToString()) &&string.IsNullOrEmpty(Request["password"].ToString()))
            {
                string username = Request["username"].ToString();
                string password = Request["password"].ToString();
            }
            else
            {
            }  
        }
        #endregion
    }
}