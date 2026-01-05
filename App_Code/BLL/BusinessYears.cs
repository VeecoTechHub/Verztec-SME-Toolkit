using System;
using System.Collections.Generic;
////using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BusinessYears
/// </summary>
namespace ABSBLL
{
    public class BusinessYears
    {
        public BusinessYears()
        {
            
        }

        public BusinessYears(string strText, string strpassword)
        {
            this.strText = strText;
            this.strpassword = strpassword;
        }

        public string strText { get; set; }
        public string strpassword { get; set; }

        //public enum Months { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }; 

    }
}