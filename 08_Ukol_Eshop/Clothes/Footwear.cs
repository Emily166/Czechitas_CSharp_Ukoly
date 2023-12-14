using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_Ukol_Eshop.Enums;

namespace _08_Ukol_Eshop.Clothes
{

    public enum FootwearType
    {
        Sneakers,
        Boots,
        Heels,
        FlipFlops
    }

    public class Footwear : Clothes
    {

        private int _size;
        public FootwearType Type;

        public int Size
        {
            get { return _size; }
            set
            {
                if (IsValidSize(value))
                {
                    _size = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("We don't sell this size of shoes.");
                }
            }
        }
        public Footwear(FootwearType type, int size, Sex sex, Color color, double price, string brand, int quantityInStock) : base(sex, color, price, brand, quantityInStock)
        {
            Size = size;
        }

        private bool IsValidSize(int size)
        {
            return size > 34 && size < 49;
        }
    }
}
