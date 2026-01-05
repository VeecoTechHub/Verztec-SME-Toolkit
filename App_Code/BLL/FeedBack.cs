using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ABSDAL;

/// <summary>
/// Summary description for FeedBack
/// </summary>
public class FeedBack
{
	public FeedBack()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    DataSet ds = new DataSet();
    CommonDAL obj_DAL = new CommonDAL();

    private int _QID;
    public int QID
    {
        get { return _QID; }
        set { _QID = value; }
    }

    private int _Answer;
    public int Answer
    {
        get { return _Answer; }
        set { _Answer = value; }
    }

    private DateTime _Created_On;
    public DateTime Created_On
    {
        get { return _Created_On; }
        set { _Created_On = value; }
    }
    private DateTime _Updated_On;
    public DateTime Updated_On
    {
        get { return _Updated_On; }
        set { _Updated_On = value; }
    }
    private DateTime _PostedOn;
    public DateTime PostedOn
    {
        get { return _PostedOn; }
        set { _PostedOn = value; }
    }

    private string _Created_By, _Updated_By, _PostedBy, _PostedId, _Question, _Recommend, _EmailIds, _Comments, _bugscomment;
    public string Created_By
    {
        get { return _Created_By; }
        set { _Created_By = value; }
    }

    public string Updated_By
    {
        get { return _Updated_By; }
        set { _Updated_By = value; }
    }
    public string PostedBy
    {
        get { return _PostedBy; }
        set { _PostedBy = value; }
    }
    public string PostedId
    {
        get { return _PostedId; }
        set { _PostedId = value; }
    }
    public string Question
    {
        get { return _Question; }
        set { _Question = value; }
    }


    public string UserID { get; set; }
    public string Recommend
    {
        get { return _Recommend; }
        set { _Recommend = value; }
    }
    public string EmailIds
    {
        get { return _EmailIds; }
        set { _EmailIds = value; }
    }
    public string Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }
    public string BugsComments
    {
        get { return _bugscomment; }
        set { _bugscomment = value; }
    }

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
    private int _IndustryId;
    public int IndustryId
    {
        get { return _IndustryId; }
        set { _IndustryId = value; }
    }
    public string ActionOn { get; set; }


    public DataSet Get_FeedbackQuestions(string Culture)
    {
        return obj_DAL.Get_FeedbackQuestions(Culture);
    }

    public int Insert_FeedbackAnswers(FeedBack obj_Feedback)
    {
        return obj_DAL.Insert_FeedbackAnswers(obj_Feedback);
    }

    public int Insert_FeedbackAnswers_General(FeedBack obj_Feedback)
    {
        return obj_DAL.Insert_FeedbackAnswers_General(obj_Feedback);
    }

    public int Insert_FeedbackComments(FeedBack obj_Feedback)
    {
        return obj_DAL.Insert_FeedbackComments(obj_Feedback);
    }


    public DataSet Get_Improvement_Comments(FeedBack obj_Feedback)
    {
        return obj_DAL.Get_Improvement_Comments(obj_Feedback);
    }
    public DataSet Get_Bugs_Comments(FeedBack obj_Feedback)
    {
        return obj_DAL.Get_Bugs_Comments(obj_Feedback);
    }

    public DataSet Get_FeedbackAnswers_ByUserId(FeedBack obj_Feedback)
    {
        return obj_DAL.Get_FeedbackAnswers_ByUserId(obj_Feedback);
    }
    public DataSet Get_FeedbackAnswers(FeedBack obj_Feedback)
    {
        return obj_DAL.Get_FeedbackAnswers(obj_Feedback);
    }
    public void InsertRegistrationFbFlag(FeedBack obj_Feedback)
    {
        obj_DAL.InsertRegistrationFbFlag(obj_Feedback);
    }
    public DataSet GetRegistrationFbFlag(FeedBack obj_Feedback)
    {
        return obj_DAL.GetRegistrationFbFlag(obj_Feedback);
    }

}