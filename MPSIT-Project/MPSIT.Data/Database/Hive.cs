//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPSIT.Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hive
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hive()
        {
            this.HiveInfoes = new HashSet<HiveInfo>();
            this.SensorDatas = new HashSet<SensorData>();
        }
    
        public int Id { get; set; }
        public int ApiaryId { get; set; }
        public string GUID { get; set; }
    
        public virtual Apiary Apiary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HiveInfo> HiveInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SensorData> SensorDatas { get; set; }
    }
}
