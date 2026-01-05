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

using ABSBLL;
using ABSCommon;
using System.Data;


public partial class Administration_Admin_AddNewsAnnouncement : System.Web.UI.Page
{

    NewsAnnouncementDetails obj_NsDetails = new NewsAnnouncementDetails();
    CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();

    public string strparm;
    public string strtags = "";
    DataSet tagds = new DataSet();
    DataSet ds_Search;
    int index = 0;
    public static string token;
    int nid=0;
    protected void Page_Load(object sender, EventArgs e)
    {
      

        //ViewState["type"] = "insert";
       
       
        if (!Page.IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[1];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

           // string v = Request["IDforEdit"].ToString();
            token = Request["token"].ToString();
            lbloperation.Text = "insert";
            if (token != "")
            {

                BindCheckList();
                if (Request["IDforEdit"] != "")
                {

                    string str = CommonFunctions.Decrypt(Request["IDforEdit"]);
                    nid = Convert.ToInt32(str);
                    ViewState["nid"] = nid;
                    BindCheckListWithSel(nid);
                    // ViewState["type"] = "update";
                    lbloperation.Text = "update";

                    Get_NewsDetails_ById(nid);


                }


            }
            else
            {
                Response.Redirect("default.aspx");
            
            }

        }

    }
    public void Get_NewsDetails_ById(int id)
    {
        obj_NsDetails.N_ID = id;

        DataSet dsbyid = obj_NsDetails.Get_NewsDetails_ByID(obj_NsDetails);
        if (dsbyid.Tables[0].Rows.Count > 0)
        {
            id_txt_AddTitle.Text = dsbyid.Tables[0].Rows[0]["NewsTitle"].ToString();
            id_txt_AddAuthor.Text = dsbyid.Tables[0].Rows[0]["Author_Name"].ToString();
            id_txt_AddDescription.Text = dsbyid.Tables[0].Rows[0]["NewsDescription"].ToString();
            id_txt_AddDetails.Text = dsbyid.Tables[0].Rows[0]["News_Details"].ToString();
            id_ddl_Rating.SelectedValue = dsbyid.Tables[0].Rows[0]["Rating"].ToString();
            DatePicker_PublishedOn.DateString  = CommonBindings.TextToBind(dsbyid.Tables[0].Rows[0]["publishedon"].ToString());
          
        }
    
    
    }
    public void BindCheckListWithSel(int nid)
    {
        DataSet dsselcat = new System.Data.DataSet();

        obj_NsDetails.N_ID  = nid ;
        dsselcat = obj_NsDetails.GetSelCategory (obj_NsDetails );
        string[] j = new string[5];
        int count = dsselcat.Tables[0].Rows.Count;
        for (int p = 0; p < count; p++)
        {
            string kj = dsselcat.Tables[0].Rows[p][0].ToString();
            id_cklist.Items.FindByValue(dsselcat.Tables[0].Rows[p][0].ToString()).Selected = true;
        }
    }
    public void BindCheckList()
    {
        DataSet ds = new DataSet();

        ds = obj_NsDetails.Get_Category(obj_NsDetails);
        id_cklist.DataSource = ds;
        id_cklist.DataTextField = "TopicName";
        id_cklist.DataValueField = "TopicID";
        id_cklist.DataBind();
        

    }    

    public void bingcategory()
    {



    }
   
