using SSO_Material.Models;
using SSO_Material.Utilities;
using SSO_Material.ViewModels.SecurityApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO_Material.Repositories.SecurityApplication
{
    public class VisitorApplicationMasterRepository
    {
        PortalEntities _db = new PortalEntities();
        #region Visitor Application Master
        public List<VisitorApplicationMasterModel> GetAll(int? id, DateTime? fromDate, DateTime? toDate, int? applicationType, string userId, string approvalStatus)
        {
            try
            {
                var list = (from l in _db.SP_VISITOR_APPLICATION_MASTER_GET(id, fromDate, toDate, applicationType, userId, approvalStatus)
                            select new VisitorApplicationMasterModel()
                            {
                                Id = l.Id,
                                Code = l.Code,

                                Applicant = l.Applicant,
                                ApplicantName = l.ApplicantName,
                                PhoneNumber = l.PhoneNumber,
                                HandPhoneNumber = l.HandPhoneNumber,

                                Purpose = l.Purpose.ToString(),
                                PurposeName = l.PurposeName,
                                Gate = l.Gate.ToString(),
                                GateName = l.GateName,
                                ApplicationType = l.ApplicationType,
                                ApplicationTypeName = l.ApplicationTypeName,
                                FromDate = l.FromDate,
                                ToDate = l.ToDate,

                                ApprovalKind = l.ApprovalKind.ToString(),
                                ApprovalKindName = l.KindName,
                                ApprovalLineJson = l.ApprovalLineJson,
                                ApprovalLine = l.ApprovalLine,
                                ApprovalStatus = l.ApprovalStatus.ToString(),
                                ApprovalStatusName = l.ApprovalStatusName,
                                NextApprover = l.NextApprover,
                                NextApproverName = l.NextApproverName,
                                ConfirmDate = l.ConfirmDate,

                                Location = l.Location,
                                LocationName = l.LocationName,
                                LocationOther = l.LocationOther,

                                Vendor = l.Vendor,
                                VendorName = l.CompanyName,
                                ContactPerson = l.ContactPerson,
                                ContactNumber = l.ContactPhone,
                                ContactEmail = l.ContactEmail,
                                VendorAddress = l.VendorAddress,

                                OrgName = l.OrgName,
                                PlantName = l.PlantName,
                                DeptName = l.DeptName,
                                SectionName = l.SectName,

                                CreateUid = l.CreateUid,
                                CreateName = l.CreateName,
                                CreateDate = l.CreateDate
                            }).ToList();
                foreach (var item in list)
                {
                    item.IdEncrypt = Util.Encrypt(item.Id.ToString() + "_" + item.ApplicationType.ToString() + "_" + string.Format("hhss", DateTime.Now));
                }
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository GetAll: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return null;
            }
        }
        public VisitorApplicationMasterModel GetMasterDetail(int id, string userId)
        {
            try
            {
                var list = (from l in _db.SP_VISITOR_APPLICATION_MASTER_GETDETAIL(id, userId)
                            select new VisitorApplicationMasterModel()
                            {
                                Id = l.Id,
                                Code = l.Code,

                                Applicant = l.Applicant,
                                ApplicantName = l.ApplicantName,
                                PhoneNumber = l.PhoneNumber,
                                HandPhoneNumber = l.HandPhoneNumber,

                                Purpose = l.Purpose.ToString(),
                                PurposeName = l.PurposeName,
                                Gate = l.Gate.ToString(),
                                GateName = l.GateName,
                                ApplicationType = l.ApplicationType,
                                ApplicationTypeName = l.ApplicationTypeName,
                                FromDate = l.FromDate,
                                ToDate = l.ToDate,

                                ApprovalKind = l.ApprovalKind.ToString(),
                                ApprovalKindName = l.KindName,
                                ApprovalLineJson = l.ApprovalLineJson,
                                ApprovalLine = l.ApprovalLine,
                                ApprovalStatus = l.ApprovalStatus.ToString(),
                                ApprovalStatusName = l.ApprovalStatusName,
                                NextApprover = l.NextApprover,
                                NextApproverName = l.NextApproverName,
                                ConfirmDate = l.ConfirmDate,

                                Location = l.Location,
                                LocationName = l.LocationName,
                                LocationOther = l.LocationOther,

                                Vendor = l.Vendor,
                                VendorName = l.CompanyName,
                                ContactPerson = l.ContactPerson,
                                ContactNumber = l.ContactPhone,
                                ContactEmail = l.ContactEmail,
                                VendorAddress = l.VendorAddress,

                                OrgName = l.OrgName,
                                PlantName = l.PlantName,
                                DeptName = l.DeptName,
                                SectionName = l.SectName,

                                CreateUid = l.CreateUid,
                                CreateName = l.CreateName,
                                CreateDate = l.CreateDate,

                                IsRecall = l.IsRecall ?? false
                            }).FirstOrDefault();

                list.IdEncrypt = Util.Encrypt(list.Id.ToString() + "_" + list.ApplicationType.ToString() + "_" + string.Format("hhss", DateTime.Now));
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository GetDetail: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return null;
            }
        }
        public int ApplicationMasterInsert(VisitorApplicationMasterModel model, string userId)
        {
            try
            {
                var result = (_db.SP_VISITOR_APPLICATION_MASTER_INSERT(model.DeptId, model.Applicant, model.PhoneNumber, model.HandPhoneNumber, model.ApplicationType,
                                                                        model.Vendor, model.Purpose, model.FromDate, model.ToDate, model.Gate, model.Location, model.LocationOther, model.Remark, userId)).FirstOrDefault();
                return int.Parse(result.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository ApplicationMasterInsert: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return 0;
            }
        }
        public string ApplicationMasterUpdate(VisitorApplicationMasterModel model, string userId)
        {
            try
            {
                _db.SP_VISITOR_APPLICATION_MASTER_UPDATE(model.Id, model.DeptId, model.Applicant, model.PhoneNumber, model.HandPhoneNumber, model.ApplicationType,
                                                                        model.Vendor, model.Purpose, model.FromDate, model.ToDate, model.Gate, model.Location, model.LocationOther, model.Remark, userId);
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository ApplicationMasterUpdate: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.ToString();
            }
        }

        public string ApplicationMasterUpdateAll(VisitorApplicationMasterModel model, string userId)
        {
            try
            {
                _db.SP_VISITOR_APPLICATION_MASTER_UPDATE_ALLDATA(model.Id, model.ApplicationType, model.ApprovalLine, model.ApprovalLineJson, userId);
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository ApplicationMasterUpdateAll: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.ToString();
            }
        }

        public string ApplicationMasterDelete(int id)
        {
            try
            {
                _db.SP_VISITOR_APPLICATION_MASTER_DELETE(id);
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository ApplicationMasterDelete: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.ToString();
            }
        }

        public string ApplicationMasterDeleteUpdate(int id, string userId)
        {
            try
            {
                var item = (from d in _db.VisitorApplicationMaster
                            where d.Id == id
                            select d).FirstOrDefault();
                if (item == null)
                    return "Not found";
                item.DeleteDate = DateTime.Now;
                item.DeleteUid = userId;
                _db.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository ApplicationDelete: " + ex.Message + " Inner exception: " + ex.InnerException.Message);
                return ex.InnerException.Message;
            }
        }


        #region Detail
        public List<VisitorApplicationDetailModel> GetDetail(int? applicationMasterId, int? Id)
        {
            if (applicationMasterId == 0)
                return null;
            try
            {
                var list = (from l in _db.SP_VISITOR_APPLICATION_DETAIL_GET(applicationMasterId, Id)
                            select new VisitorApplicationDetailModel()
                            {
                                Id = l.Id,
                                ApplicationMaster = l.ApplicationMaster,
                                Image = l.Image,
                                FullName = l.FullName,
                                IdentityCard = l.IdentityCard,
                                TemporaryCard = l.TemporaryCard,
                                PhoneNumber = l.PhoneNumber,
                                FromDate = l.FromDate,
                                ToDate = l.ToDate,
                                DriverPlate = l.DriverPlate,
                                VehicleType = l.VehicleType.ToString(),
                                VehicleTypeName = l.VehicleTypeName,
                                IsWorkHourOfficial = l.IsWorkHourOfficial ?? true
                            }).ToList();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository GetDetail: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return null;
            }
        }

        public string DetailInsert(VisitorApplicationDetailModel model, string userId)
        {
            try
            {
                var result = (from i in _db.SP_VISITOR_APPLICATION_DETAIL_INSERT(model.ApplicationMaster, model.Image, model.FullName, model.IdentityCard, model.TemporaryCard, model.PhoneNumber,
                                                    model.FromDate, model.ToDate, model.DriverPlate, model.VehicleType, model.IsWorkHourOfficial, userId)
                              select i).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository DetailInsert: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.ToString();
            }
        }

        public string DetailUpdate(VisitorApplicationDetailModel model, string userId)
        {
            try
            {
                var result = (from i in _db.SP_VISITOR_APPLICATION_DETAIL_UPDATE(model.Id, model.ApplicationMaster, model.Image, model.FullName, model.IdentityCard, model.TemporaryCard, model.PhoneNumber,
                                                    model.FromDate, model.ToDate, model.DriverPlate, model.VehicleType, model.IsWorkHourOfficial, userId)
                              select i).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository DetailUpdate: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.ToString();
            }
        }

        public string DetailDelete(int id, string userId)
        {
            try
            {
                _db.SP_VISITOR_APPLICATION_DETAIL_DELETE(id, userId);
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository DetailUpdate: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.ToString();
            }
        }

        #endregion

        #endregion
        #region Vendor
        public List<VendorModel> GetListVendor(int? id, DateTime fromDate, DateTime toDate, string userId)
        {
            try
            {
                var list = (from l in _db.SP_VENDOR_GET(id, userId, fromDate, toDate)
                            select new VendorModel()
                            {
                                Id = l.Id,
                                CompanyName = l.CompanyName,
                                Address = l.Address,
                                DeptId = l.DeptId,
                                PersonInCharge = l.PersonInCharge,
                                PersonInChargeName = l.PersonInChargeName,
                                ContactPerson = l.ContactPerson,
                                IdentityCard = l.IdentityCard,
                                PhoneNumber = l.PhoneNumber,
                                Email = l.Email,
                                IsActive = l.IsActive,
                                CreateUid = l.CreateUid,
                                CreateDate = l.CreateDate,
                                OrgName = l.OrganizationName,
                                PlantName = l.PlantName,
                                DeptName = l.DeptName,
                                SectName = l.SectName,
                                CreateName = l.CreateName
                            }).ToList();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository GetListVendor: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return null;
            }
        }
        public string VendorInsert(VendorModel model, string userId)
        {
            try
            {
                if (model == null)
                    return "Model null";
                _db.SP_VENDOR_INSERT(model.CompanyName, model.Address, model.DeptId, model.PersonInCharge, model.ContactPerson, model.IdentityCard, model.PhoneNumber, model.Email, model.IsActive, userId);
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository VendorInsert: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.InnerException.Message;
            }
        }
        public string VendorUpdate(VendorModel model, string userId)
        {
            try
            {
                if (model == null)
                    return "Model null";
                _db.SP_VENDOR_UPDATE(model.Id, model.CompanyName, model.Address, model.DeptId, model.PersonInCharge, model.ContactPerson, model.IdentityCard, model.PhoneNumber, model.Email, model.IsActive, userId);
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository VendorUpdate: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.InnerException.Message;
            }
        }
        public string VendorDelete(int id, string userId)
        {
            try
            {
                _db.SP_VENDOR_DELETE(id, userId);
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository VendorDelete: " + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return ex.InnerException.Message;
            }
        }
        #endregion
        #region Common
        public string GetDefaultApproval(int applicationId)
        {
            try
            {

                var approvalLine = (from l in _db.ApplicationConfig
                                    where l.Id == applicationId
                                    select l.ApprovalLineJson + "|" + l.ApprovalKind.ToString()).FirstOrDefault();
                return approvalLine;

            }
            catch (Exception ex)
            {
                LogHelper.Error("ApplicationConfigRepository GetDefaultApproval: " + applicationId.ToString() + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return null;
            }
        }

        public List<ApprovalHistoryModel> ApprovalHistoryGetList(string userId, int applicationId)
        {
            try
            {

                var list = (from d in _db.SP_APPROVAL_HISTORY(userId, applicationId)
                            select new ApprovalHistoryModel()
                            {
                                Id = d.Id,
                                ApprovalLine = d.ApprovalLine,
                                ApprovalLineJson = d.ApprovalLineJson,
                                CreateDate = d.CreateDate,
                                MasterId = d.MasterId,
                                ApplicationMasterName = d.ApplicationMasterName,
                                ApplicationSubject = d.ApplicationSubject,
                                ApplicationId = d.ApplicationId
                            }).ToList();
                if (list == null)
                    return null;
                foreach (var item in list)
                {
                    if (item.ApprovalLine.Split('|').Length == 5)
                    { 
                        item.ApprName = item.ApprovalLine == "" ? "" : item.ApprovalLine.Split('|')[1];
                        item.CirName = item.ApprovalLine == "" ? "" : item.ApprovalLine.Split('|')[4];
                    }
                }
                return list;

            }
            catch (Exception ex)
            {
                LogHelper.Error("ApplicationMasterRepository ApprovalHistoryGetList: " + ex.Message + " Inner exception: " + ex.InnerException.Message);
                return null;
            }
        }
        #endregion
        #region Approval
        public List<ApprovalModel> GetApproval(int applicationId, int masterId)
        {
            try
            {
                var list = (from l in _db.SP_VISITOR_APPLICATION_GET_APPROVAL(applicationId, masterId)
                            select new ApprovalModel()
                            {
                                Id = l.Id,
                                ApplicationId = l.ApplicationId,
                                MasterId = l.MasterId,
                                EmpId = l.EmpId,
                                EmpName = l.EmpName,
                                ApproverType = l.ApproverType.ToString(),
                                ApproverTypeName = l.ApproverTypeName,
                                IsApprove = l.IsApprove,
                                Comment = l.Comment,
                                DateApprove = l.DateApprove,
                                Seq = l.Seq
                            }).ToList();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error("ApplicationConfigRepository GetApproval: " + applicationId.ToString() + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return null;
            }

        }
        public List<ApprovalModel> GetApprovalHistory(int applicationId, int masterId)
        {
            try
            {
                var list = (from l in _db.SP_VISITOR_APPLICATION_MASTER_APPROVAL_HISTORY(masterId, applicationId)
                            select new ApprovalModel()
                            {
                                Id = l.Id ?? 0,
                                EmpId = l.EmpId,
                                EmpName = l.EmpName,
                                ApproverType = l.ApprovalType.ToString(),
                                ApproverTypeName = l.ApproverTypeName,
                                IsApprove = l.IsApprove,
                                Comment = l.Comment,
                                DateApprove = l.DateApprove,
                                DateApproveFormat = l.DateApproveFormat,
                                Seq = l.Seq ?? 0
                            }).ToList();
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.Error("ApplicationConfigRepository GetApprovalHistory: " + applicationId.ToString() + ex.Message + " Inner Exception: " + ex.InnerException.Message);
                return null;
            }
        }
        public string ApplicationConfirm(int id, bool isConfirm, string linkApplication)
        {
            try
            {
                var result = _db.SP_VISITOR_APPLICATION_MASTER_CONFIRM(id, isConfirm, linkApplication);
                return "Ok";
            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository ApplicationConfirm: " + ex.Message + " Inner exception: " + ex.InnerException.Message);
                return ex.InnerException.Message;
            }
        }
        public string ApproveApplication(ApprovalModel model, string userId)
        {
            try
            {
                if (model == null)
                    return "Error: model null";

                var result = _db.SP_VISITOR_APPLICATION_MASTER_APPROVE(model.MasterId, model.ApplicationId, model.IsApprove, model.Comment, userId, model.LinkApplication);
                return "Ok";

            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository ApproveApplication: " + ex.Message + " Inner exception: " + ex.InnerException.Message);
                return ex.InnerException.Message;
            }
        }
        public string RecallApplication(int masterId, int applicationId, string userId)
        {
            try
            {

                var result = _db.SP_VISITOR_APPLICATION_MASTER_RECALL(masterId, applicationId, userId);
                return "Ok";

            }
            catch (Exception ex)
            {
                LogHelper.Error("VisitorApplicationMasterRepository RecallApplication: " + ex.Message + " Inner exception: " + ex.InnerException.Message);
                return ex.InnerException.Message;
            }
        }
        #endregion
    }
}