using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.Win32;
using DBLinks;
using ABSDAL;
using ABSSecurity;
/// <summary>
/// Summary description for UserMgmt
/// </summary>
public class UserMgmt
{
    ////private DataAccessLayer dataAcessLayer;
    CommonFunctions objCommonFunctions = new CommonFunctions();
    CommonDAL commonObj = new CommonDAL();
    Security objSecurity = new Security();


    #region Variable Declaration
    private string _userid, _Error_Source, _Error_Description, _AccessBy, _AccessId, _PageView,_Downloading,_AccessDescription;
    private string _password;
    private int _CategoryId,_IndustryId;
    #endregion

    #region Property Methods
    public string UserID
    {
        get { return _userid; }
        set { _userid = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
    public string Error_Source
    {
        get { return _Error_Source; }
        set { _Error_Source = value; }
    }
    public string Error_Description
    {
        get { return _Error_Description; }
        set { _Error_Description = value; }
    }
      
    public string AccessBy
    {
        get { return _AccessBy; }
        set { _AccessBy = value; }
    }
    public string AccessId
    {
        get { return _AccessId; }
        set { _AccessId = value; }
    }
    public int CategoryId
    {
        get { return _CategoryId; }
        set { _CategoryId = value; }
    }
    public int IndustryId
    {
        get { return _IndustryId; }
        set { _IndustryId = value; }
    }
    public string PageView
    {
        get { return _PageView; }
        set { _PageView = value; }
    }
    public string Downloading
    {
        get { return _Downloading; }
        set { _Downloading = value; }
    }
    public string AccessDescription
    {
        get { return _AccessDescription; }
        set { _AccessDescription = value; }
    }

    public int Culture { get; set; }

    #endregion

    #region Constructor
    public UserMgmt()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    public DataSet CheckUserLog()
    {
        try
        {

            DataSet dsTemp = new DataSet();
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = CommonFunctions.MakeParam("@pUserID", SqlDbType.VarChar, 50, ParameterDirection.Input, UserID);
            parameter[1] = CommonFunctions.MakeParam("@pPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, Password);
            dsTemp = DAL.GetListWithParam("[Usp_CheckUser]", parameter);
            return dsTemp;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    /**
    public int InsertUserLoginDetls(string UserNm,string Pwd)
    {
        try {            
                dataAcessLayer = new NusDataAccessLayer();
                return dataAcessLayer.InsertUserLoginTime(UserNm,Pwd); 
            }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet getUserLoginTime(string UserNm)
    {
        try {
                dataAcessLayer = new NusDataAccessLayer();
                return dataAcessLayer.GetUserLoginTime(UserNm); 
            }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetUserLogForAd()
    {
        try
        {
            CommonFunctions CommonFunctions = new CommonFunctions();
            dataAcessLayer = new NusDataAccessLayer();
            return dataAcessLayer.GetUserLogForAd(UserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    **/


      /// <summary>
    /// 23/01/2012
    /// </summary>
    /// <param name="userObj"></param>
    /// <returns></returns>
     public int InsertErrorDetails(UserMgmt userObj)
     {
        try
        {
            return commonObj.InsertErrorDetails(userObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




     /// <summary>
     /// 05/03/2012
     /// </summary>
     /// <param name="userObj"></param>
     /// <returns></returns>
     public int InsertModuleTrack(UserMgmt userObj)
     {
         try
         {
             return commonObj.InsertModuleTrack(userObj);
         }
         catch (Exception ex)
         {
             throw ex;
         }

     }


    #region Ateeq

     /// <summary>
     /// 05/03/2012
     /// </summary>
     /// <param name="userObj"></param>
     /// <returns></returns>
     public int InsertModuleTrack_ResLib(UserMgmt userObj)
     {
         try
         {
             return commonObj.InsertModuleTrack_ResLib(userObj);
         }
         catch (Exception ex)
         {
             throw ex;
         }

     }
    #endregion




}
