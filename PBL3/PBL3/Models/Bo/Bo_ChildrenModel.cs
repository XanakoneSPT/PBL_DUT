using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.Model.Bean;
using PBL3.Model.Dao;
using PBL3.Models.Dao;

namespace PBL3.Models.Bo
{
    internal class Bo_ChildrenModel
    {
        private Dao_ChildrenModel daoChildren;

        public Bo_ChildrenModel(dbConnection connection)
        {
            daoChildren = new Dao_ChildrenModel(connection);
        }

        // Phương thức lấy danh sách các Children
        public List<ChildrenModel> GetChildrenList()
        {
            return daoChildren.GetChildrenList();
        }

        // Phương thức thêm Children
        public bool AddChildren(ChildrenModel child)
        {
            // Kiểm tra dữ liệu đầu vào trước khi thêm
            if (child == null /*|| string.IsNullOrEmpty(child.ChildID)*/ || string.IsNullOrEmpty(child.FirstName) || string.IsNullOrEmpty(child.LastName))
            {
                throw new ArgumentException("Invalid child data.");
            }

            return daoChildren.AddChildren(child);
        }

        // Phương thức xóa Children
        public bool DeleteChildren(string childID)
        {
            // Kiểm tra dữ liệu đầu vào trước khi xóa
            if (string.IsNullOrEmpty(childID))
            {
                throw new ArgumentException("ChildID cannot be null or empty.");
            }

            return daoChildren.DeleteChildren(childID);
        }

        // Phương thức cập nhật thông tin Children
        public bool UpdateChildren(ChildrenModel child)
        {
            // Kiểm tra dữ liệu đầu vào trước khi cập nhật
            if (child == null /*|| string.IsNullOrEmpty(child.ChildID)*/ || string.IsNullOrEmpty(child.FirstName) || string.IsNullOrEmpty(child.LastName))
            {
                throw new ArgumentException("Invalid child data.");
            }

            return daoChildren.UpdateChildren(child);
        }
        public Dictionary<string, int> GetChildrenCountByMonth()
        {
            return daoChildren.GetChildrenCountByMonth();
        }

        // Get total count of children
        public int GetTotalChildrenCount()
        {
            return daoChildren.GetTotalChildrenCount();
        }
    }
}
