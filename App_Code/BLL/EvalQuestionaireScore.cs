using System;
using System.Collections.Generic;

using System.Web;

/// <summary>
/// Summary description for EvalQuestionaireScore
/// </summary>
namespace ABSBLL
{
    public class EvalQuestionaireScore
    {
        public EvalQuestionaireScore()
        {
            
        }

        public EvalQuestionaireScore(string strCompanyID, string strQID, string strRating)
        {
            this.strCompanyID = strCompanyID;
            this.strQID = strQID;
            this.strRating = strRating;
        }

        public string strCompanyID { get; set; }
        public string strQID { get; set; }
        public string strRating { get; set; }
    }
}