using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

public partial class UserControls_RadarGraph : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //double[] yValues = { 1, 1, 3, 9 };
        ////double[] yValues2 = { 76.45, 23.78, 86.45, 30.76, 23.79, 35.67, 89.56, 67.45, 38.98 };
        //string[] xValues  = { "Growing & Glowing", "Healthy but need ideas to break-through", "Rejuvenation needed", "Survival is at risk" };
        //Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
        ////Chart1.Series["Series2"].Points.DataBindXY(xValues, yValues2);

        //// Set radar chart style
        //  Chart1.Series["Series1"]["RadarDrawingStyle"] = RadarStyleList.SelectedItem.Text;
        //Chart1.Series["Series2"]["RadarDrawingStyle"] = RadarStyleList.SelectedItem.Text;
        //if (RadarStyleList.SelectedItem.Text == "Area")
        //{
        //    Chart1.Series["Series1"].BorderColor = Color.FromArgb(100, 100, 100);
        //    Chart1.Series["Series1"].BorderWidth = 1;
        //    Chart1.Series["Series2"].BorderColor = Color.FromArgb(100, 100, 100);
        //    Chart1.Series["Series2"].BorderWidth = 1;
        //}
        //else if (RadarStyleList.SelectedItem.Text == "Line")
        //{
        //    Chart1.Series["Series1"].BorderColor = Color.Empty;
        //    Chart1.Series["Series1"].BorderWidth = 2;
        //    Chart1.Series["Series2"].BorderColor = Color.Empty;
        //    Chart1.Series["Series2"].BorderWidth = 2;
        //}
        //else if (RadarStyleList.SelectedItem.Text == "Marker")
        //{
        //    Chart1.Series["Series1"].BorderColor = Color.Empty;
        //    Chart1.Series["Series2"].BorderColor = Color.Empty;
        //}

        //// Set circular area drawing style
        //Chart1.Series["Series1"]["AreaDrawingStyle"] = AreaDrawingStyleList.SelectedItem.Text;
        //Chart1.Series["Series2"]["AreaDrawingStyle"] = AreaDrawingStyleList.SelectedItem.Text;

        //// Set labels style
        //Chart1.Series["Series1"]["CircularLabelsStyle"] = LabelStyleList.SelectedItem.Text;
        //Chart1.Series["Series2"]["CircularLabelsStyle"] = LabelStyleList.SelectedItem.Text;

        // Populate series data
        // double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42, 55.9, 63.6, 55.1, 77.2 };
        double[] yValues = { 1, 1, 3, 9 };
        // double[] yValues2 = { 76.45, 23.78, 86.45, 30.76, 23.79, 35.67, 89.56, 67.45, 38.98 };
        //  string[] xValues = { "asdsa dsadA", "Bsadas sa sadd ", "C sad as", "D asdasdasd" };
        string[] xValues = { "Growing & Glowing", "Healthy ", "Rejuvenation needed", "Survival is at risk" };
        Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
        //Chart1.Series[0]["RadarDrawingStyle"] = "Line";
        // Chart1.Series[0]["CircularLabelsStyle"] = "Horizontal"; 

        //Chart1.Series["Series2"].Points.DataBindXY(xValues, yValues2);
    }
}