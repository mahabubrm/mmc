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
    
    public partial class PictureGalleryItem
    {
        public int PicId { get; set; }
        public Nullable<int> GalleryId { get; set; }
        public string PictureName { get; set; }
        public string PictureTitle { get; set; }
        public Nullable<int> DisplaySL { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual PictureGallery PictureGallery { get; set; }
    }
}
