using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ABSCommon;


public partial class Administration_Group_Update : System.Web.UI.Page
{
    private DataSet DS_Temp;
    private Function_Maintain_Logic my_Function_Maintain_Logic = new Function_Maintain_Logic();
    private Group_Maintain_Logic my_Group_Maintain_Logic = new Group_Maintain_Logic();
    private string StrCheckAccess;
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();



    public static string token;
    protected void Page_Load(object sender, EventArgs e)
    {
    
       



        if (!(Page.IsPostBack))
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[0];
            token = Request.Form["token"];

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {


                if (Session["USER_ID"] != null)
                {
                    ViewState["USER_ID"] = Convert.ToString(Session["USER_ID"]);
                }
                ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
                //Bttn_Save.Attributes.Add("onClick", "return confirm('Do you want to update this group? Click OK to update. Otherwise, click Cancel.');");
                //this.Rad_Yes.Attributes.Add("onClick", "toggleAllCheckboexs(true);");
                //this.Rad_No.Attributes.Add("onClick", "document.frm1.reset();this.checked=true;");
                Bind_DataGrid();
            }
        }
    }

        public int instr_fun(string str1,string str2)
		{
			string SearchString;
			SearchString =str1;
			int myPos=SearchString.IndexOf(str2);
			return myPos;
		}
		private void Bind_DataGrid() 
		{
            my_Group_Maintain_Logic.GROUP_ID = CommonFunctions.Decrypt(Request["IDforEdit"]);
 
			my_Group_Maintain_Logic.Get_Group_Vlues(); 
			this.Txt_Group_Id.Text = my_Group_Maintain_Logic.GROUP_ID; 
			this.Txt_Group_Id.ReadOnly = true; 
			this.Txt_Group_Id.BorderStyle = BorderStyle.None; 
			
			this.Txt_Description.Text = my_Group_Maintain_Logic.GROUP_DESCR; 
            //if (my_Group_Maintain_Logic.IS_ADMIN == "Y") 
            //{ 
            //    this.Rad_Yes.Checked = true; 
            //} 
            //else 
            //{ 
            //    this.Rad_No.Checked = true; 
            //} 
            DS_Temp = my_Group_Maintain_Logic.Get_Fun_Update_List(Session["GROUP_ID"].ToString()); 
			if (DS_Temp.Tables[0].Rows.Count == 0) 
			{ 
				this.Lblnorecords.Visible = true; 
			} 
			this.DG_Function_List.DataSource = DS_Temp; 
			this.DG_Function_List.DataBind(); 
		}
    protected void Bttn_Save_Click(object sender, ImageClickEventArgs e) 
		{   

			Page.Validate(); 
			if (!(Page.IsValid)) 
			{
                //Commented by Dinakar on 4-12-2007 changed the message so that user can understand it clearly
				//lblError.Text = "Please enter the mandatory fields (coloured).";

                lblError.Text = "Fields marked '*' are compulsory"; 
				lblError.Visible = true; 
			} 
			else
            {
               				
			
				my_Group_Maintain_Logic.GROUP_ID = CommonBindings.TextToBind(this.Txt_Group_Id.Text); 
				my_Group_Maintain_Logic.GROUP_DESCR = CommonBindings.TextToBind(this.Txt_Description.Text); 
				my_Group_Maintain_Logic.DISC_PERCENT = "0"; 
				my_Group_Maintain_Logic.EXTRA_FREE_PACKS ="0"; 
				my_Group_Maintain_Logic.MAINT_BY = Convert.ToString(ViewState["USER_ID"]); 
				my_Group_Maintain_Logic.IS_ADMIN = "Y"; 
				my_Group_Maintain_Logic.Update_Group(Request["Cbx_Fid"]);
                
                //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
                //string response = "<script type='text/javascript'>alert('Group has successfully updated');parent.mainframe.location.href='" + navurl + "';</script>";
                //Response.Write(response); 


                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");


                //Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0] + "?showList=Y"); 
			} 
		}
		 
		public string Is_Exist(string Str_Fid) 
		{
            my_Group_Maintain_Logic.GROUP_ID = CommonFunctions.Decrypt(Request["IDforEdit"]);
			if (my_Group_Maintain_Logic.Is_Function_Exist(Str_Fid)) 
			{ 
				return "Checked"; 
			} 
			else 
			{ 
				return ""; 
			} 
		}
        protected void DG_Function_List_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e) 
		{ 
			my_Group_Maintain_Logic.Sort_On_Fun = e.SortExpression; 
			Bind_DataGrid(); 
		}

    protected void Bttn_Back_Click(object sender, ImageClickEventArgs e)
		{
		Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0]); 
		}
//
//		private void Bttn_Save_Click(object sender, System.EventArgs e)
//		{
//			Page.Validate(); 
//			if (!(Page.IsValid)) 
//			{ 
//				lblError.Text = "Please enter the mandatory fields (coloured)."; 
//				lblError.Visible = true; 
//			} 
//			else 
//			{ 
//				my_Group_Maintain_Logic.GROUP_ID = Request["Group_ID"]; 
//				my_Group_Maintain_Logic.Get_Group_Vlues(); 
//				my_Group_Maintain_Logic.GROUP_ID = this.Txt_Group_Id.Text; 
//				my_Group_Maintain_Logic.GROUP_DESCR = this.Txt_Description.Text; 
//				my_Group_Maintain_Logic.DISC_PERCENT = Txt_Disc_Percent.Text; 
//				my_Group_Maintain_Logic.EXTRA_FREE_PACKS = Txt_No_FreePacks.Text; 
//				my_Group_Maintain_Logic.MAINT_BY = Session["USER_ID"].ToString(); 
//				my_Group_Maintain_Logic.MAINT_DT =string.Format("('{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Today)) + "')";
//				if (this.Rad_Yes.Checked) 
//				{ 
//					my_Group_Maintain_Logic.IS_ADMIN = "Y"; 
//				} 
//				else 
//				{ 
//					my_Group_Maintain_Logic.IS_ADMIN = "N"; 
//				} 
//				my_Group_Maintain_Logic.GROUP_ID = Request["IDforEdit"]; 
//				my_Group_Maintain_Logic.Update_Group(Request["Cbx_Fid"]); 
//				Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0] + "?showList=Y"); 
//			}
//		}

	}
 
