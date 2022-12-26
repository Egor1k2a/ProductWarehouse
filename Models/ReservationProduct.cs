using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    public class ReservationProduct
    {
        public string IDOfClient { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Condition { get; set; }
    }
}
