using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    class Admin : User
    {
        public override string TypeOfUser { get => base.TypeOfUser = "admin"; }
    }
}
