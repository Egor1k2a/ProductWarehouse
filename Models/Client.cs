using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    public class Client : User
    {
        public override string TypeOfUser { get => base.TypeOfUser = "client"; }
    }
}
