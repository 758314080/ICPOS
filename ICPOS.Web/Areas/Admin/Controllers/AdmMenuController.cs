using ICPOS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICPOS.EntityFramwork.Model;
using Newtonsoft.Json;
using ICPOS.Service.Dto.Adm_Role;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmMenuController : AdmBaseController
    {
        // GET: Admin/AdmMenu
        public ActionResult MenuList()
        {
            return View();
        }

        public ActionResult MenuAdd()
        {
            if (!string.IsNullOrEmpty(GetQuerystring("Module_ID")))
            {
                int menuid = int.Parse(GetQuerystring("Module_ID"));
                if (new ICPOS.EntityFramwork.BLL.Module().Exists(menuid))
                {
                    string sql = "select * from [ICPOS].[dbo].[Module] S where Module_ID='" + menuid + "'";
                    ICPOS.EntityFramwork.Model.Module MModule = DbHelperSQL.GetList<ICPOS.EntityFramwork.Model.Module>(sql)[0];
                    ViewBag.MenuMod = MModule;
                }
            }
            return View();
        }

        #region Ajax

        #region 获取菜单列表
        public string GetMenuList()
        {
            ResultJson res = new ResultJson();
            string sql = @"select [Module_ID],[Type],[Module_Name],[Module_Parent],[Module_Hierarchy],[Module_Level],[Module_OrderBy],[ModuleIcon_Url],[Module_TrueUrl],[Module_VirtualUrl] from Module";
            List<ICPOS.EntityFramwork.Model.Module> menuList = DbHelperSQL.GetList<ICPOS.EntityFramwork.Model.Module>(sql);
            if (menuList != null && menuList.Count > 0)
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
            string o = JsonConvert.SerializeObject(res);
            return o;
        }
        #endregion

        #region 获取一级菜单
        public string GetMenuFirst()
        {
            string res = null;
            string sql = @"select Module_ID,Module_Name from Module where Type='1' and Module_Level='1'";
            string tabjson = DbHelperSQL.DataTableConvertJson(sql, out int count);
            if (tabjson != null && tabjson != "")
            {
                res = "{\"code\":\"0\",\"msg\":\"成功\",\"count\":\"" + count + "\",\"data\":" + tabjson + "}";
            }
            else
            {
                res = "{\"code\":\"1\",\"msg\":\"失败\",\"data\":[]}";
            }
            return res;
        }
        #endregion

        #region 菜单添加或修改
        [HttpPost]
        public string AddOrUpd()
        {
            ResultJson res = new ResultJson();
            if (!string.IsNullOrEmpty(GetQuerystring("Module_Name")) && !string.IsNullOrEmpty(GetQuerystring("Module_Level")) && !string.IsNullOrEmpty(GetQuerystring("Module_OrderBy")) && !string.IsNullOrEmpty(GetQuerystring("Module_VirtualUrl")))
            {
                int id = int.Parse(GetQuerystring("Module_ID"));
                string name = GetQuerystring("Module_Name").ToString();
                string parent = GetQuerystring("Module_Parent").ToString();
                string level = GetQuerystring("Module_Level").ToString();
                string orderby = GetQuerystring("Module_OrderBy").ToString();
                string VirtualUrl = GetQuerystring("Module_VirtualUrl").ToString();
                string icon = string.IsNullOrEmpty(GetQuerystring("ModuleIcon_Url")) ? "" : GetQuerystring("ModuleIcon_Url").ToString();

                Module MModule = GetQuerystring("Module_ID").ToString() == "0" ? new Module() : new ICPOS.EntityFramwork.BLL.Module().GetModel(id);
                MModule.Type = 1;
                MModule.Module_Name = name;
                MModule.Module_Parent = level == "1" ? 0 : int.Parse(parent);
                MModule.Module_Hierarchy = level;
                MModule.Module_Level = int.Parse(level);
                MModule.Module_OrderBy = int.Parse(orderby);
                MModule.ModuleIcon_Url = icon;
                MModule.Module_TrueUrl = "";
                MModule.Module_VirtualUrl = VirtualUrl;
                if (id == 0)
                {
                    if (new ICPOS.EntityFramwork.BLL.Module().Add(MModule) > 0)
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
                    if (new ICPOS.EntityFramwork.BLL.Module().Update(MModule))
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

            }

            return JsonConvert.SerializeObject(res);
        }
        #endregion

        #region 菜单删除
        [HttpPost]
        public string MenuDel()
        {
            ResultJson res = new ResultJson();
            EntityFramwork.BLL.Module BMenu = new EntityFramwork.BLL.Module();
            string menu_id = GetQuerystring("Module_ID");
            if (!string.IsNullOrEmpty(menu_id))
            {
                int menuid = int.Parse(menu_id);
                if (BMenu.Exists(menuid))
                {
                    if (BMenu.Delete(menuid))
                    {
                        res.code = "0";
                        res.msg = "删除成功";
                    }
                    else
                    {
                        res.code = "1";
                        res.msg = "请稍后重试";
                    }
                }
            }

            return JsonConvert.SerializeObject(res);
        }
        #endregion

        #region 获取角色菜单列表
        public string GetRoleMenuList()
        {
            ResultJson res = new ResultJson();
            string sql = @"select m.Module_ID as id,m.Module_Name title,m.Module_Level [level],m.Module_Parent parentId,'0' [type],CASE WHEN (#a.Module_ID IS NOT NULL) THEN '1' WHEN (#a.Module_ID IS NULL) THEN '0' END type,'1' isChecked
                           from [ICPOS].[dbo].[Module] m left join  (select * from Authorized where Role_ID='1') #a on m.Module_ID= #a.Module_ID
                           where Type=1";
            IList<RoleTreeDto> menuList = DbHelperSQL.GetList<RoleTreeDto>(sql);
            if (menuList != null && menuList.Count > 0)
            {
                res.code = "0";
                res.msg = "成功";
                res.count = menuList.Count.ToString();
                res.data = menuList;

                #region authtree用法
                //Dictionary<string, IList<MenuListDto>> tree = new Dictionary<string, IList<MenuListDto>>();
                //IList<MenuListDto> treedto = new List<MenuListDto>();
                //IList<Module> first = menuList.Where(a=>a.Module_Level==1).OrderBy(a=>a.Module_OrderBy).ToList();
                //if (first != null && first.Count > 0)
                //{
                //    foreach (var item1 in first)
                //    {
                //        MenuListDto firstDto = new MenuListDto();
                //        firstDto.name = item1.Module_Name;
                //        firstDto.value = item1.Module_ID.ToString();
                //        IList<Module> second = menuList.Where(a => a.Module_Parent == item1.Module_ID).OrderBy(a=>a.Module_OrderBy).ToList();
                //        IList<Dictionary<string, string>> listdto = new List<Dictionary<string, string>>();
                //        if (second != null && second.Count > 0)
                //        {
                //            foreach (var item2 in second)
                //            {
                //                Dictionary<string, string> seconddto = new Dictionary<string, string>();
                //                seconddto.Add("name", item2.Module_Name);
                //                seconddto.Add("value", item2.Module_ID.ToString());
                //                listdto.Add(seconddto);
                //            }
                //            firstDto.list = listdto;
                //        }
                //        treedto.Add(firstDto);
                //    }
                //}
                //tree.Add("trees", treedto);

                //res.code = "0";
                //res.msg = "成功";
                //res.data = tree;
                #endregion
            }
            else
            {
                res.code = "1";
                res.msg = "失败";
            }
            string o = JsonConvert.SerializeObject(res);
            return JsonConvert.SerializeObject(res);
        }
        #endregion

        #region 获取导航栏
        //[HttpPost]
        //public string GetNavigationBar()
        //{
        //    string roleid = Session["Role_ID"].ToString();
        //    ResultJson res = new ResultJson();
        //    string sql = "select m.* from Authorized a left join Module m on a.Module_ID=m.Module_ID where Role_ID='" + roleid + "'";
        //    IList<Module> modules = DbHelperSQL.GetList<Module>(sql);
        //    if (modules != null && modules.Count > 0)
        //    {
        //        IList<NavigationBarDto> navigationBarDtos = new List<NavigationBarDto>();
        //        IList<Module> first = modules.Where(a => a.Module_Level == 1).ToList();
        //        if (first != null && first.Count > 0)
        //        {
        //            for (int i = 0; i < first.Count; i++)
        //            {
        //                NavigationBarDto nbdto = new NavigationBarDto();
        //                nbdto.Module_ID = first[i].Module_ID;
        //                nbdto.Module_Name = first[i].Module_Name;
        //                nbdto.ModuleIcon_Url = first[i].ModuleIcon_Url;
        //                nbdto.Module_TrueUrl = first[i].Module_TrueUrl;
        //                nbdto.Module_VirtualUrl = first[i].Module_VirtualUrl;

        //                IList<Module> second = modules.Where(a => a.Module_Level == 2).ToList();
        //                if (second != null && second.Count > 0)
        //                {
        //                    IList<NavigationBarDto> Module_Son = new List<NavigationBarDto>();
        //                    for (int j = 0; j < second.Count; j++)
        //                    {
        //                        NavigationBarDto sonnbdto = new NavigationBarDto();
        //                        sonnbdto.Module_ID = second[j].Module_ID;
        //                        sonnbdto.Module_Name = second[j].Module_Name;
        //                        sonnbdto.ModuleIcon_Url = second[j].ModuleIcon_Url;
        //                        sonnbdto.Module_TrueUrl = second[j].Module_TrueUrl;
        //                        sonnbdto.Module_VirtualUrl = second[j].Module_VirtualUrl;
        //                        Module_Son.Add(sonnbdto);
        //                    }
        //                    nbdto.Module_Son = Module_Son;
        //                }
        //                navigationBarDtos.Add(nbdto);
        //            }
        //        }
        //        res.code = "0";
        //        res.msg = "成功";
        //        res.count = navigationBarDtos.Count.ToString();
        //        res.data = navigationBarDtos;
        //    }
        //    else
        //    {
        //        res.code = "1";
        //        res.msg = "失败";
        //    }
        //    string o = JsonConvert.SerializeObject(res);
        //    return JsonConvert.SerializeObject(res);
        //}
        #endregion

        #endregion
    }
}