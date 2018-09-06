using ICPOS.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmRoleController : AdmBaseController
    {
        // GET: Admin/AdmRole
        public ActionResult Index()
        {
            return View();
        }

        //RoleHandle
        public ActionResult RoleHandle()
        {
            if (GetQuerystring("Role_ID") != null)
            {
                int userid = int.Parse(GetQuerystring("Role_ID"));
                if (new ICPOS.EntityFramwork.BLL.Role().Exists(userid))
                {
                    ICPOS.EntityFramwork.Model.Role MRole = new ICPOS.EntityFramwork.BLL.Role().GetModel(userid);
                    ViewBag.RoleMod = MRole;
                }
            }
            return View();
        }

        public ActionResult RoleAuthorize()
        {
            return View();
        }

        //-------- ajax --------

        #region 获取用户角色列表
        public string GetRoleList()
        {
            ResultJson res = new ResultJson();
            string sql = "select * from Role where Role_Priv_Level=1";
            IList<ICPOS.EntityFramwork.Model.Role> MRole = DbHelperSQL.GetList<ICPOS.EntityFramwork.Model.Role>(sql);
            if (MRole != null)
            {
                res.code = "0";
                res.msg = "成功";
                res.count = MRole.Count.ToString();
                res.data = MRole;
            }
            else
            {
                res.code = "1";
                res.msg = "失败";
            }
            return JsonConvert.SerializeObject(res);
        }
        #endregion

        #region 删除一条数据
        [HttpPost]
        public string Delete()
        {
            ResultJson res = new ResultJson();
            if (!string.IsNullOrEmpty(GetQuerystring("Role_ID")))
            {
                int roleid = int.Parse(GetQuerystring("Role_ID"));
                if (new ICPOS.EntityFramwork.BLL.Role().Exists(roleid))
                {
                    bool check = new ICPOS.EntityFramwork.BLL.Role().Delete(roleid);
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

        #region 添加或修改
        [HttpPost]
        public string AddOrUpd()
        {
            ResultJson res = new ResultJson();
            if (!string.IsNullOrEmpty(GetQuerystring("Role_Name")) && !string.IsNullOrEmpty(GetQuerystring("Role_Description")) && !string.IsNullOrEmpty(GetQuerystring("Authids")))
            {
                ICPOS.EntityFramwork.Model.Role MRole = new EntityFramwork.Model.Role();
                MRole.Role_Name = GetQuerystring("Role_Name");
                MRole.Role_Description = GetQuerystring("Role_Description");
                string Authorized = GetQuerystring("Authids");
                if (!string.IsNullOrEmpty(GetQuerystring("ID")))
                {
                    bool check = new ICPOS.EntityFramwork.BLL.Role().Update(MRole);
                    if (check)
                    {
                        res.code = "0";
                        res.msg = "修改成功";
                    }
                    else
                    {
                        res.code = "-1";
                        res.msg = "请稍后重试";
                    }
                }
                else
                {
                    int check = new ICPOS.EntityFramwork.BLL.Role().Add(MRole);
                    if (check > 0)
                    {
                        if (AuthorizedAdd(check,Authorized))
                        {
                            res.code = "0";
                            res.msg = "添加成功";
                        }
                        else
                        {
                            new ICPOS.EntityFramwork.BLL.Role().Delete(check);
                            res.code = "-1";
                            res.msg = "请稍后重试";
                        }
                    }
                    else
                    {
                        res.code = "-1";
                        res.msg = "请稍后重试";
                    }
                }
            }
            else
            {
                res.code = "1";
                res.msg = "参数有误";
            }
            return JsonConvert.SerializeObject(res);
        }
        //权限添加
        public bool AuthorizedAdd(int roleid, string moduleid)
        {
            bool res = false;
            if (roleid > 0 && moduleid != null && moduleid != "")
            {
                ICPOS.EntityFramwork.BLL.Authorized BAuthorized = new EntityFramwork.BLL.Authorized();
                ICPOS.EntityFramwork.Model.Authorized MAuthorized = new EntityFramwork.Model.Authorized();
                MAuthorized.Role_ID = roleid;
                MAuthorized.Module_ID = moduleid;
                if (BAuthorized.Add(MAuthorized)>1)
                {
                    res = true;
                }
            }

            return res;
        }
        #endregion
    }
}