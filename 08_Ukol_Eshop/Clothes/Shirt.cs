using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_Ukol_Eshop.Enums;
using _08_Ukol_Eshop.Clothes;

namespace _08_Ukol_Eshop.Clothes
{
    // OTAZKY:
    // - kdyz mam enum, ktery se tyka takto pouze jedne tridy, jaky je 'best-practise'? Nechat to ve stejnem souboru a nebo to i presto presunou do samostatneho souboru, jako mam napriklad 'Sizes.cs'?
    // - Je pouziti enum v tomto pripade na miste? Chtela jsem omezit uzivatele, aby tam nemohl zadavat nesmyslne imputy (napr. typ tricka "2zxc892asdf"). Je tedy vhodne pouzit enum, aby se tomuto zamezilo a nebo spiz pouzit nejaky jiny check uvnitr tridy?
    public enum Upperwear
    {
        Jacket,
        TShirt,
        Shirt,
        Sweater,
        Blouse
    }

    public class Shirt : Clothes
    {
        public Upperwear Type;
        public Sizes Size;
        public bool LongSleeves;
        public bool HasHood;
        //public bool HasPockets;
        public bool HasZip;



        public Shirt(Upperwear type, Sizes size, Sex sex, Enums.Color color, double price, string brand, int quantityInStock) : base(sex, color, price, brand, quantityInStock)
        {
            Type = type;
            Size = size;
            //HasZip = false;
            //HasHood = false;
            //HasPockets = false;
        }

        public Shirt(Upperwear type, Sizes size, Sex sex, Enums.Color color, double price, string brand, int quantityInStock, bool hasLLongSleeves, bool hasZip, bool hasHood) : this(type, size, sex, color, price, brand, quantityInStock)
        {
            LongSleeves = hasLLongSleeves;
            HasZip = hasZip;
            HasHood = hasHood;
            //HasPockets = hasPockets;
        }

    }
}
