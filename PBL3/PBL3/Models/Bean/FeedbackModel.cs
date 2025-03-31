using System;
using System.Collections.Generic;

namespace PBL3.Model.Bean
{
    public class FeedbackModel
    {
        public string FeedbackID { get; set; }
        public int UserId { get; set; }
        public string Topic { get; set; }
        public string ContactInfo { get; set; }
        public DateTime FeedbackDate { get; set; }
        public List<FeedbackMessage> Messages { get; set; }

        public FeedbackModel()
        {
            Messages = new List<FeedbackMessage>();
        }
    }

    public class FeedbackMessage
    {
        public int MessageID { get; set; }
        public string FeedbackID { get; set; }
        public int UserId { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
