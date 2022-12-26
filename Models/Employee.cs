using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    public class Employee : User
    {
        public override string TypeOfUser { get => base.TypeOfUser = "employee"; }
        public string ToAdd { get; set; }
        public string ToEdit { get; set; }
        public string ToDelete { get; set; }
    }
}
