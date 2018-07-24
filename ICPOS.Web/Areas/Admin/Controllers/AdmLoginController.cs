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
        public ActionResult CheckLogin(string username,string password)
        {

            return RedirectToAction("Index", RouteData.Values);
        }
        #endregion
    }
}