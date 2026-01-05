using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RegistrationDTO
/// </summary>

namespace ABSDTO
{
    public class RegistrationDTO
    {
        public RegistrationDTO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Registration Details DTO

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
        public string Action { get; set; }
        public int @Visited { get; set; }
        public string LoginsessionID { get; set; }
        public string Sort_On { get; set; }
        public string Sort_Direction { get; set; }

        public string Culture { get; set; }

        #endregion
    }
}