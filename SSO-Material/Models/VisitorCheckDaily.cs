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
    using System.Collections.Generic;
    
    public partial class VisitorCheckDaily
    {
        public int Id { get; set; }
        public int ApplicationMaster { get; set; }
        public int ApplicationDetail { get; set; }
        public System.DateTime WorkDate { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public bool HasVehicle { get; set; }
        public string VehiclePlate { get; set; }
    
        public virtual VisitorApplicationMaster VisitorApplicationMaster { get; set; }
        public virtual VisitorApplicationDetail VisitorApplicationDetail { get; set; }
    }
}
