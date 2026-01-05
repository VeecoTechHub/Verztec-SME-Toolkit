using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using ABSDTO;
using System.Configuration;
public partial class Public_MyRLFavouritesDtls : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    ResourceLibDetails obj_RLDetails = new ResourceLibDetails();
    UserMgmt objUserMgmt = new UserMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["RL_ID"] != null)
            {
                ViewState["RL_ID"] = commonfunction.Decrypt(Request.QueryString["RL_ID"].ToString());
                BindData();
            }

         
        }
    }
    public void BindData()
    {
        try
        {
            obj_RLDetails.RL_ID = Convert.ToInt32(ViewState["RL_ID"]);
            DataSet ds_search = obj_RLDetails.Get_ResourceLibDetails_ByID_Public(obj_RLDetails);
            if (ds_search != null)
            {
                if (ds_search.Tables[0].Rows.Count > 0)
                {
                    id_datalist.DataSource = ds_search;
                    id_datalist.DataBind();
                }

                else
                {
                    id_datalist.DataSource = ds_search;
                    id_datalist.DataBind();
                }

            }

        }
        catch (Exception ex)
        {
            throw ex;

        }
    }

    public string GetImg(object RID)
    {
        string rstring = string.Empty;
        int rint = (int)RID;
        if (rint == 1)
        {
            rstring = "../images/img_rating1.png";
        }

        else if (rint == 2)
        {
            rstring = "../images/img_rating2.png";
        }
        else if (rint == 3)
        {
            rstring = "../images/img_rating3.png";
        }
        else if (rint == 4)
        {
            rstring = "../images/img_rating4.png";
        }
        else if (rint == 5)
        {
            rstring = "../images/img_rating5.png";
        }

        return rstring;
    }

    protected void id_datalist_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.ToString().ToLower().Equals("delete"))
        {

            obj_RLDetails.RL_ID = Convert.ToInt32(e.CommandArgument);
            //obj_RLDetails.Created_On = DateTime.Now;
            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                {
                    obj_RLDetails.Created_By = objLoginDTO.UserID;
                }
            }
            int resval = obj_RLDetails.Delete_AddRLFavourite(obj_RLDetails);
            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "/public/MyRLFavourites.aspx";
            if (resval != -1)
            {


                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<Script language='javascript'> alert('Removed from your favourites successfully.'); location='" + _redirectPath + "';</Script>");

            }
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Already this article is Removed from your favourites.');;location='" + _redirectPath + "';</script>");
            
        }
        
       



    }

    public string DateFormat(DateTime date)
    {
        //date = Convert.ToDateTime(date.Day + "/" + date.Month + "/" + date.Year);
        return date != null ? ((DateTime)date).ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"].ToString()) : "";
    }
}