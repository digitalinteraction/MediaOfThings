//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenLab.Kitchen.StorageRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThingData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThingData()
        {
            this.ThingDataFieldValues = new HashSet<ThingDataFieldValue>();
        }
    
        public int Id { get; set; }
        public int ThingDataTypeId { get; set; }
        public int ThingId { get; set; }
        public string Name { get; set; }
    
        public virtual ThingDataType ThingDataType { get; set; }
        public virtual Thing Thing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThingDataFieldValue> ThingDataFieldValues { get; set; }
    }
}
