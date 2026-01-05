using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for Common
/// </summary>

namespace ABSCommon
{
    public class Common
    {
        public Common()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void ErrorMessage(Page pg, Exception ex)
        {
            string cleanMessage = ex.Message.Replace("'", "\\\'");
            pg.RegisterStartupScript("onclick", "<script language='javascript'>alert('" + cleanMessage + "');</script>");
        }
        public static void ErrorMessage(Page pg, Exception ex, bool isInsideUpdatepanel)
        {
            if (isInsideUpdatepanel)
            {
                string cleanMessage = ex.Message.Replace("'", "\\\'");
                ScriptManager.RegisterStartupScript(pg, pg.GetType(), "onclick", "<script language='javascript'>alert('" + cleanMessage + "');</script>", false);
            }
            else
                ErrorMessage(pg, ex);
        }
        public static void ShowMessage(Page pg, string message)
        {       
            string cleanMessage = message.Replace("'", "\\\'");
            pg.RegisterStartupScript("onclick", "<script language='javascript'>alert('" + cleanMessage + "');</script>");
        }
        public static void ShowMessage(Page pg, string message, bool isInsideUpdatepanel)
        {
            if (isInsideUpdatepanel)
            {
                string cleanMessage = message.Replace("'", "\\\'");
                ScriptManager.RegisterStartupScript(pg, pg.GetType(), "onclick", "<script language='javascript'>alert('" + cleanMessage + "');</script>", false);
            }
            else
                ShowMessage(pg, message);
        }

        public static void ShowUpdateMessage(Page pg, string message,string redirectPath)
        {
            string cleanMessage = message.Replace("'", "\\\'");
            ScriptManager.RegisterStartupScript(pg, pg.GetType(), "onclick", "<script language='javascript'>alert('" + cleanMessage + "'); window.location.href = '" + redirectPath  + "';</script>", false);
        }


