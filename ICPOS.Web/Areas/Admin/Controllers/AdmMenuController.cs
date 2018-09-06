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
            string sql = @"  select m.Module_ID as id,m.Module_Parent pid,m.Module_Name name
                             from Module m
                             where Type=1";
            IList<MenuAuthDto> menuList = DbHelperSQL.GetList<MenuAuthDto>(sql);
            if (menuList!=null&&menuList.Count>0)
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
            string o= JsonConvert.SerializeObject(res);
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