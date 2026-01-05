using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administration_TrafficAnalysis_DetailedReportDL : System.Web.UI.Page
{
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    public static string token;

    //gor Gridview feedback rowdatabound
    string previousCat = "";
    int firstRow = -1;

    DataSet ds;

    decimal total1 = 0M;
    decimal total2 = 0M;
    decimal total3 = 0M;
    decimal total4 = 0M;
    decimal total5 = 0M;
    decimal total6 = 0M;
    decimal total7 = 0M;

    decimal Maintotal1 = 0M;
    decimal Maintotal2 = 0M;
    decimal Maintotal3 = 0M;
    decimal Maintotal4 = 0M;
    decimal Maintotal5 = 0M;
    decimal Maintotal6 = 0M;
    decimal Maintotal7 = 0M;


    decimal dlbl1 = 0;
    decimal dlbl2 = 0;
    decimal dlbl3 = 0;
    decimal dlbl4 = 0;
    decimal dlbl5 = 0;
    decimal dlbl6 = 0;
    decimal dlbl7 = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
       
        Check_Access chkAccess = new Check_Access();

        ViewState["Links"] = chkAccess.initSystem();
        ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
        ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

        if (!IsPostBack)
        {
            token = Request.Form["token"];
            //ViewState["t_url"] = "Admin_NextSteps.aspx";
            if (token == null)
            {
                Response.Redirect("default.aspx");
            }

            else
            {
                BindData();

            }

        }
    }


    public void BindData()
    {
        ds = trafficAnalysis.GET_Industry();
        id_datalist.DataSource = ds;
        id_datalist.DataBind();

        Label1.Text = Maintotal1.ToString();
        Label2.Text = Maintotal2.ToString();
        Label3.Text = Maintotal3.ToString();
        Label4.Text = Maintotal4.ToString();
        Label5.Text = Maintotal5.ToString();
        Label6.Text = Maintotal6.ToString();
        Label7.Text = Maintotal7.ToString();
    }
    protected void id_datalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            HiddenField hf = (HiddenField)e.Item.FindControl("HiddenField1");
            int ID = Convert.ToInt32(hf.Value);
            int dlcount = ds.Tables[0].Rows.Count;

            DataSet ds_Search = trafficAnalysis.Get_TrafficAnalysis_Temp(ID);

            GridView gvTrafficAnalysis = (GridView)e.Item.FindControl("gvTrafficAnalysis");

            gvTrafficAnalysis.DataSource = ds_Search.Tables[0];
            gvTrafficAnalysis.DataBind();

            total1 = 0;
            total2 = 0;
            total3 = 0;
            total4 = 0;
            total5 = 0;
            total6 = 0;
            total7 = 0;

        }
    }

    protected void gvTrafficAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView gvTrafficAnalysis = (GridView)sender;
        DataListItem dlItem = (DataListItem)gvTrafficAnalysis.Parent;
        DataListItemEventArgs dle = new DataListItemEventArgs(dlItem);

        if (e.Row.RowType == DataControlRowType.Header)
        {

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow =
            new GridViewRow(0, 0, DataControlRowType.Header,
            DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "No. of Hit-times ";
            HeaderCell.ColumnSpan = 7;
            HeaderCell.Font.Bold = true;
            HeaderCell.Attributes.Add("align", "center");
            HeaderCell.Attributes.Add("bgcolor", "#BDBDBD");
            HeaderGridRow.Cells.Add(HeaderCell);

            gvTrafficAnalysis.Controls[0].Controls.AddAt
            (0, HeaderGridRow);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //We're only interested in Rows that contain data
            //get a reference to the data used to databound the row
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            if (previousCat == drv["Id"].ToString())
            {
                if (gvTrafficAnalysis.Rows[firstRow].Cells[0].RowSpan == 0)

                    gvTrafficAnalysis.Rows[firstRow].Cells[0].RowSpan = 2;

                else
                    gvTrafficAnalysis.Rows[firstRow].Cells[0].RowSpan += 1;
                //Remove the cell
                e.Row.Cells.RemoveAt(0);

            }
            else //It's a new category
            {

                //Set the vertical alignment to top
                e.Row.VerticalAlign = VerticalAlign.Top;

                //Maintain the category in memory
                previousCat = drv["Id"].ToString();

                firstRow = e.Row.RowIndex;

            }

        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl1 = (Label)e.Row.FindControl("lbl_Resourcelibrary");
            Label lbl2 = (Label)e.Row.FindControl("lbl_BusinessProfiling");
            Label lbl3 = (Label)e.Row.FindControl("lbl_CapabilitiesProfiling");
            Label lbl4 = (Label)e.Row.FindControl("lbl_FinancialModeling");
            Label lbl5 = (Label)e.Row.FindControl("lbl_LearnMore");
            Label lbl6 = (Label)e.Row.FindControl("lbl_Faqs");
            Label lbl7 = (Label)e.Row.FindControl("lbl_Total");

            total7 = 0;

            if (lbl1.Text != "" && lbl1.Text != null)
                dlbl1 = Convert.ToDecimal(lbl1.Text);
            else
                dlbl1 = 0;

            if (lbl2.Text != "" && lbl2.Text != null)
                dlbl2 = Convert.ToDecimal(lbl2.Text);
            else
                dlbl2 = 0;

            if (lbl3.Text != "" && lbl3.Text != null)
                dlbl3 = Convert.ToDecimal(lbl3.Text);
            else
                dlbl3 = 0;

            if (lbl4.Text != "" && lbl4.Text != null)
                dlbl4 = Convert.ToDecimal(lbl4.Text);
            else
                dlbl4 = 0;

            if (lbl5.Text != "" && lbl5.Text != null)
                dlbl5 = Convert.ToDecimal(lbl5.Text);
            else
                dlbl5 = 0;

            if (lbl6.Text != "" && lbl6.Text != null)
                dlbl6 = Convert.ToDecimal(lbl6.Text);
            else
                dlbl6 = 0;


            total1 += dlbl1;
            total2 += dlbl2;
            total3 += dlbl3;
            total4 += dlbl4;
            total5 += dlbl5;
            total6 += dlbl6;

            total7 += dlbl1 + dlbl2 + dlbl3 + dlbl4 + dlbl5 + dlbl6;
            Maintotal7 += total7;

            lbl7.Text = total7.ToString();

            Maintotal1 += dlbl1;
            Maintotal2 += dlbl2;
            Maintotal3 += dlbl3;
            Maintotal4 += dlbl4;
            Maintotal5 += dlbl5;
            Maintotal6 += dlbl6;

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            Label lbl1 = (Label)e.Row.FindControl("lblTotalR");
            Label lbl2 = (Label)e.Row.FindControl("lblTotalBP");
            Label lbl3 = (Label)e.Row.FindControl("lblTotalCP");
            Label lbl4 = (Label)e.Row.FindControl("lblTotalFM");
            Label lbl5 = (Label)e.Row.FindControl("lblTotalLM");
            Label lbl6 = (Label)e.Row.FindControl("lblTotalFaq");
            Label lbl7 = (Label)e.Row.FindControl("lblTotalFooter");

            lbl1.Text = total1.ToString();
            lbl2.Text = total2.ToString();
            lbl3.Text = total3.ToString();
            lbl4.Text = total4.ToString();
            lbl5.Text = total5.ToString();
            lbl6.Text = total6.ToString();

            lbl7.Text = (total1 + total2 + total3 + total4 + total5 + total6).ToString();



        }
    }
}
