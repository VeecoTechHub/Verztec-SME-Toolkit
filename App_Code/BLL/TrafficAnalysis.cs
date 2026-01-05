using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABSDAL;
using System.Data;

/// <summary>
/// Summary description for TrafficAnalysis
/// </summary>
public class TrafficAnalysis
{
   
	public TrafficAnalysis()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    CommonDAL obj_DAL = new CommonDAL();

    private string _PostedBy;

    private int _IndustryID;
    public int IndustryID
    {
        get { return _IndustryID; }
        set { _IndustryID = value; }
    }

    public string PostedBy
    {
        get { return _PostedBy; }
        set { _PostedBy = value; }
    }

    public string UserID { get; set; }

    private string _StartDate;
    public string StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }

    private string _EndDate;
    public string EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }
    public int Culture { get; set; }

    public DataSet GetItemsDetails(string Culture)
    {
        try
        {
            return obj_DAL.GetItemsDetails(Culture);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Get_TrafficAnalysis(TrafficAnalysis trafficAnalysis)
    {
        return obj_DAL.Get_TrafficAnalysis(trafficAnalysis);
    }

   
    public DataSet GET_Industry()
    {
        return obj_DAL.GET_Industry();
    }
    public DataSet GET_TrafficAnalysis_Login(TrafficAnalysis trafficAnalysis)
    {
        return obj_DAL.GET_TrafficAnalysis_Login(trafficAnalysis);
    }

    public DataSet GET_TrafficAnalysis_Login_SpentTime(TrafficAnalysis trafficAnalysis)
    {
        return obj_DAL.GET_TrafficAnalysis_Login_SpentTime(trafficAnalysis);
    }

    public DataSet GET_TrafficAnalysis_Login_HitTimes(TrafficAnalysis trafficAnalysis)
    {
        return obj_DAL.GET_TrafficAnalysis_Login_HitTimes(trafficAnalysis);
    }

    public DataSet Get_TrafficAnalysis_Temp(int IndustryID)
    {
        return obj_DAL.Get_TrafficAnalysis_Temp(IndustryID);
    }

    #region Ateeq
    public DataSet Get_ResLib_TemplateDownloaded(TrafficAnalysis trafficAnalysis)
    {
        return obj_DAL.Get_ResLib_TemplateDownloaded( trafficAnalysis);
    }


    public DataSet Get_ResLib_TrafficAnalysis(TrafficAnalysis trafficAnalysis)
    {
        return obj_DAL.Get_ResLib_TrafficAnalysis(trafficAnalysis);
    }

    public DataSet Get_FeedbackAnalysis(TrafficAnalysis trafficAnalysis)
    {
        return obj_DAL.Get_FeedbackAnalysis(trafficAnalysis);
    }

    public DataSet Get_FeedbackAnalysis_General(TrafficAnalysis trafficAnalysis)
    {
        return obj_DAL.Get_FeedbackAnalysis_General(trafficAnalysis);
    }


    
    #endregion

}
