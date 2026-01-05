using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ABSSecurity;
using System.Data.SqlClient;

public partial class Administration_Default : System.Web.UI.Page
{
    User_Logic ObjUser = new User_Logic();
    Security objSecurity = new Security();
    private const int LockDurationMinutes = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack))
        {

            if (System.Convert.ToBoolean(Session["TimeOut"]))
                Response.Write("<script>document.status='TimeOut';</script>");
            // Session.Clear();
            this.txtUserId.Text = "";
            // this.txtUserId.Attributes.Add("onBlur", "document.form1['" + txtPwd.ClientID + "'].focus();");
            if (txtUserId.Text == "")
                txtUserId.Focus();
        }
        else
        {
            if (txtUserId.Text == "")
                txtUserId.Focus();

        }
    }

    private void IsAdmin(DataTable DT_Temp)
    {
        Session["U_ID"] = DT_Temp.Rows[0]["UID"].ToString();
        Session["USER_GUID"]=DT_Temp.Rows[0]["UID"].ToString();
        Session["USER_ID"] = DT_Temp.Rows[0]["USER_ID"].ToString();
        Session["GROUP_ID"] = DT_Temp.Rows[0]["GROUP_ID"].ToString();
        Session["USER_NM"] = DT_Temp.Rows[0]["USER_NM"].ToString();
    }

    private bool IsAccountLocked(string userId)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT IsLocked, LockedUntil FROM AdminLoginAttempts WHERE UserId = @UserId", conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                bool isLocked = (bool)reader["IsLocked"];
                DateTime? lockedUntil = reader["LockedUntil"] as DateTime?;
                if (isLocked && lockedUntil.HasValue && lockedUntil > DateTime.Now)
                {
                    reader.Close();
                    return true;
                }
                else if (isLocked)
                {
                    // Unlock automatically
                    reader.Close();
                    SqlCommand updateCmd = new SqlCommand("UPDATE AdminLoginAttempts SET IsLocked = 0, Attempts = 0, LockedUntil = NULL WHERE UserId = @UserId", conn);
                    updateCmd.Parameters.AddWithValue("@UserId", userId);
                    updateCmd.ExecuteNonQuery();
                    return false;
                }
            }
            reader.Close();
            return false;
        }
    }

    private void IncrementAttempts(string userId)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            conn.Open();
            string sql = @"
IF EXISTS (SELECT 1 FROM AdminLoginAttempts WHERE UserId = @UserId)
BEGIN
    UPDATE AdminLoginAttempts SET Attempts = Attempts + 1, LastAttempt = GETDATE() WHERE UserId = @UserId;
    IF (SELECT Attempts FROM AdminLoginAttempts WHERE UserId = @UserId) >= 5
    BEGIN
        UPDATE AdminLoginAttempts SET IsLocked = 1, LockedUntil = DATEADD(MINUTE, " + LockDurationMinutes + @", GETDATE()) WHERE UserId = @UserId;
    END
    ELSE
    BEGIN
        UPDATE AdminLoginAttempts SET IsLocked = 0, LockedUntil = NULL WHERE UserId = @UserId;
    END
END
ELSE
BEGIN
    INSERT INTO AdminLoginAttempts (UserId, Attempts, LastAttempt, IsLocked, LockedUntil) VALUES (@UserId, 1, GETDATE(), 0, NULL);
END
";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
        }
    }

    private void ResetAttempts(string userId)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE AdminLoginAttempts SET Attempts = 0, IsLocked = 0, LockedUntil = NULL WHERE UserId = @UserId", conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
        }
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
         if (txtUserId.Text.Trim() == "")
            {
                Lblerror.Text = "Please enter User name.";
                Lblerror.Visible = true;
                return;
            }
            else if (txtPwd.Text == "")
            {
                Lblerror.Text = "Please enter Password.";
                Lblerror.Visible = true;
                return;
            }
            else
            {
                Lblerror.Visible = true;
            }
            string userId = txtUserId.Text.Trim();
            if (IsAccountLocked(userId))
            {
                Lblerror.Text = "Account is locked due to too many failed login attempts.";
                Lblerror.Visible = true;
                return;
            }
            UserMgmt userMgmt = new UserMgmt();
            userMgmt.UserID = userId;
            userMgmt.Password = objSecurity.Encrypt(this.txtPwd.Text.Trim());

            DataSet dsLogins = userMgmt.CheckUserLog();

            if (dsLogins != null && dsLogins.Tables[0].Rows != null && dsLogins.Tables[0].Rows.Count > 0)
            {
                if (dsLogins.Tables[0].Rows[0][0].ToString() == "1")
                {
                    ResetAttempts(userId);
                    IsAdmin(dsLogins.Tables[0]);
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    IncrementAttempts(userId);
                    Lblerror.Text = "The username or password you entered is incorrect.";
                    Lblerror.Visible = true;
                }
            }
     }
    
}
