using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmHomeController : AdmBaseController
    {
        // GET: Admin/AdmHome
        public ActionResult Index()
        {
            return View();
        }
    }
}