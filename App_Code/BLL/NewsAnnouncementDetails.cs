using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using ABSDAL;

/// <summary>
/// Summary description for NewsAnnouncementDetails
/// </summary>
public class NewsAnnouncementDetails
{


    DataSet ds = new DataSet();
    CommonDAL obj_DAL = new CommonDAL();
	public NewsAnnouncementDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int[] _tags = new int[5];

    private string _Admin;
    public string Admin
    {
        get { return _Admin; }
        set { _Admin = value; }
    }
    private string _Type;
    public string Type
    {
        get { return _Type ; }
        set { _Type = value; }
    }
    private int _tagno;
    public int tagno
    {
        get { return _tagno; }
        set { _tagno = value; }
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

    private int _Rating;
    public int Rating
    {
        get { return _Rating; }
        set { _Rating = value; }
    }
    public int[] tags
    {
        get { return _tags; }
        set { _tags = value; }
    }
    private string _Title, _Description,_Newsdetails, _Tags, _Author, _Upload_File_Path, _Created_By, _Updated_By, _Delete_Flag;
    private string _SortOn, _SortDirection;

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
    private DateTime _Created_On;
    public DateTime Created_On
    {
        get { return _Created_On; }
        set { _Created_On = value; }
    }

    private DateTime _Updated_On;
    public DateTime Updated_On
    {
        get { return _Updated_On; }
        set { _Updated_On = value; }
    }

    private DateTime _Published_On;
    public DateTime Published_On
    {
        get { return _Published_On; }
        set { _Published_On = value; }
    }

    private int _N_id;
    public int N_ID
    {
        get { return _N_id; }
        set { _N_id = value; }
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

    public string NewsDetails
    {
        get { return _Newsdetails ; }
        set { _Newsdetails = value; }
    }

    public string Tags
    {
        get { return _Tags; }
        set { _Tags = value; }
    }

    public string Author
    {
        get { return _Author; }
        set { _Author = value; }
    }

    public string Upload_File_Path
    {
        get { return _Upload_File_Path; }
        set { _Upload_File_Path = value; }
    }

    public string Created_By
    {
        get { return _Created_By; }
        set { _Created_By = value; }
    }


    public string Updated_By
    {
        get { return _Updated_By; }
        set { _Updated_By = value; }
    }

    public string Delete_Flag
    {
        get { return _Delete_Flag; }
        set { _Delete_Flag = value; }
    }

    private string _Topic;
    public string Topic
    {
        get { return _Topic; }
        set { _Topic = value; }
    }

    public DataSet GetSelCategory(NewsAnnouncementDetails obj_NewsDetails)
    {

        return obj_DAL.GetSelCategory(obj_NewsDetails);

    }

    public DataSet Get_Category(NewsAnnouncementDetails obj_NewsDetails)
    {

        return ds = obj_DAL.Get_Category (obj_NewsDetails);
    }
    public DataSet Get_NewsDetails(NewsAnnouncementDetails obj_NewsDetails)
    {
        return ds = obj_DAL.Get_NewsDetails(obj_NewsDetails);

    
    }
    public DataSet Get_NewsDetails_ByID(NewsAnnouncementDetails obj_NewsDetails)
    {
        return ds = obj_DAL.Get_NewsDetails_ByID(obj_NewsDetails);

    }

    public int Update_NewsDetails(NewsAnnouncementDetails obj_NSDetails)
    {
        return obj_DAL.Update_NewsDetails(obj_NSDetails);


    }
    
    public int Insert_CategoryDetails(NewsAnnouncementDetails obj_NSDetails)
    {

        return obj_DAL.Insert_CategoryDetails(obj_NSDetails);

    }
    public int Delete_CategoryDetails(NewsAnnouncementDetails obj_NSDetails)
    {
        return obj_DAL.Delete_CategoryDetails(obj_NSDetails);

    }


    /// <summary>
    /// Feb 07.2012
    /// This method inserts values related to the News which the user selected as his favourite into tbl_AddRLFavourite table in DB.
    /// </summary>
    /// <param name="obj_RLDetails"></param>

    public int Insert_AddRLFavourite(NewsAnnouncementDetails obj_NSDetails)
    {
        return obj_DAL.Insert_AddFavouriteNews(obj_NSDetails);
    }

    /// <summary>
    /// Feb 07.2012
    /// </summary>    
    public DataSet Get_MyNewsFavouritesDetails(NewsAnnouncementDetails obj_NSDetails)
    {
        return ds = obj_DAL.Get_MyNewsFavouritesDetails(obj_NSDetails);
    }

    public DataTable GetNewsTitles(NewsAnnouncementDetails obj_NSDetails)
    {
        return obj_DAL.GetNewsTitles(obj_NSDetails);
    }

}