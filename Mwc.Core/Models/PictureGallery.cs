//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mwc.Core.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PictureGallery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PictureGallery()
        {
            this.PictureGalleryItems = new HashSet<PictureGalleryItem>();
        }
    
        public int GalleryId { get; set; }
        public string GalleryName { get; set; }
        public string GalleryDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PictureGalleryItem> PictureGalleryItems { get; set; }
    }
}
