using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using ABSDAL;


/// <summary>
/// Summary description for BannerDetails
/// </summary>
public class BannerDetails
{
    CommonDAL dataAccessLayer= new CommonDAL();
	public BannerDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Banner Details 

    private string _TopBanner, _Banner2, _Banner3, _Banner4, _Banner5, _FooterBanner1, _FooterBanner2, _FooterBanner3, _FooterBanner4, _RHSBanner7, _AdBanner1, _AdBanner2, _AdBanner3, _AdBanner4, _Upload_File_Path;
    private string _TopBannerUrl, _BannerUrl2, _BannerUrl3, _BannerUrl4, _BannerUrl5, _FooterBannerUrl1, _FooterBannerUrl2, _FooterBannerUrl3, _FooterBannerUrl4, _RHSBannerUrl7, _AdBannerUrl1, _AdBannerUrl2, _AdBannerUrl3, _AdBannerUrl4, _Created_By, _Updated_By;


    private string _Operation;

    public string Upload_File_Path
    {
        get { return _Upload_File_Path; }
        set { _Upload_File_Path = value; }
    }
    public string Operation
    {
        get { return _Operation; }
        set { _Operation = value; }
    }

    public string TopBanner
    {
        get { return _TopBanner; }
        set { _TopBanner = value; }
    }
    public string Banner2
    {
        get { return _Banner2; }
        set { _Banner2 = value; }
    }
    public string Banner3
    {
        get { return _Banner3; }
        set { _Banner3 = value; }
    }
    public string Banner4
    {
        get { return _Banner4; }
        set { _Banner4 = value; }
    }
    public string Banner5
    {
        get { return _Banner5; }
        set { _Banner5 = value; }
    }
    public string FooterBanner1
    {
        get { return _FooterBanner1; }
        set { _FooterBanner1 = value; }
    }
    public string FooterBanner2
    {
        get { return _FooterBanner2; }
        set { _FooterBanner2 = value; }
    }
    public string FooterBanner3
    {
        get { return _FooterBanner3; }
        set { _FooterBanner3 = value; }
    }
    public string FooterBanner4
    {
        get { return _FooterBanner4; }
        set { _FooterBanner4 = value; }
    }
    public string Banner7
    {
        get { return _RHSBanner7; }
        set { _RHSBanner7 = value; }
    }
    public string AdBanner1
    {
        get { return _AdBanner1; }
        set { _AdBanner1 = value; }
    }
    public string AdBanner2
    {
        get { return _AdBanner2; }
        set { _AdBanner2 = value; }
    }
    public string AdBanner3
    {
        get { return _AdBanner3; }
        set { _AdBanner3 = value; }
    }
    public string AdBanner4
    {
        get { return _AdBanner4; }
        set { _AdBanner4 = value; }
    }
    public string TopBannerUrl
    {
        get { return _TopBannerUrl; }
        set { _TopBannerUrl = value; }
    }
    public string BannerUrl2
    {
        get { return _BannerUrl2; }
        set { _BannerUrl2 = value; }
    }
    public string BannerUrl3
    {
        get { return _BannerUrl3; }
        set { _BannerUrl3 = value; }
    }
    public string BannerUrl4
    {
        get { return _BannerUrl4; }
        set { _BannerUrl4 = value; }
    }
    public string BannerUrl5
    {
        get { return _BannerUrl5; }
        set { _BannerUrl5 = value; }
    }
    public string FooterBannerUrl1
    {
        get { return _FooterBannerUrl1; }
        set { _FooterBannerUrl1 = value; }
    }
    public string FooterBannerUrl2
    {
        get { return _FooterBannerUrl2; }
        set { _FooterBannerUrl2 = value; }
    }
    public string FooterBannerUrl3
    {
        get { return _FooterBannerUrl3; }
        set { _FooterBannerUrl3 = value; }
    }
    public string FooterBannerUrl4
    {
        get { return _FooterBannerUrl4; }
        set { _FooterBannerUrl4 = value; }
    }
    public string RHSBannerUrl7
    {
        get { return _RHSBannerUrl7; }
        set { _RHSBannerUrl7 = value; }
    }
    public string AdBannerUrl1
    {
        get { return _AdBannerUrl1; }
        set { _AdBannerUrl1 = value; }
    }
    public string AdBannerUrl2
    {
        get { return _AdBannerUrl2; }
        set { _AdBannerUrl2 = value; }
    }
    public string AdBannerUrl3
    {
        get { return _AdBannerUrl3; }
        set { _AdBannerUrl3 = value; }
    }
    public string AdBannerUrl4
    {
        get { return _AdBannerUrl4; }
        set { _AdBannerUrl4 = value; }
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

    public string Culture { get; set; }
    public int BannerId { get; set; }

    #endregion


    #region Methods Banner Details

    /// <summary>
    /// 05/01/2012
    /// Insert all BannerDetails in tbl_Banner table
    /// </summary>
    /// <param name="objBanner"></param>
    /// <returns></returns>

    public int InsertBannerDetails(BannerDetails objBanner)
    {
        try
        {
            return dataAccessLayer.InsertBannerDetails(objBanner);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 05/01/2012
    /// To get all BannerDetails from tbl_Banner table
    /// </summary>
    /// /// <returns></returns>
    public DataSet GetBannerDetails()
    {
        try
        {
            return dataAccessLayer.GetBannerDetails();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// 05/01/2012
    /// To get all BannerDetails from tbl_Banner table
    /// </summary>
    /// /// <returns></returns>
    public DataSet GetBannerDetails_Culture(BannerDetails objBanner)
    {
        try
        {
            return dataAccessLayer.GetBannerDetails_Culture(objBanner);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// 18/01/2012
    /// To Delete Banner image in tbl_Banner table 
    /// </summary>
    /// /// <returns></returns>
    public int DelteBannerImage(int bannerNumber)
    {
        try
        {
            return dataAccessLayer.DelteBannerImage(bannerNumber);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    #endregion

}