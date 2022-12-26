using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    public class Fish: Product
    {
        public string FishCondition { get; set; }
        public string FishType { get; set; }
    }
}
