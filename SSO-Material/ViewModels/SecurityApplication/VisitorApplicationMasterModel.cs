﻿using System;

namespace SSO_Material.ViewModels.SecurityApplication
{
    public class VisitorApplicationMasterModel
    {
        public int Id { get; set; }
        public string IdEncrypt { get; set; }
        public string Code { get; set; }
        public string Applicant { get; set; }
        public string PhoneNumber { get; set; }
        public string HandPhoneNumber { get; set; }
        public string ApplicantName { get; set; }
        public int ApplicationType { get; set; }
        public string ApplicationTypeName { get; set; }

        public string Purpose { get; set; }
        public string PurposeName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Gate { get; set; }
        public string GateName { get; set; }
        public string Location { get; set; }
        public string LocationName { get; set; }
        public string LocationOther { get; set; }
        public string Remark { get; set; }

        public string ApprovalKind { get; set; }
        public string ApprovalKindName { get; set; }
        public string ApprovalLine { get; set; }
        public string ApprovalLineJson { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public string NextApprover { get; set; }
        public string NextApproverName { get; set; }
        public DateTime? ConfirmDate { get; set; }

        public string OrgName { get; set; }
        public string PlantName { get; set; }
        public string DeptName { get; set; }
        public int DeptId { get; set; }
        public string SectionName { get; set; }

        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public int Vendor { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }

        public bool Temp { get; set; }
        public string CreateUid { get; set; }
        public string CreateName { get; set; }
        public DateTime CreateDate { get; set; }

        public bool IsRecall { get; set; }
    }

    public class VisitorApplicationDetailModel
    {
        public int Id { get; set; }
        public int ApplicationMaster { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public string TemporaryCard { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string DriverPlate { get; set; }
        public string VehicleType { get; set; }
        public string VehicleTypeName { get; set; }
        public bool IsContactPerson { get; set; }
        public bool IsWorkHourOfficial { get; set; }
    }

    public class VendorModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int DeptId { get; set; }
        public string PersonInCharge { get; set; }
        public string PersonInChargeName { get; set; }
        public string ContactPerson { get; set; }
        public string IdentityCard { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreateUid { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string OrgName { get; set; }
        public string PlantName { get; set; }
        public string DeptName { get; set; }
        public string SectName { get; set; }
        public string CreateName { get; set; }
    }
    public class ApprovalHistoryModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicationMasterName { get; set; }
        public int MasterId { get; set; }
        public string ApplicationSubject { get; set; }
        public string ApprovalLine { get; set; }
        public string ApprovalLineJson { get; set; }
        public int CreateUid { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApprName { get; set; }
        public string CirName { get; set; }
    }

    public class ApprovalModel{
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int MasterId { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string ApproverType { get; set; }
        public string ApproverTypeName { get; set; }
        public bool? IsApprove { get; set; }
        public string Comment { get; set; }
        public DateTime? DateApprove { get; set; }
        public string DateApproveFormat { get; set; }
        public int Seq { get; set; }
        public string LinkApplication { get; set; }
    }
}