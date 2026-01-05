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


public partial class Public_FinancialMgtCapabilities : System.Web.UI.Page
{


    CommonFunctions commonfunction = new CommonFunctions();
    HealthProfiling obj_HPDetails = new HealthProfiling();
    // PublicHealthProfiling obj_PubHPdetails = new PublicHealthProfiling();
    FinancialMgtCapabilities obj_FinMgtCapabilities = new FinancialMgtCapabilities();
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
                if (Session["LoginDTO"] == null)
                {
                    Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
                }
                else
                {
                    LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                    ViewState["UserID"] = objLoginDTO.UserID;

                }
                EvalQuestionaire objEval = new EvalQuestionaire();

                //obj_HPDetails.Type = "all";
                //obj_HPDetails.Qid = 0;
                //obj_HPDetails.Qdescription = "";
                //// obj_HPDetails.Category = "";
                //obj_HPDetails.Category = null;


                //   ds_Search = obj_HPDetails.Get_HealthProfileDetails(obj_HPDetails);
                obj_FinMgtCapabilities.Culture = Convert.ToString(Session["Culture"]);
                ds_Search = obj_FinMgtCapabilities.Get_FinalcialMgtDetails(obj_FinMgtCapabilities);

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
                        //added below if (ds_Search.Tables[0].Rows[i][6] != "")
                        if (ds_Search.Tables[0].Rows[i][6] != "" && lblqid.Text !="9" )
                            

                        {
                            //if (dt.Columns.Count > 4)
                            //{
                            dtQID.Rows.Add(ds_Search.Tables[0].Rows[i]["OptE"].ToString());
                            //}
                        }
                        rdbtn_OptA.DataSource = dtQID;

                        rdbtn_OptA.DataTextField = "Option";
                        rdbtn_OptA.DataValueField = "Option";
                        rdbtn_OptA.DataBind();

                        //if (i == 5 || i == 6)
                        //{
                        //    rdbtn_OptA.Style.Add("display", "none");
                        //}
                        //if (i == 6)
                        //{
                        //    lblqdescription.Style.Add("display", "none");
                        //}
                    }

                    obj_FinMgtCapabilities.PostedBy = ViewState["UserID"].ToString();

                    foreach (DataListItem dlt in Dl_Questionaire.Items)
                    {

                        ds_LastAns = obj_FinMgtCapabilities.GetLastAnswer_FinancialMgtAnswer(obj_FinMgtCapabilities);
                        if (ds_LastAns.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds_LastAns.Tables[0].Rows.Count - 1; k++)
                            {
                                RadioButtonList rdbtn_OptSet = (RadioButtonList)dlt.FindControl("rdbtn_OptA");
                                // RadioButtonList rblQ6 = (RadioButtonList)dlt.FindControl("rblQ6");
                                Label lblqid1 = (Label)dlt.FindControl("lblqid");
                                // Label lblQuestionId = (Label)dlt.FindControl("lblQuestionId");

                                // ansid = Convert.ToInt32(ds_LastAns.Tables[0].Rows[k]["Aid"].ToString());
                                obj_FinMgtCapabilities.Qid = Convert.ToInt32(lblqid1.Text);
                                //obj_FinMgtCapabilities.Qid = Convert.ToInt32 ( ds_LastAns.Tables[0].Rows[k][1].ToString());


                                ansid = Convert.ToInt32(ds_LastAns.Tables[0].Rows[k]["Answer"].ToString());
                                if (lblqid1.Text == ds_LastAns.Tables[0].Rows[k]["Qid"].ToString())
                                {

                                    if (ansid == 1)
                                    {
                                        rdbtn_OptSet.SelectedIndex = 0;

                                    }
                                    if (ansid == 2)
                                    {
                                        rdbtn_OptSet.SelectedIndex = 1;
                                    }

                                    if (ansid == 3)
                                    {
                                        rdbtn_OptSet.SelectedIndex = 2;
                                    }
                                    if (ansid == 4)
                                    { rdbtn_OptSet.SelectedIndex = 3; }
                                    if (ansid == 0)
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
        DataTable dts = new DataTable();
        dts = GenerateAnswerTable();
        if (dts != null)
        {

            obj_FinMgtCapabilities.PostedBy = ViewState["UserID"].ToString();
            //obj_PubHPdetails.PostedBy = Session["USER_ID"].ToString();
            //obj_HPDetails.inertTB_PublicPollAnswer(dts, obj_FinMgtCapabilities);
            obj_FinMgtCapabilities.inertTB_PublicFinalcialMgtPollAnswer(dts, obj_FinMgtCapabilities);

            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "Graph/FinancialMgtCapabilitiesRadarGraph.aspx";
            //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "javascript:alert('Data Saved Successfully.',window.location('" + _redirectPath + "'))", true);
           // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Data Saved Successfully.'); location='" + _redirectPath + "';</Script>");
            // Clear_Selection();
            Response.Redirect(_redirectPath);
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
                int qid = Convert.ToInt32(lblqid.Text);
                //Label lblQuestionId = (Label)li.FindControl("lblQuestionId");

                //int qid = Convert.ToInt32(lblQuestionId.Text);
                //if (qid == 6)
                //{
                //    if (rblQ6.SelectedIndex == 0)
                //    {
                //        flag = true;
                //        status = "yes";
                //    }
                //    else
                //        flag = false;

                //}
                //else if (qid == 11)
                //{
                //    if (status == "no")
                //    {
                //        flag = true;
                //    }
                //    else
                //        flag = false;

                //}
                //if (flag == false)
                //{

                //}
                //else
                //{
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
                obj_FinMgtCapabilities.Qid = qid;
                obj_FinMgtCapabilities.Answer = ans;

                DataRow dr = dt.NewRow();
                dr["Qid"] = obj_FinMgtCapabilities.Qid;
                dr["Answer"] = obj_FinMgtCapabilities.Answer;

                dt.Rows.Add(dr);
            }

            //}

        }
        catch (Exception ex)
        {
            throw ex;

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


    protected void Dl_Questionaire_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item ||
        // e.Item.ItemType == ListItemType.AlternatingItem)
        //{

        //    if (e.Item.ItemIndex == 6)
        //    {
        //        e.Item.CssClass = "AlternateGridRow";
        //    }
        //    if (e.Item.ItemIndex == 7)
        //    {
        //        e.Item.CssClass = "GridRow";
        //    }
        //    if (e.Item.ItemIndex == 8)
        //    {
        //        e.Item.CssClass = "AlternateGridRow";
        //    }
        //    if (e.Item.ItemIndex == 9)
        //    {
        //        e.Item.CssClass = "GridRow";
        //    }
        //    if (e.Item.ItemIndex == 10)
        //    {
        //        e.Item.CssClass = "AlternateGridRow";
        //    }
        //}

    }

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