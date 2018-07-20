/**  版本信息模板在安装目录下，可自行修改。
* Authorized.cs
*
* 功 能： N/A
* 类 名： Authorized
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/18 11:23:23   N/A    初版
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
	/// Authorized:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Authorized
	{
		public Authorized()
		{}
		#region Model
		private int _authorized_id;
		private int? _role_id;
		private int? _module_id;
		private int? _crud_operation;
		/// <summary>
		/// 
		/// </summary>
		public int Authorized_ID
		{
			set{ _authorized_id=value;}
			get{return _authorized_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Role_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Module_ID
		{
			set{ _module_id=value;}
			get{return _module_id;}
		}
		/// <summary>
		/// 对该表单的权限
		/// </summary>
		public int? Crud_Operation
		{
			set{ _crud_operation=value;}
			get{return _crud_operation;}
		}
		#endregion Model

	}
}

