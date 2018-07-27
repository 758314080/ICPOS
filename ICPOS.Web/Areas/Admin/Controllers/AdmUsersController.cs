using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICPOS.Common;
using ICPOS.EntityFramwork.BLL;
using Newtonsoft.Json;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmUsersController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        #region ajax
        [HttpPost]
        public string Login(string loginname, string password)
        {
            ResultJson res = new ResultJson();
            if (!string.IsNullOrEmpty(loginname) &&!string.IsNullOrEmpty(password))
            {
                string sql = "select Top 1 GUID from Users where LoginName='" + loginname + "' and Password='" + password + "'";
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if (dt!=null&&dt.Rows.Count>0)
                {
                    Session["UserGUID"] = dt.Rows[0]["GUID"].ToString();
                    res.Code = 1;
                    res.Msg = "登录成功";
                }
                else
                {
                    res.Code = 0;
                    res.Msg = "账号或密码错误";
                }
            }
            return JsonConvert.SerializeObject(res);
        }
        #endregion
    }
}