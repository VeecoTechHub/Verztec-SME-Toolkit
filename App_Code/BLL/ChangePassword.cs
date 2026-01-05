using System;
using System.Collections.Generic;
using System.Web;
using ABSDAL;

/// <summary>
/// Summary description for ChangePassword
/// </summary>
public class ChangePassword
{
	public ChangePassword()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    #region Variable Declaration
    private string _strEmailID, _strExistingPassword, _strNewPassword;

    #endregion

    #region Property Methods
    public string StrEmailID
    {
        get { return _strEmailID; }
        set { _strEmailID = value; }
    }
    public string StrExistingPassword
    {
        get { return _strExistingPassword; }
        set { _strExistingPassword  = value; }
    }

    public string strNewPassword
    {
        get { return _strNewPassword; }
        set { _strNewPassword = value; }
    }
    #endregion


    public int UpdatePassword(ChangePassword objChangePassword)
    {
        try
        {
            CommonDAL commonObj = new CommonDAL();
            return commonObj.UpdatePassword(objChangePassword);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
