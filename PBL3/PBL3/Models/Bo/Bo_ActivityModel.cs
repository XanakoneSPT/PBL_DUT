using PBL3.Model.Dao;
using PBL3.Models.Dao;
using PBL3.Model.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Models.Bo
{
    internal class Bo_ActivityModel
    {
        private Dao_ActivityModel activityDAO;

        public Bo_ActivityModel(dbConnection dbConnection)
        {
            activityDAO = new Dao_ActivityModel(dbConnection);
        }

        public List<ActivityModel> GetActivities()
        {
            return activityDAO.GetActivities();
        }

        public ActivityModel GetActivityByID(string activityID)
        {
            return activityDAO.GetActivityByID(activityID);
        }

        public void AddActivity(ActivityModel activity)
        {
            if (string.IsNullOrEmpty(activity.Name) || activity.Time == DateTime.MinValue || string.IsNullOrEmpty(activity.Location))
            {
                throw new ArgumentException("Invalid activity details");
            }

            // Delegate the generation of activity ID to the DAO layer
            activity.ActivityID = activityDAO.GenerateActivityID();

            activityDAO.AddActivity(activity);
        }

        public void DeleteActivity(string id)
        {
            activityDAO.DeleteActivity(id);
        }

        public void UpdateActivity(ActivityModel activity)
        {
            if (string.IsNullOrEmpty(activity.Name) || activity.Time == DateTime.MinValue || string.IsNullOrEmpty(activity.Location))
            {
                throw new ArgumentException("Invalid activity details");
            }
            activityDAO.UpdateActivity(activity);
        }
    }
}


