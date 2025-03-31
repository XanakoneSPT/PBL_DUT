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
    internal class Bo_Introduction
    {
        private readonly Dao_Introduction _introductionActivityDAO;
        private readonly dbConnection _dbconnection;

        public Bo_Introduction(dbConnection connection)
        {
            _introductionActivityDAO = new Dao_Introduction(connection);
            _dbconnection = connection;
        }
        public List<IntroductionModel> GetIntroductionActivityListByStatus(string status)
        {
            return _introductionActivityDAO.GetIntroductionActivityListByStatus(status);
        }
        public List<IntroductionModel> GetIntroductionActivityList()
        {
            return _introductionActivityDAO.GetIntroductionActivityList();
        }
        public List<IntroductionModel> GetIntroductionByUserID(int userId)
        {
            return _introductionActivityDAO.GetIntroductionByUserID(userId);
        }
        public bool AddIntroductionActivity(IntroductionModel introductionActivity)
        {
            if (introductionActivity == null)
            {
                throw new ArgumentException("Invalid introduction activity data.");
            }

            introductionActivity.IntroductionActivityID = _introductionActivityDAO.GenerateIntroductionActivityID();
            return _introductionActivityDAO.AddIntroductionActivity(introductionActivity);
        }

        public bool DeleteIntroductionActivity(string introductionActivityID)
        {
            if (string.IsNullOrEmpty(introductionActivityID))
            {
                throw new ArgumentException("Introduction activity ID cannot be null or empty.");
            }

            return _introductionActivityDAO.DeleteIntroductionActivity(introductionActivityID);
        }

        public bool UpdateIntroductionActivity(IntroductionModel introductionActivity)
        {
            if (introductionActivity == null || string.IsNullOrEmpty(introductionActivity.IntroductionActivityID))
            {
                throw new ArgumentException("Invalid introduction activity data.");
            }

            return _introductionActivityDAO.UpdateIntroductionActivity(introductionActivity);
        }

        public IntroductionModel GetIntroductionActivityByID(string introductionActivityID)
        {
            if (string.IsNullOrEmpty(introductionActivityID))
            {
                throw new ArgumentException("Introduction activity ID cannot be null or empty.");
            }

            return _introductionActivityDAO.GetIntroductionActivityByID(introductionActivityID);
        }

        public List<IntroductionModel> SearchIntroductionActivities(string searchText)
        {
            // Call the appropriate method from your data access layer (Dao_Introduction)
            return _introductionActivityDAO.SearchIntroductionActivities(searchText);
        }

    }
}
