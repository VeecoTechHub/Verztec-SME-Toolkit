using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ABSCommon;
using System.IO;

public partial class Administration_AdminBanner : System.Web.UI.Page
{
    private CommonFunctions CommonFunctions = new CommonFunctions();
    BannerDetails objGet = new BannerDetails();
    public HiddenField hdTopBanner = new HiddenField();
    public HiddenField hdBanner2 = new HiddenField();
    public HiddenField hdBanner3 = new HiddenField();
    public HiddenField hdBanner4 = new HiddenField();
    public HiddenField hdBanner5 = new HiddenField();
    public HiddenField hdRHSBanner7 = new HiddenField();
    public HiddenField hdAddBanner = new HiddenField();
    public HiddenField hdCreatedBy = new HiddenField();
    public HiddenField hdUpdatedBy = new HiddenField();

    public HiddenField hdFooterBanner1 = new HiddenField();
    public HiddenField hdFooterBanner2 = new HiddenField();
    public HiddenField hdFooterBanner3 = new HiddenField();
    public HiddenField hdFooterBanner4 = new HiddenField();

    public HiddenField hdAdBanner1 = new HiddenField();
    public HiddenField hdAdBanner2 = new HiddenField();
    public HiddenField hdAdBanner3 = new HiddenField();
    public HiddenField hdAdBanner4 = new HiddenField();


    public HiddenField hdCount = new HiddenField();
    Check_Access chkAccess = new Check_Access();

    bool IsfromCulture=false;


