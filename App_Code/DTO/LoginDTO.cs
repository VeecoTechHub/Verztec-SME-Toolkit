using System;
using System.Collections.Generic;
////using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginDTO
/// </summary>

namespace ABSDTO
{
    public class LoginDTO
    {
        public LoginDTO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Login Details DTO

        public string UserID { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string CompanyNm { get; set; }
        public int BussStartedMonth { get; set; }
        public int BussStartedYear { get; set; }
        public long NoofEmployees { get; set; }
        public double TotalCapital { get; set; }
        public double AnnualRevenue { get; set; }
        public int BusinessID { get; set; }
        public int IndustryID { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string ActivationKey { get; set; }
        public DateTime? LoggedInAt { get; set; }
        public string Flag { get; set; }
        public int LogId { get; set; }
        public string Wrongstatus { get; set; }
        public int Culture { get; set; }
      
        #endregion
    }
}