using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWarehouse.Models
{
    public class Dairy: Product
    {
        public int NumberOfPackages { get; set; }
        public int PricePerPack { get; set; }

        public static implicit operator Dairy(ObservableCollection<Dairy> v)
        {
            throw new NotImplementedException();
        }
    }
}
