using System;
using System.Collections.Generic;
////using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ABSDAL;

/// <summary>
/// Summary description for ResourceLibraryDetails
/// </summary>
public class ResourceLibraryDetails
{

    DataSet ds = new DataSet();
    CommonDAL obj_DAL = new CommonDAL();
    public ResourceLibraryDetails()
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
    private string _Title, _Description, _Tags, _Author, _Upload_File_Path, _Created_By, _Updated_By, _Delete_Flag;
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

    /// <summary>
    /// DEC 20.2011[public]
    /// This method invokes the Get_ResourceLibraryDetails method in DAL.cs file in DAL folder.
    /// </summary>
    /// <returns></returns>
    public DataSet Get_ResourceLibraryDetails(ResourceLibraryDetails obj_RLDetails)
    {
        return ds = obj_DAL.Get_ResourceLibraryDetails(obj_RLDetails);
    }

    /// <summary>
    /// JAN 06.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_Tags(ResourceLibraryDetails obj_RLDetails)
    {
        return ds = obj_DAL.Get_Tags(obj_RLDetails);
    }

    /// <summary>
    /// JAN 03.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_MyFavouritesDetails(ResourceLibraryDetails obj_RLDetails)
    {
        return ds = obj_DAL.Get_MyFavouritesDetails(obj_RLDetails);
    }

    /// <summary>
    /// JAN 06.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet GetSelTags(ResourceLibraryDetails obj_RLDetails)
    {
        return ds = obj_DAL.GetSelTags(obj_RLDetails);
    }


    /// <summary>
    /// DEC 22.2011
    /// This method inserts values related to the Title which the user selected as his favourite into tbl_AddFavourite table in DB.
    /// </summary>
    /// <param name="obj_RLDetails"></param>

    public int Insert_AddFavourite(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Insert_AddFavourite(obj_RLDetails);
    }

    /// <summary>
    /// DEC 22.2011
    /// This method retrieves the data based on the user Title selection
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_ResourceLibraryDetails_ByTitle(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Get_ResourceLibraryDetails_ByTitle(obj_RLDetails);
    }


    public DataSet GetTagValues()
    {
        return obj_DAL.GetTagValues();
    }


    /// <summary>
    /// DEC 29.2011
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_ResourceLibraryDetails_ByID(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Get_ResourceLibraryDetails_ByID(obj_RLDetails);
    }


    /// <summary>
    /// DEC 22.2011
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    public int Delete_Record_ResourceLibrary(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Delete_Record_ResourceLibrary(obj_RLDetails);
    }

    /// <summary>
    /// 17/01/2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    public int Delete_Record_ResourceLibrary_By_RLID(String RL_ID)
    {
        return obj_DAL.Delete_Record_ResourceLibrary_By_RLID(RL_ID);
    }

    /// <summary>
    /// DEC 27.2011
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    public int Insert_tbl_ResourceLibrary(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Insert_tbl_ResourceLibrary(obj_RLDetails);
    }

    /// <summary>
    /// JAN 03.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public int Update_ResouceLibraryDetails(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Update_ResouceLibraryDetails(obj_RLDetails);
    }

    public string Get_FileName_ByID(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Get_FileName_ByID(obj_RLDetails);
    }

    public int Insert_TagDetails(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Insert_TagDetails(obj_RLDetails);
    }


    public int DeleteTagRow_ByID(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.DeleteTagRow_ByID(obj_RLDetails);
    }

    /// <summary>
    /// JAN 07.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_RL_ID_By_Title(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Get_RL_ID_By_Title(obj_RLDetails);
    }

    /// <summary>
    /// JAN 16
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_RL_ID_By_Title_Favourites(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Get_RL_ID_By_Title_Favourites(obj_RLDetails);
    }




    /// <summary>
    /// JAN 09.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_TagSel_By_RL_ID(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Get_TagSel_By_RL_ID(obj_RLDetails);
    }

    /// <summary>
    /// JAN 09.2012
    /// </summary>
    /// <param name="obj_RLDetails"></param>
    /// <returns></returns>
    public DataSet Get_TagSelName(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.Get_TagSelName(obj_RLDetails);
    }



    /// <summary>
    /// JAN 13.2012
    /// </summary>
    /// <param name="obj_CDetails"></param>
    /// <returns></returns>
    public DataTable GetClients(ResourceLibraryDetails obj_RLDetails)
    {
        return obj_DAL.GetClients(obj_RLDetails);
    }


   
}