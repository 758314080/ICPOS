/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/8/6 16:00:00   N/A    初版
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
	/// 数据访问类:Users
	/// </summary>
	public partial class Users
	{
		public Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Users_ID", "Users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Users_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where Users_ID=@Users_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Users_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Users_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ICPOS.EntityFramwork.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");
			strSql.Append("Role_ID,LoginName,Password,Name,Phone,Email,CreateDate,Status,Note)");
			strSql.Append(" values (");
			strSql.Append("@Role_ID,@LoginName,@Password,@Name,@Phone,@Email,@CreateDate,@Status,@Note)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@Note", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.Role_ID;
			parameters[1].Value = model.LoginName;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Phone;
			parameters[5].Value = model.Email;
			parameters[6].Value = model.CreateDate;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.Note;

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
		public bool Update(ICPOS.EntityFramwork.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("Role_ID=@Role_ID,");
			strSql.Append("LoginName=@LoginName,");
			strSql.Append("Password=@Password,");
			strSql.Append("Name=@Name,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("Note=@Note");
			strSql.Append(" where GUID=@GUID");
			SqlParameter[] parameters = {
					new SqlParameter("@GUID", SqlDbType.VarChar,50),
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@Note", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.GUID;
			parameters[1].Value = model.Role_ID;
			parameters[2].Value = model.LoginName;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.CreateDate;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.Note;

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
		public bool Delete(int Users_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where Users_ID=@Users_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Users_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Users_ID;

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
		public bool DeleteList(string Users_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where Users_ID in ("+Users_IDlist + ")  ");
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
		public ICPOS.EntityFramwork.Model.Users GetModel(int Users_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Users_ID,GUID,Role_ID,LoginName,Password,Name,Phone,Email,CreateDate,Status,Note from Users ");
			strSql.Append(" where Users_ID=@Users_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Users_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Users_ID;

			ICPOS.EntityFramwork.Model.Users model=new ICPOS.EntityFramwork.Model.Users();
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
		public ICPOS.EntityFramwork.Model.Users DataRowToModel(DataRow row)
		{
			ICPOS.EntityFramwork.Model.Users model=new ICPOS.EntityFramwork.Model.Users();
			if (row != null)
			{
				if(row["Users_ID"]!=null && row["Users_ID"].ToString()!="")
				{
					model.Users_ID=int.Parse(row["Users_ID"].ToString());
				}
				if(row["GUID"]!=null)
				{
					model.GUID=row["GUID"].ToString();
				}
				if(row["Role_ID"]!=null && row["Role_ID"].ToString()!="")
				{
					model.Role_ID=int.Parse(row["Role_ID"].ToString());
				}
				if(row["LoginName"]!=null)
				{
					model.LoginName=row["LoginName"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					if((row["Status"].ToString()=="1")||(row["Status"].ToString().ToLower()=="true"))
					{
						model.Status=true;
					}
					else
					{
						model.Status=false;
					}
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
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
			strSql.Append("select Users_ID,GUID,Role_ID,LoginName,Password,Name,Phone,Email,CreateDate,Status,Note ");
			strSql.Append(" FROM Users ");
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
			strSql.Append(" Users_ID,GUID,Role_ID,LoginName,Password,Name,Phone,Email,CreateDate,Status,Note ");
			strSql.Append(" FROM Users ");
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
			strSql.Append("select count(1) FROM Users ");
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
				strSql.Append("order by T.Users_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Users T ");
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
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Users";
			parameters[1].Value = "Users_ID";
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

