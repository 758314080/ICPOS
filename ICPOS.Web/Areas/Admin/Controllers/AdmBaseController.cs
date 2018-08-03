using ICPOS.Common;
using ICPOS.EntityFramwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ICPOS.Web.Areas.Admin.Controllers
{
    public class AdmBaseController : Controller
    {
        // GET: Admin/AdmBase
        protected Users users;
        

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // TODO
            //用户信息处理
            //users = new EntityFramwork.BLL.Users().GetModel(1);
        }

        /// <summary>
        /// 获取指定菜单下的按钮
        /// </summary>
        /// <param name="parentId"></param>
        protected virtual void GetButtons(int parentId)
        {
            
        }

        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns></returns>
        protected string GetQuerystring(string key)
        {
            return HttpContext.Request[key];
        }
    }
}