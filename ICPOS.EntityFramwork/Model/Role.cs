/**  版本信息模板在安装目录下，可自行修改。
* Role.cs
*
* 功 能： N/A
* 类 名： Role
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 15:38:17   N/A    初版
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
	/// Role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Role
	{
		public Role()
		{}
		#region Model
		private int _role_id;
		private string _role_name;
		private string _role_description;
		private int? _role_priv_level;
		/// <summary>
		/// 
		/// </summary>
		public int Role_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string Role_Name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 角色简介
		/// </summary>
		public string Role_Description
		{
			set{ _role_description=value;}
			get{return _role_description;}
		}
		/// <summary>
		/// 角色权限等级---部门领导，公司领导等
		/// </summary>
		public int? Role_Priv_Level
		{
			set{ _role_priv_level=value;}
			get{return _role_priv_level;}
		}
		#endregion Model

	}
}

