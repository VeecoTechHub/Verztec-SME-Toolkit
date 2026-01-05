using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using System.Data.SqlClient;
using ABSCommon;
using ABSDTO;
using System.Text;
using System.Configuration;
public partial class Administration_Admin_AddHealthProfiling : System.Web.UI.Page
{
    HealthProfiling obj_HPDetails = new HealthProfiling();
    ResourceLibDetails obj_RsDetails = new ResourceLibDetails();

    CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();

    public string strparm;
    public string strtags = "";
    DataSet tagds = new DataSet();
    DataSet ds_Search;
    int index = 0;
    public static string token;
    int qid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
      

        if (!Page.IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[0];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            lbloperation.Text = "insert";
            // string v = Request["IDforEdit"].ToString();
            token = Request["token"].ToString();
            lbloperation.Text = "insert";
            if (token != "")
            {

                // BindCheckList();
                if (Request["IDforEdit"] != "")
                {

                    string id = CommonFunctions.Decrypt(Request["IDforEdit"]);
                    qid = Convert.ToInt32(id);
                    ViewState["qid"] = qid;
                    lbloperation.Text = "update";

                    binddata(qid);

                }


            }
            else
            {
                Response.Redirect("default.aspx");

            }

        }

    }
    public void binddata(int qid)
    {
        obj_HPDetails.Type = "id";
        obj_HPDetails.Qid = qid;



        ds_Search = obj_HPDetails.Get_HealthProfileDetails(obj_HPDetails);
        if (ds_Search.Tables[0].Rows.Count > 0)
        {
            txt_Description.Text = ds_Search.Tables[0].Rows[0]["Qdescription"].ToString();
            txt_OptA.Text = ds_Search.Tables[0].Rows[0]["OptA"].ToString();
            txt_OptB.Text = ds_Search.Tables[0].Rows[0]["OptB"].ToString();
            txt_OptC.Text = ds_Search.Tables[0].Rows[0]["OptC"].ToString();
            txt_OptD.Text = ds_Search.Tables[0].Rows[0]["OptD"].ToString();
            //ddl_Answer.SelectedItem.Text = ds_Search.Tables[0].Rows[0]["Answer"].ToString();
        }


    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {

    }
    int id;
    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {


        if (lbloperation.Text == "insert")
        {
            obj_HPDetails.Type = "insert";

            obj_HPDetails.Qid = 0;



            obj_HPDetails.Qdescription = txt_Description.Text;
            obj_HPDetails.OptA = txt_OptA.Text;
            obj_HPDetails.OptB = txt_OptB.Text;
            obj_HPDetails.OptC = txt_OptC.Text;
            obj_HPDetails.OptD = txt_OptD.Text;
            obj_HPDetails.CreatedBy = Session["USER_ID"].ToString();
            obj_HPDetails.CreatedOn = DateTime.Now.Date;
           // obj_HPDetails.Answer = Convert.ToInt32(ddl_Answer.SelectedItem.Value);


            id = obj_HPDetails.Update_HealthProfileDetails(obj_HPDetails);

            if (id > 0)
            {



                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('HealthProfile Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");




            }
        }

        //UPDATE 

        if (lbloperation.Text == "update")
        {
            obj_HPDetails.Type = "update";

            string editid = ViewState["qid"].ToString();

            obj_HPDetails.Qid = Convert.ToInt32(editid);




            obj_HPDetails.Qdescription = txt_Description.Text;
            obj_HPDetails.OptA = txt_OptA.Text;
            obj_HPDetails.OptB = txt_OptB.Text;
            obj_HPDetails.OptC = txt_OptC.Text;
            obj_HPDetails.OptD = txt_OptD.Text;
            obj_HPDetails.CreatedBy = Session["USER_ID"].ToString();
            obj_HPDetails.CreatedOn = DateTime.Now.Date;
            obj_HPDetails.Answer =0;




            id = obj_HPDetails.Update_HealthProfileDetails(obj_HPDetails);
           
            if (id > 0)
            {



                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('HealthProfile Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");




            }

        }

    }
    
}
