//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSO_Material.Models
{
    using System;
    
    public partial class SP_VISITOR_APPLICATION_DETAIL_GET_Result
    {
        public int Id { get; set; }
        public int ApplicationMaster { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public string TemporaryCard { get; set; }
        public string PhoneNumber { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public string DriverPlate { get; set; }
        public Nullable<System.Guid> VehicleType { get; set; }
        public Nullable<bool> IsWorkHourOfficial { get; set; }
        public string VehicleTypeName { get; set; }
    }
}
