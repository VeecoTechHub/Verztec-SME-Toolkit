using System;
using System.Collections.Generic;
////using System.Linq;
using System.Web;
using System.Data;
using ABSDAL;
/// <summary>
/// Summary description for ForgotPassword
/// </summary>
public class ForgotPassword
{
    CommonDAL dataAccessLayer;
	public ForgotPassword()
	{
		//
		// TODO: Add constructor logic here
		//

        dataAccessLayer = new CommonDAL();
    }

    #region properties

    public string UserID { get; set; }
    public string EmailID { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public string ActivationID { get; set; }
    public DateTime? ExpiryDate { get; set; }

    #endregion


    #region Forgot password page methods

    /// <summary>
    /// Method to get User status by passing the Mail ID.
    /// </summary>
    /// <param name="EmailID"></param>
    /// <returns></returns>
    public DataSet GetUserStatus(string EmailID)
    {
        try
        {
            return dataAccessLayer.GetUserStatus(EmailID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// Method to insert into Forgot Password.
    /// </summary>
    /// <param name="obj_FGPwd"></param>
    /// <returns></returns>
    public int InsertForgotPWdDetails(ForgotPassword obj_FGPwd)
    {
        try
        {
            return dataAccessLayer.InsertForgotPWdDetails(obj_FGPwd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Method to get forgot password detaisl  by passing the Activation Key.
    /// </summary>
    /// <param name="EmailID"></param>
    /// <returns></returns>
    public DataSet GetForgotPwdDtlsbyAcctKey(ForgotPassword obj_FGPwd)
    {
        try
        {
            return dataAccessLayer.GetForgotPwdDtlsbyAcctKey(obj_FGPwd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateUserPwdbyUserID(ForgotPassword obj_FGPwd)
    {
        try
        {
            return dataAccessLayer.UpdateUserPwdbyUserID(obj_FGPwd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    #endregion


}