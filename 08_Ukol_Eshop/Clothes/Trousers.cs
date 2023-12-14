using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_Ukol_Eshop.Enums;

namespace _08_Ukol_Eshop.Clothes
{
    public enum TrousersType
    {
        Shorts,
        Jeans,
        Swaetpants,
        Skirt
    }
    public class Trousers : Clothes
    {
        public TrousersType Type;
        public Sizes Size;
        public bool ComesWithBelt;
        public Trousers(TrousersType type, Sizes size, Sex sex, Color color, double price, string brand, int quantityInStock) : base(sex, color, price, brand, quantityInStock)
        {
            Type = type;
            ComesWithBelt = false;
        }

        public Trousers(TrousersType type, Sizes size, Sex sex, Color color, double price, string brand, int quantityInStock, bool comesWithBelt) : this(type, size, sex, color, price, brand, quantityInStock)
        {
            ComesWithBelt = comesWithBelt;
        }
    }
}
