using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using ABSBLL;
using ABSDAL;
using ABSDTO;
using System.Configuration;

public partial class UserControls_Appendix : System.Web.UI.UserControl
{
      FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
      TradeCycle_Bll obj = new TradeCycle_Bll();
     // public static string strLblClientIds = string.Empty;
      protected void Page_Load(object sender, EventArgs e)
      {
          int intDay3 = 0;
          int intDay4 = 0;
          int intDay5 = 0;
          int intDay6 = 0;
          if (Request.QueryString["UserId"] != null)
          {

              ViewState["UserID"] = Convert.ToString(Request.QueryString["UserId"]);
          }

          else if (Session["LoginDTO"] == null)
          {
              Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
          }
          else
          {
              LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
              ViewState["UserID"] = objLoginDTO.UserID;
              //ScriptManager.RegisterStartupScript(this, this.GetType(), "FormatCells", "formatCellsWithComma('" + strLblClientIds + "');", true);


          }

              DataSet ds = obj.getTradeCycleDate(ViewState["UserID"].ToString());
              int x2, x3, x4, x5, x6, x7;
              x2 = Convert.ToString(ds.Tables[0].Rows[0][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[0][0]) : 0;
              x3 = Convert.ToString(ds.Tables[0].Rows[1][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[1][0]) : 0;
              x4 = Convert.ToString(ds.Tables[0].Rows[2][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[2][0]) : 0;
              x5 = Convert.ToString(ds.Tables[0].Rows[3][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[3][0]) : 0;
              x6 = Convert.ToString(ds.Tables[0].Rows[4][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[4][0]) : 0;
              x7 = Convert.ToString(ds.Tables[0].Rows[5][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[5][0]) : 0;


              lblDay2.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
              lblDay3.Text = Convert.ToString(ds.Tables[0].Rows[1][0]);
              lblDay4.Text = Convert.ToString(ds.Tables[0].Rows[2][0]);
              lblDay5.Text = Convert.ToString(ds.Tables[0].Rows[3][0]);
              lblDay6.Text = Convert.ToString(ds.Tables[0].Rows[4][0]);
              lblCDay7.Text = Convert.ToString(ds.Tables[0].Rows[5][0]);


              lblDay1.Text = "0";
              lblCDay1.Text = lblDay1.Text;
              // lblCDay1.Text = lblDay1.Text;

              lblCDay2.Text = Convert.ToString(x2 + Convert.ToInt32(lblDay1.Text));
              lblCDay3.Text = Convert.ToString(x3 + Convert.ToInt32(lblCDay2.Text));
              lblCDay4.Text = Convert.ToString(x4 + Convert.ToInt32(lblCDay3.Text));
              lblCDay5.Text = Convert.ToString(x5 + Convert.ToInt32(lblCDay4.Text));
              lblCDay6.Text = Convert.ToString(x6 + Convert.ToInt32(lblCDay5.Text));
              if(lblDay3.Text != "")
                 intDay3=Convert.ToInt32(lblDay3.Text);
               if(lblDay4.Text != "")
                 intDay4=Convert.ToInt32(lblDay4.Text);
               if(lblDay5.Text != "")
                 intDay5=Convert.ToInt32(lblDay5.Text);
               if (lblDay6.Text != "")
                   intDay6 = Convert.ToInt32(lblDay6.Text);
               lblCDay8.Text = Convert.ToString(intDay3 + intDay4 + intDay5 + intDay6);


               int oneValue = 0;
               int twoValue = 0;
               int threeValue = 0;
               int intToSupplier =0;

               if (lblCDay8.Text != "")
                   oneValue = Convert.ToInt32(lblCDay8.Text);
               if (lblCDay7.Text != "")
                   twoValue = Convert.ToInt32(lblCDay7.Text);
               if (lblCDay2.Text != "")
                   threeValue = Convert.ToInt32(lblCDay2.Text);

               if (oneValue > twoValue)
               {
                   intToSupplier = oneValue + threeValue;
               }
               else
               {
                   intToSupplier = threeValue + twoValue;
               }

               lblCycleDays.Text = intToSupplier.ToString();

               int intFinancingPeriodRequired=oneValue - twoValue;

               if (intFinancingPeriodRequired > 0)
               {
                   lblFinancingPeriod.Text = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text")) + " " + intFinancingPeriodRequired + " " + Convert.ToString(GetLocalResourceObject("lbl11DaysResource1.Text"));
               }
               else
               {
                   if (intFinancingPeriodRequired == 0)
                   {
                       lblFinancingPeriod.Text = Convert.ToString(GetLocalResourceObject("lblDes2Resource1.Text"));
                   }
                   else
                       lblFinancingPeriod.Text = Convert.ToString(GetLocalResourceObject("lblDes3Resource1.Text")) + " " + (-intFinancingPeriodRequired) + " " + Convert.ToString(GetLocalResourceObject("lbl11DaysResource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblDes4Resource1.Text"));

               }
               if (lblDay2.Text.ToString() == "0" || lblDay2.Text.ToString() == "")
                   lblFinancingPeriodIncrease.Text = Convert.ToString(GetLocalResourceObject("lblDes5Resource1.Text"));
               else
                   lblFinancingPeriodIncrease.Text = Convert.ToString(GetLocalResourceObject("lblDes6Resource1.Text")) + " " + lblDay2.Text + " " + Convert.ToString(GetLocalResourceObject("lbl11DaysResource1.Text"));
              


        //  }
      }
}