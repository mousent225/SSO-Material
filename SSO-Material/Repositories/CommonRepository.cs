using SSO_Material.Models;
using SSO_Material.Utilities;
using SSO_Material.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO_Material.Repositories
{
    public class CommonRepository
    {
        PortalEntities _db = new PortalEntities();
        public List<DeptModel> GetDeptTreeView()
        {
            try
            {
                var list = (from u in _db.HrDeptMaster
                            where u.Parent == null
                            from mm in _db.HrDeptMaster.Where(m => m.Id == u.Parent && m.IsDelete == false).DefaultIfEmpty()
                            select new DeptModel
                            {
                                Id = u.Id.ToString(),
                                EnName = u.EnName,
                                HasChildren = _db.HrDeptMaster.Any(m => m.Parent == u.Id),
                                DeptCode = u.Code
                            }).ToList();

                return list.OrderBy(c => c.Code).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<UserModel> GetUsers(int searchType, string userId, string userName, string status, int deptCode, string sex, string nation, bool? hasEmail)
        {
            try
            {
                var item = (from u in _db.SP_SYS_USER_LIST(searchType, userId, userName, deptCode, sex == "" ? null : sex, nation == "" ? null : nation, hasEmail)
                            select new UserModel
                            {
                                LoginID = u.Code,
                                Name = u.LocalName,
                                Email = u.Email,
                                OrganizeName = u.OrganizationName,
                                PlantName = u.PlantName,
                                DeptName = u.DeptName,
                                SectionName = u.SectName,
                                StatusName = u.NAME,
                                DeptFullName = u.DeptFullName,
                                DeptId = u.DeptId,
                                CostCenter = u.Costcenter
                            }).ToList();

                return item;
            }
            catch (Exception ex)
            {
                LogHelper.Error("UserRepository: GetUsers: " + ex.Message + " Exception: " + ex.InnerException.Message);
                return null;
            }
        }
    }
}