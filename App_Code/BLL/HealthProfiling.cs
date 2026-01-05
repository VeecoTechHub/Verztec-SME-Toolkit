using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Data.SqlClient;
using ABSDAL;
/// <summary>
/// Summary description for HealthProfiling
/// </summary>
public class HealthProfiling
{
    public HealthProfiling()
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
    private int  _Qid;
    public int  Qid
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
 
    private string _OptA;
    public string OptA
    {
        get { return _OptA; }
        set { _OptA = value; }
    }
    private string _OptB;
    public string OptB
    {
        get { return _OptB; }
        set { _OptB = value; }
    }
    private string _OptC;
    public string OptC
    {
        get { return _OptC; }
        set { _OptC = value; }
    }
    private string _OptD;
    public string OptD
    {
        get { return _OptD; }
        set { _OptD = value; }
    }

    private int _Answer;
    public int Answer
    {
        get { return _Answer; }
        set { _Answer = value; }
    }
    private DateTime _CreatedOn;

    public DateTime CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }
    private string _CreatedBy;
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    private int _cat_Id;
    public int  CatId
    {
        get { return _cat_Id; }
        set { _cat_Id = value; }
    }

    private string _Category;
    public string Category
    {
        get { return _Category; }
        set { _Category = value; }
    }

    private string   _startdate ;
    public string  StartDate
    {
        get { return _startdate; }
        set { _startdate = value; }
    }

    private string  _enddate ;
    public string  EndDate
    {
        get { return _enddate; }
        set { _enddate = value; }
    }
    private string _SortOn;

    public string SortOn
    {
        get { return _SortOn; }
        set { _SortOn = value; }

    }
    private string _SortDirection;
    public string SortDirection
    {
        get { return _SortDirection; }
        set { _SortDirection = value; }
    }
    private string _Culture;
    public string Culture
    {
        get { return _Culture; }
        set { _Culture = value; }
    }



    public DataSet Get_HealthProfileDetails(HealthProfiling obj_HProfDetails)
    {
        return obj_DAL.Get_HealthProfileDetails(obj_HProfDetails);


    }

  
    public DataSet Get_QueCategory()
    {
        return obj_DAL.Get_QueCategory();
    
    }
    public int Update_HealthProfileDetails(HealthProfiling obj_HProfDetails)
    {
        return obj_DAL.Update_HealthProfileDetails(obj_HProfDetails);

    }
    public DataSet Get_ReportHealthProfile(HealthProfiling obj_HProfDetails)
    {

        return obj_DAL.Get_ReportHealthProfile(obj_HProfDetails);



    }

    public void  inertTB_PublicPollAnswer(DataTable dtTbDetails, PublicHealthProfiling obj_healthprofile)
    {

        obj_DAL.inertTB_PublicPollAnswer(dtTbDetails, obj_healthprofile);
    }
    
    public DataSet Get_PollQuestionCategory()
    {
        return obj_DAL.Get_PollQuestionCategory();

    
    }

}