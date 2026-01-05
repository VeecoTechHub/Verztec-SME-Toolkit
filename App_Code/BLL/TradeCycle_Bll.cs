using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ABSDAL;


/// <summary>
/// Summary description for TradeCycle_Bll
/// </summary>
public class TradeCycle_Bll
{
    private CommonDAL dataAccessLayer;
	public TradeCycle_Bll()
	{
        dataAccessLayer = new CommonDAL();
	}
    public DataSet getTradeCycleDate(string UserID)
    {
        try
        {
            return dataAccessLayer.getTradeCycleDate(UserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}