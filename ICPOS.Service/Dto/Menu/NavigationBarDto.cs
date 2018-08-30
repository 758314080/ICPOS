using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPOS.Service.Dto.Menu
{
    public class NavigationBarDto
    {
        private int _Module_ID;
        private string _Module_Name;
        private string _ModuleIcon_Url;
        private string _Module_TrueUrl;
        private string _Module_VirtualUrl;
        private object _Module_Son;

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int Module_ID { get => _Module_ID; set => _Module_ID = value; }
        /// <summary>
        /// 菜单名字
        /// </summary>
        public string Module_Name { get => _Module_Name; set => _Module_Name = value; }
        /// <summary>
        /// 菜单图标地址
        /// </summary>
        public string ModuleIcon_Url { get => _ModuleIcon_Url; set => _ModuleIcon_Url = value; }
        /// <summary>
        /// 网站地址
        /// </summary>
        public string Module_TrueUrl { get => _Module_TrueUrl; set => _Module_TrueUrl = value; }
        /// <summary>
        /// 页面路径
        /// </summary>
        public string Module_VirtualUrl { get => _Module_VirtualUrl; set => _Module_VirtualUrl = value; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public object Module_Son { get => _Module_Son; set => _Module_Son = value; }
    }
}
