using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for Report_BLL
/// </summary>
public class Report_BLL
{
    private Reports_DAL dataAccessLayer;
    public Report_BLL()
    {
        dataAccessLayer = new Reports_DAL();
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet getFinancialPerfomance(string userid)
    {
        try
        {
            return dataAccessLayer.getFinancialPerfomance(userid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet getReport(string fsmappingIds, string userid)
    {
        try
        {
            return dataAccessLayer.getReport(fsmappingIds, userid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet getReport_workingcapital(string fsmappingIds, string userid)
    {
        try
        {
            return dataAccessLayer.getReport_workingcapital(fsmappingIds, userid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet getMasterReport(string fsmappingIds, string userid)
    {
        try
        {
            return dataAccessLayer.getMasterReport(fsmappingIds, userid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet getReport_health(string userid)
    {
        try
        {
            return dataAccessLayer.getReport_health(userid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet getReport_health1(string userid)
    {
        try
        {
            return dataAccessLayer.getReport_health1(userid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet getReport_GetQuestionPercentange(string userid)
    {
        try
        {
            return dataAccessLayer.getReport_GetQuestionPercentange(userid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    
    public DataSet getSales_GP(string userid)
    {
        try
        {
            return dataAccessLayer.getSales_GP(userid);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int ChangeDollarStatus(string userid, int roundDollar, string roundDollarType)
    {
        try
        {
            return dataAccessLayer.ChangeDollarStatus(userid, roundDollar, roundDollarType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet getReport_FinancialMgtDetails(string userid)
    {
        return dataAccessLayer.getReport_FinancialMgtDetails(userid);

    
    }
    public DataSet getReport_GetFinancialMgtRatingPercentage(string userid)
    {
        return dataAccessLayer.getReport_GetFinancialMgtRatingPercentage(userid);
    }

}