using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using ABSDAL;
using System.Data;
using System.Web.UI;
/// <summary>
/// Summary description for CourseDetails
/// </summary>
public class CourseDetails
{
	public CourseDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    CommonDAL obj_DAL = new CommonDAL();
    DataSet ds = new DataSet();
    private Guid _TitleID;
    private string _Title, _Description,_Created_By,_CourseName;
    private string _SortOn, _SortDirection;
    private DateTime _Duration_From, _Duration_To, _Created_On, _Updated_On;
    private string _Topic;
    public string Topic
    {
        get { return _Topic; }
        set { _Topic = value; }
    }

    private int[] _tags = new int[5];

    private int _ReturnId,_CourseId;
    public int ReturnId
    {
        get { return _ReturnId; }
        set { _ReturnId = value; }
    }

    private string _Admin;
    public string Admin
    {
        get { return _Admin; }
        set { _Admin = value; }
    }

    public int CourseId
    {
        get { return _CourseId; }
        set { _CourseId = value; }
    }

    public string CourseName
    {
        get { return _CourseName; }
        set { _CourseName = value; }
    }
    private int _tagno;
    public int tagno
    {
        get { return _tagno; }
        set { _tagno = value; }
    }

    private string _Faculty;
    public string Faculty
    {
        get { return _Faculty; }
        set { _Faculty = value; }
    }

    private int _TagID;
    public int TagID
    {
        get { return _TagID; }
        set { _TagID = value; }

    }

    private int _SelID;
    public int SelID
    {
        get { return _SelID; }
        set { _SelID = value; }
    }

    public int[] tags
    {
        get { return _tags; }
        set { _tags = value; }
    }

    private int _CID;
    public int CID
    {
        get { return _CID; }
        set { _CID = value; }
    }

    public string SortOn
    {
        get { return _SortOn; }
        set { _SortOn = value; }
    }

    public string SortDirection
    {
        get { return _SortDirection; }
        set { _SortDirection = value; }
    }

   

    public Guid  TitleID
    {
        get { return _TitleID; }
        set { _TitleID = value; }
    }

    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public DateTime Duration_From
    {
        get { return _Duration_From; }
        set { _Duration_From = value; }
    }

    public DateTime Duration_To
    {
        get { return _Duration_To; }
        set { _Duration_To = value; }
    }

    public DateTime Created_On
    {
        get { return _Created_On; }
        set { _Created_On = value; }
    }

    public string Created_By
    {
        get { return _Created_By; }
        set { _Created_By = value; }
    }

    public DateTime Updated_On
    {
        get { return _Updated_On; }
        set { _Updated_On = value; }
    }

    private string _Updated_By;
    public string Updated_By
    {
        get { return _Updated_By; }
        set { _Updated_By = value; }
    }

    /// <summary>
    /// JAN 10.2012 3.15PM
    /// </summary>
    /// <returns></returns>
    public DataSet CDetails_GetTagValues()
    {
        try
        {
            return obj_DAL.CDetails_GetTagValues();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    /// <summary>
    /// JAN 10.2012 3.50 PM
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet CDetails_GetSelTags(CourseDetails obj_CDetais)
    {
        try
        {
        return ds = obj_DAL.CDetails_GetSelTags(obj_CDetais);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>


    public int Insert_CourseDetails(CourseDetails obj_CDetais)
    {
        try
        {
            return obj_DAL.Insert_CourseDetails(obj_CDetais);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_CourseDetails(CourseDetails obj_CDetails)
    {
        DataSet ds = new DataSet();
        try
        {
             ds = obj_DAL.Get_CourseDetails(obj_CDetails);
        }
        catch (Exception ex)
        {
           throw ex;
            
            
        }
        return ds;
    }

    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_CourseDetails_By_Id(int CID)
    {
        try
        {
            return ds = obj_DAL.Get_CourseDetails_By_Id(CID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_CourseMaster()
    {
        try
        {
            return ds = obj_DAL.Get_CourseMaster();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_Course_ById(int CID)
    {
        try
        {
            return ds = obj_DAL.Get_Course_ById(CID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public int Delete_Record_CourseDetails(string CID)
    {
        try
        {
            return obj_DAL.Delete_Record_CourseDetails(CID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_CDetails"></param>
    /// <returns></returns>
    public int CDetails_DeleteTagRow_ByID(CourseDetails obj_CDetails)
    {
        try
        {
            return obj_DAL.CDetails_DeleteTagRow_ByID(obj_CDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public int CDetails_Insert_TagDetails(CourseDetails obj_CDetails)
    {
        try
        {
            return obj_DAL.CDetails_Insert_TagDetails(obj_CDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

  


    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_Course_ID_By_Title(CourseDetails obj_CDetails)
    {
        try
        {
            return obj_DAL.Get_Course_ID_By_Title(obj_CDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// JAN 10.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>

    public DataSet GetCourseDetails_By_Service(CourseDetails obj_CDetails)
    {
        try
        {
            return  obj_CDetails.Get_Course_ID_By_Title(obj_CDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    


}