using PBL3.Model.Bean;
using PBL3.Models.Dao;
using System.Collections.Generic;

namespace PBL3.Models.Bo
{
    internal class Bo_FeedbackModel
    {
        private Dao_FeedbackModel daoFeedbackModel;

        public Bo_FeedbackModel()
        {
            daoFeedbackModel = new Dao_FeedbackModel();
        }

        // Add new feedback
        public void AddFeedback(FeedbackModel feedback)
        {
            daoFeedbackModel.AddFeedback(feedback);
        }

        // Add new message
        public void AddFeedbackMessage(FeedbackMessage message)
        {
            daoFeedbackModel.AddFeedbackMessage(message);
        }

        // Delete feedback
        public void DeleteFeedback(string feedbackID)
        {
            daoFeedbackModel.DeleteFeedback(feedbackID);
        }

        // Update feedback
        public void UpdateFeedback(FeedbackModel feedback)
        {
            daoFeedbackModel.UpdateFeedback(feedback);
        }
        public List<FeedbackModel> GetFeedbackList()
        {
            return daoFeedbackModel.GetfeedbackList();
        }
        // Get feedback by feedback ID
        public FeedbackModel GetFeedbackById(string feedbackID)
        {
            return daoFeedbackModel.GetFeedbackById(feedbackID);
        }

        // Get feedback by User ID
        public IEnumerable<FeedbackModel> GetFeedbackByUserId(int userId)
        {
            return daoFeedbackModel.GetFeedbackByUserId(userId);
        }
    }
}
