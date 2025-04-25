using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGrocerLib
{
    public class UpdateProduceDTO
    {
        public string? Item { get; set; }
        public string? Amount { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Image { get; set; }
    }
}
