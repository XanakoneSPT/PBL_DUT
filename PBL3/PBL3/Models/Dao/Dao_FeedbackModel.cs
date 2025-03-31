using Dapper;
using PBL3.Model.Bean;
using PBL3.Model.Dao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PBL3.Models.Dao
{
    internal class Dao_FeedbackModel
    {
        private dbConnection dbConnection;

        public Dao_FeedbackModel()
        {
            dbConnection = new dbConnection();
        }

        // Auto Generate ID
        private string GenerateFeedbackID()
        {
            string newFeedbackID = "";

            try
            {
                string query = "SELECT TOP 1 FeedbackID FROM Feedback ORDER BY FeedbackID DESC";
                dbConnection.OpenConnection();

                var lastFeedbackID = dbConnection.GetConnection().Query<string>(query).FirstOrDefault();

                if (!string.IsNullOrEmpty(lastFeedbackID))
                {
                    int lastNumber = int.Parse(lastFeedbackID.Substring(2));
                    int newNumber = lastNumber + 1;
                    newFeedbackID = "FB" + newNumber.ToString("D3");
                }
                else
                {
                    newFeedbackID = "FB001";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return newFeedbackID;
        }

        // Add new feedback
        public void AddFeedback(FeedbackModel feedback)
        {
            string feedbackID = GenerateFeedbackID();

            string query = "INSERT INTO Feedback (FeedbackID, UserId, Topic, ContactInfo, FeedbackDate) VALUES (@FeedbackID, @UserId, @Topic, @ContactInfo, @FeedbackDate)";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, new
                {
                    FeedbackID = feedbackID,
                    UserId = feedback.UserId,
                    Topic = feedback.Topic,
                    ContactInfo = feedback.ContactInfo,
                    FeedbackDate = feedback.FeedbackDate
                });

                feedback.FeedbackID = feedbackID; // Set the generated ID back to the model
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        // Add new message
        public void AddFeedbackMessage(FeedbackMessage message)
        {
            string query = "INSERT INTO FeedbackMessages (FeedbackID, UserId, MessageText, MessageDate) VALUES (@FeedbackID, @UserId, @MessageText, @MessageDate)";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, new
                {
                    FeedbackID = message.FeedbackID,
                    UserId = message.UserId,
                    MessageText = message.MessageText,
                    MessageDate = message.MessageDate
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        // Delete feedback
        public void DeleteFeedback(string feedbackID)
        {
            string query = "DELETE FROM Feedback WHERE FeedbackID = @FeedbackID";

            try
            {
                dbConnection.OpenConnection();
                dbConnection.GetConnection().Execute(query, new { FeedbackID = feedbackID });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        // Update feedback
        public void UpdateFeedback(FeedbackModel feedback)
        {
            string feedbackQuery = "UPDATE Feedback SET Topic = @Topic, ContactInfo = @ContactInfo WHERE FeedbackID = @FeedbackID";
            string messageQuery = "UPDATE FeedbackMessages SET MessageText = @MessageText WHERE FeedbackID = @FeedbackID";

            try
            {
                dbConnection.OpenConnection();

                // Update the Feedback table
                dbConnection.GetConnection().Execute(feedbackQuery, new
                {
                    FeedbackID = feedback.FeedbackID,
                    Topic = feedback.Topic,
                    ContactInfo = feedback.ContactInfo
                });

                // Update the FeedbackMessages table
                foreach (var message in feedback.Messages)
                {
                    dbConnection.GetConnection().Execute(messageQuery, new
                    {
                        FeedbackID = feedback.FeedbackID,
                        MessageText = message.MessageText,
                        //MessageDate = message.MessageDate
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        public List<FeedbackModel> GetfeedbackList()
        {
            List<FeedbackModel> feedbackList = new List<FeedbackModel>();
            string query = "SELECT * FROM Feedback";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FeedbackModel feedback = new FeedbackModel
                            {
                                FeedbackID = reader.GetString(0),
                                UserId = reader.GetInt32(1),
                                Topic = reader.GetString(2),
                                ContactInfo = reader.GetString(3),
                                FeedbackDate = reader.GetDateTime(4),
                            };
                            feedbackList.Add(feedback);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return feedbackList;
        }
        // Get feedback by feedback ID
        public FeedbackModel GetFeedbackById(string feedbackID)
        {
            string query = @"
                SELECT F.FeedbackID, F.UserId, F.Topic, F.ContactInfo, F.FeedbackDate, M.MessageID, M.UserId AS MessageUserId, M.MessageText, M.MessageDate
                FROM Feedback F
                LEFT JOIN FeedbackMessages M ON F.FeedbackID = M.FeedbackID
                WHERE F.FeedbackID = @FeedbackID
                ORDER BY M.MessageDate";

            try
            {
                dbConnection.OpenConnection();
                var result = dbConnection.GetConnection().Query<dynamic>(query, new { FeedbackID = feedbackID }).ToList();

                if (!result.Any()) return null;

                var feedback = new FeedbackModel
                {
                    FeedbackID = result.First().FeedbackID,
                    UserId = result.First().UserId,
                    Topic = result.First().Topic,
                    ContactInfo = result.First().ContactInfo,
                    FeedbackDate = result.First().FeedbackDate,
                    Messages = result.Where(r => r.MessageID != null).Select(r => new FeedbackMessage
                    {
                        MessageID = r.MessageID,
                        FeedbackID = r.FeedbackID,
                        UserId = r.MessageUserId,
                        MessageText = r.MessageText,
                        MessageDate = r.MessageDate
                    }).ToList()
                };

                return feedback;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        // Get feedback by User ID
        public IEnumerable<FeedbackModel> GetFeedbackByUserId(int userId)
        {
            string query = @"
                SELECT F.FeedbackID, F.UserId, F.Topic, F.ContactInfo, F.FeedbackDate, M.MessageID, M.UserId AS MessageUserId, M.MessageText, M.MessageDate
                FROM Feedback F
                LEFT JOIN FeedbackMessages M ON F.FeedbackID = M.FeedbackID
                WHERE F.UserId = @UserId
                ORDER BY F.FeedbackDate, M.MessageDate";

            try
            {
                dbConnection.OpenConnection();
                var result = dbConnection.GetConnection().Query<dynamic>(query, new { UserId = userId }).ToList();

                var feedbackDict = new Dictionary<string, FeedbackModel>();

                foreach (var row in result)
                {
                    if (!feedbackDict.ContainsKey(row.FeedbackID))
                    {
                        feedbackDict[row.FeedbackID] = new FeedbackModel
                        {
                            FeedbackID = row.FeedbackID,
                            UserId = row.UserId,
                            Topic = row.Topic,
                            ContactInfo = row.ContactInfo,
                            FeedbackDate = row.FeedbackDate,
                            Messages = new List<FeedbackMessage>()
                        };
                    }

                    if (row.MessageID != null)
                    {
                        feedbackDict[row.FeedbackID].Messages.Add(new FeedbackMessage
                        {
                            MessageID = row.MessageID,
                            FeedbackID = row.FeedbackID,
                            UserId = row.MessageUserId,
                            MessageText = row.MessageText,
                            MessageDate = row.MessageDate
                        });
                    }
                }

                return feedbackDict.Values;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
    }
}
