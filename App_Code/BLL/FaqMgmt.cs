using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ABSDAL;
/// <summary>
/// Summary description for FaqMgmt
/// </summary>
public class FaqMgmt
{
    private CommonDAL dataAccessLayer;
    public FaqMgmt()
    {
        dataAccessLayer = new CommonDAL();
    }
    #region Business Entities

    #region Variables
    private string _categoryId;
    private string _faqQuestion;
    private string _faqAnswer;
    private int _sortOrder;
    private string _sort_On;
    private string _sort_Direction;
    private string _faqId;
    #endregion

    #region Properties
    public string FaqId
    {

        get
        {
            return _faqId;
        }
        set
        {
            _faqId = value;
        }
    }
    public string Sort_Direction
    {

        get
        {
            return _sort_Direction;
        }
        set
        {
            _sort_Direction = value;
        }
    }
    public string Sort_On
    {

        get
        {
            return _sort_On;
        }
        set
        {
            _sort_On = value;
        }
    }
    public string CategoryId
    {

        get
        {
            return _categoryId;
        }
        set
        {
            _categoryId = value;
        }
    }
    public string FaqQuestion
    {

        get
        {
            return _faqQuestion;
        }
        set
        {
            _faqQuestion = value;
        }
    }
    public string FaqAnswer
    {

        get
        {
            return _faqAnswer;
        }
        set
        {
            _faqAnswer = value;
        }
    }
    public int SortOrder
    {

        get
        {
            return _sortOrder;
        }
        set
        {
            _sortOrder = value;
        }
    }
    #endregion

    #endregion
    public DataSet getDataForCategory()
    {
        try
        {

            return dataAccessLayer.getDataForCategory();
        }
        catch (Exception ex) { throw ex; }
    }

    public int insetFaq(string CreatedBy)
    {
        try
        {

            return dataAccessLayer.insetFaq(CategoryId, FaqQuestion, FaqAnswer, CreatedBy);
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet getAllFaq()
    {
        try
        {

            return dataAccessLayer.getAllFaq(CategoryId,Sort_On,Sort_Direction);
        }
        catch (Exception ex) { throw ex; }
    }
    public int deleteFaq(string strFaqIds)
    {
        try
        {

            return dataAccessLayer.deleteFaq(strFaqIds);
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet getFaqById()
    {
        try
        {
            return dataAccessLayer.getFaqById(FaqId);
        }
        catch (Exception ex) { throw ex; }
    }
    public int updateFaq(string UpdatedBy)
    {
        try
        {

            return dataAccessLayer.updateFaq(CategoryId, FaqQuestion, FaqAnswer, FaqId, UpdatedBy);
        }
        catch (Exception ex) { throw ex; }
    }

}
