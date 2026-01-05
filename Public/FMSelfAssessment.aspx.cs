using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using System.Configuration;

public partial class Public_FMSelfAssessment : BasePage
{
    static IList<EvalQuestionaireScore> EvalScore;
    CommonFunctions commonfunction = new CommonFunctions();
    UserMgmt objUserMgmt = new UserMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }

        try
        {
            if (!IsPostBack)
            {
                EvalQuestionaire objEval = new EvalQuestionaire();
                string strCategory;
                //changes 
                if (Request.QueryString["Category"] != null)
                {
                    strCategory = Convert.ToString(commonfunction.Decrypt(Request.QueryString["Category"].ToString()));


                    DataSet dsQuestions = objEval.GetEvalQuestionaireByUserID("95ED1CC3-0270-4474-80DE-4F847AE5A5EF", strCategory);
                    //DataSet dsQuestions = objEval.GetEvalQuestionaireByUserID("95ED1CC3-0270-4474-80DE-4F847AE5A5EF");
                    if (dsQuestions != null && dsQuestions.Tables.Count > 0)
                    {
                        gvQuestionaire.DataSource = dsQuestions;
                        gvQuestionaire.DataBind();
                    }
                }


            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }
    }

    protected void btnProcess_Click(object sender, EventArgs e)
    {
        try
        {
            EvalScore = new List<EvalQuestionaireScore>();

            for (int i = 0; i < gvQuestionaire.Rows.Count; i++)
            {
                HiddenField hdfldQID = (HiddenField)gvQuestionaire.Rows[i].FindControl("hdfldQID");
                AjaxControlToolkit.Rating Rating1 = (AjaxControlToolkit.Rating)gvQuestionaire.Rows[i].FindControl("Rating1");

                EvalQuestionaireScore objScore = new EvalQuestionaireScore("95ED1CC3-0270-4474-80DE-4F847AE5A5EF", hdfldQID.Value, Rating1.CurrentRating.ToString());
                EvalScore.Add(objScore);
            }

            if (EvalScore != null)
            {
                EvalQuestionaire objBLL = new EvalQuestionaire();
                objBLL.InsertEvaluationScore(EvalScore);

             
                ABSCommon.Common.ShowMessage(this, "Data saved successfully", true);
            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }
    }
}