    public void Insert_Category()
    {
        string[] kk = new string[5];
        int ii = 0;
        obj_NsDetails.N_ID = Convert.ToInt32(ViewState["nid"].ToString());


        foreach (ListItem listItems in id_cklist.Items)
        {


            if (listItems.Selected)
            {
                obj_NsDetails.tags[ii] = Convert.ToInt32(listItems.Value.ToString());
                kk[ii] = obj_NsDetails.tags[ii].ToString();

                obj_NsDetails.tagno = int.Parse(kk[ii]);
                obj_NsDetails.Insert_CategoryDetails(obj_NsDetails);

            }
            else
            { //do something else }
            }
            ii++;
        }
    }
    int id;
    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {

        if (lbloperation.Text  == "insert")
        {
            obj_NsDetails.Type = "insert";
            //obj_NsDetails.N_ID = Convert.ToInt32(ViewState["nid"].ToString());

            //obj_NsDetails.Delete_CategoryDetails(obj_NsDetails);
           // Insert_Category();

            obj_NsDetails.Title = id_txt_AddTitle.Text;
            obj_NsDetails.Description = id_txt_AddDescription.Text;
            obj_NsDetails.Author = id_txt_AddAuthor.Text;
            obj_NsDetails.Published_On = Convert.ToDateTime(DatePicker_PublishedOn.DateString);
            obj_NsDetails.Created_On = DateTime.Now.Date;
            obj_NsDetails.Created_By = Session["USER_ID"].ToString();
            obj_NsDetails.Updated_On = DateTime.Now.Date;
            obj_NsDetails.Updated_By = Session["USER_ID"].ToString();
            obj_NsDetails.Rating = Convert.ToInt32(id_ddl_Rating.SelectedItem.Value);
            obj_NsDetails.NewsDetails = id_txt_AddDetails.Text;
           

            string[] kk = new string[5];
            int ii = 0;
            id = obj_NsDetails.Update_NewsDetails(obj_NsDetails);
            ViewState["nid"]=id;
           obj_NsDetails.N_ID = Convert.ToInt32(ViewState["nid"].ToString());


            foreach (ListItem listItems in id_cklist.Items)
            {


                if (listItems.Selected)
                {
                    obj_NsDetails.tags[ii] = Convert.ToInt32(listItems.Value.ToString());
                    kk[ii] = obj_NsDetails.tags[ii].ToString();

                    obj_NsDetails.tagno = int.Parse(kk[ii]);
                    obj_NsDetails.Insert_CategoryDetails(obj_NsDetails);

                }
                else
                { //do something else }
                }
                ii++;
            }

           
            //obj_NsDetails.N_ID = Convert.ToInt32(ViewState["nid"].ToString());


            //ViewState["id"] = obj_NsDetails.N_ID;
            //obj_NsDetails.N_ID = Convert.ToInt32(ViewState["id"].ToString());

            
        }
      //  if (lbloperation.Text == "update")
        else 

        {
            obj_NsDetails.N_ID =Convert.ToInt32( ViewState["nid"].ToString());

            obj_NsDetails.Delete_CategoryDetails(obj_NsDetails);
            Insert_Category();

            obj_NsDetails.Type = "update";
            obj_NsDetails.Title = id_txt_AddTitle.Text;
            obj_NsDetails.Description = id_txt_AddDescription.Text;
            obj_NsDetails.Author = id_txt_AddAuthor.Text;
            obj_NsDetails.Published_On = Convert.ToDateTime(DatePicker_PublishedOn.DateString);
            obj_NsDetails.Created_On = DateTime.Now.Date;
            obj_NsDetails.Created_By = Session["USER_ID"].ToString();
            obj_NsDetails.Updated_On = DateTime.Now.Date;
            obj_NsDetails.Updated_By = Session["USER_ID"].ToString();
            obj_NsDetails.Rating = Convert.ToInt32(id_ddl_Rating.SelectedItem.Value);
            obj_NsDetails.NewsDetails = id_txt_AddDetails.Text;
            obj_NsDetails.N_ID = Convert.ToInt32(ViewState["nid"].ToString());


            //ViewState["id"] = obj_NsDetails.N_ID;
            //obj_NsDetails.N_ID = Convert.ToInt32(ViewState["id"].ToString());

             id = obj_NsDetails.Update_NewsDetails(obj_NsDetails);
        }

      

      if (id > 0)
      { 
          

      //string[] kk = new string[5];
      //int ii = 0;
      //obj_NsDetails.N_ID = id;
    

      //foreach (ListItem listItems in id_cklist.Items)
      //{
        
          
      //    if (listItems.Selected)
      //    {
      //        obj_NsDetails.tags[ii] = Convert.ToInt32(listItems.Value.ToString());
      //        kk[ii] = obj_NsDetails.tags[ii].ToString();
              
      //        obj_NsDetails.tagno = int.Parse(kk[ii]);
      //        obj_NsDetails.Insert_CategoryDetails(obj_NsDetails);

      //    }
      //    else
      //    { //do something else }
      //    }
      //    ii++;

        
          
         // }


      string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
      this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('News And Announcement Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");




       }

       

      }
    public void Delete_Category(int nid)
    {
        obj_NsDetails.N_ID = nid;
       
    
    }
  
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {

    }
}
