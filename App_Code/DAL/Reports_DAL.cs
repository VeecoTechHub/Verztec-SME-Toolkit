using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

using System.Collections;
using System.Web.Mail;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Reports_DAL
/// </summary>
public class Reports_DAL
{
    #region Database Oledb connection variable

    SqlDatabase sqlCon;

    #endregion
	public Reports_DAL()
	{
        try
        {
            string conString = GetConnectionString();
            sqlCon = new SqlDatabase(conString);
        }
        catch (Exception err)
        {
            throw err;
        }
	}
    private static string GetConnectionString()
    {
        try
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        }
        catch (Exception err)
        {
            throw err;
        }
    }
    public DataSet getFinancialPerfomance(string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_Fin_Performance");
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }
    public DataSet getReport(string fsmappingIds, string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GetReport");
            sqlCon.AddInParameter(DBCom, "@fsmappingIDs", DbType.String,fsmappingIds);//DbType.Guid, new Guid(CategoryId));
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }
    public DataSet getReport_workingcapital(string fsmappingIds, string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GetReport_workingcapital");
            sqlCon.AddInParameter(DBCom, "@fsmappingIDs", DbType.String, fsmappingIds);//DbType.Guid, new Guid(CategoryId));
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }
    public DataSet getMasterReport(string fsmappingIds, string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GetMasterReport");
            sqlCon.AddInParameter(DBCom, "@fsmappingIDs", DbType.String,fsmappingIds);//DbType.Guid, new Guid(CategoryId));
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }
    public DataSet getReport_health(string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_GetQuestionsRating");
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }
    public DataSet getReport_health1(string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_GetQuestionsRating");
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    public DataSet getReport_GetQuestionPercentange(string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_GetRatingPercentage");
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }
    public DataSet getSales_GP(string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("usp_sales_GP");
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }
    public int ChangeDollarStatus(string userid, int roundDollar, string roundDollarType)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_UpdateRoundDollar");
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            sqlCon.AddInParameter(DBCom, "@roundDollar", DbType.Int32, roundDollar);
            sqlCon.AddInParameter(DBCom, "@roundDollarType", DbType.String, roundDollarType);
            int k = sqlCon.ExecuteNonQuery(DBCom);
            return k;
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    public DataSet getReport_FinancialMgtDetails(string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_GetFinancialMgtQuestionRating");
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    public DataSet getReport_GetFinancialMgtRatingPercentage(string userid)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_GetFinancialMgtRatingPercentage");
            sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
            ds = sqlCon.ExecuteDataSet(DBCom);
            return ds;
        }
        catch (Exception err)
        {
            throw err;
        }
    }
}