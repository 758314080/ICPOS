/**  版本信息模板在安装目录下，可自行修改。
* Module.cs
*
* 功 能： N/A
* 类 名： Module
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
using System.Text;
using System.Data.SqlClient;
using ICPOS.Common;

namespace ICPOS.EntityFramwork.DAL
{
	/// <summary>
	/// 数据访问类:Module
	/// </summary>
	public partial class Module
	{
		public Module()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Module_ID", "Module"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Module_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Module");
			strSql.Append(" where Module_ID=SQL2012Module_ID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Module_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Module_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ICPOS.EntityFramwork.Model.Module model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Module(");
			strSql.Append("Type,Module_Name,Module_Parent,Module_Hierarchy,Module_Level,Module_OrderBy,ModuleIcon_Url,Module_TrueUrl,Module_VirtualUrl)");
			strSql.Append(" values (");
			strSql.Append("SQL2012Type,SQL2012Module_Name,SQL2012Module_Parent,SQL2012Module_Hierarchy,SQL2012Module_Level,SQL2012Module_OrderBy,SQL2012ModuleIcon_Url,SQL2012Module_TrueUrl,SQL2012Module_VirtualUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Type", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module_Name", SqlDbType.NVarChar,20),
					new SqlParameter("SQL2012Module_Parent", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module_Hierarchy", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012Module_Level", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module_OrderBy", SqlDbType.Int,4),
					new SqlParameter("SQL2012ModuleIcon_Url", SqlDbType.VarChar,200),
					new SqlParameter("SQL2012Module_TrueUrl", SqlDbType.VarChar,200),
					new SqlParameter("SQL2012Module_VirtualUrl", SqlDbType.VarChar,200)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Module_Name;
			parameters[2].Value = model.Module_Parent;
			parameters[3].Value = model.Module_Hierarchy;
			parameters[4].Value = model.Module_Level;
			parameters[5].Value = model.Module_OrderBy;
			parameters[6].Value = model.ModuleIcon_Url;
			parameters[7].Value = model.Module_TrueUrl;
			parameters[8].Value = model.Module_VirtualUrl;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ICPOS.EntityFramwork.Model.Module model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Module set ");
			strSql.Append("Type=SQL2012Type,");
			strSql.Append("Module_Name=SQL2012Module_Name,");
			strSql.Append("Module_Parent=SQL2012Module_Parent,");
			strSql.Append("Module_Hierarchy=SQL2012Module_Hierarchy,");
			strSql.Append("Module_Level=SQL2012Module_Level,");
			strSql.Append("Module_OrderBy=SQL2012Module_OrderBy,");
			strSql.Append("ModuleIcon_Url=SQL2012ModuleIcon_Url,");
			strSql.Append("Module_TrueUrl=SQL2012Module_TrueUrl,");
			strSql.Append("Module_VirtualUrl=SQL2012Module_VirtualUrl");
			strSql.Append(" where Module_ID=SQL2012Module_ID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Type", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module_Name", SqlDbType.NVarChar,20),
					new SqlParameter("SQL2012Module_Parent", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module_Hierarchy", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012Module_Level", SqlDbType.Int,4),
					new SqlParameter("SQL2012Module_OrderBy", SqlDbType.Int,4),
					new SqlParameter("SQL2012ModuleIcon_Url", SqlDbType.VarChar,200),
					new SqlParameter("SQL2012Module_TrueUrl", SqlDbType.VarChar,200),
					new SqlParameter("SQL2012Module_VirtualUrl", SqlDbType.VarChar,200),
					new SqlParameter("SQL2012Module_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Module_Name;
			parameters[2].Value = model.Module_Parent;
			parameters[3].Value = model.Module_Hierarchy;
			parameters[4].Value = model.Module_Level;
			parameters[5].Value = model.Module_OrderBy;
			parameters[6].Value = model.ModuleIcon_Url;
			parameters[7].Value = model.Module_TrueUrl;
			parameters[8].Value = model.Module_VirtualUrl;
			parameters[9].Value = model.Module_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Module_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Module ");
			strSql.Append(" where Module_ID=SQL2012Module_ID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Module_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Module_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Module_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Module ");
			strSql.Append(" where Module_ID in ("+Module_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ICPOS.EntityFramwork.Model.Module GetModel(int Module_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Module_ID,Type,Module_Name,Module_Parent,Module_Hierarchy,Module_Level,Module_OrderBy,ModuleIcon_Url,Module_TrueUrl,Module_VirtualUrl from Module ");
			strSql.Append(" where Module_ID=SQL2012Module_ID");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Module_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Module_ID;

			ICPOS.EntityFramwork.Model.Module model=new ICPOS.EntityFramwork.Model.Module();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ICPOS.EntityFramwork.Model.Module DataRowToModel(DataRow row)
		{
			ICPOS.EntityFramwork.Model.Module model=new ICPOS.EntityFramwork.Model.Module();
			if (row != null)
			{
				if(row["Module_ID"]!=null && row["Module_ID"].ToString()!="")
				{
					model.Module_ID=int.Parse(row["Module_ID"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["Module_Name"]!=null)
				{
					model.Module_Name=row["Module_Name"].ToString();
				}
				if(row["Module_Parent"]!=null && row["Module_Parent"].ToString()!="")
				{
					model.Module_Parent=int.Parse(row["Module_Parent"].ToString());
				}
				if(row["Module_Hierarchy"]!=null)
				{
					model.Module_Hierarchy=row["Module_Hierarchy"].ToString();
				}
				if(row["Module_Level"]!=null && row["Module_Level"].ToString()!="")
				{
					model.Module_Level=int.Parse(row["Module_Level"].ToString());
				}
				if(row["Module_OrderBy"]!=null && row["Module_OrderBy"].ToString()!="")
				{
					model.Module_OrderBy=int.Parse(row["Module_OrderBy"].ToString());
				}
				if(row["ModuleIcon_Url"]!=null)
				{
					model.ModuleIcon_Url=row["ModuleIcon_Url"].ToString();
				}
				if(row["Module_TrueUrl"]!=null)
				{
					model.Module_TrueUrl=row["Module_TrueUrl"].ToString();
				}
				if(row["Module_VirtualUrl"]!=null)
				{
					model.Module_VirtualUrl=row["Module_VirtualUrl"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Module_ID,Type,Module_Name,Module_Parent,Module_Hierarchy,Module_Level,Module_OrderBy,ModuleIcon_Url,Module_TrueUrl,Module_VirtualUrl ");
			strSql.Append(" FROM Module ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Module_ID,Type,Module_Name,Module_Parent,Module_Hierarchy,Module_Level,Module_OrderBy,ModuleIcon_Url,Module_TrueUrl,Module_VirtualUrl ");
			strSql.Append(" FROM Module ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Module ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Module_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Module T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012PageSize", SqlDbType.Int),
					new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
					new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
					new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
					new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Module";
			parameters[1].Value = "Module_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

