using Mwc.Core.DataLayer.Interface;
using Mwc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.DataLayer.Repository
{
    public class PictureGalleryItemRepository : BaseRepository<PictureGalleryItem>, IPictureGalleryItems, IDisposable
    {
        public MWCEntities context
        {
            get
            {
                return _db as MWCEntities;
            }
        }

        public PictureGalleryItemRepository() : base(new MWCEntities())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
