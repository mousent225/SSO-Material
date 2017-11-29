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
    
    public partial class HrEmpMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HrEmpMaster()
        {
            this.SysCategory = new HashSet<SysCategory>();
            this.SysCategoryValue = new HashSet<SysCategoryValue>();
            this.SysCategoryValue1 = new HashSet<SysCategoryValue>();
            this.SysCategory1 = new HashSet<SysCategory>();
            this.SysCategory2 = new HashSet<SysCategory>();
            this.SysCategoryValue2 = new HashSet<SysCategoryValue>();
            this.ApplicationConfig = new HashSet<ApplicationConfig>();
            this.ApplicationConfig1 = new HashSet<ApplicationConfig>();
            this.SysUserMapping = new HashSet<SysUserMapping>();
        }
    
        public string EmpId { get; set; }
        public string Code { get; set; }
        public string LocalName { get; set; }
        public string KoName { get; set; }
        public string EnName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Nation { get; set; }
        public string PositionId { get; set; }
        public bool Status { get; set; }
        public int DeptCode { get; set; }
        public byte[] Img { get; set; }
        public string WorkGroup { get; set; }
        public string Temp { get; set; }
        public Nullable<int> FactoryId { get; set; }
        public string Password { get; set; }
        public System.Guid uStatus { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> InterfaceDate { get; set; }
        public Nullable<System.DateTime> ActiveDate { get; set; }
        public string Costcenter { get; set; }
        public string JobTitleId { get; set; }
        public string JoinDate { get; set; }
        public Nullable<System.Guid> UserType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysCategory> SysCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysCategoryValue> SysCategoryValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysCategoryValue> SysCategoryValue1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysCategory> SysCategory1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysCategory> SysCategory2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysCategoryValue> SysCategoryValue2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationConfig> ApplicationConfig { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationConfig> ApplicationConfig1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysUserMapping> SysUserMapping { get; set; }
    }
}