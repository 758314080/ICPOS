using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICPOS.Common;
using Newtonsoft.Json;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmUsersController : AdmBaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult UsersList()
        {
            return View();
        }

        public ActionResult UsersAdd()
        {
            if (GetQuerystring("Users_ID")!=null)
            {
                int userid = int.Parse(GetQuerystring("Users_ID"));
                if (new ICPOS.EntityFramwork.BLL.Users().Exists(userid))
                {
                    ICPOS.EntityFramwork.Model.Users MUsers = new ICPOS.EntityFramwork.BLL.Users().GetModel(userid);
                    ViewBag.UsersMod = MUsers;
                }
            }
            return View();
        }

        #region ajax

        #region Login
        [HttpPost]
        //登录校验
        public string Login(string loginname, string password)
        {
            ResultJson res = new ResultJson();
            if (!string.IsNullOrEmpty(loginname) && !string.IsNullOrEmpty(password))
            {
                string sql = "select Top 1 GUID from Users where LoginName='" + loginname + "' and Password='" + password + "'";
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["UserGUID"] = dt.Rows[0]["GUID"].ToString();
                    res.code = "0";
                    res.msg = "登录成功";
                }
                else
                {
                    res.code = "1";
                    res.msg = "账号或密码错误";
                }
            }
            return JsonConvert.SerializeObject(res);
        }
        #endregion

        #region UserList
        //获取用户列表
        public string GetUsersList()
        {
            ResultJson res = new ResultJson();
            string sql = "select u.Users_ID,r.Role_Name,u.Name,u.Phone,u.Email,u.CreateDate,u.Status,u.Note from Users u left join Role r on u.Role_ID=r.Role_ID";
            IList<ICPOS.Service.Dto.UserListDto> menuList = DbHelperSQL.GetList<ICPOS.Service.Dto.UserListDto>(sql);
            if (menuList != null)
            {
                res.code = "0";
                res.msg = "成功";
                res.count = menuList.Count().ToString();
                res.data = menuList;
            }
            else
            {
                res.code = "1";
                res.msg = "失败";
            }
            return JsonConvert.SerializeObject(res);
        }


        [HttpPost]
        public string Delete()
        {
            ResultJson res = new ResultJson();
            if (!string.IsNullOrEmpty(GetQuerystring("Users_ID")))
            {
                int userid = int.Parse(GetQuerystring("Users_ID"));
                if (new ICPOS.EntityFramwork.BLL.Users().Exists(userid))
                {
                    bool check = new ICPOS.EntityFramwork.BLL.Users().Delete(userid);
                    if (check)
                    {
                        res.code = "0";
                        res.msg = "删除成功";
                    }
                    else
                    {
                        res.code = "-1";
                        res.msg = "请稍后重试";
                    }
                }
                else
                {
                    res.code = "2";
                    res.msg = "已删除";
                }
            }
            else
            {
                res.code = "1";
                res.msg = "参数有误";
            }
            return JsonConvert.SerializeObject(res);
        }
        #endregion

        #region UserAdd
        //获取用户角色列表
        public string GetRoleList()
        {
            ResultJson res = new ResultJson();
            string sql = "select * from Role where Role_Priv_Level=1";
            IList<ICPOS.EntityFramwork.Model.Role> MRole = DbHelperSQL.GetList<ICPOS.EntityFramwork.Model.Role>(sql);
            if (MRole != null)
            {
                res.code = "0";
                res.msg = "成功";
                res.count = "10";
                res.data = MRole;
            }
            else
            {
                res.code = "1";
                res.msg = "失败";
            }
            return JsonConvert.SerializeObject(res);
        }

        [HttpPost]
        public string Add()
        {
            ResultJson res = new ResultJson();
            if (!string.IsNullOrEmpty(GetQuerystring("LoginName")) && !string.IsNullOrEmpty(GetQuerystring("PassWord")) && !string.IsNullOrEmpty(GetQuerystring("RoleName")) && !string.IsNullOrEmpty(GetQuerystring("Name")) && !string.IsNullOrEmpty(GetQuerystring("Phone")) && !string.IsNullOrEmpty(GetQuerystring("Email")))
            {
                ICPOS.EntityFramwork.Model.Users MUsers = new EntityFramwork.Model.Users();
                MUsers.GUID = new Guid().ToString();
                MUsers.LoginName = GetQuerystring("LoginName");
                MUsers.Password = GetQuerystring("PassWord");
                MUsers.Role_ID = int.Parse(GetQuerystring("RoleName"));
                MUsers.Name = GetQuerystring("Name");
                MUsers.Phone = GetQuerystring("Phone");
                MUsers.Email = GetQuerystring("Email");
                MUsers.Status = GetQuerystring("Status") == null ? 0 : int.Parse(GetQuerystring("Status"));
                int check = new ICPOS.EntityFramwork.BLL.Users().Add(MUsers);
                if (check > 0)
                {
                    res.code = "0";
                    res.msg = "添加成功";
                }
                else
                {
                    res.code = "-1";
                    res.msg = "请稍后重试";
                }
            }
            else
            {
                res.code = "1";
                res.msg = "参数有误";
            }
            return JsonConvert.SerializeObject(res);
        }
        #endregion

        #endregion
    }
}