using PBL3.Model.Dao;
using PBL3.Models.Dao;
using PBL3.Model.Bean;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Models.Bo
{
    internal class Bo_AdoptionModel
    {
        private readonly Dao_Adoption _adoptionActivityDAO;
        private readonly dbConnection _dbconnection;

        public Bo_AdoptionModel(dbConnection connection)
        {
            _adoptionActivityDAO = new Dao_Adoption(connection);
            _dbconnection = connection;
        }
        public List<AdoptionModel> GetAdoptionActivityList(string status = null)
        {
            return _adoptionActivityDAO.GetAdoptionActivityList(status);
        }
        public List<AdoptionModel> GetAdoptionActivityList()
        {
            return _adoptionActivityDAO.GetAdoptionActivityList();
        }
        public List<AdoptionModel> GetAdoptionActivityByUserID(int userId)
        {
            return _adoptionActivityDAO.GetAdoptionActivityByUserID(userId);
        }
        public bool AddAdoptionActivity(AdoptionModel adoptionActivity)
        {
            if (adoptionActivity == null)
            {
                throw new ArgumentException("Invalid adoption activity data.");
            }

            // Check if the ChildID exists in the Children table before adding the adoption activity
            if (!ChildExists(adoptionActivity.ChildID))
            {
                throw new ArgumentException("Child with the provided ID does not exist.");
            }
            adoptionActivity.AdoptionActivityID = _adoptionActivityDAO.GenerateAdoptionActivityID();
            return _adoptionActivityDAO.AddAdoptionActivity(adoptionActivity);
        }

        public bool ChildExists(string childID)
        {
            const string query = "SELECT COUNT(*) FROM Children WHERE ChildID = @ChildID";

            try
            {
                _dbconnection.OpenConnection();
                using (var command = new SqlCommand(query, _dbconnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@ChildID", childID);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                _dbconnection.CloseConnection();
            }
        }

        public bool DeleteAdoptionActivity(string adoptionActivityID)
        {
            if (string.IsNullOrEmpty(adoptionActivityID))
            {
                throw new ArgumentException("Adoption activity ID cannot be null or empty.");
            }

            return _adoptionActivityDAO.DeleteAdoptionActivity(adoptionActivityID);
        }

        public bool UpdateAdoptionActivity(AdoptionModel adoptionActivity)
        {
            if (adoptionActivity == null || string.IsNullOrEmpty(adoptionActivity.AdoptionActivityID))
            {
                throw new ArgumentException("Invalid adoption activity data.");
            }

            return _adoptionActivityDAO.UpdateAdoptionActivity(adoptionActivity);
        }

        public AdoptionModel GetAdoptionActivityByID(string adoptionActivityID)
        {
            if (string.IsNullOrEmpty(adoptionActivityID))
            {
                throw new ArgumentException("Adoption activity ID cannot be null or empty.");
            }

            return _adoptionActivityDAO.GetAdoptionActivityByID(adoptionActivityID);
        }
        public List<AdoptionModel> GetAdoptionActivityListSort()
        {
            return _adoptionActivityDAO.GetAdoptionActivityListSort();
        }
    }
}
