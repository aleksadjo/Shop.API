using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class ImageProduct : Product
    {
        public virtual ICollection<ImageProductFile> Images { get; set; } = new HashSet<ImageProductFile>();
    }
}
