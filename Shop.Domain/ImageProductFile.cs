using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class ImageProductFile
    {
        public int ImageProductId { get; set; }
        public int FileId { get; set; }

        public virtual ImageProduct ImageProduct { get; set; }
        public virtual File File { get; set; }
    }
}
