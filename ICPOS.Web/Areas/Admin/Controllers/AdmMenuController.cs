using ICPOS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICPOS.EntityFramwork.Model;
using Newtonsoft.Json;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmMenuController : AdmBaseController
    {
        // GET: Admin/AdmMenu
        public ActionResult Index()
        {
            string sql = "select * from Module";
            IList<Module> menuList = DbHelperSQL.GetList<Module>(sql);
            if (menuList != null)
            {
                ViewBag.MenuList = menuList;
            }
            return View() ;
        }

        public ActionResult MenuList()
        {
            return View();
        }

        #region Ajax
        public string GetMenuList()
        {
            ResultJson res = new ResultJson();
            string sql = "select * from Module";
            IList<Module> menuList = DbHelperSQL.GetList<Module>(sql);
            if (menuList != null)
            {
                res.code = "0";
                res.msg = "成功";
                res.count = "10";
                res.data = menuList;
            }
            else
            {
                res.code = "1";
                res.msg = "失败";
            }
            string op = JsonConvert.SerializeObject(res);
            return JsonConvert.SerializeObject(res);
        }
        #endregion
    }
}