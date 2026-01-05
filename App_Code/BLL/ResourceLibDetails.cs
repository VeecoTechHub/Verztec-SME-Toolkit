using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ABSDAL;


/// <summary>
/// Summary description for ResourceLibDetails
/// new ver of ResourceLibraryDetails.cs
/// 
/// </summary>
public class ResourceLibDetails
{
    DataSet ds = new DataSet();
    CommonDAL obj_DAL = new CommonDAL();
    public ResourceLibDetails()
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
        get { return _Type; }
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
    private string _Title, _Description, _C_Description, _Tags, _Author, _Upload_File_Path, _Created_By, _Updated_By, _Delete_Flag;
    private string _SortOn, _SortDirection,_UserId;
    private string _CTitle;

    public string CTitle
    {
        get { return _CTitle; }
        set { _CTitle = value; }
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

    private int _RL_ID;
    public int RL_ID
    {
        get { return _RL_ID; }
        set { _RL_ID = value; }
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

    public string C_Description
    {
        get { return _C_Description; }
        set { _C_Description = value; }
    }

    public string Tags
    {
        get { return _Tags; }
        set { _Tags = value; }
    }

    public string UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
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
    public int typedownloadoraddfav {get;set;}
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

    private int _TopicId;
    public int TopicID
    {
        get { return _TopicId; }
        set { _TopicId = value; }
    }

    private string _Newsdetails;
    public string NewsDetails
    {
        get { return _Newsdetails; }
        set { _Newsdetails = value; }
    }
    private string _CNewdetails;
    public string CNewdetails
    {
        get { return _CNewdetails; }
        set { _CNewdetails = value; }
    }
    private string _Docs;
    public string Docs
    {
        get { return _Docs; }
        set { _Docs = value; }
    }
    public string ImageType { get; set; }
    public string Level { get; set; }

    public string TopicName { get; set; }
    public string TopicDesc { get; set; }
    public string action { get; set; }
    public string TopicIDS { get; set; }
    public string RL_FileName { get; set; }
    public string C_RL_FileName { get; set; }
    public string DocSelection { get; set; }
    public string RLStatus { get; set; }
    public string Culture { get; set; }
    public string C_Title { get; set; }
    public string C_RL_Details { get; set; }
    public int intCulture { get; set; }

    /// <summary>
    /// DEC 20.2011[public]
    /// This method invokes the Get_ResourceLibraryDetails method in DAL.cs file in DAL folder.
    /// </summary>
    /// <returns></returns>
    public DataSet Get_ResourceLibraryDetails(ResourceLibraryDetails obj_RSDetails)
    {
        return ds = obj_DAL.Get_ResourceLibraryDetails(obj_RSDetails);
    }


    public DataSet Get_ResourceLibCategory(ResourceLibDetails obj_RLDetails)
    {

        return obj_DAL.Get_ResourceLibCategory(obj_RLDetails);

    }

    public DataSet GetSelResourceLibCategory(ResourceLibDetails  obj_RLDetails)
    {

        return obj_DAL.GetSelResourceLibCategory(obj_RLDetails);

    }

    //public DataSet Get_ResourceLibCategory(ResourceLibDetails obj_RsDetails)
    //{
    //    return obj_DAL.Get_ResourceLibCategory(obj_RsDetails);

    //}
    public DataSet Get_ResourceLibDetails(ResourceLibDetails  obj_RLDetails)
    {
        return ds = obj_DAL.Get_ResourceLibDetails(obj_RLDetails);


    }
    public DataSet Get_ResourceLibDetails_ByID(ResourceLibDetails obj_RLDetails)
    {
        return ds = obj_DAL.Get_ResourceLibDetails_ByID(obj_RLDetails);

    }

    public int Update_ResourceLibDetails(ResourceLibDetails obj_RSDetails)
    {
        //return obj_DAL.Update_ResourceLibDetails(obj_RSDetails);
        return obj_DAL.Update_ResourceLibDetails(obj_RSDetails );


    
    }

    //public int Update_ResourceLibDetails(ResourceLibDetails obj_RLDetails)
    //{
        
    //    return obj_DAL.Update_ResourceLibDetails(obj_RLDetails);
    //} 
     
    public int Insert_ResourceLibCategoryDetails(ResourceLibDetails  obj_RSDetails)
    {
        //new details123
        return obj_DAL.Insert_ResourceLibCategoryDetails (obj_RSDetails);

    }
    public int Delete_ResourceLibCategoryDetails(ResourceLibDetails  obj_RSDetails)
    {
        return obj_DAL.Delete_ResourceLibCategoryDetails(obj_RSDetails);

    }

    /// <summary>
    /// Feb 07.2012
    /// This method inserts values related to the News which the user selected as his favourite into tbl_AddRLFavourite table in DB.
    /// </summary>
    /// <param name="obj_RLDetails"></param>


    //public int Insert_AddFavouriteNews(ResourceLibraryDetails obj_NSDetails)
    //{
    //    return obj_DAL.Insert_AddFavouriteNews(obj_NSDetails);
    //}

    public int Insert_AddRLFavourite(ResourceLibDetails obj_RSDetails)
    {
        return obj_DAL.Insert_AddRLFavourite(obj_RSDetails);
    }

    public DataSet Get_MyRLFavouritesDetails(ResourceLibDetails obj_RSDetails)
    {
        return ds = obj_DAL.Get_MyRLFavouritesDetails(obj_RSDetails);
    }

    public DataTable GetRLTitles(ResourceLibDetails obj_RSDetails)
    {
        return obj_DAL.GetRLTitles(obj_RSDetails);
    }

    public DataSet Get_ResourceLibDetails_Public(ResourceLibDetails obj_RLDetails)
    {
        return ds = obj_DAL.Get_ResourceLibDetails_Public(obj_RLDetails);
    }
    public DataSet Get_ResourceLibDetails_ByID_Public(ResourceLibDetails obj_RLDetails)
    {
        return ds = obj_DAL.Get_ResourceLibDetails_ByID_Public(obj_RLDetails);

    }

    public int Delete_AddRLFavourite(ResourceLibDetails obj_RSDetails)
    {
        return obj_DAL.Delete_AddRLFavourite(obj_RSDetails);
    }


    /* Added by shekar for new version of resource library on May 10th 2012*/

    public DataSet GET_RESOURCELIBRARY_CATEGORYDTLS(ResourceLibDetails obj_RsDetails)
    {
        return ds = obj_DAL.GET_RESOURCELIBRARY_CATEGORYDTLS(obj_RsDetails);


    }
    public DataSet GET_RESOURCELIBRARY_DETAILS_ByTopicID(ResourceLibDetails obj_RLDetails)
    {
        return ds = obj_DAL.GET_RESOURCELIBRARY_DETAILS_ByTopicID(obj_RLDetails);
    }

    public int GET_STATUS_FAVOURITE(ResourceLibDetails obj_RSDetails)
    {
        return obj_DAL.GET_STATUS_FAVOURITE(obj_RSDetails);
    }

    public DataSet GET_RelatedArticals(ResourceLibDetails obj_RLDetails)
    {
        return ds = obj_DAL.GET_RelatedArticals(obj_RLDetails);
    }

    #region Manage Topic Details

    public void InsertTopicDetails(ResourceLibDetails objBLL)
    {
        obj_DAL.InsertTopicDetails(objBLL);
    }
    public DataSet GetTopicDetails(ResourceLibDetails objBLL)
    {
        return ds = obj_DAL.GetTopicDetails(objBLL);
    }
    public string ValidateTopicDetails(string[] TopicIDs)
    {
        return obj_DAL.ValidateTopicDetails(TopicIDs);
    }

    #endregion

}
