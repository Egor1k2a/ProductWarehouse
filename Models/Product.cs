using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    public abstract class Product
    {
        public virtual int ID { get; set; }
        public virtual string NameOfProduct { get; set; }
        public virtual float PricePerKilogram { get; set; }
        public virtual float TotalKilogram { get; set; }
        public virtual string TypeOfProduct { get; set; }
    }
}
