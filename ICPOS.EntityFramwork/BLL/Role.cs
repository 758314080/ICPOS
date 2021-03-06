﻿/**  版本信息模板在安装目录下，可自行修改。
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
using System.Data;
using System.Collections.Generic;
using ICPOS.EntityFramwork.Model;
namespace ICPOS.EntityFramwork.BLL
{
	/// <summary>
	/// Role
	/// </summary>
	public partial class Role
	{
		private readonly ICPOS.EntityFramwork.DAL.Role dal=new ICPOS.EntityFramwork.DAL.Role();
		public Role()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Role_ID)
		{
			return dal.Exists(Role_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ICPOS.EntityFramwork.Model.Role model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ICPOS.EntityFramwork.Model.Role model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Role_ID)
		{
			
			return dal.Delete(Role_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Role_IDlist )
		{
			return dal.DeleteList(Role_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ICPOS.EntityFramwork.Model.Role GetModel(int Role_ID)
		{
			
			return dal.GetModel(Role_ID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ICPOS.EntityFramwork.Model.Role> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ICPOS.EntityFramwork.Model.Role> DataTableToList(DataTable dt)
		{
			List<ICPOS.EntityFramwork.Model.Role> modelList = new List<ICPOS.EntityFramwork.Model.Role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ICPOS.EntityFramwork.Model.Role model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

