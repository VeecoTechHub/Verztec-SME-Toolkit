using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ABSDAL;

/// <summary>
/// Summary description for FinancialModelingMgmt
/// </summary>

namespace ABSBLL
{
    public class FinancialModelingMgmt
    {
        private CommonDAL dataAccessLayer;
        public FinancialModelingMgmt()
        {
            dataAccessLayer = new CommonDAL();
        }
        #region Business Entities
        private string _companyId, _companyName, _currency, _finYearEndDate, _isFinancialStmtAvailable, _userID, _Culture;
        private string _feedback_Status1, _feedback_Status2, _feedback_Status3,  _emailId, _comments;
        private int _RoundDollar, _isRecommended;
        public string CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public string FinYearEndDate
        {
            get { return _finYearEndDate; }
            set { _finYearEndDate = value; }
        }

        public string IsFinancialStmtAvailable
        {
            get { return _isFinancialStmtAvailable; }
            set { _isFinancialStmtAvailable = value; }
        }

        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string feedback_Status1
        {
            get { return _feedback_Status1; }
            set { _feedback_Status1 = value; }
        }
        public string feedback_Status2
        {
            get { return _feedback_Status2; }
            set { _feedback_Status2 = value; }
        }
        public string feedback_Status3
        {
            get { return _feedback_Status3; }
            set { _feedback_Status3 = value; }
        }
        public string emailId
        {
            get { return _emailId; }
            set { _emailId = value; }
        }
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public int RoundDollar
        {
            get { return _RoundDollar; }
            set { _RoundDollar = value; }
        }
        public int isRecommended
        {
            get { return _isRecommended; }
            set { _isRecommended = value; }
        }
        public string Culture
        {
            get { return _Culture; }
            set { _Culture = value; }
        }
        #endregion

        public DataTable bindCompanyInformationByUserID()
        {
            try
            {

                return dataAccessLayer.bindCompanyInformationByUserID(UserID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int insertCompanyInformation()
        {
            try
            {
                return dataAccessLayer.insertCompanyInformation(CompanyName, Currency, FinYearEndDate, IsFinancialStmtAvailable, UserID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int updateCompanyInformation(int DeleteFlag)
        {
            try
            {
                return dataAccessLayer.updateCompanyInformation(CompanyId, CompanyName, Currency, FinYearEndDate, IsFinancialStmtAvailable, UserID, DeleteFlag);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataTable Get_CompanyFinDetails(string UserID)
        {
            try
            {
                return dataAccessLayer.Get_CompanyFinDetails(UserID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public int Update_CompanyFinDetails(FinancialModelingMgmt objFinancialModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Update_CompanyFinDetails(objFinancialModelingMgmt);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet getStatementByType(string FsMappingType)
        {
            try
            {
                return dataAccessLayer.getStatementByType(UserID, FsMappingType,Culture);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateStatements(DataTable dtStatement, string stmtType)
        {
            try
            {
                return dataAccessLayer.UpdateStatements(dtStatement, stmtType, UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    

        public DataSet getKeySensitivityReportForFinTable()
        {
            try
            {
                return dataAccessLayer.getKeySensitivityReportForFinTable(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       



        public DataSet getBreakEvenPoints()
        {
            try
            {
                return dataAccessLayer.getBreakEvenPoints(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     

        public int updateInteractiveData(string P_P_RevenueGrowth, string P_RevenueGrowth, string C_RevenueGrowth, string P_P_TaxRate,
                string P_TaxRate, string C_TaxRate, string DebtRepaymentPeriod, string EffectiveInterestOnDebt, string UserID)
        {
            try
            {
                return dataAccessLayer.updateInteractiveData(P_P_RevenueGrowth, P_RevenueGrowth, C_RevenueGrowth, P_P_TaxRate, P_TaxRate, C_TaxRate, DebtRepaymentPeriod, EffectiveInterestOnDebt, UserID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet getInteractiveData()
        {
            try
            {
                return dataAccessLayer.getInteractiveData(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int BreakEvenPointSensitivity(string GpMargin)
        {
            try
            {
                return dataAccessLayer.BreakEvenPointSensitivity(UserID, GpMargin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*New Methods*/

        public int UpdateFsMappings(DataTable dtFsMapping, DataTable dtInputValues)
        {
            try
            {
                return dataAccessLayer.UpdateFsMappings(dtFsMapping, dtInputValues, UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getDataBySection(int Section)
        {
            try
            {
                return dataAccessLayer.getDataBySection(UserID, Section);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getStatementByMapID(string FsMappingIds)
        {
            try
            {
                return dataAccessLayer.getStatementByMapID(UserID,FsMappingIds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update_FinTool_Totals()
        {
            try
            {
                return dataAccessLayer.Update_FinTool_Totals(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update_FinTool_Sales(string UserID)
        {
            try
            {
                return dataAccessLayer.Update_FinTool_Sales(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update_FinTool_CostOfSales(string UserID)
        {
            try
            {
                return dataAccessLayer.Update_FinTool_CostOfSales(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update_FinTool_OtherOperating_Expenses(string UserID)
        {
            try
            {
                return dataAccessLayer.Update_FinTool_OtherOperating_Expenses(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update_FinTool_Funding(string UserID)
        {
            try
            {
                return dataAccessLayer.Update_FinTool_Funding(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update_FinTool_Assets(string UserID)
        {
            try
            {
                return dataAccessLayer.Update_FinTool_Assets(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update_FinTool_Tax_Depreciation(string UserID)
        {
            try
            {
                return dataAccessLayer.Update_FinTool_Tax_Depreciation(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getInputStatus(string masterInputId,string userid)
        {
            try
            {
                return dataAccessLayer.getInputStatus(masterInputId,userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_FinTool_Highlights_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Get_FinTool_Highlights_Report(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_FinTool_Breakeven_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Get_FinTool_Breakeven_Report(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_FinTool_WorkingCapital_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Get_FinTool_WorkingCapital_Report(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_FinTool_CashFlowReport_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Get_FinTool_CashFlowReport_Report(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_FinTool_Funding_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Get_FinTool_Funding_Report(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_FinTool_Appa_Financials_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Get_FinTool_Appa_Financials_Report(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_FinTool_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Get_FinTool_Report(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insert_Fintool_Feedback(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Insert_Fintool_Feedback(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_Fintool_Feedback(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                return dataAccessLayer.Get_Fintool_Feedback(objFinModelingMgmt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}