using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ABSBLL;
using ABSDTO;
using System.Data.Common;


/// <summary>
/// Summary description for CommonDAL
/// </summary>

namespace ABSDAL
{
    public class CommonDAL
    {
        #region Properties
        public static SqlDatabase sqlCon;
        public static SqlConnection Con;
        #endregion

        public CommonDAL()
        {
            try
            {


                string conString = GetConnectionString();
                sqlCon = new SqlDatabase(conString);
                Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// updated by mahesh 20-01-2012 
        //summary : to validate user for connection string

        static string constr;

        private static string GetConnectionString()
        {


            try
            {

                //if (HttpContext.Current.Session["USER_ID"] != null) 
                //{
                //    constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                //}
                //return constr;


            }

            catch (Exception err)
            {
                throw err;
            }

        }

        #region Registration Page Methods

        /// <summary>
        /// Method to save User details in [tbl_Registration]
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int InsertRegistration(RegistrationDTO objDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_InsertRegistrationDetails");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(objDTO.UserID));
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, objDTO.EmailID);
                sqlCon.AddInParameter(DbCom, "@Password", DbType.String, objDTO.Password);
                sqlCon.AddInParameter(DbCom, "@Title", DbType.String, objDTO.Title);
                sqlCon.AddInParameter(DbCom, "@Name", DbType.String, objDTO.Name);
                sqlCon.AddInParameter(DbCom, "@CompanyNm", DbType.String, objDTO.CompanyNm);
                sqlCon.AddInParameter(DbCom, "@BussStartedMonth", DbType.Int32, objDTO.BussStartedMonth);
                sqlCon.AddInParameter(DbCom, "@BussStartedYear", DbType.Int32, objDTO.BussStartedYear);
                sqlCon.AddInParameter(DbCom, "@NoofEmployees", DbType.Int32, objDTO.NoofEmployees);
                sqlCon.AddInParameter(DbCom, "@TotalCapital", DbType.Double, objDTO.TotalCapital);
                sqlCon.AddInParameter(DbCom, "@AnnualRevenue", DbType.Double, objDTO.AnnualRevenue);
                sqlCon.AddInParameter(DbCom, "@BusinessID", DbType.Int32, objDTO.BusinessID);
                sqlCon.AddInParameter(DbCom, "@IndustryID", DbType.Int32, objDTO.IndustryID);
                sqlCon.AddInParameter(DbCom, "@Status", DbType.String, objDTO.Status);
                sqlCon.AddInParameter(DbCom, "@CreatedOn", DbType.DateTime, objDTO.CreatedOn);
                sqlCon.AddInParameter(DbCom, "@CompletedOn", DbType.DateTime, DBNull.Value);
                sqlCon.AddInParameter(DbCom, "@ActivationKey", DbType.Guid, new Guid(objDTO.ActivationKey));
                sqlCon.AddOutParameter(DbCom, "@output", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@output"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Insert_CourseDetails

        /// <summary>
        /// JAN 05.2012
        /// Method used to stored CourseDetails into tbl_NextSteps table entered by admin in Admin_NextSteps.aspx under Adminfintool folder.
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int Insert_CourseDetails(CourseDetails obj_CDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_Insert_CourseDetails");
                sqlCon.AddInParameter(DbCom, "@NS_ID", DbType.Guid, obj_CDetails.TitleID);
                sqlCon.AddInParameter(DbCom, "@CID", DbType.Int32, obj_CDetails.CID);
                sqlCon.AddInParameter(DbCom, "@Category_Title", DbType.String, obj_CDetails.Title);
                sqlCon.AddInParameter(DbCom, "@Faculty", DbType.String, obj_CDetails.Faculty);
                sqlCon.AddInParameter(DbCom, "@Description", DbType.String, obj_CDetails.Description);
                sqlCon.AddInParameter(DbCom, "@Duration_From", DbType.DateTime, obj_CDetails.Duration_From);
                sqlCon.AddInParameter(DbCom, "@Duration_To", DbType.DateTime, obj_CDetails.Duration_To);
                sqlCon.AddInParameter(DbCom, "@Created_On", DbType.DateTime, obj_CDetails.Created_On);
                sqlCon.AddInParameter(DbCom, "@Created_By", DbType.String, obj_CDetails.Created_By);
                sqlCon.AddInParameter(DbCom, "@Updated_On", DbType.DateTime, obj_CDetails.Updated_On);
                sqlCon.AddInParameter(DbCom, "@Updated_By", DbType.String, obj_CDetails.Updated_By);
                sqlCon.AddOutParameter(DbCom, "@output", DbType.Int32, 1);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@output"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        ///13/01/2012
        /// To get all details from tbl_NextSteps based on CID
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public DataSet Get_CourseDetails_By_Id(int CID)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Usp_Get_CourseDetails_By_ID");
                sqlCon.AddInParameter(DBCmnd, "@CID", DbType.Int32, CID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///13/01/2012
        /// To get coursename and id from tbl_CourseDetailsTopics and tbl_CourseMaster based on CID
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public DataSet Get_Course_ById(int CID)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Usp_Get_Course_By_ID");
                sqlCon.AddInParameter(DBCmnd, "@CID", DbType.String, CID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>
        ///13/01/2012
        /// To get all details from tbl_CourseMaster
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>


        public DataSet Get_CourseMaster()
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Usp_Get_CourseMaster");
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        ///13/01/2012
        ///To get details from tbl_nextsteps based on coursename and CID (FOR COURSEDETAILS WEB SERVICE)
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>

        public DataSet Get_Course_ID_By_Title(CourseDetails obj_CDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_Get_Course_ID_By_Title");
                sqlCon.AddInParameter(DbCom, "@CourseID", DbType.Int16, obj_CDetails.CourseId);
                sqlCon.AddInParameter(DbCom, "@CourseName", DbType.String, obj_CDetails.CourseName);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        #region Insert_TagDetails

        /// <summary>
        /// JAN 05.2012
        /// 
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int Insert_TagDetails(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Insert_TagDetails");
                sqlCon.AddInParameter(DbCom, "@RL_ID", DbType.Int32, obj_RLDetails.RL_ID);
                sqlCon.AddInParameter(DbCom, "@TopicID", DbType.Int32, obj_RLDetails.tagno);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        /// <summary>
        /// JAN 10.2012
        /// Insert details into tbl_CourseDetailsTopics table 
        /// </summary>
        /// <param name="obj_CDetails"></param>
        /// <returns></returns>
        public int CDetails_Insert_TagDetails(CourseDetails obj_CDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_CDetails_Insert_TagDetails");
                sqlCon.AddInParameter(DbCom, "@CID", DbType.Int32, obj_CDetails.CID);
                sqlCon.AddInParameter(DbCom, "@CourseID", DbType.Int32, obj_CDetails.tagno);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #region DeleteTagRow_ByID

        /// <summary>
        /// JAN 06.2012
        /// 
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int DeleteTagRow_ByID(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("DeleteTagRow_ByID");
                sqlCon.AddInParameter(DbCom, "@RL_ID", DbType.Int32, obj_RLDetails.RL_ID);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// 13/01/2012
        /// Delete records based on CID
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        public int CDetails_DeleteTagRow_ByID(CourseDetails obj_CDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_CDetails_DeleteTagRow_ByID");
                sqlCon.AddInParameter(DbCom, "@CID", DbType.Int32, obj_CDetails.CID);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region
        /// <summary>
        /// JAN 07.2012
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        public DataSet Get_RL_ID_By_Title(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Get_RL_ID_By_Title");
                sqlCon.AddInParameter(DbCom, "@TopicID", DbType.Int16, obj_RLDetails.TagID);
                sqlCon.AddInParameter(DbCom, "@ArticleTitle", DbType.String, obj_RLDetails.Title);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// JAN 16
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        public DataSet Get_RL_ID_By_Title_Favourites(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Get_RL_ID_By_Title_Favourites");
                sqlCon.AddInParameter(DbCom, "@TopicID", DbType.Int16, obj_RLDetails.TagID);
                sqlCon.AddInParameter(DbCom, "@ArticleTitle", DbType.String, obj_RLDetails.Title);
                sqlCon.AddInParameter(DbCom, "@CreatedBy", DbType.String, obj_RLDetails.Created_By);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #region Get_TagSel_By_RL_ID
        /// <summary>
        /// JAN 09.2012
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        public DataSet Get_TagSel_By_RL_ID(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Get_TagSel_By_RL_ID");
                sqlCon.AddInParameter(DbCom, "@RL_ID", DbType.Int16, obj_RLDetails.RL_ID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        /// <summary>
        /// JAN 09.2012
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        public DataSet Get_TagSelName(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Get_TagSelName");
                sqlCon.AddInParameter(DbCom, "@RL_ID", DbType.Int16, obj_RLDetails.RL_ID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to get User details from [tbl_Registration] by Activation Key
        /// </summary>
        /// <param name="ActivationKey"></param>
        /// <returns></returns>
        public DataSet GetUserDetails(string UserID, string ActivationKey, string strStatus)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetRegistrationDetails");
                if (!string.IsNullOrEmpty(UserID))
                    sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(UserID));
                if (!string.IsNullOrEmpty(ActivationKey))
                    sqlCon.AddInParameter(DbCom, "@ActivationKey", DbType.Guid, new Guid(ActivationKey));
                sqlCon.AddInParameter(DbCom, "@Status", DbType.String, strStatus);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to update 'Status' column in [tbl_Registration] as 'Completed' when user clicks on link in Notification Mail
        /// </summary>
        /// <param name="objDTO"></param>
        public void UpdateUserStatus(RegistrationDTO objDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_UpdateUserStatus");
                sqlCon.AddInParameter(DbCom, "@UserId", DbType.Guid, new Guid(objDTO.UserID));
                sqlCon.AddInParameter(DbCom, "@Status", DbType.String, objDTO.Status);
                sqlCon.AddInParameter(DbCom, "@Action", DbType.String, objDTO.Action);
                sqlCon.ExecuteNonQuery(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetItemsDetails(string Culture)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_GET_Industry");
                sqlCon.AddInParameter(DbCom, "@Culture", DbType.String, Culture);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to authenticate the user with the entered credentials
        /// </summary>
        /// <param name="objUserDTO"></param>
        /// <returns></returns>
        public DataSet CheckUser(RegistrationDTO objUserDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetCheckLoginDetails");
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, objUserDTO.EmailID);
                sqlCon.AddInParameter(DbCom, "@Password", DbType.String, objUserDTO.Password);
                sqlCon.AddInParameter(DbCom, "@SessionID", DbType.String, objUserDTO.LoginsessionID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to maintain User Log Details in [tbl_UserLogs]
        /// </summary>
        /// <param name="objDTO"></param>
        public int InsertUserLogs(LoginDTO objDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_InsertUserLogs");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(objDTO.UserID));
                sqlCon.AddInParameter(DbCom, "@Flag", DbType.String, objDTO.Flag);
                sqlCon.AddInParameter(DbCom, "@LogId", DbType.Int32, objDTO.LogId);
                sqlCon.AddInParameter(DbCom, "@IndustryId", DbType.Int32, objDTO.IndustryID);
                sqlCon.AddInParameter(DbCom, "@Culture", DbType.Int32, objDTO.Culture);
                sqlCon.AddOutParameter(DbCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);

                return int.Parse(DbCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to update the user details in [tbl_Registration] by User ID
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int UpdateUserDetails(RegistrationDTO objDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_UpdateUserDetails");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(objDTO.UserID));
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, objDTO.EmailID);
                sqlCon.AddInParameter(DbCom, "@Password", DbType.String, objDTO.Password);
                sqlCon.AddInParameter(DbCom, "@Title", DbType.String, objDTO.Title);
                sqlCon.AddInParameter(DbCom, "@Name", DbType.String, objDTO.Name);
                sqlCon.AddInParameter(DbCom, "@CompanyNm", DbType.String, objDTO.CompanyNm);
                sqlCon.AddInParameter(DbCom, "@BussStartedMonth", DbType.Int32, objDTO.BussStartedMonth);
                sqlCon.AddInParameter(DbCom, "@BussStartedYear", DbType.Int32, objDTO.BussStartedYear);
                sqlCon.AddInParameter(DbCom, "@NoofEmployees", DbType.Int64, objDTO.NoofEmployees);
                sqlCon.AddInParameter(DbCom, "@TotalCapital", DbType.Double, objDTO.TotalCapital);
                sqlCon.AddInParameter(DbCom, "@AnnualRevenue", DbType.Double, objDTO.AnnualRevenue);
                sqlCon.AddInParameter(DbCom, "@BusinessID", DbType.Int32, objDTO.BusinessID);
                sqlCon.AddInParameter(DbCom, "@IndustryID", DbType.Int32, objDTO.IndustryID);
                sqlCon.AddOutParameter(DbCom, "@output", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@output"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string Get_FileName_ByID(ResourceLibraryDetails obj_RLDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_FileName_ByID");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", DbType.Int32, obj_RLDetails.RL_ID);
                sqlCon.AddOutParameter(DBCmnd, "@FileName", DbType.String, 100000000);


                sqlCon.ExecuteScalar(DBCmnd);
                return DBCmnd.Parameters["@FileName"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet GetUserDetailsByEmailID(string EmailID)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetRegistrationDetailsByEmailID");
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, EmailID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to fetch all months from [tbl_Month]
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllMonths()
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetAllMonths");
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Evaluation Questionaire Methods

        /// <summary>
        /// Method to fetch Evaluation Questionaire By User ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetEvalQuestionaireByUserID(string UserID, string strCategory)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetEvalQuestionaireByUserID");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                sqlCon.AddInParameter(DbCom, "@Category", DbType.String, strCategory);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to Insert User Ratings on Questionaire in table [tbl_FMT_ EvaluationScore] 
        /// </summary>
        /// <param name="EvalScore"></param>
        public void InsertEvaluationScore(IList<EvalQuestionaireScore> EvalScore)
        {
            try
            {
                int intAction = 0;
                foreach (EvalQuestionaireScore QS in EvalScore)
                {
                    if (!string.IsNullOrEmpty(QS.strRating))
                    {
                        DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_InsertEvaluationScore");
                        sqlCon.AddInParameter(DbCom, "@FMT_CompanyID", DbType.Guid, new Guid(QS.strCompanyID));
                        sqlCon.AddInParameter(DbCom, "@FMT_EQ_ID", DbType.Guid, new Guid(QS.strQID));
                        sqlCon.AddInParameter(DbCom, "@Rating", DbType.Int32, QS.strRating);
                        sqlCon.AddInParameter(DbCom, "@intAction", DbType.Int32, intAction);
                        sqlCon.ExecuteNonQuery(DbCom);
                        intAction++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to get User Status, whether it is pending or completed by passing the User ID.
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserStatusbyUserID(string UserID)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetUserStatusbyUserID");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(UserID));
                return sqlCon.ExecuteScalar(DbCom).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method to get All users.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllUsers(RegistrationDTO objDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetAllUsers");
                sqlCon.AddInParameter(DbCom, "@Name", DbType.String, objDTO.Name);
                sqlCon.AddInParameter(DbCom, "@Status", DbType.String, objDTO.Status);
                sqlCon.AddInParameter(DbCom, "@EmailAddress", DbType.String, objDTO.EmailID);
                sqlCon.AddInParameter(DbCom, "@CompanyName", DbType.String, objDTO.CompanyNm);
                sqlCon.AddInParameter(DbCom, "@pSortOn", DbType.String, objDTO.Sort_On);
                sqlCon.AddInParameter(DbCom, "@IndustryID", DbType.Int32, objDTO.IndustryID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// JAN 21.2012
        /// </summary>
        /// <param name="objDTO"></param>
        public void DeleteUser(string pdelrecid)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_DeleteUser");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(pdelrecid.ToString()));//SUCCESS FOR ONE REC.

                // sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, pdelrecid);
                //sqlCon.AddInParameter(DbCom, "@Status", DbType.String, objDTO.Status);
                sqlCon.ExecuteNonQuery(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        /// <summary>
        /// DEC 21.2011[public]
        /// This method retrieves the whole records from tbl_ResourceLibrary in DB
        /// </summary>
        /// <returns></returns>
        #region Getting Resourcelibrarydetials
        public DataSet Get_ResourceLibraryDetails(ResourceLibraryDetails obj_RLDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_ResourceLibraryDetails");
                sqlCon.AddInParameter(DBCmnd, "@admin", DbType.String, obj_RLDetails.Admin);
                sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_RLDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_RLDetails.Topic);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion




        /// <summary>
        /// JAN 19.2012
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region Getting ResourceLibraryTopics
        public DataSet Get_ResourceLibraryTopics(ResourceLibraryDetails obj_RLDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_ResourceLibraryTopics");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", DbType.String, obj_RLDetails.RL_ID);
                //sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_RLDetails.Title);
                //sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_RLDetails.Topic);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion




        /// <summary>
        /// JAN 19.2012 C
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>

        #region Getting Get_CourseDetailsTopics
        public DataSet Get_CourseDetailsTopics(CourseDetails obj_CDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_CourseDetailsTopics");
                sqlCon.AddInParameter(DBCmnd, "@CID", DbType.String, obj_CDetails.CID);
                //sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_RLDetails.Title);
                //sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_RLDetails.Topic);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion


        /// <summary>
        /// JAN 06.2012
        /// </summary>
        /// <param name="obj_CDetails"></param>
        /// <returns></returns>
        #region  Get_Tags
        public DataSet Get_Tags(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_Tags");
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetSelCategory
        public DataSet GetSelCategory(NewsAnnouncementDetails obj_NewsDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("GetSelCategory");
                sqlCon.AddInParameter(DBCmnd, "@N_ID", DbType.String, obj_NewsDetails.N_ID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  Get_Category
        public DataSet Get_Category(NewsAnnouncementDetails obj_NewsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_Category");
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Get_NewsDetails
        public DataSet Get_NewsDetails(NewsAnnouncementDetails obj_NewsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_NewsDetails");
                sqlCon.AddInParameter(DBCmnd, "@admin", DbType.String, obj_NewsDetails.Admin);
                sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_NewsDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_NewsDetails.Topic);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
        #region Get_NewsDetails_ByID
        public DataSet Get_NewsDetails_ByID(NewsAnnouncementDetails obj_NewsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_NewsDetails_ByID");
                sqlCon.AddInParameter(DBCmnd, "@N_ID", DbType.Int32, obj_NewsDetails.N_ID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Feb 07.2012
        /// This method inserts the record in tbl_AddFavouriteNews with the selected Title[N_ID]
        /// </summary>
        /// <param name="obj_NsDtls"></param>
        #region Insert_AddFavouriteNews
        public int Insert_AddFavouriteNews(NewsAnnouncementDetails obj_NSDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Insert_AddFavouriteNews");
                sqlCon.AddInParameter(DBCmnd, "@N_ID", SqlDbType.Int, obj_NSDetails.N_ID);
                sqlCon.AddInParameter(DBCmnd, "@Created_On", SqlDbType.DateTime, obj_NSDetails.Created_On);
                sqlCon.AddInParameter(DBCmnd, "@Created_By", SqlDbType.VarChar, obj_NSDetails.Created_By);
                return sqlCon.ExecuteNonQuery(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Feb 07.2012
        /// </summary>
        /// <param name="obj_NsDtls"></param>
        /// <returns></returns>
        #region Getting MyNewsFavouritesdetials
        public DataSet Get_MyNewsFavouritesDetails(NewsAnnouncementDetails obj_NSDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_MyNewsFavouritesDetails");
                sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_NSDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_NSDetails.Topic);
                sqlCon.AddInParameter(DBCmnd, "@CreatedBy", DbType.String, obj_NSDetails.Created_By);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        /// <summary>
        ///FEB 07.2012
        /// for webservice usuage
        /// </summary>
        /// <param name="obj_NsDtls"></param>
        /// <returns></returns>
        public DataTable GetNewsTitles(NewsAnnouncementDetails obj_NSDetails)
        {
            DataSet ds;
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Getting_NewsDetais_ByTitleSearch");
                sqlCon.AddInParameter(DBCmnd, "@Company", SqlDbType.VarChar, obj_NSDetails.Title);
                ds = sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception err)
            {
                throw err;
            }

            return ds.Tables[0];

        }



        #region Update_NewsDetails
        public int Update_NewsDetails(NewsAnnouncementDetails obj_NSDetails)
        {



            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Sp_update_NewsDetails");

                sqlCon.AddInParameter(DBCmnd, "@type", SqlDbType.NVarChar, obj_NSDetails.Type);
                sqlCon.AddInParameter(DBCmnd, "@NewsTitle", SqlDbType.NVarChar, obj_NSDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@NewsDescription", SqlDbType.NVarChar, obj_NSDetails.Description);

                sqlCon.AddInParameter(DBCmnd, "@Author_Name", SqlDbType.NVarChar, obj_NSDetails.Author);
                sqlCon.AddInParameter(DBCmnd, "@PublishedOn", SqlDbType.DateTime, obj_NSDetails.Published_On);
                sqlCon.AddInParameter(DBCmnd, "@CreatedOn", SqlDbType.DateTime, obj_NSDetails.Created_On);

                sqlCon.AddInParameter(DBCmnd, "@CreatedBy", SqlDbType.NVarChar, obj_NSDetails.Created_By);
                sqlCon.AddInParameter(DBCmnd, "@UpdatedOn", SqlDbType.DateTime, obj_NSDetails.Updated_On);
                sqlCon.AddInParameter(DBCmnd, "@UpdatedBy", SqlDbType.NVarChar, obj_NSDetails.Updated_By);

                sqlCon.AddInParameter(DBCmnd, "@Rating", SqlDbType.Int, obj_NSDetails.Rating);
                sqlCon.AddInParameter(DBCmnd, "@News_Details", SqlDbType.NVarChar, obj_NSDetails.NewsDetails);
                sqlCon.AddInParameter(DBCmnd, "@N_ID", SqlDbType.Int, obj_NSDetails.N_ID);

                sqlCon.AddOutParameter(DBCmnd, "@return", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DBCmnd);
                return int.Parse(DBCmnd.Parameters["@return"].Value.ToString());


                // return sqlCon.ExecuteNonQuery(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Insert_CategoryDetails


        public int Insert_CategoryDetails(NewsAnnouncementDetails obj_NSDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Insert_CategoryDetails");
                sqlCon.AddInParameter(DbCom, "@N_ID", DbType.Int32, obj_NSDetails.N_ID);
                sqlCon.AddInParameter(DbCom, "@TopicID", DbType.Int32, obj_NSDetails.tagno);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete_CategoryDetails


        public int Delete_CategoryDetails(NewsAnnouncementDetails obj_NSDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Delete_CategoryDetails");
                sqlCon.AddInParameter(DbCom, "@N_ID", DbType.Int32, obj_NSDetails.N_ID);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Getting CourseDetails
        /// <summary>
        /// JAN 10.2012
        /// </summary>
        /// <param name="obj_CDetails"></param>
        /// <returns></returns>
        public DataSet Get_CourseDetails(CourseDetails obj_CDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_CourseDetails");
                sqlCon.AddInParameter(DBCmnd, "@admin", DbType.String, obj_CDetails.Admin);
                sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_CDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_CDetails.Topic);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion










        /// <summary>
        /// JAN 03.2012
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region Getting MyFavouritesdetials
        public DataSet Get_MyFavouritesDetails(ResourceLibraryDetails obj_RLDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_MyFavouritesDetails");
                sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_RLDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_RLDetails.Topic);

                //sqlCon.AddInParameter(DBCmnd, "@Sort_On", DbType.String, obj_RLDetails.SortOn);
                //sqlCon.AddInParameter(DBCmnd, "@Sort_Direction", DbType.String, obj_RLDetails.SortDirection);
                sqlCon.AddInParameter(DBCmnd, "@CreatedBy", DbType.String, obj_RLDetails.Created_By);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion



        /// <summary>
        /// JAN 06.2012
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region GetSelTags
        public DataSet GetSelTags(ResourceLibraryDetails obj_RLDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("GetSelTags");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", DbType.String, obj_RLDetails.RL_ID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 13/01/2012
        /// To get CourseId CourseName from two tables like tbl_CourseDetailsTopics and tbl_CourseMaster based on CID 
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region CDetails_GetSelTags
        public DataSet CDetails_GetSelTags(CourseDetails obj_CDetais)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Usp_CDetails_GetSelTags");
                sqlCon.AddInParameter(DBCmnd, "@CID", DbType.Int32, obj_CDetais.CID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        /// <summary>
        /// DEC 29.2011
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region Get_ResourceLibraryDetails_ByID
        public DataSet Get_ResourceLibraryDetails_ByID(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_ResourceLibraryDetails_ByID");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", DbType.Int32, obj_RLDetails.RL_ID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// DEC 27.2011
        /// </summary>
        /// <returns></returns>
        #region Insert_tbl_ResourceLibrary
        public int Insert_tbl_ResourceLibrary(ResourceLibraryDetails obj_RLDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Insert_tbl_ResourceLibrary");
                sqlCon.AddInParameter(DBCmnd, "@Title", SqlDbType.VarChar, obj_RLDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@Description", SqlDbType.VarChar, obj_RLDetails.Description);
                sqlCon.AddInParameter(DBCmnd, "@Author", SqlDbType.VarChar, obj_RLDetails.Author);
                sqlCon.AddInParameter(DBCmnd, "@Created_On", SqlDbType.VarChar, obj_RLDetails.Created_On);
                sqlCon.AddInParameter(DBCmnd, "@Created_By", SqlDbType.VarChar, obj_RLDetails.Created_By);
                sqlCon.AddInParameter(DBCmnd, "@Published_On", SqlDbType.VarChar, obj_RLDetails.Published_On);
                sqlCon.AddInParameter(DBCmnd, "@Upload_File_Path", SqlDbType.VarChar, obj_RLDetails.Upload_File_Path);
                sqlCon.AddInParameter(DBCmnd, "@Rating", SqlDbType.Int, obj_RLDetails.Rating);
                sqlCon.AddOutParameter(DBCmnd, "@output", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DBCmnd);
                return int.Parse(DBCmnd.Parameters["@output"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion



        /// <summary>
        /// JAN 03.2012
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region Update_ResouceLibraryDetails
        public int Update_ResouceLibraryDetails(ResourceLibraryDetails obj_RLDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Update_ResouceLibraryDetails");
                sqlCon.AddInParameter(DBCmnd, "@Title", SqlDbType.VarChar, obj_RLDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@Description", SqlDbType.VarChar, obj_RLDetails.Description);
                sqlCon.AddInParameter(DBCmnd, "@Author", SqlDbType.VarChar, obj_RLDetails.Author);
                sqlCon.AddInParameter(DBCmnd, "@Updated_On", SqlDbType.DateTime, obj_RLDetails.Updated_On);
                sqlCon.AddInParameter(DBCmnd, "@Updated_By", SqlDbType.VarChar, obj_RLDetails.Updated_By);
                sqlCon.AddInParameter(DBCmnd, "@Upload_File_Path", SqlDbType.VarChar, obj_RLDetails.Upload_File_Path);



                sqlCon.AddInParameter(DBCmnd, "@Rating", SqlDbType.Int, obj_RLDetails.Rating);
                sqlCon.AddInParameter(DBCmnd, "@Published_On", SqlDbType.DateTime, obj_RLDetails.Published_On);
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", SqlDbType.Int, obj_RLDetails.RL_ID);
                return sqlCon.ExecuteNonQuery(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        /// <summary>
        /// DEC 22.2011
        /// This method inserts the record in tbl_AddFavourite with the selected Title[RL_ID]
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        #region Insert_AddFavourite
        public int Insert_AddFavourite(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Insert_AddFavourite");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", SqlDbType.Int, obj_RLDetails.RL_ID);
                sqlCon.AddInParameter(DBCmnd, "@Created_On", SqlDbType.DateTime, obj_RLDetails.Created_On);
                sqlCon.AddInParameter(DBCmnd, "@Created_By", SqlDbType.VarChar, obj_RLDetails.Created_By);
                return sqlCon.ExecuteNonQuery(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        /// <summary>
        /// DEC 22.2011
        /// This method passes the parameter Title from Admin_ResourceLibrary page
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region Get_ResourceLibraryDetails_ByTitle
        public DataSet Get_ResourceLibraryDetails_ByTitle(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Getting_ResLibraryDetais_ByTitle");
                sqlCon.AddInParameter(DBCmnd, "@Title", SqlDbType.VarChar, obj_RLDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@TagID", SqlDbType.Int, obj_RLDetails.TagID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// JAN 05 2012
        /// </summary>
        /// <returns></returns>
        public DataSet GetTagValues()
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("GetTagValues");
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// JAN 10.2012 3.11pm
        ///  This SP gets the CourseName column values from tbl_CourseMaster
        /// </summary>
        /// <returns></returns>
        public DataSet CDetails_GetTagValues()
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Usp_CDetails_GetTagValues");
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// DEC 22.2011
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region Delete_Record_ResourceLibrary
        public int Delete_Record_ResourceLibrary(ResourceLibraryDetails obj_RLDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Delete_Record_ResourceLibrary");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", SqlDbType.Int, obj_RLDetails.RL_ID);
                int result = sqlCon.ExecuteNonQuery(DBCmnd);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        /// <summary>
        /// 17/01/2012
        /// </summary>
        /// <param name="RL_ID"></param>
        /// <returns></returns>
        #region Delete_Record_ResourceLibrary_By_RLID
        public int Delete_Record_ResourceLibrary_By_RLID(string RL_ID)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_DeleteRecord_Resourcelibrary_By_RLID");
                sqlCon.AddInParameter(DBCom, "@RL_ID", DbType.String, RL_ID);
                int i = sqlCon.ExecuteNonQuery(DBCom);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        /// <summary>7777
        /// JAN 10.2012
        ///  Deletes the record temporarily   
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        #region Delete_Record_CourseDetails
        public int Delete_Record_CourseDetails(string CID)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_Delete_Record_CourseDetails");
                sqlCon.AddInParameter(DBCom, "@CID", DbType.String, CID);
                int i = sqlCon.ExecuteNonQuery(DBCom);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion


        /// <summary>
        /// DEC 29.2011
        /// for webservice usuage
        /// </summary>
        /// <param name="obj_RLDetails"></param>
        /// <returns></returns>
        public DataTable GetClients(ResourceLibraryDetails obj_RLDetails)
        {
            DataSet ds;
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Getting_ResLibraryDetais_ByTitleSearch");
                sqlCon.AddInParameter(DBCmnd, "@Company", SqlDbType.VarChar, obj_RLDetails.Title);
                ds = sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception err)
            {
                throw err;
            }

            return ds.Tables[0];

        }


        /// <summary>
        /// 05/01/2012
        /// update date: 19/01/2012 by Mahesh
        /// Insert all BannerDetails in tbl_Banner table
        /// </summary>
        /// <param name="objBanner"></param>
        /// <returns></returns>
        public int InsertBannerDetails(BannerDetails objBanner)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_InsertBannerDetails");
                sqlCon.AddInParameter(DbCom, "@BannerId", DbType.Int32, objBanner.BannerId);
                sqlCon.AddInParameter(DbCom, "@BannerName1", DbType.String, objBanner.TopBanner);
                sqlCon.AddInParameter(DbCom, "@BannerURL1", DbType.String, objBanner.TopBannerUrl);
                sqlCon.AddInParameter(DbCom, "@BannerName2", DbType.String, objBanner.Banner2);
                sqlCon.AddInParameter(DbCom, "@BannerURL2", DbType.String, objBanner.BannerUrl2);
                sqlCon.AddInParameter(DbCom, "@BannerName3", DbType.String, objBanner.Banner3);
                sqlCon.AddInParameter(DbCom, "@BannerURL3", DbType.String, objBanner.BannerUrl3);
                sqlCon.AddInParameter(DbCom, "@BannerName4", DbType.String, objBanner.Banner4);
                sqlCon.AddInParameter(DbCom, "@BannerURL4", DbType.String, objBanner.BannerUrl4);
                sqlCon.AddInParameter(DbCom, "@BannerName5", DbType.String, objBanner.Banner5);
                sqlCon.AddInParameter(DbCom, "@BannerURL5", DbType.String, objBanner.BannerUrl5);
                sqlCon.AddInParameter(DbCom, "@FooterBanner1", DbType.String, objBanner.FooterBanner1);
                sqlCon.AddInParameter(DbCom, "@FooterBannerURL1", DbType.String, objBanner.FooterBannerUrl1);
                sqlCon.AddInParameter(DbCom, "@FooterBanner2", DbType.String, objBanner.FooterBanner2);
                sqlCon.AddInParameter(DbCom, "@FooterBannerURL2", DbType.String, objBanner.FooterBannerUrl2);
                sqlCon.AddInParameter(DbCom, "@FooterBanner3", DbType.String, objBanner.FooterBanner3);
                sqlCon.AddInParameter(DbCom, "@FooterBannerURL3", DbType.String, objBanner.FooterBannerUrl3);
                sqlCon.AddInParameter(DbCom, "@FooterBanner4", DbType.String, objBanner.FooterBanner4);
                sqlCon.AddInParameter(DbCom, "@FooterBannerURL4", DbType.String, objBanner.FooterBannerUrl4);
                sqlCon.AddInParameter(DbCom, "@RHSBanner", DbType.String, objBanner.Banner7);
                sqlCon.AddInParameter(DbCom, "@RHSBannerURL7", DbType.String, objBanner.RHSBannerUrl7);
                sqlCon.AddInParameter(DbCom, "@ADBANNER1", DbType.String, objBanner.AdBanner1);
                sqlCon.AddInParameter(DbCom, "@ADBANNERURL1", DbType.String, objBanner.AdBannerUrl1);
                sqlCon.AddInParameter(DbCom, "@ADBANNER2", DbType.String, objBanner.AdBanner2);
                sqlCon.AddInParameter(DbCom, "@ADBANNERURL2", DbType.String, objBanner.AdBannerUrl2);
                sqlCon.AddInParameter(DbCom, "@ADBANNER3", DbType.String, objBanner.AdBanner3);
                sqlCon.AddInParameter(DbCom, "@ADBANNERURL3", DbType.String, objBanner.AdBannerUrl3);
                sqlCon.AddInParameter(DbCom, "@ADBANNER4", DbType.String, objBanner.AdBanner4);
                sqlCon.AddInParameter(DbCom, "@ADBANNERURL4", DbType.String, objBanner.AdBannerUrl4);
                sqlCon.AddInParameter(DbCom, "@Operation", DbType.String, objBanner.Operation);
                sqlCon.AddInParameter(DbCom, "@CreatedBy", DbType.String, objBanner.Created_By);
                sqlCon.AddInParameter(DbCom, "@UpdatedBy", DbType.String, objBanner.Updated_By);
                sqlCon.AddInParameter(DbCom, "@Culture", DbType.String, objBanner.Culture);
                sqlCon.AddOutParameter(DbCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 05/01/2012
        /// Get all BannerDetails in tbl_Banner table
        /// </summary>
        /// <param name="objBanner"></param>
        /// <returns></returns>
        public DataSet GetBannerDetails()
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_Get_BannerDetails");
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 05/01/2012
        /// Get all BannerDetails in tbl_Banner table
        /// </summary>
        /// <param name="objBanner"></param>
        /// <returns></returns>
        public DataSet GetBannerDetails_Culture(BannerDetails objBanner)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("[Usp_Get_BannerDetails_Culture]");
                sqlCon.AddInParameter(DbCom, "@Culture", DbType.String, objBanner.Culture);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        ///18/01/2012
        /// To Delete Banner image in tbl_Banner table 
        /// </summary>
        /// <param name="Banner Number"></param>
        /// <returns></returns>
        public int DelteBannerImage(int bannerNumber)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_Delte_BannerImage");
                sqlCon.AddInParameter(DbCom, "@BANNERNUMBER", DbType.Int32, bannerNumber);
                sqlCon.AddOutParameter(DbCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #region Company Information
        public DataTable bindCompanyInformationByUserID(string UserID)
        {
            DataTable dt = new DataTable();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_bindCompanyInformationByUserID");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                dt = sqlCon.ExecuteDataSet(DBCom).Tables[0];
                return dt;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int insertCompanyInformation(string CompanyName, string Currency, string FinYearEndDate, string IsFinancialStmtAvailable, string UserID)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_InsertCompanyInformation");
                sqlCon.AddInParameter(DBCom, "@CompanyName", DbType.String, CompanyName);
                sqlCon.AddInParameter(DBCom, "@Currency", DbType.String, Currency);
                sqlCon.AddInParameter(DBCom, "@FinYearEndDate", DbType.DateTime, FinYearEndDate);
                sqlCon.AddInParameter(DBCom, "@IsFinancialStmtAvailable", DbType.String, IsFinancialStmtAvailable);
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                sqlCon.AddOutParameter(DBCom, "@OutPutValue", DbType.Int32, 0);
                sqlCon.ExecuteNonQuery(DBCom);

                int intOutPut;
                return intOutPut = int.Parse(DBCom.Parameters["@OutPutValue"].Value.ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int updateCompanyInformation(string CompanyId, string CompanyName, string Currency, string FinYearEndDate, string IsFinancialStmtAvailable, string UserID, int DeleteFlag)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_updateCompanyInformation");
                sqlCon.AddInParameter(DBCom, "@CompanyId", DbType.Int32, CompanyId);
                sqlCon.AddInParameter(DBCom, "@CompanyName", DbType.String, CompanyName);
                sqlCon.AddInParameter(DBCom, "@Currency", DbType.String, Currency);
                sqlCon.AddInParameter(DBCom, "@FinYearEndDate", DbType.String, FinYearEndDate);
                sqlCon.AddInParameter(DBCom, "@IsFinancialStmtAvailable", DbType.String, IsFinancialStmtAvailable);
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                sqlCon.AddInParameter(DBCom, "@DeleteFlag", DbType.Int32, DeleteFlag);
                sqlCon.AddOutParameter(DBCom, "@OutPutValue", DbType.Int32, 0);
                sqlCon.ExecuteNonQuery(DBCom);

                int intOutPut;
                return intOutPut = int.Parse(DBCom.Parameters["@OutPutValue"].Value.ToString());
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
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_UPDATE_COMPANY_FINDETAILS");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinancialModelingMgmt.UserID);
                sqlCon.AddInParameter(DBCom, "@ROUNDDOLLAR", DbType.Int32, objFinancialModelingMgmt.RoundDollar);
                sqlCon.AddOutParameter(DBCom, "@RETURN", DbType.Int32, 0);
                sqlCon.ExecuteNonQuery(DBCom);

                int intOutPut;
                return intOutPut = int.Parse(DBCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable Get_CompanyFinDetails(string UserID)
        {
            DataTable dt = new DataTable();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GET_COMPANY_FINDETAILS");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                dt = sqlCon.ExecuteDataSet(DBCom).Tables[0];
                return dt;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int updateInteractiveData(string P_P_RevenueGrowth, string P_RevenueGrowth, string C_RevenueGrowth, string P_P_TaxRate,
            string P_TaxRate, string C_TaxRate, string DebtRepaymentPeriod, string EffectiveInterestOnDebt, string UserID)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_updateInteractiveData");
                sqlCon.AddInParameter(DBCom, "@P_P_RevenueGrowth", DbType.Decimal, P_P_RevenueGrowth);
                sqlCon.AddInParameter(DBCom, "@P_RevenueGrowth", DbType.Decimal, P_RevenueGrowth);
                sqlCon.AddInParameter(DBCom, "@C_RevenueGrowth", DbType.Decimal, C_RevenueGrowth);
                sqlCon.AddInParameter(DBCom, "@P_P_TaxRate", DbType.Decimal, P_P_TaxRate);
                sqlCon.AddInParameter(DBCom, "@P_TaxRate", DbType.Decimal, P_TaxRate);
                sqlCon.AddInParameter(DBCom, "@C_TaxRate", DbType.Decimal, C_TaxRate);
                sqlCon.AddInParameter(DBCom, "@DebtRepaymentPeriod", DbType.Decimal, DebtRepaymentPeriod);
                sqlCon.AddInParameter(DBCom, "@EffectiveInterestOnDebt", DbType.Decimal, EffectiveInterestOnDebt);
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                sqlCon.AddOutParameter(DBCom, "@OutPutValue", DbType.Int32, 0);
                sqlCon.ExecuteNonQuery(DBCom);

                int intOutPut;
                return intOutPut = int.Parse(DBCom.Parameters["@OutPutValue"].Value.ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int BreakEvenPointSensitivity(string UserID, string GpMargin)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_BreakEvenPointSensitivity");
                sqlCon.AddInParameter(DBCom, "@GpMargin", DbType.Decimal, GpMargin);
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                sqlCon.AddOutParameter(DBCom, "@OutPutValue", DbType.Int32, 0);
                sqlCon.ExecuteNonQuery(DBCom);

                int intOutPut;
                return intOutPut = int.Parse(DBCom.Parameters["@OutPutValue"].Value.ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public DataSet getStatementByType(string UserID, string FsMappingType,string Culture)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_getStatementByType");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                sqlCon.AddInParameter(DBCom, "@FsMappingType", DbType.String, FsMappingType);
                sqlCon.AddInParameter(DBCom, "@Culture", DbType.String, Culture);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public int UpdateStatements(DataTable dtStatement, string stmtType, string UserID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_UpdateStatements");
                sqlCon.AddInParameter(DbCom, "@tblStatement", SqlDbType.Structured, dtStatement);
                sqlCon.AddInParameter(DbCom, "@StmtType", DbType.String, stmtType);
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                sqlCon.AddOutParameter(DbCom, "@OutPutValue", DbType.Int32, 0);
                sqlCon.ExecuteNonQuery(DbCom);
                int intOutPut;
                return intOutPut = int.Parse(DbCom.Parameters["@OutPutValue"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateKeySensitivityReport(string UserId, string Revenue, string GpMargin, string OpExp, string Inv, string Receivables, string Payables)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_UpdateKeySensitivityReport");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserId);
                sqlCon.AddInParameter(DbCom, "@C_Percent_Revenue", DbType.Double, Revenue);
                sqlCon.AddInParameter(DbCom, "@C_Percent_GpMargin", DbType.Double, GpMargin);
                sqlCon.AddInParameter(DbCom, "@C_Percent_OperatingExpenses", DbType.Double, OpExp);
                sqlCon.AddInParameter(DbCom, "@C_Percent_InventoryDays", DbType.Double, Inv);
                sqlCon.AddInParameter(DbCom, "@C_Percent_TradeReceivablesDays", DbType.Double, Receivables);
                sqlCon.AddInParameter(DbCom, "@C_Percent_TradePayableDays", DbType.Double, Payables);
                sqlCon.AddOutParameter(DbCom, "@OutPutValue", DbType.Int32, 0);
                sqlCon.ExecuteNonQuery(DbCom);
                int intOutPut;
                return intOutPut = int.Parse(DbCom.Parameters["@OutPutValue"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     

        public DataSet getKeySensitivityReportForFinTable(string UserID)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_getKeySensitivityReportForFinTable");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet getKeySensitivityDataForGraph(string UserID)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_getKeySensitivityDataForGraph");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet getBreakEvenPoints(string UserID)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_getBreakEvenPoints");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet getInteractiveData(string UserID)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_getInteractiveData");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        #endregion

        #region FAQ Mgmt
        public DataSet getDataForCategory()
        {
            DataSet dsHomeFunc = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_getDataForCategory");
                dsHomeFunc = sqlCon.ExecuteDataSet(DBCom);
                return dsHomeFunc;
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        public int insetFaq(string CategoryId, string FaqQuestion, string FaqAnswer, string CreatedBy)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_insetFaq");
                sqlCon.AddInParameter(DBCom, "@CategoryId", DbType.Guid, new Guid(CategoryId));
                sqlCon.AddInParameter(DBCom, "@FaqQuestion", DbType.String, FaqQuestion);
                sqlCon.AddInParameter(DBCom, "@FaqAnswer", DbType.String, FaqAnswer);
                sqlCon.AddInParameter(DBCom, "@CreatedBy", DbType.String, CreatedBy);
                int i = sqlCon.ExecuteNonQuery(DBCom);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getAllFaq(string CategoryId, string Sort_On, string Sort_Direction)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_getAllFaq");
                sqlCon.AddInParameter(DBCom, "@CategoryId", DbType.String, CategoryId);
                sqlCon.AddInParameter(DBCom, "@SortOn", DbType.String, Sort_On);
                sqlCon.AddInParameter(DBCom, "@SortDirection", DbType.String, Sort_Direction);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        public DataSet getFaqById(string FaqId)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_getFaqById");
                sqlCon.AddInParameter(DBCom, "@FaqId", DbType.String, FaqId);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        public int deleteFaq(string FaqIds)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("sp_deleteFaq");
                sqlCon.AddInParameter(DBCom, "@FaqId", DbType.String, FaqIds);
                int i = sqlCon.ExecuteNonQuery(DBCom);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateFaq(string CategoryId, string FaqQuestion, string FaqAnswer, string FaqId, string UpdatedBy)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_updateFaq");
                sqlCon.AddInParameter(DBCom, "@CategoryId", DbType.Guid, new Guid(CategoryId));
                sqlCon.AddInParameter(DBCom, "@FaqQuestion", DbType.String, FaqQuestion);
                sqlCon.AddInParameter(DBCom, "@FaqAnswer", DbType.String, FaqAnswer);
                sqlCon.AddInParameter(DBCom, "@FaqId", DbType.String, FaqId);
                sqlCon.AddInParameter(DBCom, "@UpdatedBy", DbType.String, UpdatedBy);
                int i = sqlCon.ExecuteNonQuery(DBCom);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // no need
        public DataSet getDataForFaq()
        {
            DataSet dsHomeFunc = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("getDetailsforFAQ");
                dsHomeFunc = sqlCon.ExecuteDataSet(DBCom);
                return dsHomeFunc;
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        // no need
        public DataSet getcategory()
        {
            DataSet dsHomeFunc = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_Getcategory");
                dsHomeFunc = sqlCon.ExecuteDataSet(DBCom);
                return dsHomeFunc;
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        // no need
        public DataSet getcategoryForFaq()
        {
            DataSet dsHomeFunc = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_getcategoryForFaq");
                dsHomeFunc = sqlCon.ExecuteDataSet(DBCom);
                return dsHomeFunc;
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        #endregion

        #region MenuChain
        // no need
        public DataSet getMenuChainWithSubMenu(string sSubMenu)
        {

            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_getMenuDetails");
                sqlCon.AddInParameter(DBCom, "@pSubMenuID", DbType.String, sSubMenu);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }



        }
        // no need
        public DataSet getMenuChainWithMainMenu(string sMainMenu)
        {

            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_getMenuDetails");
                sqlCon.AddInParameter(DBCom, "@pParentMenuID", DbType.String, sMainMenu);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }



        }
        #endregion



        #region Course Registration Page Methods

        /// <summary>
        /// Method to save User details in [tbl_CourseRegistration]
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int InsertCourseRegistration(CourseRegistration obj_CourseRegs)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_InsertCourseRegistrationDetails");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(obj_CourseRegs.UserID));
                sqlCon.AddInParameter(DbCom, "@Name", DbType.String, obj_CourseRegs.Name);
                sqlCon.AddInParameter(DbCom, "@NRIC_ID_Number", DbType.String, obj_CourseRegs.NRIC_ID_Number);
                sqlCon.AddInParameter(DbCom, "@Contact_Number", DbType.String, obj_CourseRegs.Contact_Number);
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, obj_CourseRegs.EmailID);
                sqlCon.AddInParameter(DbCom, "@CreatedOn", DbType.DateTime, obj_CourseRegs.CreatedOn);
                sqlCon.AddInParameter(DbCom, "@ActivationKey", DbType.Guid, new Guid(obj_CourseRegs.ActivationKey));
                sqlCon.AddInParameter(DbCom, "@CID", DbType.Int32, obj_CourseRegs.CID);
                sqlCon.AddOutParameter(DbCom, "@output", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@output"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to get Course Registration details from [tbl_CourseRegistration] by Activation Key
        /// </summary>
        /// <param name="ActivationKey"></param>
        /// <returns></returns>
        public DataSet GetCourseRegistrationDetails(string UserID)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetCourseRegistrationDetails");
                if (!string.IsNullOrEmpty(UserID))
                    sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(UserID));
                return sqlCon.ExecuteDataSet(DbCom);
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
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_CourseDetailsByID");
                sqlCon.AddInParameter(DBCmnd, "@CID", DbType.Guid, new Guid(CID));
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// JAN 20.2012
        /// </summary>
        /// <param name="obj_CourseRegs"></param>
        /// <returns></returns>
        public int getCid(string CID)
        {
            DbCommand DBCmnd = sqlCon.GetStoredProcCommand("getCid");
            sqlCon.AddInParameter(DBCmnd, "@ccid", DbType.String, CID);
            sqlCon.AddOutParameter(DBCmnd, "@output", DbType.Int32, 1);
            sqlCon.ExecuteNonQuery(DBCmnd);

            return int.Parse(DBCmnd.Parameters["@output"].Value.ToString());
            //return sqlCon.ExecuteDataSet(DBCmnd);
        }

        #endregion



        /// <summary>
        /// 23/01/2012
        /// Insert error details in tbl_CustomErrorLog
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int InsertErrorDetails(UserMgmt userObj)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_INSERT_ERRORLOG");
                sqlCon.AddInParameter(DbCom, "@ERRORSOURCE", DbType.String, userObj.Error_Source);
                sqlCon.AddInParameter(DbCom, "@ERRORDESCRIPTION", DbType.String, userObj.Error_Description);
                sqlCon.AddOutParameter(DbCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to update the user details in [tbl_Registration] by User ID
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int UpdateUserDetailsWithoutPwd(RegistrationDTO objDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_UpdateUserDetailsWithoutPwd");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(objDTO.UserID));
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, objDTO.EmailID);
                sqlCon.AddInParameter(DbCom, "@Title", DbType.String, objDTO.Title);
                sqlCon.AddInParameter(DbCom, "@Name", DbType.String, objDTO.Name);
                sqlCon.AddInParameter(DbCom, "@CompanyNm", DbType.String, objDTO.CompanyNm);
                sqlCon.AddInParameter(DbCom, "@BussStartedMonth", DbType.Int32, objDTO.BussStartedMonth);
                sqlCon.AddInParameter(DbCom, "@BussStartedYear", DbType.Int32, objDTO.BussStartedYear);
                sqlCon.AddInParameter(DbCom, "@NoofEmployees", DbType.Int64, objDTO.NoofEmployees);
                sqlCon.AddInParameter(DbCom, "@TotalCapital", DbType.Double, objDTO.TotalCapital);
                sqlCon.AddInParameter(DbCom, "@AnnualRevenue", DbType.Double, objDTO.AnnualRevenue);
                sqlCon.AddInParameter(DbCom, "@BusinessID", DbType.Int32, objDTO.BusinessID);
                sqlCon.AddInParameter(DbCom, "@IndustryID", DbType.Int32, objDTO.IndustryID);
                sqlCon.AddOutParameter(DbCom, "@output", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@output"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Method to get User Details, by passing the User ID.
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetUserDetailsbyUserID(string UserID)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetUserDetailsbyUserID");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(UserID));
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// JAN 27.2012
        /// </summary>
        /// <param name="obj_CourseRegs"></param>
        /// <returns></returns>
        public DataSet Get_CourseRegs_DetailsById(int CID)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_CourseRegs_DetailsById");
                sqlCon.AddInParameter(DBCmnd, "@CID", DbType.Int32, CID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Delete_Record_CourseRegsDetails(string UserID)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_Delete_Record_CourseRegsDetails");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);

                int i = sqlCon.ExecuteNonQuery(DBCom);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        /// <summary>
        /// JAN 30.2012
        /// </summary>
        /// <param name="obj_CourseRegs"></param>
        /// <returns></returns>
        public DataSet Get_CourseRegs_DetailsByAll(string strTitle)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_CourseRegs_DetailsByAll");
                sqlCon.AddInParameter(DBCmnd, "@Title", DbType.String, strTitle);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        #region Forgot password page methods

        /// <summary>
        /// Method to get User Status, by passing theEmail ID.
        /// </summary>
        /// <param name="EmailID"></param>
        /// <returns></returns>
        public DataSet GetUserStatus(string EmailID)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetUserStatus");
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, EmailID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 02/02/2012
        /// Insert into tbl_forgotpassword 
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int InsertForgotPWdDetails(ForgotPassword obj_FGPwd)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_INSERT_FORGOTPWDDETALS");
                sqlCon.AddInParameter(DbCom, "@ActivationID", DbType.Guid, new Guid(obj_FGPwd.ActivationID));
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(obj_FGPwd.UserID));
                sqlCon.AddInParameter(DbCom, "@ExpiryDate", DbType.Date, obj_FGPwd.ExpiryDate);
                int i = sqlCon.ExecuteNonQuery(DbCom);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to get forgot password details, by passing theEmail ID.
        /// </summary>
        /// <param name="obj_FGPwd"></param>
        /// <returns></returns>
        public DataSet GetForgotPwdDtlsbyAcctKey(ForgotPassword obj_FGPwd)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("GET_FORGOTPWDDETALS_BYACCTKEY");
                sqlCon.AddInParameter(DbCom, "@ActivationID", DbType.Guid, new Guid(obj_FGPwd.ActivationID));
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to update the user password in [tbl_Registration] by User ID
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        public int UpdateUserPwdbyUserID(ForgotPassword obj_FGPwd)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_UpdateUserPwdbyUserID");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.Guid, new Guid(obj_FGPwd.UserID));
                sqlCon.AddInParameter(DbCom, "@Password", DbType.String, obj_FGPwd.Password);
                sqlCon.AddOutParameter(DbCom, "@output", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@output"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update_ResourcelibDetails
        //new ver for insert,update,delete resource lib ( 8 feb 2012)
        public int Update_ResourceLibDetails(ResourceLibDetails obj_RSDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Sp_update_ResourceLibDetails");

                sqlCon.AddInParameter(DBCmnd, "@type", SqlDbType.NVarChar, obj_RSDetails.Type);
                sqlCon.AddInParameter(DBCmnd, "@Title", SqlDbType.VarChar, obj_RSDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@C_Title", SqlDbType.NVarChar, obj_RSDetails.C_Title);
                sqlCon.AddInParameter(DBCmnd, "@Description", SqlDbType.VarChar, obj_RSDetails.Description);
                sqlCon.AddInParameter(DBCmnd, "@C_Description", SqlDbType.NVarChar, obj_RSDetails.C_Description);
                sqlCon.AddInParameter(DBCmnd, "@CreateImage", SqlDbType.NVarChar, obj_RSDetails.ImageType);
                sqlCon.AddInParameter(DBCmnd, "@PublishedOn", SqlDbType.DateTime, obj_RSDetails.Published_On);
                sqlCon.AddInParameter(DBCmnd, "@CreatedOn", SqlDbType.DateTime, obj_RSDetails.Created_On);
                sqlCon.AddInParameter(DBCmnd, "@CreatedBy", SqlDbType.NVarChar, obj_RSDetails.Created_By);
                sqlCon.AddInParameter(DBCmnd, "@UpdatedOn", SqlDbType.DateTime, obj_RSDetails.Updated_On);
                sqlCon.AddInParameter(DBCmnd, "@UpdatedBy", SqlDbType.NVarChar, obj_RSDetails.Updated_By);
                sqlCon.AddInParameter(DBCmnd, "@Level", SqlDbType.VarChar, obj_RSDetails.Level);
                sqlCon.AddInParameter(DBCmnd, "@RL_Details", SqlDbType.NVarChar, obj_RSDetails.NewsDetails);
                sqlCon.AddInParameter(DBCmnd, "@C_RL_Details", SqlDbType.NVarChar, obj_RSDetails.CNewdetails);
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", SqlDbType.Int, obj_RSDetails.RL_ID);

                if (!string.IsNullOrEmpty(obj_RSDetails.RL_FileName))
                    sqlCon.AddInParameter(DBCmnd, "@RL_FileName", SqlDbType.VarChar, obj_RSDetails.RL_FileName);
                else
                    sqlCon.AddInParameter(DBCmnd, "@RL_FileName", SqlDbType.VarChar, DBNull.Value);
                if (!string.IsNullOrEmpty(obj_RSDetails.C_RL_FileName))
                    sqlCon.AddInParameter(DBCmnd, "@C_RL_FileName", SqlDbType.NVarChar, obj_RSDetails.C_RL_FileName);
                else
                    sqlCon.AddInParameter(DBCmnd, "@C_RL_FileName", SqlDbType.NVarChar, DBNull.Value);
                sqlCon.AddInParameter(DBCmnd, "@DocSelection", SqlDbType.VarChar, obj_RSDetails.DocSelection);
                sqlCon.AddInParameter(DBCmnd, "@RL_Status", SqlDbType.Int, obj_RSDetails.RLStatus);
                
                sqlCon.AddOutParameter(DBCmnd, "@return", DbType.Int32, 1);

                sqlCon.ExecuteNonQuery(DBCmnd);
                return int.Parse(DBCmnd.Parameters["@return"].Value.ToString());
                // return sqlCon.ExecuteNonQuery(DBCmnd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Get_ResourceLibDetails
        public DataSet Get_ResourceLibDetails(ResourceLibDetails obj_RsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_ResourceLibDetails");
                sqlCon.AddInParameter(DBCmnd, "@admin", DbType.String, obj_RsDetails.Admin);
                sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_RsDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_RsDetails.Topic);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion


        #region  Get_ResourceLibCategory
        public DataSet Get_ResourceLibCategory(ResourceLibDetails obj_RsDetails)
        {//123
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_ResourceLibCategory");
                sqlCon.AddInParameter(DBCmnd, "@type", DbType.String, obj_RsDetails.Type);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.String, obj_RsDetails.Culture);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region GetSelResourceLibCategory
        public DataSet GetSelResourceLibCategory(ResourceLibDetails obj_RsDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("GetSelResourceLibCategory");
                sqlCon.AddInParameter(DBCmnd, "@type", DbType.String, obj_RsDetails.Type);
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", DbType.String, obj_RsDetails.RL_ID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Get_ResourceLibDetails_ByID
        public DataSet Get_ResourceLibDetails_ByID(ResourceLibDetails obj_NewsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_ResourceLibDetails_ByID");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", DbType.Int32, obj_NewsDetails.RL_ID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Insert_ResourceLibCategoryDetails


        public int Insert_ResourceLibCategoryDetails(ResourceLibDetails obj_RSDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Insert_ResourcelibCategoryDetails");
                sqlCon.AddInParameter(DbCom, "@RL_ID", DbType.Int32, obj_RSDetails.RL_ID);
                sqlCon.AddInParameter(DbCom, "@TopicID", DbType.Int32, obj_RSDetails.tagno);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Delete_ResourceLibCategoryDetails


        public int Delete_ResourceLibCategoryDetails(ResourceLibDetails obj_RSDetails)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Delete_ResourceLibCategoryDetails");
                sqlCon.AddInParameter(DbCom, "@RL_ID", DbType.Int32, obj_RSDetails.RL_ID);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Insert_AddRLFavourite
        public int Insert_AddRLFavourite(ResourceLibDetails obj_RSDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Insert_AddRLFavourite");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", SqlDbType.Int, obj_RSDetails.RL_ID);
                sqlCon.AddInParameter(DBCmnd, "@Created_On", SqlDbType.DateTime, obj_RSDetails.Created_On);
                sqlCon.AddInParameter(DBCmnd, "@Created_By", SqlDbType.VarChar, obj_RSDetails.Created_By);
                sqlCon.AddInParameter(DBCmnd, "@typedownloadoraddfav", SqlDbType.Int, obj_RSDetails.typedownloadoraddfav);
                return sqlCon.ExecuteNonQuery(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Feb 08.2012
        /// </summary>
        /// <param name="obj_RSDetails"></param>
        /// <returns></returns>
        #region Getting MyRlFavouritesdetials
        public DataSet Get_MyRLFavouritesDetails(ResourceLibDetails obj_RSDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_MyRLFavouritesDetails");
                sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_RSDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_RSDetails.Topic);
                sqlCon.AddInParameter(DBCmnd, "@CreatedBy", DbType.String, obj_RSDetails.Created_By);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        /// <summary>
        ///FEB 08.2012
        /// for webservice usuage
        /// </summary>
        /// <param name="obj_RSDetails"></param>
        /// <returns></returns>
        public DataTable GetRLTitles(ResourceLibDetails obj_RSDetails)
        {
            DataSet ds;
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Getting_RLDetais_ByTitleSearch");
                sqlCon.AddInParameter(DBCmnd, "@Company", SqlDbType.VarChar, obj_RSDetails.Title);
                ds = sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception err)
            {
                throw err;
            }

            return ds.Tables[0];

        }


        #region Get_ResourceLibDetails for public module
        public DataSet Get_ResourceLibDetails_Public(ResourceLibDetails obj_RsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_ResourceLibDetails_Public");
                sqlCon.AddInParameter(DBCmnd, "@admin", DbType.String, obj_RsDetails.Admin);
                sqlCon.AddInParameter(DBCmnd, "@title", DbType.String, obj_RsDetails.Title);
                sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_RsDetails.Topic);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Get_ResourceLibDetails_ByID for public module
        public DataSet Get_ResourceLibDetails_ByID_Public(ResourceLibDetails obj_RsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_ResourceLibDetails_ByID_Public");
                sqlCon.AddInParameter(DBCmnd, "@USERID", DbType.String, obj_RsDetails.UserId);
                sqlCon.AddInParameter(DBCmnd, "@ACCESSBY", DbType.String, obj_RsDetails.Author);
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", DbType.Int32, obj_RsDetails.RL_ID);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.Int32, obj_RsDetails.intCulture);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete_AddRLFavourite
        public int Delete_AddRLFavourite(ResourceLibDetails obj_RSDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Delete_AddRLFavourite");
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", SqlDbType.Int, obj_RSDetails.RL_ID);
                sqlCon.AddInParameter(DBCmnd, "@Created_By", SqlDbType.VarChar, obj_RSDetails.Created_By);
                return sqlCon.ExecuteNonQuery(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Get Last Answer from public
        public DataSet GetLastAnswer_PublicPollAnswer(PublicHealthProfiling obj_healthprofile)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("Sp_PollLastAnswer");
                sqlCon.AddInParameter(DbCom, "@UserId", SqlDbType.NVarChar, obj_healthprofile.PostedBy);
                //sqlCon.AddInParameter(DbCom, "@Qid", SqlDbType.Int , obj_healthprofile.Qid);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Getting HealthProfileDetails
        public DataSet Get_HealthProfileDetails(HealthProfiling obj_HProfDetails)
        {

            try
            {
                //  DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_HealthProfileLibraryDetails");

                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_HealthProfileLibraryDetails");
                sqlCon.AddInParameter(DBCmnd, "@type", DbType.String, obj_HProfDetails.Type);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.String, obj_HProfDetails.Culture);
                sqlCon.AddInParameter(DBCmnd, "@qid", DbType.Int32, obj_HProfDetails.Qid);
                sqlCon.AddInParameter(DBCmnd, "@Qdescription", DbType.String, obj_HProfDetails.Qdescription);
                //sqlCon.AddInParameter(DBCmnd, "@category", DbType.String, obj_HProfDetails.CatId);
                sqlCon.AddInParameter(DBCmnd, "@category", DbType.String, obj_HProfDetails.Category);

                //sqlCon.AddInParameter(DBCmnd, "@topic", DbType.String, obj_RLDetails.Topic);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
        #region Get_UniueCategoryFrom HealthProfilingQuestion
        public DataSet Get_QueCategory()
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Sp_QueGetCategory");
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion
        #region Update_HealthProfileDetails
        //new ver for insert,update,delete resource lib ( 8 feb 2012)
        public int Update_HealthProfileDetails(HealthProfiling obj_HProfDetails)
        {



            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Sp_UpdateHealthProfiling");

                sqlCon.AddInParameter(DBCmnd, "@type", SqlDbType.NVarChar, obj_HProfDetails.Type);
                sqlCon.AddInParameter(DBCmnd, "@QId", SqlDbType.Int, obj_HProfDetails.Qid);

                // sqlCon.AddInParameter(DBCmnd, "@QId", DbType.Guid,obj_HProfDetails.Qid);
                // sqlCon.AddInParameter(DBCmnd, "@QId", DbType.Guid, Guid.NewGuid());

                sqlCon.AddInParameter(DBCmnd, "@Qdescription", SqlDbType.NVarChar, obj_HProfDetails.Qdescription);

                sqlCon.AddInParameter(DBCmnd, "@OptA", SqlDbType.NVarChar, obj_HProfDetails.OptA);
                sqlCon.AddInParameter(DBCmnd, "@OptB", SqlDbType.NVarChar, obj_HProfDetails.OptB);
                sqlCon.AddInParameter(DBCmnd, "@OptC", SqlDbType.NVarChar, obj_HProfDetails.OptC);
                sqlCon.AddInParameter(DBCmnd, "@OptD", SqlDbType.NVarChar, obj_HProfDetails.OptD);
                sqlCon.AddInParameter(DBCmnd, "@CreatedBy", SqlDbType.NVarChar, obj_HProfDetails.CreatedBy);
                sqlCon.AddInParameter(DBCmnd, "@Answer", SqlDbType.Int, obj_HProfDetails.Answer);


                //sqlCon.AddInParameter(DBCmnd, "@PublishedOn", SqlDbType.DateTime, obj_HProfDetails.CreatedOn) ;




                return sqlCon.ExecuteNonQuery(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Update_HealthProfileDetails
        //new ver for insert,update,delete resource lib ( 8 feb 2012)
        public int Update_HealthProfileAnswer(PublicHealthProfiling obj_PubHProfDetails)
        {



            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Sp_UpdatePollAnswer");

                sqlCon.AddInParameter(DBCmnd, "@type", SqlDbType.NVarChar, obj_PubHProfDetails.Type);
                sqlCon.AddInParameter(DBCmnd, "@QId", SqlDbType.Int, obj_PubHProfDetails.Qid);
                sqlCon.AddInParameter(DBCmnd, "@Answer", SqlDbType.Int, obj_PubHProfDetails.Answer);
                sqlCon.AddInParameter(DBCmnd, "@PostedBy", SqlDbType.NVarChar, obj_PubHProfDetails.PostedBy);

                //sqlCon.AddInParameter(DBCmnd, "@PublishedOn", SqlDbType.DateTime, obj_HProfDetails.CreatedOn) ;




                return sqlCon.ExecuteNonQuery(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion



        /// <summary>
        ///03/03/2012
        ///To Insert Module Track Records
        /// </summary>
        /// <param name="obj_RSDetails"></param>
        /// <returns></returns>
        public int InsertModuleTrack(UserMgmt objUserMgmt)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_INSERT_MODULETRACK");
                sqlCon.AddInParameter(DBCom, "@USERID", DbType.String, objUserMgmt.UserID);
                sqlCon.AddInParameter(DBCom, "@ACCESSBY", DbType.String, objUserMgmt.AccessBy);
                sqlCon.AddInParameter(DBCom, "@CATEGORYID", DbType.Int32, objUserMgmt.CategoryId);
                sqlCon.AddInParameter(DBCom, "@DESCRIPTION", DbType.String, objUserMgmt.AccessDescription);
                sqlCon.AddInParameter(DBCom, "@PAGEVIEW", DbType.String, objUserMgmt.PageView);
                sqlCon.AddInParameter(DBCom, "@DOWNLOADING", DbType.String, objUserMgmt.Downloading);
                sqlCon.AddInParameter(DBCom, "@INDUSTRYID", DbType.Int32, objUserMgmt.IndustryId);
                sqlCon.AddInParameter(DBCom, "@Culture", DbType.Int32, objUserMgmt.Culture);
                sqlCon.AddOutParameter(DBCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DBCom);
                return int.Parse(DBCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Get_PollQuestionCategory
        //To get all category for questions 

        public DataSet Get_PollQuestionCategory()
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Sp_GetPollQuestionCategory");

                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion
        #region Entering Pollansswer from public
        public void inertTB_PublicPollAnswer(DataTable dtTbDetails, PublicHealthProfiling obj_healthprofile)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Sp_Insert_TB_PublicPollAnswer");
                sqlCon.AddInParameter(DbCom, "@tblDetails", SqlDbType.Structured, dtTbDetails);
                //changes 
                sqlCon.AddInParameter(DbCom, "@PostedBy", SqlDbType.NVarChar, obj_healthprofile.PostedBy);
                sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Get_ReportHealthProfile
        public DataSet Get_ReportHealthProfile(HealthProfiling obj_HProfDetails)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("SP_GetQuestionsRating_Rpt");
                sqlCon.AddInParameter(DBCmnd, "@Qcat", SqlDbType.NVarChar, obj_HProfDetails.Category);
                sqlCon.AddInParameter(DBCmnd, "@startdate", SqlDbType.DateTime, obj_HProfDetails.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@enddate", SqlDbType.DateTime, obj_HProfDetails.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion


        #region FeedBack Procedures

        public DataSet Get_FeedbackQuestions(string Culture)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_FeedbackQuestions");
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.String, Culture);

                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //insert feedback answers
        public int Insert_FeedbackAnswers(FeedBack obj_Feedback)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Insert_FeedbackAnswers");
                sqlCon.AddInParameter(DbCom, "@Q_ID", DbType.Int32, obj_Feedback.QID);
                sqlCon.AddInParameter(DbCom, "@Answer", DbType.Int32, obj_Feedback.Answer);
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, obj_Feedback.UserID);
                sqlCon.AddInParameter(DbCom, "@PostedBy", DbType.String, obj_Feedback.PostedBy);
                sqlCon.AddInParameter(DbCom, "@IndustryId", DbType.Int32, obj_Feedback.IndustryId);
               // sqlCon.AddInParameter(DbCom, "@PostedOn", DbType.Date, obj_Feedback.PostedOn);
                sqlCon.AddInParameter(DbCom, "@PostedID", DbType.String, obj_Feedback.PostedId);

                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert_FeedbackAnswers_General(FeedBack obj_Feedback)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Insert_FeedbackAnswers_General");
                sqlCon.AddInParameter(DbCom, "@Q_ID", DbType.Int32, obj_Feedback.QID);
                sqlCon.AddInParameter(DbCom, "@Answer", DbType.Int32, obj_Feedback.Answer);
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, obj_Feedback.UserID);
                sqlCon.AddInParameter(DbCom, "@PostedBy", DbType.String, obj_Feedback.PostedBy);
                sqlCon.AddInParameter(DbCom, "@IndustryId", DbType.Int32, obj_Feedback.IndustryId);
                // sqlCon.AddInParameter(DbCom, "@PostedOn", DbType.Date, obj_Feedback.PostedOn);
                sqlCon.AddInParameter(DbCom, "@PostedID", DbType.String, obj_Feedback.PostedId);

                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //insert feedback answers
        public int Insert_FeedbackComments(FeedBack obj_Feedback)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Insert_FeedbackComments");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, obj_Feedback.UserID);
                sqlCon.AddInParameter(DbCom, "@Recommend", DbType.String, obj_Feedback.Recommend);
                sqlCon.AddInParameter(DbCom, "@EmailIds", DbType.String, obj_Feedback.EmailIds);
                sqlCon.AddInParameter(DbCom, "@Comments", DbType.String, obj_Feedback.Comments);
                sqlCon.AddInParameter(DbCom, "@BugComments", DbType.String, obj_Feedback.BugsComments);
                sqlCon.AddInParameter(DbCom, "@PostedID", DbType.String, obj_Feedback.PostedId);
                int resvalue = sqlCon.ExecuteNonQuery(DbCom);
                return resvalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_FeedbackAnswers_ByUserId(FeedBack obj_Feedback)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_FeedbackAnswers_ByUserId");
                sqlCon.AddInParameter(DBCmnd, "@UserID", DbType.String, obj_Feedback.UserID);
                sqlCon.AddInParameter(DBCmnd, "@PostedID", DbType.String, obj_Feedback.PostedId);

                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Get_FeedbackAnswers(FeedBack obj_Feedback)
        {

            try
            {
              // DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_FeedbackAnswers");
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("SP_Get_FeedbackAnswers");
                sqlCon.AddInParameter(DBCmnd, "@UserName", DbType.String, obj_Feedback.PostedBy);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", DbType.String, obj_Feedback.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", DbType.String, obj_Feedback.EndDate);

                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion


        /*New Methods*/
        public int UpdateFsMappings(DataTable dtFsMapping, DataTable dtInputValues, string UserID)
        {
            try
            {
                //dude
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_UpdateFsMapping");
                DbCom.CommandTimeout = 3600;
                sqlCon.AddInParameter(DbCom, "@tblFsMapping", SqlDbType.Structured, dtFsMapping);
                sqlCon.AddInParameter(DbCom, "@tblInputValues", SqlDbType.Structured, dtInputValues);
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                sqlCon.AddOutParameter(DbCom, "@OutPutValue", DbType.Int32, 0);
                sqlCon.ExecuteNonQuery(DbCom);
                int intOutPut;
                return intOutPut = int.Parse(DbCom.Parameters["@OutPutValue"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getDataBySection(string UserID, int Section)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_getDataBySection");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                sqlCon.AddInParameter(DBCom, "@Section", DbType.Int32, Section);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /* by shekar*/
        public DataSet getStatementByMapID(string UserID, string FsMappingIds)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_getStatementByMapId");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, UserID);
                sqlCon.AddInParameter(DBCom, "@FsMappingIds", DbType.String, FsMappingIds);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int Update_FinTool_Totals(string UserID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Usp_Fintool_HardCodeRules");
                DbCom.CommandTimeout = 3600;
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                return sqlCon.ExecuteNonQuery(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getTradeCycleDate(string UserID)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GetTradeCycle");
                sqlCon.AddInParameter(DBCom, "@userid", DbType.String, UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public string getInputStatus(string masterInputId, string userid)
        {

            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("getinputStatus");
                sqlCon.AddInParameter(DBCom, "@masterinputid", DbType.String, masterInputId);
                sqlCon.AddInParameter(DBCom, "@userid", DbType.String, userid);
                string ds = Convert.ToString(sqlCon.ExecuteScalar(DBCom));
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet Get_FinTool_Highlights_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GET_FINTOOL_HIGHLIGHTS_REPORT");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                sqlCon.AddInParameter(DBCom, "@Culture", DbType.String, objFinModelingMgmt.Culture);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet Get_FinTool_Breakeven_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GET_FINTOOL_BREAKEVEN_REPORT");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet Get_FinTool_WorkingCapital_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GET_FINTOOL_WORKINGCAPITAL_REPORT");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet Get_FinTool_CashFlowReport_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GET_FINTOOL_CASHFLOW_REPORT");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet Get_FinTool_Funding_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GET_FINTOOL_FUNDING_REPORT");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                sqlCon.AddInParameter(DBCom, "@Culture", DbType.String, objFinModelingMgmt.Culture);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet Get_FinTool_Appa_Financials_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GET_FINTOOL_APPA_FINANCIALS_REPORT");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                sqlCon.AddInParameter(DBCom, "@Culture", DbType.String, objFinModelingMgmt.Culture);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet Get_FinTool_Report(FinancialModelingMgmt objFinModelingMgmt)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_GET_FINTOOL_REPORT");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public int Insert_Fintool_Feedback(FinancialModelingMgmt objFinModelingMgmt)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_INSERT_FEEDBACK");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                sqlCon.AddInParameter(DbCom, "@FEEDBACK_STAUS1", DbType.String, objFinModelingMgmt.feedback_Status1);
                sqlCon.AddInParameter(DbCom, "@FEEDBACK_STAUS2", DbType.String, objFinModelingMgmt.feedback_Status2);
                sqlCon.AddInParameter(DbCom, "@FEEDBACK_STAUS3", DbType.String, objFinModelingMgmt.feedback_Status3);
                sqlCon.AddInParameter(DbCom, "@ISRECOMMENDED", DbType.String, objFinModelingMgmt.isRecommended);
                sqlCon.AddInParameter(DbCom, "@EMAILID", DbType.String, objFinModelingMgmt.emailId);
                sqlCon.AddInParameter(DbCom, "@COMMENTS", DbType.String, objFinModelingMgmt.comments);
                sqlCon.AddOutParameter(DbCom, "@RETURN", DbType.Int32, 0);
                return sqlCon.ExecuteNonQuery(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_Fintool_Feedback(FinancialModelingMgmt objFinModelingMgmt)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("[USP_GET_FEEDBACK]");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, objFinModelingMgmt.UserID);
                ds = sqlCon.ExecuteDataSet(DBCom);
                return ds;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int Update_FinTool_Sales(string UserID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_FINTOOL_SALES");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                return sqlCon.ExecuteNonQuery(DbCom);
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
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_FINTOOL_COSTOFSALES");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                return sqlCon.ExecuteNonQuery(DbCom);
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
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_FINTOOL_OTHEROPERATING_EXPENSES");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                return sqlCon.ExecuteNonQuery(DbCom);
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
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_FINTOOL_FUNDING");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                return sqlCon.ExecuteNonQuery(DbCom);
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
                //dude
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_FINTOOL_ASSETS");
                DbCom.CommandTimeout = 3600;
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                return sqlCon.ExecuteNonQuery(DbCom);
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
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_FINTOOL_TAX_DEPRECIATION");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, UserID);
                return sqlCon.ExecuteNonQuery(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Getting Finalcial Management Capability Details
        // public DataSet Get_HealthProfileDetails(HealthProfiling obj_HProfDetails)
        public DataSet Get_FinalcialMgtDetails(FinancialMgtCapabilities obj_FMgtCapbilities)
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Get_FinancialMgtQuestionDetails");
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.String, obj_FMgtCapbilities.Culture);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
        #region Get Last Finalcial Management Answer from public
        public DataSet GetLastAnswer_FinancialMgtAnswer(FinancialMgtCapabilities obj_FMgtCapbilities)
        {
            try
            {

                DbCommand DbCom = sqlCon.GetStoredProcCommand("Sp_FinancialMgtLastAnswer");
                sqlCon.AddInParameter(DbCom, "@UserId", SqlDbType.NVarChar, obj_FMgtCapbilities.PostedBy);
                //sqlCon.AddInParameter(DbCom, "@Qid", SqlDbType.Int , obj_healthprofile.Qid);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Entering Finalcial Management Answer from public
        public void inertTB_PublicFinalcialMgtPollAnswer(DataTable dtTbDetails, FinancialMgtCapabilities obj_FMgtCapbilities)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Sp_Insert_TB_FinalcialMgtPollAnswer");
                sqlCon.AddInParameter(DbCom, "@tblDetails", SqlDbType.Structured, dtTbDetails);
                //changes 
                sqlCon.AddInParameter(DbCom, "@PostedBy", SqlDbType.NVarChar, obj_FMgtCapbilities.PostedBy);
                sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region ChangePassword
        /// <summary>
        /// 06/may/2012
        /// Update change password
        /// </summary>
        /// <param name="objDTO"></param>
        /// <returns></returns>
        /// 

        public int UpdatePassword(ChangePassword objChangePassword)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("USP_ChangePassword");
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, objChangePassword.StrEmailID);
                sqlCon.AddInParameter(DbCom, "@ExistingPassword", DbType.String, objChangePassword.StrExistingPassword);
                sqlCon.AddInParameter(DbCom, "@NewPassword", DbType.String, objChangePassword.strNewPassword);
                sqlCon.AddOutParameter(DbCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DbCom);
                return int.Parse(DbCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //updates the visited status to 1 
        public int UpdateVisitStatus(RegistrationDTO objDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Sp_UpdateVisit");
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, objDTO.EmailID);

                return sqlCon.ExecuteNonQuery(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Returns the visiting status  of user (for 1st time or not)
        public int Get_VisitStatus(RegistrationDTO objDTO)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Sp_GetVisitStatus");
                sqlCon.AddInParameter(DbCom, "@EmailID", DbType.String, objDTO.EmailID);
                return Convert.ToInt32( sqlCon.ExecuteScalar (DbCom));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Record_UserDetails(string ID)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("Usp_Delete_Record_UserDetails");
                sqlCon.AddInParameter(DBCom, "@UserID", DbType.String, ID);
                int i = sqlCon.ExecuteNonQuery(DBCom);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        #endregion



        /* ADDED BY SHEKAR FOR RESOURCE LIBRARY NEW VERSION ON 10-MAY-2012*/

        public DataSet GET_RESOURCELIBRARY_CATEGORYDTLS(ResourceLibDetails obj_RsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("SP_GET_RESOURCELIBRARY_CATEGORYDTLS");
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.String, obj_RsDetails.Culture);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GET_RESOURCELIBRARY_DETAILS_ByTopicID(ResourceLibDetails obj_RsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("SP_GET_RESOURCELIBRARY_DETAILS");
                sqlCon.AddInParameter(DBCmnd, "@TopicID", DbType.Int32, obj_RsDetails.TopicID);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.Int32, Convert.ToInt32(obj_RsDetails.Culture));
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int GET_STATUS_FAVOURITE(ResourceLibDetails obj_RSDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("SP_GET_STATUS_FAVOURITE");
                sqlCon.AddInParameter(DBCmnd, "@UserId", SqlDbType.VarChar, obj_RSDetails.UserId);
                sqlCon.AddInParameter(DBCmnd, "@RL_ID", SqlDbType.Int, obj_RSDetails.RL_ID);
                sqlCon.AddOutParameter(DBCmnd, "@output", SqlDbType.Int, 0);               
                sqlCon.ExecuteNonQuery(DBCmnd);
                return int.Parse(DBCmnd.Parameters["@output"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GET_RelatedArticals(ResourceLibDetails obj_RsDetails)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("SP_GET_RelatedArticals");
                sqlCon.AddInParameter(DBCmnd, "@Docs", DbType.String, obj_RsDetails.Docs);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.String, Convert.ToString( obj_RsDetails.intCulture));
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

   //21 may 2012
        #region Get_UniqueCategoryFrom ManageCapabilities Profiling
        public DataSet Get_QueCategory_ManageCapabilities()
        {

            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("Sp_ManageCapabilitiesQueCategory");
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        #region Get_ReportCapabilitiesProfiling
        public DataSet Get_ReportCapabilitiesProfiling(FinancialMgtCapabilities  obj_MangeCapabilities)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("SP_GetManageCapabilitiesQueRating_Rpt");
                sqlCon.AddInParameter(DBCmnd, "@Qcat", SqlDbType.NVarChar, obj_MangeCapabilities.Category);
                sqlCon.AddInParameter(DBCmnd, "@startdate", SqlDbType.DateTime, obj_MangeCapabilities.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@enddate", SqlDbType.DateTime, obj_MangeCapabilities.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion
        //21 may 2012

        #region TrafficAnalysis

        public DataSet GET_Industry()
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_Industry");
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet Get_TrafficAnalysis(TrafficAnalysis trafficAnalysis)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_TRAFFICANALYSIS_SEARCH");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int, trafficAnalysis.IndustryID);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, trafficAnalysis.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, trafficAnalysis.EndDate);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.Int32, trafficAnalysis.Culture);
                //  sqlCon.AddInParameter(DBCmnd, "@enddate", SqlDbType.DateTime, obj_TrafficAnalysis.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    

        public DataSet GET_TrafficAnalysis_Login(TrafficAnalysis trafficAnalysis)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_TRAFFICANALYSIS_LOGIN_SEARCH");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int,trafficAnalysis.IndustryID);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, trafficAnalysis.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, trafficAnalysis.EndDate);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.Int32, trafficAnalysis.Culture);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet GET_TrafficAnalysis_Login_SpentTime(TrafficAnalysis trafficAnalysis)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_TRAFFICANALYSIS_LOGIN_SPENT_SEARCH");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int, trafficAnalysis.IndustryID);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, trafficAnalysis.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, trafficAnalysis.EndDate);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.Int32, trafficAnalysis.Culture);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DataSet GET_TrafficAnalysis_Login_HitTimes(TrafficAnalysis trafficAnalysis)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_TRAFFICANALYSIS_HITTIMES_SEARCH");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int, trafficAnalysis.IndustryID);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, trafficAnalysis.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, trafficAnalysis.EndDate);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.Int32, trafficAnalysis.Culture);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DataSet Get_TrafficAnalysis_Temp(int IndustryID)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_TRAFFICANALYSIS_TEMP");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int, IndustryID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion



        #region Ateeq Report
        public DataSet Get_ResLib_TemplateDownloaded(TrafficAnalysis trafficAnalysis)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_ResLib_TemplateDownloaded");
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, trafficAnalysis.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, trafficAnalysis.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet Get_ResLib_TrafficAnalysis(TrafficAnalysis trafficAnalysis)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_ResLib_TrafficAnalysis");
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, trafficAnalysis.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, trafficAnalysis.EndDate);
                sqlCon.AddInParameter(DBCmnd, "@Culture", DbType.Int32, trafficAnalysis.Culture);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

                
        }


        public DataSet Get_FeedbackAnalysis(TrafficAnalysis trafficAnalysis)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_Get_FeedbackAnalysis");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int, trafficAnalysis.IndustryID);
               sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, trafficAnalysis.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, trafficAnalysis.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet Get_Improvement_Comments(FeedBack obj_Feedback)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_IMPROVEMENT_REPORT_SEARCH");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int, obj_Feedback.IndustryId);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, obj_Feedback.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, obj_Feedback.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DataSet Get_Bugs_Comments(FeedBack obj_Feedback)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_BUGS_REPORT_SEARCH");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int, obj_Feedback.IndustryId);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, obj_Feedback.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, obj_Feedback.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public int InsertModuleTrack_ResLib(UserMgmt objUserMgmt)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_INSERT_MODULETRACK_ResLib");
                sqlCon.AddInParameter(DBCom, "@USERID", DbType.String, objUserMgmt.UserID);
                sqlCon.AddInParameter(DBCom, "@ACCESSBY", DbType.String, objUserMgmt.AccessBy);
                sqlCon.AddInParameter(DBCom, "@CATEGORYID", DbType.Int32, objUserMgmt.CategoryId);
                sqlCon.AddInParameter(DBCom, "@DESCRIPTION", DbType.String, objUserMgmt.AccessDescription);
                sqlCon.AddInParameter(DBCom, "@PAGEVIEW", DbType.String, objUserMgmt.PageView);
                sqlCon.AddInParameter(DBCom, "@DOWNLOADING", DbType.String, objUserMgmt.Downloading);
                sqlCon.AddInParameter(DBCom, "@INDUSTRYID", DbType.Int32, objUserMgmt.IndustryId);
                sqlCon.AddInParameter(DBCom, "@Culture", DbType.Int32, objUserMgmt.Culture);
                sqlCon.AddOutParameter(DBCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DBCom);
                return int.Parse(DBCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Get_FeedbackAnalysis_General(TrafficAnalysis trafficAnalysis)
        {

            try
            {//changes sp
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_Get_FeedbackAnalysis_General");
                sqlCon.AddInParameter(DBCmnd, "@IndustryId", SqlDbType.Int, trafficAnalysis.IndustryID);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, trafficAnalysis.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, trafficAnalysis.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        #region Manage Topic Details

        public void InsertTopicDetails(ResourceLibDetails objBLL)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_ManageCategory");
                sqlCon.AddInParameter(DBCom, "@TopicID", DbType.Int32, objBLL.TopicID);
                sqlCon.AddInParameter(DBCom, "@TopicName", DbType.String, objBLL.TopicName);
                sqlCon.AddInParameter(DBCom, "@TopicDesc", DbType.String, objBLL.TopicDesc);
                sqlCon.AddInParameter(DBCom, "@action", DbType.String, objBLL.action);
                sqlCon.AddInParameter(DBCom, "@TopicIDs", DbType.String, objBLL.TopicIDS);
                sqlCon.ExecuteNonQuery(DBCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTopicDetails(ResourceLibDetails objBLL)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_GetCategory");
                sqlCon.AddInParameter(DBCom, "@TopicID", DbType.Int32, objBLL.TopicID);
                sqlCon.AddInParameter(DBCom, "@action", DbType.String, objBLL.action);
                return sqlCon.ExecuteDataSet(DBCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidateTopicDetails(string[] TopicIDs)
        {
            try
            {
                string strCategories = string.Empty;
                for (int i = 0; i < TopicIDs.Length; i++)
                {
                    DbCommand DBCom = sqlCon.GetStoredProcCommand("SP_ManageCategory");
                    sqlCon.AddInParameter(DBCom, "@TopicID", DbType.Int32, TopicIDs[i].ToString());
                    sqlCon.AddInParameter(DBCom, "@action", DbType.String, "Validate");
                    strCategories += sqlCon.ExecuteScalar(DBCom);

                    //bCommand DBCom = sqlCon.GetStoredProcCommand("SP_ManageCategory");
                    //sqlCon.AddInParameter(DBCom, "@TopicID", DbType.Int32, objBLL.TopicID);
                    //sqlCon.AddInParameter(DBCom, "@action", DbType.String, "D");
                    //return sqlCon.ExecuteDataSet(DBCom);
                }
                return strCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Manage Registration Feedback

        public void InsertRegistrationFbFlag(FeedBack obj_Feedback)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_InsertRegistrationFbFlag");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, obj_Feedback.UserID);
                sqlCon.AddInParameter(DbCom, "@ActionOn", DbType.String, obj_Feedback.ActionOn);
                sqlCon.ExecuteNonQuery(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRegistrationFbFlag(FeedBack obj_Feedback)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("SP_GetRegistrationFbFlag");
                sqlCon.AddInParameter(DbCom, "@UserID", DbType.String, obj_Feedback.UserID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region ClinicalSession Records

        /// <summary>
        ///01/08/2012
        ///To Get ClinicalSession Records
        /// </summary>
        /// <param name="objReg"></param>
        /// <returns></returns>
        public DataSet Get_ClinicalSession(Registration objReg)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_CLINICALSESSION");
                sqlCon.AddInParameter(DBCmnd, "@COMPANY", SqlDbType.VarChar, objReg.Company);
                sqlCon.AddInParameter(DBCmnd, "@EMAIL", SqlDbType.VarChar, objReg.Email);
                sqlCon.AddInParameter(DBCmnd, "@StartDate", SqlDbType.DateTime, objReg.StartDate);
                sqlCon.AddInParameter(DBCmnd, "@EndDate", SqlDbType.DateTime, objReg.EndDate);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        ///01/08/2012
        ///To Insert ClinicalSession Records
        /// </summary>
        /// <param name="objReg"></param>
        /// <returns></returns>
        public int Insert_ClinicalSession(Registration objReg)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_INSERT_CLINICALSESSION ");
                sqlCon.AddInParameter(DBCom, "@USERID", DbType.String, objReg.UserID);
                sqlCon.AddInParameter(DBCom, "@TITLE", DbType.String, objReg.Title);
                sqlCon.AddInParameter(DBCom, "@NAME", DbType.String, objReg.Name);
                sqlCon.AddInParameter(DBCom, "@DESIGNATION", DbType.String, objReg.Designation);
                sqlCon.AddInParameter(DBCom, "@COMPANY", DbType.String, objReg.Company);
                sqlCon.AddInParameter(DBCom, "@TELEPHONE", DbType.String, objReg.Telephone);
                sqlCon.AddInParameter(DBCom, "@EMAIL", DbType.String, objReg.Email);
                sqlCon.AddInParameter(DBCom, "@PREFERREDDATES", DbType.String, objReg.PreferredDates);
                sqlCon.AddInParameter(DBCom, "@TOPICS", DbType.String, objReg.Topics);
                sqlCon.AddOutParameter(DBCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DBCom);
                return int.Parse(DBCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///01/08/2012
        ///To Update ClinicalSession Records
        /// </summary>
        /// <param name="objReg"></param>
        /// <returns></returns>
        public int Update_ClinicalSession(Registration objReg)
        {
            try
            {
                DbCommand DBCom = sqlCon.GetStoredProcCommand("USP_UPDATE_CLINICALSESSION ");
                sqlCon.AddInParameter(DBCom, "@USERID", DbType.String, objReg.UserID);
                sqlCon.AddInParameter(DBCom, "@ADMIN_PREFERREDDATE", DbType.String, objReg.Admin_PreferredDate);
                sqlCon.AddOutParameter(DBCom, "@RETURN", DbType.Int32, 1);
                sqlCon.ExecuteNonQuery(DBCom);
                return int.Parse(DBCom.Parameters["@RETURN"].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///14/08/2012
        ///To Get Registration details to ClinicalSession Records
        /// </summary>
        /// <param name="objReg"></param>
        /// <returns></returns>
        public DataSet Get_RegDetails_ClinicalSession(Registration objReg)
        {
            try
            {
                DbCommand DBCmnd = sqlCon.GetStoredProcCommand("USP_GET_REG_CLINICALSESSION");
                sqlCon.AddInParameter(DBCmnd, "@USERID", SqlDbType.VarChar, objReg.UserID);
                return sqlCon.ExecuteDataSet(DBCmnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


    }
}



