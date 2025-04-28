using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGrocerLib
{
    public class Produce
    {
        public int Barcode { get; set; }
        public string Description {  get; set; }
        public string Amount { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public Produce(int barcode, string description, string amount, double price, int quantity, string image) 
        {
            Barcode = barcode;
            Description = description;
            Amount = amount;
            Price = price;
            Quantity = quantity;
            Image = image;
        }

        public Produce() 
        {
            Barcode = -1;
            Description = "Default";
            Amount = "Default";
            Price = 0;
            Quantity = 0;
            Image = "";
        }
    }
}
