using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using System.Configuration;
using ABSDTO;
using System.Globalization;
using System.Threading;


public partial class Public_PublicHealthProfiling : System.Web.UI.Page
{

    CommonFunctions commonfunction = new CommonFunctions();
    HealthProfiling obj_HPDetails = new HealthProfiling();
    PublicHealthProfiling obj_PubHPdetails = new PublicHealthProfiling();
    UserMgmt objUserMgmt = new UserMgmt();

    DataSet ds_Search = new DataSet();
    DataTable dt = new DataTable();
    int ans = 0;
    int ansid;
    DataSet ds_LastAns = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["LoginDTO"].ToString() == string.Empty)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
                }
                else
                {
                    LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];

                    //  objLoginDTO = (LoginDTO)Session["LoginDTO"];
                    ViewState["UserID"] = objLoginDTO.UserID;

                }
                EvalQuestionaire objEval = new EvalQuestionaire();

                obj_HPDetails.Type = "all";
                obj_HPDetails.Qid = 0;
                obj_HPDetails.Qdescription = "";
                // obj_HPDetails.Category = "";
                obj_HPDetails.Category = null;
                obj_HPDetails.Culture = Convert.ToString(Session["Culture"]);


                ds_Search = obj_HPDetails.Get_HealthProfileDetails(obj_HPDetails);

                if (ds_Search.Tables[0].Rows.Count > 0)
                {
                    lblError.Visible = false;
                    Dl_Questionaire.DataSource = ds_Search;
                    Dl_Questionaire.DataBind();

                    for (int i = 0; i < ds_Search.Tables[0].Rows.Count; i++)
                    {
                        //if (i == 5)
                        //{
                        //    Label lblQ6 = (Label)Dl_Questionaire.Items[i].FindControl("lblQ6");
                        //    RadioButtonList rblQ6_f = (RadioButtonList)Dl_Questionaire.Items[i].FindControl("rblQ6");
                        //    lblQ6.Visible = true;
                        //    DataTable dtQID1 = new DataTable();
                        //    dtQID1.Columns.Add("Option");
                        //    dtQID1.Rows.Add("Yes");
                        //    dtQID1.Rows.Add("No");
                        //    rblQ6_f.DataSource = dtQID1;
                        //    rblQ6_f.DataTextField = "Option";
                        //    rblQ6_f.DataValueField = "Option";
                        //    rblQ6_f.DataBind();
                        //    rblQ6_f.SelectedIndex = 1;               
                        //}

                        Label lblqid = (Label)Dl_Questionaire.Items[i].FindControl("lblqid");
                        Label lblqdescription = (Label)Dl_Questionaire.Items[i].FindControl("lblqdescription");
                        RadioButtonList rdbtn_OptA = (RadioButtonList)Dl_Questionaire.Items[i].FindControl("rdbtn_OptA");

                        DataTable dtQID = new DataTable();
                        dtQID.Columns.Add("Option");
                        dtQID.Rows.Add(ds_Search.Tables[0].Rows[i]["OptA"].ToString());
                        dtQID.Rows.Add(ds_Search.Tables[0].Rows[i]["OptB"].ToString());
                        dtQID.Rows.Add(ds_Search.Tables[0].Rows[i]["OptC"].ToString());
                        dtQID.Rows.Add(ds_Search.Tables[0].Rows[i]["OptD"].ToString());


                        if (ds_Search.Tables[0].Rows[i][1].ToString() == "7")
                        {

                            dtQID.Rows.Add(ds_Search.Tables[0].Rows[i]["OptE"].ToString());

                        }

                        rdbtn_OptA.DataSource = dtQID;

                        rdbtn_OptA.DataTextField = "Option";
                        rdbtn_OptA.DataValueField = "Option";
                        rdbtn_OptA.DataBind();

                    }
                    //added by prashant to display the existig answer selected by user preveously
                    obj_PubHPdetails.PostedBy = ViewState["UserID"].ToString();

                    foreach (DataListItem dlt in Dl_Questionaire.Items)
                    {

                        ds_LastAns = obj_PubHPdetails.GetLastAnswer_PublicPollAnswer(obj_PubHPdetails);
                        if (ds_LastAns.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds_LastAns.Tables[0].Rows.Count - 1; k++)
                            {
                                RadioButtonList rdbtn_OptSet = (RadioButtonList)dlt.FindControl("rdbtn_OptA");
                                RadioButtonList rblQ6 = (RadioButtonList)dlt.FindControl("rblQ6");
                                Label lblqid1 = (Label)dlt.FindControl("lblqid");
                                Label lblQuestionId = (Label)dlt.FindControl("lblQuestionId");

                                // ansid = Convert.ToInt32(ds_LastAns.Tables[0].Rows[k]["Aid"].ToString());
                                obj_PubHPdetails.Qid = Convert.ToInt32(lblqid1.Text);

                                ansid = Convert.ToInt32(ds_LastAns.Tables[0].Rows[k]["Answer"].ToString());
                                //added bello if (lblQuestionId.Text == ds_LastAns.Tables[0].Rows[k]["Qid"].ToString())
                                if (lblqid1.Text == ds_LastAns.Tables[0].Rows[k]["Qid"].ToString())
                                {
                                    //start here
                                    //if (ds_LastAns.Tables[0].Rows[k]["Qid"].ToString() == "7")
                                    //{
                                    //    rblQ6.SelectedIndex = 1;
                                    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "hide", "hideQ6();", true);
                                    //}
                                    //else if (ds_LastAns.Tables[0].Rows[k]["Qid"].ToString() == "11")
                                    //{
                                    //    rblQ6.SelectedIndex = 1;
                                    //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "hide", "hideQ6();", true);
                                    //}
                                    //end here
                                    
                                    if (ansid == 1)
                                    {
                                        rdbtn_OptSet.SelectedIndex = 0;

                                    }
                                    else  if (ansid == 2)
                                    {
                                        rdbtn_OptSet.SelectedIndex = 1;
                                    }

                                    else if (ansid == 3)
                                    {
                                        rdbtn_OptSet.SelectedIndex = 2;
                                    }
                                    else if (ansid == 4)
                                    { rdbtn_OptSet.SelectedIndex = 3; }
                                    else

                                    { rdbtn_OptSet.SelectedIndex = 4; }
                                }
                            }
                        }
                    }

                }
                else
                {

                    lblError.Visible = true;
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

        //foreach (DataListItem dlt in Dl_Questionaire.Items)
        //{
        //    RadioButtonList rdbtn_OptSet = (RadioButtonList)dlt.FindControl("rdbtn_OptA");
        //    RadioButtonList rblQ6 = (RadioButtonList)dlt.FindControl("rblQ6");
        //    RequiredFieldValidator rfv = (RequiredFieldValidator)dlt.FindControl("RequiredFieldValidator1");
        //    if (rdbtn_OptSet.SelectedIndex < 0)
        //    { rfv.Visible = true; }
        //    else
        //    { rfv.Visible = false ; }
        //}

        DataTable dts = new DataTable();
        dts = GenerateAnswerTable();
        if (dts != null)
        {
            obj_PubHPdetails.PostedBy = ViewState["UserID"].ToString();
            obj_HPDetails.inertTB_PublicPollAnswer(dts, obj_PubHPdetails);
            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "Graph/RadarGraph.aspx";
            Response.Redirect(_redirectPath);
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Data Saved Successfully.'); location='" + _redirectPath + "';</Script>");

        }

    }

    private DataTable GenerateAnswerTable()
    {
        try
        {
            bool flag;
            string status = "no";
            dt.Columns.Add("Qid");
            dt.Columns.Add("Answer");

            foreach (DataListItem li in Dl_Questionaire.Items)
            {
                flag = true; ;
                RadioButtonList rdbtn_OptA = (RadioButtonList)li.FindControl("rdbtn_OptA");
                RadioButtonList rblQ6 = (RadioButtonList)li.FindControl("rblQ6");
                Label lblqid = (Label)li.FindControl("lblqid");
                //Label lblQuestionId = (Label)li.FindControl("lblQuestionId");

                int qid = Convert.ToInt32(lblqid.Text);

                if (rdbtn_OptA.SelectedIndex == 0)
                {
                    ans = 1;
                }
                else if (rdbtn_OptA.SelectedIndex == 1)
                {
                    ans = 2;
                }
                else if (rdbtn_OptA.SelectedIndex == 2)
                {
                    ans = 3;
                }
                else if (rdbtn_OptA.SelectedIndex == 3)
                {
                    ans = 4;
                }
                else
                {
                    ans = 0;
                }
                obj_PubHPdetails.Qid = qid;
                obj_PubHPdetails.Answer = ans;

                DataRow dr = dt.NewRow();
                dr["Qid"] = obj_PubHPdetails.Qid;
                dr["Answer"] = obj_PubHPdetails.Answer;

                dt.Rows.Add(dr);
                // }               

            }

        }
        catch (Exception ex)
        {
            throw ex;

            // ABSCommon.Common.ShowMessage(this,ex.Message);


        }
        return dt;

    }

    //public void Clear_Selection()
    //{
    //    foreach (DataListItem dlt in Dl_Questionaire.Items)
    //    {
    //        RadioButtonList rdbtn_OptA = (RadioButtonList)dlt.FindControl("rdbtn_OptA");
    //        rdbtn_OptA.ClearSelection();

    //    }
    //}


    //protected void Dl_Questionaire_ItemDataBound(object sender, DataListItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item ||
    //     e.Item.ItemType == ListItemType.AlternatingItem)
    //    {

    //        if (e.Item.ItemIndex == 6)
    //        {
    //            e.Item.CssClass = "AlternateGridRow";
    //        }
    //        if (e.Item.ItemIndex == 7)
    //        {
    //            e.Item.CssClass = "GridRow";
    //        }
    //        if (e.Item.ItemIndex == 8)
    //        {
    //            e.Item.CssClass = "AlternateGridRow";
    //        }
    //        if (e.Item.ItemIndex == 9)
    //        {
    //            e.Item.CssClass = "GridRow";
    //        }
    //        if (e.Item.ItemIndex == 10)
    //        {
    //            e.Item.CssClass = "AlternateGridRow";
    //        }           
    //    }

    //}

    protected override void InitializeCulture()
    {
        string culture = string.Empty;
        //culture = Request.Form["ddlLang"];
        // if (string.IsNullOrEmpty(culture)) culture = "Auto";
        //   UICulture = "zh-SG";
        //  Page.Culture = "zh-SG";
        culture = Convert.ToString(Session["Culture"]);
        if (culture != "Auto")
        {
            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

        }

    }
    
}