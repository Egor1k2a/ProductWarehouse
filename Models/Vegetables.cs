using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    public class Vegetables: Product
    {
        public int CollectionDay { get; set; }
        public int CollectionMonth { get; set; }
    }
}
