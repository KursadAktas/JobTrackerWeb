//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobTrackerWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Companies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Companies()
        {
            this.Call = new HashSet<Call>();
            this.Messages = new HashSet<Messages>();
            this.Messages1 = new HashSet<Messages>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Authorized { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Sektor { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Call> Call { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Messages> Messages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Messages> Messages1 { get; set; }
    }
}
