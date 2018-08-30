using ICPOS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICPOS.EntityFramwork.Model;
using Newtonsoft.Json;
using ICPOS.Service.Dto.Menu;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmMenuController : AdmBaseController
    {
        // GET: Admin/AdmMenu
        public ActionResult Index()
        {
            return View();
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

        #region 获取菜单列表
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
        #endregion

        #region 获取导航栏
        [HttpPost]
        public string GetNavigationBar()
        {
            string roleid = Session["Role_ID"].ToString();
            ResultJson res = new ResultJson();
            string sql = "select m.* from Authorized a left join Module m on a.Module_ID=m.Module_ID where Role_ID='" + roleid + "'";
            IList<Module> modules = DbHelperSQL.GetList<Module>(sql);
            if (modules != null && modules.Count > 0)
            {
                IList<NavigationBarDto> navigationBarDtos = new List<NavigationBarDto>();
                IList<Module> first = modules.Where(a => a.Module_Level == 1).ToList();
                if (first != null && first.Count > 0)
                {
                    for (int i = 0; i < first.Count; i++)
                    {
                        NavigationBarDto nbdto = new NavigationBarDto();
                        nbdto.Module_ID = first[i].Module_ID;
                        nbdto.Module_Name = first[i].Module_Name;
                        nbdto.ModuleIcon_Url = first[i].ModuleIcon_Url;
                        nbdto.Module_TrueUrl = first[i].Module_TrueUrl;
                        nbdto.Module_VirtualUrl = first[i].Module_VirtualUrl;

                        IList<Module> second = modules.Where(a => a.Module_Level == 2).ToList();
                        if (second!=null&&second.Count>0)
                        {
                            IList<NavigationBarDto> Module_Son = new List<NavigationBarDto>();
                            for (int j = 0; j < second.Count; j++)
                            {
                                NavigationBarDto sonnbdto = new NavigationBarDto();
                                sonnbdto.Module_ID = second[j].Module_ID;
                                sonnbdto.Module_Name = second[j].Module_Name;
                                sonnbdto.ModuleIcon_Url = second[j].ModuleIcon_Url;
                                sonnbdto.Module_TrueUrl = second[j].Module_TrueUrl;
                                sonnbdto.Module_VirtualUrl = second[j].Module_VirtualUrl;
                                Module_Son.Add(sonnbdto);
                            }
                            nbdto.Module_Son = Module_Son;
                        }
                        navigationBarDtos.Add(nbdto);
                    }
                }
                res.code = "0";
                res.msg = "成功";
                res.count = navigationBarDtos.Count.ToString();
                res.data = navigationBarDtos;
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

        #endregion
    }
}