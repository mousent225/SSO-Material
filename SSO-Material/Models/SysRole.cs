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
    
    public partial class SysRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SysRole()
        {
            this.SysRoleMapping = new HashSet<SysRoleMapping>();
            this.SysUserMapping = new HashSet<SysUserMapping>();
        }
    
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public Nullable<int> SystemId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public string DeleteUser { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysRoleMapping> SysRoleMapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysUserMapping> SysUserMapping { get; set; }
    }
}