    public static string token;
    string StrFileName = string.Empty;
    public DataSet dsBannerDetails = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];


            Getdata();
            token = Request.Form["token"];

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
        }
        //else
        //{
        //    //ViewState["Operation"] = "";
        //    //ViewState["dsBanner"] = "";
        //    Getdata();
        //}

    }


    private void Getdata()
    {
        DataSet dsBanner = new DataSet();

        objGet.Culture = rblCulture.SelectedItem.Value;
        dsBanner = objGet.GetBannerDetails_Culture(objGet);
      //  dsBanner = objGet.GetBannerDetails();

        if (IsfromCulture)
        {
            dsBanner = (DataSet)ViewState["dsBannerCulture"];
            Clear();
        }
      
        ViewState["dsBanner"] = (DataSet)dsBanner;

        if (dsBanner.Tables[0].Rows.Count > 0)
        {
            if (dsBanner.Tables[0].Rows[0][1].ToString() != "")
            {
                hdTopBanner.Value = dsBanner.Tables[0].Rows[0][1].ToString();
                hlTopBanner.Visible = true;
                hlTopBanner.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][1].ToString();
            }

            if (dsBanner.Tables[0].Rows[0][2].ToString() != "")
                txtTopBannerUrl.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][2].ToString());
            else
                txtTopBannerUrl.Text = txtTopBannerUrl.Text.Trim().ToString();
            if (dsBanner.Tables[0].Rows[0][3].ToString() != "")
            {
                hdBanner2.Value = dsBanner.Tables[0].Rows[0][3].ToString();
                hlBanner2.Visible = true;
                hlBanner2.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][3].ToString();
            }
            else
            {
                hdBanner2.Value = dsBanner.Tables[0].Rows[0][3].ToString();
                hlBanner2.Visible = false;
            }
            txtBannerUrl2.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][4].ToString());

            if (dsBanner.Tables[0].Rows[0][5].ToString() != "")
            {
                hdBanner3.Value = dsBanner.Tables[0].Rows[0][5].ToString();
                hlBanner3.Visible = true;
                ibtnBanner3.Visible = true;
                hlBanner3.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][5].ToString();
            }
            else
            {
                hdBanner3.Value = dsBanner.Tables[0].Rows[0][5].ToString();
                hlBanner3.Visible = false;
                ibtnBanner3.Visible = false;
            }
            txtBannerUrl3.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][6].ToString());

            if (dsBanner.Tables[0].Rows[0][7].ToString() != "")
            {
                hdBanner4.Value = dsBanner.Tables[0].Rows[0][7].ToString();
                hlBanner4.Visible = true;
                ibtnBanner4.Visible = true;
                hlBanner4.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][7].ToString();
            }
            else
            {
                hdBanner4.Value = dsBanner.Tables[0].Rows[0][7].ToString();
                hlBanner4.Visible = false;
                ibtnBanner4.Visible = false;
            }
            txtBannerUrl4.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][8].ToString());
            if (dsBanner.Tables[0].Rows[0][9].ToString() != "")
            {
                hdBanner5.Value = dsBanner.Tables[0].Rows[0][9].ToString();
                hlBanner5.Visible = true;
                ibtnBanner5.Visible = true;
                hlBanner5.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][9].ToString();
            }
            else
            {
                hdBanner5.Value = dsBanner.Tables[0].Rows[0][9].ToString();
                hlBanner5.Visible = false;
                ibtnBanner5.Visible = false;
            }
            txtBannerUrl5.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][10].ToString());

            if (dsBanner.Tables[0].Rows[0][11].ToString() != "")
            {
                hdRHSBanner7.Value = dsBanner.Tables[0].Rows[0][11].ToString();
                hlRHSBanner7.Visible = true;
                ibtnRHSBanner.Visible = true;
                hlRHSBanner7.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][11].ToString();
            }
            else
            {
                hdRHSBanner7.Value = dsBanner.Tables[0].Rows[0][11].ToString();
                hlRHSBanner7.Visible = false;
                ibtnRHSBanner.Visible = false;
            }
            txtRHSBannerUrl7.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][12].ToString());


            if (dsBanner.Tables[0].Rows[0][13].ToString() != "")
            {
                hdFooterBanner1.Value = dsBanner.Tables[0].Rows[0][13].ToString();
                hlFooterBanner1.Visible = true;
                ibtnFooterBanner1.Visible = true;
                hlFooterBanner1.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][13].ToString();
            }
            else
            {
                hdFooterBanner1.Value = dsBanner.Tables[0].Rows[0][13].ToString();
                hlFooterBanner1.Visible = false;
                ibtnFooterBanner1.Visible = false;
            }
            txtFooterBannerUrl1.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][14].ToString());

            if (dsBanner.Tables[0].Rows[0][15].ToString() != "")
            {
                hdFooterBanner2.Value = dsBanner.Tables[0].Rows[0][15].ToString();
                hlFooterBanner2.Visible = true;
                ibtnFooterBanner2.Visible = true;
                hlFooterBanner2.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][15].ToString();
            }
            else
            {
                hdFooterBanner2.Value = dsBanner.Tables[0].Rows[0][15].ToString();
                hlFooterBanner2.Visible = false;
                ibtnFooterBanner2.Visible = false;
            }
            txtFooterBannerUrl2.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][16].ToString());
            if (dsBanner.Tables[0].Rows[0][17].ToString() != "")
            {
                hdFooterBanner3.Value = dsBanner.Tables[0].Rows[0][17].ToString();
                hlFooterBanner3.Visible = true;
                ibtnFooterBanner3.Visible = true;
                hlFooterBanner3.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][17].ToString();
            }
            else
            {
                hdFooterBanner3.Value = dsBanner.Tables[0].Rows[0][17].ToString();
                hlFooterBanner3.Visible = false;
                ibtnFooterBanner3.Visible = false;
            }
            txtFooterBannerUrl3.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][18].ToString());
            if (dsBanner.Tables[0].Rows[0][19].ToString() != "")
            {
                hdFooterBanner4.Value = dsBanner.Tables[0].Rows[0][19].ToString();
                hlFooterBanner4.Visible = true;
                ibtnFooterBanner4.Visible = true;
                hlFooterBanner4.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][19].ToString();
            }
            else
            {
                hdFooterBanner4.Value = dsBanner.Tables[0].Rows[0][19].ToString();
                hlFooterBanner4.Visible = false;
                ibtnFooterBanner4.Visible = false;
            }
            txtFooterBannerUrl4.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][20].ToString());


            if (dsBanner.Tables[0].Rows[0][21].ToString() != "")
            {
                hdAdBanner1.Value = dsBanner.Tables[0].Rows[0][21].ToString();
                hlkAdBanner1.Visible = true;
                imgbtnAdBanner1.Visible = true;
                hlkAdBanner1.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][21].ToString();
            }
            else
            {
                hdAdBanner1.Value = dsBanner.Tables[0].Rows[0][21].ToString();
                hlkAdBanner1.Visible = false;
                imgbtnAdBanner1.Visible = false;
            }
            txtAdBannerURL1.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][22].ToString());

            if (dsBanner.Tables[0].Rows[0][23].ToString() != "")
            {
                hdAdBanner2.Value = dsBanner.Tables[0].Rows[0][23].ToString();
                hlkAdBanner2.Visible = true;
                imgbtnAdBanner2.Visible = true;
                hlkAdBanner2.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][23].ToString();
            }
            else
            {
                hdAdBanner2.Value = dsBanner.Tables[0].Rows[0][23].ToString();
                hlkAdBanner2.Visible = false;
                imgbtnAdBanner2.Visible = false;
            }
            txtAdBannerURL2.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][24].ToString());
            if (dsBanner.Tables[0].Rows[0][25].ToString() != "")
            {
                hdAdBanner3.Value = dsBanner.Tables[0].Rows[0][25].ToString();
                hlkAdBanner3.Visible = true;
                imgbtnAdBanner3.Visible = true;
                hlkAdBanner3.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][25].ToString();
            }
            else
            {
                hdAdBanner3.Value = dsBanner.Tables[0].Rows[0][25].ToString();
                hlkAdBanner3.Visible = false;
                imgbtnAdBanner3.Visible = false;
            }
            txtAdBannerURL3.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][26].ToString());
            if (dsBanner.Tables[0].Rows[0][27].ToString() != "")
            {
                hdAdBanner4.Value = dsBanner.Tables[0].Rows[0][27].ToString();
                hlkAdBanner4.Visible = true;
                imgbtnAdBanner4.Visible = true;
                hlkAdBanner4.NavigateUrl = "~/Administration/ViewImage.aspx?Banner=" + dsBanner.Tables[0].Rows[0][27].ToString();
            }
            else
            {
                hdAdBanner4.Value = dsBanner.Tables[0].Rows[0][27].ToString();
                hlkAdBanner4.Visible = false;
                imgbtnAdBanner4.Visible = false;
            }
            txtAdBannerURL4.Text = CommonBindings.TextToBind(dsBanner.Tables[0].Rows[0][28].ToString());

            hlTopBanner.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdTopBanner.Value + "')");
            hlBanner2.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdBanner2.Value + "')");
            hlBanner3.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdBanner3.Value + "')");
            hlBanner4.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdBanner4.Value + "')");
            hlBanner5.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdBanner5.Value + "')");
            hlRHSBanner7.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdRHSBanner7.Value + "')");

            hlFooterBanner1.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdFooterBanner1.Value + "')");
            hlFooterBanner2.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdFooterBanner2.Value + "')");
            hlFooterBanner3.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdFooterBanner3.Value + "')");
            hlFooterBanner4.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdFooterBanner4.Value + "')");

            hlkAdBanner1.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdAdBanner1.Value + "')");
            hlkAdBanner2.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdAdBanner2.Value + "')");
            hlkAdBanner3.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdAdBanner3.Value + "')");
            hlkAdBanner4.Attributes.Add("onclick", "return popitup('ViewImage.aspx?Banner=" + hdAdBanner4.Value + "')");

        }
        else
        {
            Clear();
        }
    }
    public void Clear()
    {
        txtTopBannerUrl.Text = "";
        txtBannerUrl2.Text = "";
        txtBannerUrl3.Text = "";
        txtBannerUrl4.Text = "";
        txtBannerUrl5.Text = "";
        txtRHSBannerUrl7.Text = "";
        txtFooterBannerUrl1.Text = "";
        txtFooterBannerUrl2.Text = "";
        txtFooterBannerUrl3.Text = "";
        txtFooterBannerUrl4.Text = "";
        txtAdBannerURL1.Text = "";
        txtAdBannerURL2.Text = "";
        txtAdBannerURL3.Text = "";
        txtAdBannerURL4.Text = "";

        hlTopBanner.Visible = false;
        hlBanner2.Visible = false;
        hlBanner3.Visible = false;
        hlBanner4.Visible = false;
        hlBanner5.Visible = false;
        hlRHSBanner7.Visible = false;
        hlFooterBanner1.Visible = false;
        hlFooterBanner2.Visible = false;
        hlFooterBanner3.Visible = false;
        hlFooterBanner4.Visible = false;
        hlkAdBanner1.Visible = false;
        hlkAdBanner2.Visible = false;
        hlkAdBanner3.Visible = false;
        hlkAdBanner4.Visible = false;

        ibtnBanner3.Visible = false;
        ibtnBanner4.Visible = false;
        ibtnBanner5.Visible = false;
        ibtnRHSBanner.Visible = false;
        ibtnFooterBanner1.Visible = false;
        ibtnFooterBanner2.Visible = false;
        ibtnFooterBanner3.Visible = false;
        ibtnFooterBanner4.Visible = false;
        imgbtnAdBanner1.Visible = false;
        imgbtnAdBanner2.Visible = false;
        imgbtnAdBanner3.Visible = false;
        imgbtnAdBanner4.Visible = false;
    }

    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BannerDetails objBannerDTO = new BannerDetails();


        DataSet dsBannerCulture = new DataSet();
      
        dsBannerCulture = (DataSet)ViewState["dsBanner"];

        if (dsBannerCulture.Tables[0].Rows.Count > 0)
        {
            if (dsBannerCulture.Tables[0].Rows[0][1].ToString() != "")
                hdTopBanner.Value = dsBannerCulture.Tables[0].Rows[0][1].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][3].ToString() != "")
                hdBanner2.Value = dsBannerCulture.Tables[0].Rows[0][3].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][5].ToString() != "")
                hdBanner3.Value = dsBannerCulture.Tables[0].Rows[0][5].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][7].ToString() != "")
                hdBanner4.Value = dsBannerCulture.Tables[0].Rows[0][7].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][9].ToString() != "")
                hdBanner5.Value = dsBannerCulture.Tables[0].Rows[0][9].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][11].ToString() != "")
                hdRHSBanner7.Value = dsBannerCulture.Tables[0].Rows[0][11].ToString();

            if (dsBannerCulture.Tables[0].Rows[0][13].ToString() != "")
                hdFooterBanner1.Value = dsBannerCulture.Tables[0].Rows[0][13].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][15].ToString() != "")
                hdFooterBanner2.Value = dsBannerCulture.Tables[0].Rows[0][15].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][17].ToString() != "")
                hdFooterBanner3.Value = dsBannerCulture.Tables[0].Rows[0][17].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][19].ToString() != "")
                hdFooterBanner4.Value = dsBannerCulture.Tables[0].Rows[0][19].ToString();

            if (dsBannerCulture.Tables[0].Rows[0][21].ToString() != "")
                hdAdBanner1.Value = dsBannerCulture.Tables[0].Rows[0][21].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][23].ToString() != "")
                hdAdBanner2.Value = dsBannerCulture.Tables[0].Rows[0][23].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][25].ToString() != "")
                hdAdBanner3.Value = dsBannerCulture.Tables[0].Rows[0][25].ToString();
            if (dsBannerCulture.Tables[0].Rows[0][27].ToString() != "")
                hdAdBanner4.Value = dsBannerCulture.Tables[0].Rows[0][27].ToString();
            ViewState["Operation"] = "Update";
        }
        else
        {
            ViewState["Operation"] = "Insert";
        }

        try
        {
            if (Page.IsValid)
            {

                objBannerDTO.Culture = rblCulture.SelectedItem.Value;

                if (rblCulture.SelectedItem.Text == "Chinese")
                    objBannerDTO.BannerId = 2;
                else
                    objBannerDTO.BannerId = 1;

                if (fuTopBanner1.FileName == "")
                    objBannerDTO.TopBanner = hdTopBanner.Value.ToString();
                else
                {
                    //Modified By Mahesh 17/01/2012
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuTopBanner1.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuTopBanner1, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.TopBanner = StrFileName;


                    // Modified by Lavanya 13 Jan 2012
                    // TopBannerFileName = System.IO.Path.GetFileName(fuTopBanner1.PostedFile.FileName);
                    //  ABSCommon.Common.UploadFile(fuTopBanner1, Server.MapPath("~/BannerImages"), TopBannerFileName);
                    // End Code

                    //fuTopBanner1.SaveAs(Server.MapPath("BannerImages/" + TopBannerFileName));
                }


                objBannerDTO.TopBannerUrl = CommonBindings.TextToBind(txtTopBannerUrl.Text.Trim().ToString());

                if (fuBanner2.FileName == "")
                    objBannerDTO.Banner2 = hdBanner2.Value.ToString();
                else
                {
                    //Modified By Mahesh 17/01/2012

                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuBanner2.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuBanner2, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.Banner2 = StrFileName;

                    // Modified by Lavanya 13 Jan 2012
                    // Banner2FileName = System.IO.Path.GetFileName(fuBanner2.PostedFile.FileName);
                    //  ABSCommon.Common.UploadFile(fuBanner2, Server.MapPath("~/BannerImages"), Banner2FileName);
                    // End Code
                }
                objBannerDTO.BannerUrl2 = CommonBindings.TextToBind(txtBannerUrl2.Text.Trim().ToString());

                if (fuBanner3.FileName == "")
                    objBannerDTO.Banner3 = hdBanner3.Value.ToString();
                else
                {
                    //Modified By Mahesh 17/01/2012
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuBanner3.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuBanner3, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.Banner3 = StrFileName;

                    // Modified by Lavanya 13 Jan 2012
                    //Banner3FileName = System.IO.Path.GetFileName(fuBanner3.PostedFile.FileName);
                    //  ABSCommon.Common.UploadFile(fuBanner3, Server.MapPath("~/BannerImages"), Banner3FileName);
                    // End Code
                }
                objBannerDTO.BannerUrl3 = CommonBindings.TextToBind(txtBannerUrl3.Text.Trim().ToString());

                if (fuBanner4.FileName == "")
                    objBannerDTO.Banner4 = hdBanner4.Value.ToString();
                else
                {
                    //Modified By Mahesh 17/01/2012

                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuBanner4.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuBanner4, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.Banner4 = StrFileName;

                    // Modified by Lavanya 13 Jan 2012
                    // Banner4FileName = System.IO.Path.GetFileName(fuBanner4.PostedFile.FileName);
                    //  ABSCommon.Common.UploadFile(fuBanner4, Server.MapPath("~/BannerImages"), Banner4FileName);
                    // End Code
                }
                objBannerDTO.BannerUrl4 = CommonBindings.TextToBind(txtBannerUrl4.Text.Trim().ToString());

                if (fuBanner5.FileName == "")
                    objBannerDTO.Banner5 = hdBanner5.Value.ToString();
                else
                {
                    //Modified By Mahesh 17/01/2012
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuBanner5.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuBanner5, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.Banner5 = StrFileName;

                    // Modified by Lavanya 13 Jan 2012
                    // Banner5FileName = System.IO.Path.GetFileName(fuBanner5.PostedFile.FileName);
                    // ABSCommon.Common.UploadFile(fuBanner5, Server.MapPath("~/BannerImages"), Banner5FileName);
                    // End Code
                }
                objBannerDTO.BannerUrl5 = CommonBindings.TextToBind(txtBannerUrl5.Text.Trim().ToString());




                if (fuRHSBanner7.FileName == "")
                    objBannerDTO.Banner7 = hdRHSBanner7.Value.ToString();
                else
                {
                    //Modified By Mahesh 17/01/2012
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuRHSBanner7.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuRHSBanner7, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.Banner7 = StrFileName;

                    // Modified by Lavanya 13 Jan 2012
                    // RHSBannerFileName = System.IO.Path.GetFileName(fuRHSBanner7.PostedFile.FileName);
                    //  ABSCommon.Common.UploadFile(fuRHSBanner7, Server.MapPath("~/BannerImages"), RHSBannerFileName);
                    // End Code
                }
                objBannerDTO.RHSBannerUrl7 = CommonBindings.TextToBind(txtRHSBannerUrl7.Text.Trim().ToString());

                if (fuFooterBanner1.FileName == "")
                    objBannerDTO.FooterBanner1 = hdFooterBanner1.Value.ToString();
                else
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuFooterBanner1.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuFooterBanner1, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.FooterBanner1 = StrFileName;
                }
                objBannerDTO.FooterBannerUrl1 = CommonBindings.TextToBind(txtFooterBannerUrl1.Text.Trim().ToString());

                if (fuFooterBanner2.FileName == "")
                    objBannerDTO.FooterBanner2 = hdFooterBanner2.Value.ToString();
                else
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuFooterBanner2.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuFooterBanner2, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.FooterBanner2 = StrFileName;
                }
                objBannerDTO.FooterBannerUrl2 = CommonBindings.TextToBind(txtFooterBannerUrl2.Text.Trim().ToString());

                if (fuFooterBanner3.FileName == "")
                    objBannerDTO.FooterBanner3 = hdFooterBanner3.Value.ToString();
                else
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuFooterBanner3.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuFooterBanner3, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.FooterBanner3 = StrFileName;
                }
                objBannerDTO.FooterBannerUrl3 = CommonBindings.TextToBind(txtFooterBannerUrl3.Text.Trim().ToString());
                if (fuFooterBanner4.FileName == "")
                    objBannerDTO.FooterBanner4 = hdFooterBanner4.Value.ToString();
                else
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuFooterBanner4.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuFooterBanner4, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.FooterBanner4 = StrFileName;
                }
                objBannerDTO.FooterBannerUrl4 = CommonBindings.TextToBind(txtFooterBannerUrl4.Text.Trim().ToString());

                if (fuAdBanner1.FileName == "")
                    objBannerDTO.AdBanner1 = hdAdBanner1.Value.ToString();
                else
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuAdBanner1.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuAdBanner1, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.AdBanner1 = StrFileName;
                }
                objBannerDTO.AdBannerUrl1 = CommonBindings.TextToBind(txtAdBannerURL1.Text.Trim().ToString());

                if (fuAdBanner2.FileName == "")
                    objBannerDTO.AdBanner2 = hdAdBanner2.Value.ToString();
                else
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuAdBanner2.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuAdBanner2, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.AdBanner2 = StrFileName;
                }
                objBannerDTO.AdBannerUrl2 = CommonBindings.TextToBind(txtAdBannerURL2.Text.Trim().ToString());

                if (fuAdBanner3.FileName == "")
                    objBannerDTO.AdBanner3 = hdAdBanner3.Value.ToString();
                else
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuAdBanner3.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuAdBanner3, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.AdBanner3 = StrFileName;
                }
                objBannerDTO.AdBannerUrl3 = CommonBindings.TextToBind(txtAdBannerURL3.Text.Trim().ToString());

                if (fuAdBanner4.FileName == "")
                    objBannerDTO.AdBanner4 = hdAdBanner4.Value.ToString();
                else
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(fuAdBanner4.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(fuAdBanner4, Server.MapPath("~/BannerImages"), StrFileName);
                    objBannerDTO.Upload_File_Path = StrFileName;
                    objBannerDTO.AdBanner4 = StrFileName;
                }
                objBannerDTO.AdBannerUrl4 = CommonBindings.TextToBind(txtAdBannerURL4.Text.Trim().ToString());

                objBannerDTO.Created_By = Session["USER_NM"].ToString();
                objBannerDTO.Updated_By = Session["USER_NM"].ToString();

                if (Convert.ToString(ViewState["Operation"]) == "Insert")
                {
                    objBannerDTO.Operation = Convert.ToString(ViewState["Operation"]);
                    ViewState["Operation"] = "Update";

                }
                else
                    objBannerDTO.Operation = Convert.ToString(ViewState["Operation"]);


                if (Convert.ToBoolean(objBannerDTO.InsertBannerDetails(objBannerDTO)) == true)
                {
                    Getdata();
                    Common.ShowMessage(this, "Details Saved Successfully");
                }
                else
                    Common.ShowMessage(this, "Unable To Save the Details");

            }
         

        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }
    }


    protected void ibtnBanner3_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][5].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(3)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");

        Getdata();

    }
    protected void ibtnBanner4_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][7].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(4)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();

    }
    protected void ibtnBanner5_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][9].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(5)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }
    protected void ibtnRHSBanner_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][11].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(6)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }
    protected void ibtnFooterBanner1_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][13].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(7)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }

    protected void ibtnFooterBanner2_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][15].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(8)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }
    protected void ibtnFooterBanner3_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][17].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(9)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }
    protected void ibtnFooterBanner4_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][19].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(10)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }

    protected void imgbtnAdBanner1_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][21].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(11)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }

    protected void imgbtnAdBanner2_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][23].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(12)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }
    protected void imgbtnAdBanner3_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][25].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(13)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }
    protected void imgbtnAdBanner4_Click(object sender, ImageClickEventArgs e)
    {
        //Image delete from Folder
        DataSet ds = (DataSet)ViewState["dsBanner"];
        string Filename = ds.Tables[0].Rows[0][27].ToString();
        string TargetDir = Server.MapPath("~/BannerImages/").ToString() + Filename;
        if (File.Exists(TargetDir))
            File.Delete(TargetDir);

        //Image delete from database
        if (Convert.ToBoolean(objGet.DelteBannerImage(14)) == true)
            Common.ShowMessage(this, "Record has been Deleted Successfully");
        else
            Common.ShowMessage(this, "Unable to Delete the Banner");
        Getdata();
    }
    protected void rblCulture_SelectedIndexChanged(object sender, EventArgs e)
    {
        BannerDetails objBannerDetails = new BannerDetails();
        objBannerDetails.Culture = rblCulture.SelectedItem.Value;
        DataSet dsBannerCulture = new DataSet();
        dsBannerCulture = objGet.GetBannerDetails_Culture(objBannerDetails);
        ViewState["dsBannerCulture"] = dsBannerCulture;
        IsfromCulture = true;
        Getdata();

    }
}