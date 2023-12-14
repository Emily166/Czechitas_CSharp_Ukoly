using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_Ukol_Eshop.Clothes;
using _08_Ukol_Eshop.Enums;

namespace _08_Ukol_Eshop
{
    public class ContentLoader
    {
        public List<Clothes.Clothes> List = new List<Clothes.Clothes>();
        //public ContentLoader(List<Clothes.Clothes> list)
        //{
        //    List = list;
        //}

        public static void LoadItems(List<Clothes.Clothes> items)
        {
            items.Add(new Shirt(Upperwear.TShirt, Sizes.S, Sex.Female, Color.Black, 400, "Brand 1", 15));
            items.Add(new Shirt(Upperwear.TShirt, Sizes.S, Sex.Female, Color.White, 400, "Brand 1", 2));
            //items.Add(new Shirt(Upperwear.TShirt, Sizes.M, Sex.Female, Color.White, 400, "Brand 1", 15));
            //items.Add(new Shirt(Upperwear.TShirt, Sizes.M, Sex.Female, Color.Black, 400, "Brand 1", 15));
            //items.Add(new Shirt(Upperwear.TShirt, Sizes.L, Sex.Female, Color.White, 400, "Brand 1", 15));
            //items.Add(new Shirt(Upperwear.TShirt, Sizes.L, Sex.Female, Color.Black, 400, "Brand 1", 15));

            //items.Add(new Shirt(Upperwear.TShirt, Sizes.S, Sex.Male, Color.Black, 400, "Brand 1", 15));
            //items.Add(new Shirt(Upperwear.TShirt, Sizes.S, Sex.Male, Color.White, 400, "Brand 1", 15));
            //items.Add(new Shirt(Upperwear.TShirt, Sizes.M, Sex.Male, Color.White, 400, "Brand 1", 15));
            //items.Add(new Shirt(Upperwear.TShirt, Sizes.M, Sex.Male, Color.Black, 400, "Brand 1", 15));
            //items.Add(new Shirt(Upperwear.TShirt, Sizes.L, Sex.Male, Color.White, 400, "Brand 1", 15));
            items.Add(new Shirt(Upperwear.TShirt, Sizes.L, Sex.Male, Color.Black, 400, "Brand 1", 0));

            //items.Add(new Shirt(Upperwear.Sweater, Sizes.S, Sex.Female, Color.Blue, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.S, Sex.Female, Color.Red, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.M, Sex.Female, Color.Blue, 800, "Brand 2", 10));
            items.Add(new Shirt(Upperwear.Sweater, Sizes.M, Sex.Female, Color.Red, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.L, Sex.Female, Color.Blue, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.L, Sex.Female, Color.Red, 800, "Brand 2", 10));

            //items.Add(new Shirt(Upperwear.Sweater, Sizes.S, Sex.Male, Color.Blue, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.S, Sex.Male, Color.Red, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.M, Sex.Male, Color.Blue, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.M, Sex.Male, Color.Red, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.L, Sex.Male, Color.Blue, 800, "Brand 2", 10));
            //items.Add(new Shirt(Upperwear.Sweater, Sizes.L, Sex.Male, Color.Red, 800, "Brand 2", 10));

            //items.Add(new Trousers(TrousersType.Jeans, Sizes.S, Sex.Female, Color.Blue, 1000, "Brand 3", 30));
            items.Add(new Trousers(TrousersType.Jeans, Sizes.M, Sex.Female, Color.Blue, 1000, "Brand 3", 30));
            //items.Add(new Trousers(TrousersType.Jeans, Sizes.L, Sex.Female, Color.Blue, 1000, "Brand 3", 30));

            //items.Add(new Trousers(TrousersType.Jeans, Sizes.S, Sex.Male, Color.Blue, 1000, "Brand 3", 30));
            //items.Add(new Trousers(TrousersType.Jeans, Sizes.M, Sex.Male, Color.Blue, 1000, "Brand 3", 30));
            //items.Add(new Trousers(TrousersType.Jeans, Sizes.L, Sex.Male, Color.Blue, 1000, "Brand 3", 30));

            items.Add(new Trousers(TrousersType.Skirt, Sizes.S, Sex.Female, Color.Black, 1200, "Brand 3", 10));
            //items.Add(new Trousers(TrousersType.Skirt, Sizes.M, Sex.Female, Color.Black, 1200, "Brand 3", 10));
            //items.Add(new Trousers(TrousersType.Skirt, Sizes.L, Sex.Female, Color.Black, 1200, "Brand 3", 10));

            //items.Add(new Trousers(TrousersType.Shorts, Sizes.S, Sex.Male, Color.Black, 700, "Brand 3", 10));
            //items.Add(new Trousers(TrousersType.Shorts, Sizes.M, Sex.Male, Color.Black, 700, "Brand 3", 10));
            //items.Add(new Trousers(TrousersType.Shorts, Sizes.L, Sex.Male, Color.Black, 700, "Brand 3", 10));

            items.Add(new Footwear(FootwearType.Boots, 38, Sex.Female, Color.Brown, 1600, "Brand 4", 5));
            //items.Add(new Footwear(FootwearType.Boots, 39, Sex.Female, Color.Brown, 1600, "Brand 4", 5));
            //items.Add(new Footwear(FootwearType.Boots, 40, Sex.Female, Color.Brown, 1600, "Brand 4", 5));

            //items.Add(new Footwear(FootwearType.Boots, 44, Sex.Male, Color.Brown, 1600, "Brand 4", 5));
            //items.Add(new Footwear(FootwearType.Boots, 45, Sex.Male, Color.Brown, 1600, "Brand 4", 5));
            //items.Add(new Footwear(FootwearType.Boots, 46, Sex.Male, Color.Brown, 1600, "Brand 4", 5));

            //items.Add(new Footwear(FootwearType.Sneakers, 38, Sex.Female, Color.White, 1600, "Brand 4", 10));
            //items.Add(new Footwear(FootwearType.Sneakers, 39, Sex.Female, Color.White, 1600, "Brand 4", 10));
            //items.Add(new Footwear(FootwearType.Sneakers, 40, Sex.Female, Color.White, 1600, "Brand 4", 10));

            //items.Add(new Footwear(FootwearType.Sneakers, 44, Sex.Male, Color.White, 1600, "Brand 4", 5));
            //items.Add(new Footwear(FootwearType.Sneakers, 45, Sex.Male, Color.White, 1600, "Brand 4", 5));
            //items.Add(new Footwear(FootwearType.Sneakers, 46, Sex.Male, Color.White, 1600, "Brand 4", 5));

        }

    }
}
