using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using ABSDAL;
using ABSDTO;
using System.Data;


/// <summary>
/// Summary description for CourseRegistration
/// </summary>
public class CourseRegistration
{
    CommonDAL dataAccessLayer;
	public CourseRegistration()
	{
        dataAccessLayer = new CommonDAL();
    }

    #region Variabes
    private string _UserID;
    private string _Name ;
    private string _NRIC_ID_Number;
    private string _Contact_Number;
    private string _EmailID;
    private DateTime _CreatedOn;
    private string _ActivationKey;


    public string UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string NRIC_ID_Number
    {
        get { return _NRIC_ID_Number; }
        set { _NRIC_ID_Number = value; }
    }

    public string Contact_Number
    {
        get { return _Contact_Number; }
        set { _Contact_Number = value; }
    }
    public string EmailID
    {
        get { return _EmailID; }
        set { _EmailID = value; }
    }
    public DateTime CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }
    public string ActivationKey
    {
        get { return _ActivationKey; }
        set { _ActivationKey = value; }
    }


    private int _CID;
    public int CID
    {
        get { return _CID; }
        set { _CID = value; }
    }

    #endregion


    #region Course Registration Page Methods

    /// <summary>
    /// Method to save User details in [tbl_CourseRegistration]
    /// </summary>
    /// <param name="obj_CourseRegs"></param>
    /// <returns></returns>
    public int InsertCourseRegistration(CourseRegistration obj_CourseRegs)
    {
        try
        {
            return dataAccessLayer.InsertCourseRegistration(obj_CourseRegs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet GetCourseRegistrationDetails(string UserID)
    {
        try
        {
            return dataAccessLayer.GetCourseRegistrationDetails(UserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Get_CourseDetailsById(string CID)
    {
        try
        {
            return dataAccessLayer.Get_CourseDetailsById(CID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// JAN 20.2012
    /// This method retrieves the CID(identity value) based on uniqueidentifier
    /// </summary>
    /// <param name="CID"></param>
    /// <returns></returns>
    public int getCid(string CID)
    {
        return dataAccessLayer.getCid(CID);
    }


    /// <summary>
    /// Shekar
    /// Method to save User details in [tbl_CourseRegistration]
    /// </summary>
    /// <param name="obj_CourseRegs"></param>
    /// <returns></returns>
    public DataSet Get_CourseRegs_DetailsById(int CID)
    {
        try
        {
            return dataAccessLayer.Get_CourseRegs_DetailsById(CID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Method to Delete Registered User details in [tbl_CourseRegistration]
    /// </summary>
    /// <param name="obj_CourseRegs"></param>
    /// <returns></returns>
    public int DeleteCourseRegistration(string UserID)
    {
        try
        {
            return dataAccessLayer.Delete_Record_CourseRegsDetails(UserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Shekar
    /// Method to get User details in [tbl_CourseRegistration]
    /// </summary>
    /// <param name="obj_CourseRegs"></param>
    /// <returns></returns>
    public DataSet Get_CourseRegs_DetailsAll(string strTitle)
    {
        try
        {
            return dataAccessLayer.Get_CourseRegs_DetailsByAll(strTitle);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion






}