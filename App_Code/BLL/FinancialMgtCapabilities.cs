using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Data.SqlClient;
using ABSDAL;
/// <summary>
/// Summary description for FinancialMgtCapabilities
/// </summary>
public class FinancialMgtCapabilities
{
    public FinancialMgtCapabilities()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    DataSet ds = new DataSet();
    CommonDAL obj_DAL = new CommonDAL();
    private string _Type;
    public string Type
    {
        get { return _Type; }
        set { _Type = value; }
    }
    private int _Qid;
    public int Qid
    {
        get { return _Qid; }
        set { _Qid = value; }
    }
    private string _Qdescription;
    public string Qdescription
    {
        get { return _Qdescription; }
        set { _Qdescription = value; }
    }



    private int _Answer;
    public int Answer
    {
        get { return _Answer; }
        set { _Answer = value; }
    }
    private DateTime _PostedOn;

    public DateTime PostedOn
    {
        get { return _PostedOn; }
        set { _PostedOn = value; }
    }
    private string _PostedBy;
    public string PostedBy
    {
        get { return _PostedBy; }
        set { _PostedBy = value; }
    }
    public string Category { get; set; }

    public string StartDate { get; set; }
    public string Culture { get; set; }


    public string EndDate { get; set; }

    public DataSet Get_FinalcialMgtDetails(FinancialMgtCapabilities obj_FMgtCapbilities)
    {
        return obj_DAL.Get_FinalcialMgtDetails(obj_FMgtCapbilities);

    }

    public DataSet GetLastAnswer_FinancialMgtAnswer(FinancialMgtCapabilities obj_FMgtCapbilities)
    {
        return obj_DAL.GetLastAnswer_FinancialMgtAnswer(obj_FMgtCapbilities);


    }



    public void inertTB_PublicFinalcialMgtPollAnswer(DataTable dtTbDetails, FinancialMgtCapabilities obj_FMgtCapbilities)
    {

        obj_DAL.inertTB_PublicFinalcialMgtPollAnswer(dtTbDetails, obj_FMgtCapbilities);
    }
    //21 may 2012

    public DataSet Get_QueCategory_ManageCapabilities()
    {
        return obj_DAL.Get_QueCategory_ManageCapabilities();

    }
    public DataSet Get_ReportCapabilitiesProfiling(FinancialMgtCapabilities obj_MangeCapabilities)
     {
         return obj_DAL.Get_ReportCapabilitiesProfiling(obj_MangeCapabilities);

     }
    //21 may 2012

}
