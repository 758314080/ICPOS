/**  版本信息模板在安装目录下，可自行修改。
* Module.cs
*
* 功 能： N/A
* 类 名： Module
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/23 18:01:21   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ICPOS.EntityFramwork.Model
{
	/// <summary>
	/// Module:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Module
	{
		public Module()
		{}
		#region Model
		private int _module_id;
		private string _module_name;
		private int? _module_parent;
		private string _module_hierarchy;
		private int? _module_level;
		private int? _module_orderby;
		private string _moduleicon_url;
		private string _module_trueurl;
		private string _module_virtualurl;
		/// <summary>
		/// 
		/// </summary>
		public int Module_ID
		{
			set{ _module_id=value;}
			get{return _module_id;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string Module_Name
		{
			set{ _module_name=value;}
			get{return _module_name;}
		}
		/// <summary>
		/// 父级
		/// </summary>
		public int? Module_Parent
		{
			set{ _module_parent=value;}
			get{return _module_parent;}
		}
		/// <summary>
		/// 层级
		/// </summary>
		public string Module_Hierarchy
		{
			set{ _module_hierarchy=value;}
			get{return _module_hierarchy;}
		}
		/// <summary>
		/// 等级
		/// </summary>
		public int? Module_Level
		{
			set{ _module_level=value;}
			get{return _module_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Module_OrderBy
		{
			set{ _module_orderby=value;}
			get{return _module_orderby;}
		}
		/// <summary>
		/// 图标地址
		/// </summary>
		public string ModuleIcon_Url
		{
			set{ _moduleicon_url=value;}
			get{return _moduleicon_url;}
		}
		/// <summary>
		/// 连接地址(固定路径)
		/// </summary>
		public string Module_TrueUrl
		{
			set{ _module_trueurl=value;}
			get{return _module_trueurl;}
		}
		/// <summary>
		/// 虚拟路径
		/// </summary>
		public string Module_VirtualUrl
		{
			set{ _module_virtualurl=value;}
			get{return _module_virtualurl;}
		}
		#endregion Model

	}
}