        public static string UploadFile(FileUpload fup, string filepath, string filename)
        {
            try
            {
                if (fup.FileContent.Length > 0)
                {
                    if (!IsDirExists(filepath))
                    {
                        throw new ApplicationException("File not Exists");
                    }
                    else
                    {
                        if (!IsFileExists(filepath + "/" + filename))
                        {
                            fup.PostedFile.SaveAs(filepath + "/" + filename);
                            return filename;
                        }
                        else
                            throw new ApplicationException("File already Exists");
                    }
                }
                else
                {
                    throw new ApplicationException("Select File");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string RenameFile(string filepath, string filename, string newfilename)
        {
            string fileName = null;
            try
            {
                if (!IsFileExists(filepath + filename))
                {
                    throw new ApplicationException("File not Exists");
                }
                else
                {
                    if (!IsFileExists(filepath + newfilename))
                    {
                        System.IO.File.Move(filepath + filename, filepath + newfilename);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fileName;
        }
        public static Boolean IsDirExists(string filePath)
        {
            try
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(filePath);
                if (dirInfo.Exists == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Boolean IsFileExists(string filepath)
        {
            try
            {
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(filepath);
                if (fileinfo.Exists == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Boolean IsFileNameExists(string filepath)
        {
            try
            {
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(filepath);
                if (fileinfo.Exists == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteFile(string FilePath, string Filename)
        {
            try
            {
                if (IsFileExists(FilePath + Filename))
                    System.IO.File.Delete(FilePath + Filename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DownloadFile(string filename, bool forceDownload)
        {
            string path = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + filename);
            string name = System.IO.Path.GetFileName(path);
            string ext = System.IO.Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
                    case ".xls":
                    case ".csv":
                        type = "text/Delimited";
                        break;
                }
            }
            if (forceDownload)
            {
                HttpContext.Current.Response.AppendHeader("content-disposition",
                    "attachment; filename=" + name);
            }
            if (type != "")
                HttpContext.Current.Response.ContentType = type;
            HttpContext.Current.Response.WriteFile(path);
            HttpContext.Current.Response.End();
        }

        public static void Clear(Page objpg)
        {
            foreach (Control ct11 in objpg.Form.Controls)
            {
                if (ct11.GetType() == typeof(ContentPlaceHolder))

                    foreach (Control ct1 in ct11.Controls)
                    {

                        System.Type type = ct1.GetType();
                        switch (type.Name)
                        {
                            case "TextBox":
                                ((TextBox)ct1).Text = string.Empty;
                                break;

                            case "DropDownList":
                                ((DropDownList)ct1).ClearSelection();
                                break;
                            //case "RadioButtonList":
                            //    ((RadioButtonList)ct1).ClearSelection();
                            //    break;
                            case "CheckBoxList":
                                ((CheckBoxList)ct1).ClearSelection();
                                break;
                            case "CheckBox":
                                ((CheckBox)ct1).Checked = false;
                                break;
                            case "ListBox":
                                ((ListBox)ct1).ClearSelection();
                                break;
                            //case "Label":
                            //    ((Label)ct1).Text = string.Empty;
                            //    break;
                            case "Image":
                                ((Image)ct1).ImageUrl = "~/images/s_nopic.jpg";
                                break;
                            case "Panel":
                                foreach (Control ct2 in ct1.Controls)
                                {

                                    System.Type type1 = ct2.GetType();
                                    switch (type1.Name)
                                    {
                                        case "TextBox":
                                            ((TextBox)ct2).Text = string.Empty;
                                            break;

                                        case "DropDownList":
                                            ((DropDownList)ct2).ClearSelection();
                                            break;
                                        //case "RadioButtonList":
                                        //    ((RadioButtonList)ct2).ClearSelection();
                                        //    break;
                                        case "CheckBoxList":
                                            ((CheckBoxList)ct2).ClearSelection();
                                            break;
                                        case "CheckBox":
                                            ((CheckBox)ct2).Checked = false;
                                            break;
                                        case "ListBox":
                                            ((ListBox)ct2).Items.Clear();
                                            ((ListBox)ct2).Items.Insert(0, "Select");
                                            ((ListBox)ct2).SelectedIndex = 0;
                                            break;
                                    }


                                }
                                break;
                        }


                    }
            }
        }

        public static void ClearUpdate(Page objpg)
        {
            foreach (Control ct11 in objpg.Form.Controls)
            {
                if (ct11.GetType() == typeof(ContentPlaceHolder))
                {
                    foreach (Control ct12 in ct11.Controls)
                    {
                        if (ct12.GetType() == typeof(UpdatePanel))
                        {
                            foreach (Control ct13 in ct12.Controls)
                            {
                                if (ct13.GetType() == typeof(Control))
                                {

                                    foreach (Control ct1 in ct13.Controls)
                                    {
                                        System.Type type = ct1.GetType();
                                        switch (type.Name)
                                        {
                                            case "TextBox":
                                                ((TextBox)ct1).Text = string.Empty;
                                                break;

                                            case "DropDownList":
                                                ((DropDownList)ct1).ClearSelection();
                                                break;
                                            //case "RadioButtonList":
                                            //    ((RadioButtonList)ct1).ClearSelection();
                                            //    break;
                                            case "CheckBoxList":
                                                ((CheckBoxList)ct1).ClearSelection();
                                                break;
                                            case "CheckBox":
                                                ((CheckBox)ct1).Checked = false;
                                                break;
                                            case "ListBox":
                                                ((ListBox)ct1).Items.Clear();
                                                ((ListBox)ct1).Items.Insert(0, "Select");
                                                ((ListBox)ct1).SelectedIndex = 0;
                                                break;
                                        }
                                        if (ct1.GetType() == typeof(Panel))
                                        {
                                            foreach (Control ctpanel in ct1.Controls)
                                            {
                                                System.Type type1 = ctpanel.GetType();
                                                switch (type1.Name)
                                                {
                                                    case "TextBox":
                                                        ((TextBox)ctpanel).Text = string.Empty;
                                                        break;

                                                    case "DropDownList":
                                                        ((DropDownList)ctpanel).ClearSelection();
                                                        break;
                                                    case "CheckBox":
                                                        ((CheckBox)ctpanel).Checked = false;
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ateeq on 20th sept......
        /// </summary>
        /// <param name="e"></param>
        public bool CheckFeedback(string UserID)
        {
            FeedBack obj_Feedback = new FeedBack();
            //if (ViewState["UserID"] != null)
            //{
                //Check Given User Feedback crossed 90 days or not
               // obj_Feedback.UserID = ViewState["UserID"].ToString();
                obj_Feedback.UserID = UserID.ToString();
                DataSet dsexport = obj_Feedback.Get_FeedbackAnswers_ByUserId(obj_Feedback);
                if (dsexport.Tables[0].Rows.Count > 0)
                {
                    if (dsexport.Tables[0].Rows[0]["Postedon"].ToString() != string.Empty)
                    {
                        DateTime nowTime = DateTime.Now;
                        DateTime CompareTime = (DateTime)dsexport.Tables[0].Rows[0]["Postedon"];

                        TimeSpan span = nowTime.Subtract(CompareTime);


                        if (span.Days > 90)
                        {
                            //Crossed
                            //HideTr.Visible = false;
                            //BindGrid();
                            return true;

                        }
                        else
                        {
                            //Not Crossed
                            //HideTr.Visible = true;
                            //HideTable.Visible = false;
                            //btnSave.Visible = false;
                            //gv_excel.Visible = false;


                            //objUserMgmt.UserID = ViewState["UserID"].ToString();
                            //objUserMgmt.AccessBy = Session["USER_ID"].ToString();
                            //objUserMgmt.CategoryId = 4;
                            //objUserMgmt.Downloading = "Y";
                            //objUserMgmt.AccessDescription = "DownLoaded Report";
                            //objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                            //objUserMgmt.InsertModuleTrack(objUserMgmt);


                            //generatePdf();

                            return false;

                        }
                    }

                }
                //else
                //{
                    //HideTr.Visible = false;
                    //BindGrid();

                    return true;
               // }
            //}
            //else
            //    Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
    }
}