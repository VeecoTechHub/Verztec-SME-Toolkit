using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Data.SqlClient;
using ABSDAL;

/// <summary>
/// Summary description for PublicHealthProfiling
/// </summary>
public class PublicHealthProfiling
{
	public PublicHealthProfiling()
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
    public int Update_HealthProfileAnswer(PublicHealthProfiling obj_PubHProfDetails)
    { 
        //Update_HealthProfileAnswer
        return obj_DAL.Update_HealthProfileAnswer(obj_PubHProfDetails);

    
    }

    public DataSet GetLastAnswer_PublicPollAnswer( PublicHealthProfiling obj_healthprofile)
    {
        return obj_DAL.GetLastAnswer_PublicPollAnswer(obj_healthprofile);

    }

}