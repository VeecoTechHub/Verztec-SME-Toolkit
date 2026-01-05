using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using ABSDAL;
using ABSDTO;
using System.Data;

/// <summary>
/// Summary description for EvalQuestionaire
/// </summary>

namespace ABSBLL
{
    public class EvalQuestionaire
    {
        CommonDAL dataAccessLayer;
        public EvalQuestionaire()
        {
            dataAccessLayer = new CommonDAL();
        }

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
                return dataAccessLayer.GetEvalQuestionaireByUserID(UserID, strCategory);
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
                dataAccessLayer.InsertEvaluationScore(EvalScore);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}