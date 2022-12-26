using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    public class Logs
    {
        public string IDOfUserLog { get; set; }
        public string Operation { get; set; }
        public string NameOfProductLog { get; set; }
        public string Editing { get; set; }
        public string TimeToEdit { get; set; }
    }
}
