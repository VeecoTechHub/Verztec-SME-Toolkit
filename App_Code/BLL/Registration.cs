using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using ABSDAL;
using ABSDTO;
using System.Data;

/// <summary>
/// Summary description for Registration
/// </summary>

namespace ABSBLL
{
    public class Registration
    {

        #region ClinicalSession Page properties

        public string UserID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string PreferredDates { get; set; }
        public string Topics { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Admin_PreferredDate { get; set; }
        public string Culture { get; set; }
        public int intCulture { get; set; }
        #endregion

        CommonDAL dataAccessLayer;
        public Registration()
        {
            dataAccessLayer = new CommonDAL();
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
                return dataAccessLayer.InsertRegistration(objDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUserDetails(string UserID, string ActivationKey, string strStatus)
        {
            try
            {
                return dataAccessLayer.GetUserDetails(UserID, ActivationKey, strStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserStatus(RegistrationDTO objDTO)
        {
            try
            {
                dataAccessLayer.UpdateUserStatus(objDTO);
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
                return dataAccessLayer.GetItemsDetails(Culture);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoginDTO CheckUser(RegistrationDTO objUserDTO)
        {
            try
            {
                LoginDTO objDTO = new LoginDTO();
                // Method to authenticate the user.
                DataSet dsUser = dataAccessLayer.CheckUser(objUserDTO);
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        // Code to bind logged in user details.
                        objDTO.UserID = dsUser.Tables[0].Rows[0]["UserID"].ToString();
                        objDTO.EmailID = dsUser.Tables[0].Rows[0]["EmailID"].ToString();
                        objDTO.Password = dsUser.Tables[0].Rows[0]["Password"].ToString();
                        objDTO.Title = dsUser.Tables[0].Rows[0]["Title"].ToString();
                        objDTO.Name = dsUser.Tables[0].Rows[0]["Name"].ToString();
                        objDTO.CompanyNm = dsUser.Tables[0].Rows[0]["CompanyNm"].ToString();
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["BussStartedYear"].ToString()))
                            objDTO.BussStartedMonth = int.Parse(dsUser.Tables[0].Rows[0]["BussStartedMonth"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["BussStartedYear"].ToString()))
                            objDTO.BussStartedYear = int.Parse(dsUser.Tables[0].Rows[0]["BussStartedYear"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["NoofEmployees"].ToString()))
                            objDTO.NoofEmployees = Int64.Parse(dsUser.Tables[0].Rows[0]["NoofEmployees"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["TotalCapital"].ToString()))
                            objDTO.TotalCapital = Convert.ToDouble(dsUser.Tables[0].Rows[0]["TotalCapital"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["AnnualRevenue"].ToString()))
                            objDTO.AnnualRevenue = Convert.ToDouble(dsUser.Tables[0].Rows[0]["AnnualRevenue"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["BusinessID"].ToString()))
                            objDTO.BusinessID = int.Parse(dsUser.Tables[0].Rows[0]["BusinessID"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["IndustryID"].ToString()))
                            objDTO.IndustryID = int.Parse(dsUser.Tables[0].Rows[0]["IndustryID"].ToString());
                        objDTO.Status = dsUser.Tables[0].Rows[0]["Status"].ToString();
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["CreatedOn"].ToString()))
                            objDTO.CreatedOn = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["CreatedOn"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["CompletedOn"].ToString()))
                            objDTO.CompletedOn = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["CompletedOn"].ToString());
                        objDTO.ActivationKey = dsUser.Tables[0].Rows[0]["ActivationKey"].ToString();
                    }
                    if (dsUser.Tables[1].Rows.Count > 0)
                    {
                        // Code to get latest user Log details.
                        if (!string.IsNullOrEmpty(dsUser.Tables[1].Rows[0]["LoggedInAt"].ToString()))
                            objDTO.LoggedInAt = Convert.ToDateTime(dsUser.Tables[1].Rows[0]["LoggedInAt"].ToString());
                    }
                    if (dsUser.Tables[2] != null)
                    {
                        if (dsUser.Tables[2].Rows.Count > 0)
                        {
                            // Code to get latest user Log details.
                            if (!string.IsNullOrEmpty(dsUser.Tables[2].Rows[0]["STATUS"].ToString()))
                                objDTO.Wrongstatus = dsUser.Tables[2].Rows[0]["STATUS"].ToString();
                        }
                    }

                }
                return objDTO;
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
        public int  InsertUserLogs(LoginDTO objDTO)
        {
            try
            {
               return dataAccessLayer.InsertUserLogs(objDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateUserDetails(RegistrationDTO objDTO)
        {
            try
            {
                return dataAccessLayer.UpdateUserDetails(objDTO);
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
                return dataAccessLayer.GetUserDetailsByEmailID(EmailID);
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
                return dataAccessLayer.GetAllMonths();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoginDTO GetUserDetailsAfterUpdate(string EmailID, string strLastLogIn)
        {
            try
            {
                LoginDTO objDTO = new LoginDTO();
                // Method to get the user by Email ID.
                DataSet dsUser = dataAccessLayer.GetUserDetailsByEmailID(EmailID);
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        // Code to bind logged in user details after updating the profile details.
                        objDTO.UserID = dsUser.Tables[0].Rows[0]["UserID"].ToString();
                        objDTO.EmailID = dsUser.Tables[0].Rows[0]["EmailID"].ToString();
                        objDTO.Password = dsUser.Tables[0].Rows[0]["Password"].ToString();
                        objDTO.Title = dsUser.Tables[0].Rows[0]["Title"].ToString();
                        objDTO.Name = dsUser.Tables[0].Rows[0]["Name"].ToString();
                        objDTO.CompanyNm = dsUser.Tables[0].Rows[0]["CompanyNm"].ToString();
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["BussStartedYear"].ToString()))
                            objDTO.BussStartedMonth = int.Parse(dsUser.Tables[0].Rows[0]["BussStartedMonth"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["BussStartedYear"].ToString()))
                            objDTO.BussStartedYear = int.Parse(dsUser.Tables[0].Rows[0]["BussStartedYear"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["NoofEmployees"].ToString()))
                            objDTO.NoofEmployees = Int64.Parse(dsUser.Tables[0].Rows[0]["NoofEmployees"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["TotalCapital"].ToString()))
                            objDTO.TotalCapital = Convert.ToDouble(dsUser.Tables[0].Rows[0]["TotalCapital"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["AnnualRevenue"].ToString()))
                            objDTO.AnnualRevenue = Convert.ToDouble(dsUser.Tables[0].Rows[0]["AnnualRevenue"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["BusinessID"].ToString()))
                            objDTO.BusinessID = int.Parse(dsUser.Tables[0].Rows[0]["BusinessID"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["IndustryID"].ToString()))
                            objDTO.IndustryID = int.Parse(dsUser.Tables[0].Rows[0]["IndustryID"].ToString());
                        objDTO.Status = dsUser.Tables[0].Rows[0]["Status"].ToString();
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["CreatedOn"].ToString()))
                            objDTO.CreatedOn = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["CreatedOn"].ToString());
                        if (!string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["CompletedOn"].ToString()))
                            objDTO.CompletedOn = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["CompletedOn"].ToString());
                        objDTO.ActivationKey = dsUser.Tables[0].Rows[0]["ActivationKey"].ToString();
                    }
                    // Code to last logged in status of user.
                    if (!string.IsNullOrEmpty(strLastLogIn))
                        objDTO.LoggedInAt = Convert.ToDateTime(strLastLogIn);
                }
                return objDTO;
            }
            catch (Exception ex)
            {
                throw ex;
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
                return dataAccessLayer.GetUserStatusbyUserID(UserID);
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
                return dataAccessLayer.GetAllUsers(objDTO);
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
        public void DeleteUser(string delrecid)
        {
            try
            {
                 dataAccessLayer.DeleteUser(delrecid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        /// <summary>
        /// Method to get User Details by passing the User ID.
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetUserDetailsbyUserID(string UserID)
        {
            try
            {
                return dataAccessLayer.GetUserDetailsbyUserID(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public int UpdateUserDetailsWithoutPwd(RegistrationDTO objDTO)
        {
            try
            {
                return dataAccessLayer.UpdateUserDetailsWithoutPwd(objDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //7th may
        public int  UpdateVisitStatus(RegistrationDTO objDTO)

        {
            try
            {
              return   dataAccessLayer.UpdateVisitStatus(objDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Get_VisitStatus(RegistrationDTO objDTO)

        {
            try
            {
                return dataAccessLayer.Get_VisitStatus(objDTO);
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
                return dataAccessLayer.Delete_Record_UserDetails(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region ClinicalSession methods

        public DataSet Get_ClinicalSession(Registration objReg)
        {
            try
            {
                return dataAccessLayer.Get_ClinicalSession(objReg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert_ClinicalSession(Registration objReg)
        {
            try
            {
                return dataAccessLayer.Insert_ClinicalSession(objReg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update_ClinicalSession(Registration objReg)
        {
            try
            {
                return dataAccessLayer.Update_ClinicalSession(objReg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_RegDetails_ClinicalSession(Registration objReg)
        {
            try
            {
                return dataAccessLayer.Get_RegDetails_ClinicalSession(objReg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion



    }

    
}