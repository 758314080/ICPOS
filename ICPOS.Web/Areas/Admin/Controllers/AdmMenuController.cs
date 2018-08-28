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
            return View() ;
        }

        public ActionResult MenuList()
        {
            return View();
        }

        public ActionResult MenuAdd()
        {
            return View();
        }

        #region Ajax
        //获取菜单列表
        public string GetMenuList()
        {
            ResultJson res = new ResultJson();
            string sql = "select * from Module";
            IList<Module> menuList = DbHelperSQL.GetList<Module>(sql);
            if (menuList != null)
            {
                res.code = "0";
                res.msg = "成功";
                res.count = menuList.Count.ToString();
                res.data = menuList;
            }
            else
            {
                res.code = "1";
                res.msg = "失败";
            }
            return JsonConvert.SerializeObject(res);
        }

        #region 获取导航栏
        [HttpPost]
        public string GetNavigationMenu()
        {
            string roleid = Session["Role_ID"].ToString();
            ResultJson res = new ResultJson();
            string sql = "select m.* from Authorized a left join Module m on a.Module_ID=m.Module_ID where Role_ID='" + roleid + "'";
            IList<Module> modules = DbHelperSQL.GetList<Module>(sql);
            if (modules!=null)
            {
                res.code = "0";
                res.msg = "成功";
                res.count = modules.Count.ToString();
                res.data = modules;
            }
            else
            {
                res.code = "1";
                res.msg = "失败";
            }
            return JsonConvert.SerializeObject(res);
        }
        #endregion
        #endregion
    }
}