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
    
    public partial class Personel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personel()
        {
            this.Missions = new HashSet<Missions>();
            this.Missions1 = new HashSet<Missions>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public Nullable<int> Department { get; set; }
        public Nullable<bool> Delete { get; set; }
    
        public virtual Departments Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Missions> Missions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Missions> Missions1 { get; set; }
    }
}
