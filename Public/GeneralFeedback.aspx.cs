using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSCommon;
using ABSDTO;
using System.Data;
using System.Configuration;
using System.IO;
using ABSDAL;
using System.Web.UI.HtmlControls;
using Winnovative.WnvHtmlConvert;
using System.Drawing;
using System.Web.Security;


public partial class Public_GeneralFeedback : System.Web.UI.Page
{
    FeedBack obj_Feedback = new FeedBack();
    UserMgmt objUserMgmt = new UserMgmt();
    static bool flag = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["LoginDTO"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
            }
            else
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                ViewState["UserName"] = objLoginDTO.Name;
                ViewState["MailId"] = objLoginDTO.EmailID;
                ViewState["IndustryId"] = objLoginDTO.IndustryID;
                BindGrid();
            }
        }

    }


    public void BindGrid()
    {
        try
        {
            string Culture = Convert.ToString(Session["Culture"]);
            DataSet ds = obj_Feedback.Get_FeedbackQuestions(Culture);
            if (ds.Tables[0].Rows.Count > 0)
            {
                id_GV_FeedBack.DataSource = ds.Tables[1];
                id_GV_FeedBack.DataBind();
            }

        }
        catch (Exception ex)
        {
            // throw ex;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int Result = 0;
        try
        {
            flag = false;

            obj_Feedback.PostedId = Guid.NewGuid().ToString();
            for (int i = 0; i < id_GV_FeedBack.Rows.Count; i++)
            {

                HiddenField hfqid = (HiddenField)id_GV_FeedBack.Rows[i].FindControl("hfQid");
                obj_Feedback.QID = Convert.ToInt32(hfqid.Value);
                RadioButtonList rbtCheck = (RadioButtonList)id_GV_FeedBack.Rows[i].FindControl("radio");
                int count = 1;

                foreach (ListItem li in rbtCheck.Items)
                {

                    if (li.Selected == true)
                    {
                        obj_Feedback.Answer = Convert.ToInt32(li.Value);
                    }
                    count = count + 1;
                }

                obj_Feedback.UserID = ViewState["UserID"].ToString();
                obj_Feedback.PostedBy = ViewState["UserName"].ToString();
                obj_Feedback.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                Result = obj_Feedback.Insert_FeedbackAnswers_General(obj_Feedback);


            }

            foreach (ListItem li in rbtlist.Items)
            {
                if (li.Selected == true)
                {
                    obj_Feedback.Recommend = li.Value;
                    flag = true;
                }
            }

            obj_Feedback.UserID = ViewState["UserID"].ToString();
            obj_Feedback.EmailIds = txtEmailids.Text.ToString();
            obj_Feedback.Comments = txtComments.Text.ToString();
            obj_Feedback.BugsComments = txtInformBugs.Text.ToString();

            int output = obj_Feedback.Insert_FeedbackComments(obj_Feedback);
            //if (output > 0)
            //{
            //    obj_Feedback.UserID = ViewState["UserID"].ToString();
            //    DataSet dsexport = obj_Feedback.Get_FeedbackAnswers_ByUserId(obj_Feedback);
            //    if (dsexport.Tables[0].Rows.Count > 0)
            //    {
            //        //gv_excel.DataSource = dsexport.Tables[0];
            //        //gv_excel.DataBind();
            //        //if (flag == true)
            //        //{
            //        //    sendRecommendSitemail(obj_Feedback.EmailIds);
            //        //}
            //        //Public_FMFeedback.ExportToFile(Server.MapPath("~/Public/Feedback.xls"), this.gv_excel);
            //        //sendmail("Feedback.xls");
            //        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Feedback saved successfully...')</script>");

            //    }
            //}
        }

        catch (Exception ex)
        {
            throw ex;
        }

    }
 

   
  



  
  
}
