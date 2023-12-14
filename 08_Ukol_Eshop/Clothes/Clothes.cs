using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_Ukol_Eshop.Enums;

namespace _08_Ukol_Eshop.Clothes
{
    public class Clothes
    {
        private static int s_clotheIdIncrementor = 1111;
        private int _itemsSold;
        public string ClotheId { get; }
        public Sex Sex;
        public double Price;
        public string Brand;
        public Color Color;
        public int QuantityInStock;

        public Clothes(Sex sex, Color color, double price, string brand, int quantityInStock)
        {
            ClotheId = s_clotheIdIncrementor.ToString();
            s_clotheIdIncrementor++;
            Sex = sex;
            Color = color;
            Price = price;
            Brand = brand;
            QuantityInStock = quantityInStock;

        }
        public string Sell(int quantity)
        {
            if (quantity < 1)
            {
                return $"Wrong input. You've entered either negative number or zero.";
            }
            else if (quantity < QuantityInStock)
            {
                QuantityInStock -= quantity;
                _itemsSold += quantity;
                return $"{quantity} item/s sold. Currently there are {QuantityInStock} items remaining.";
            }
            else
            {
                return $"There is not enough items in stock.\nThere are {QuantityInStock} items in stock.";
            }
        }

        public string StockUp(int quantity)
        {
            /// add some check input logic (cannot be negative, decimal, string, etc.)
            QuantityInStock += quantity;
            return $"{quantity} items were added in stock.";
        }

        public double CalculateRevenue()
        {
            return Convert.ToDouble(_itemsSold) * Price;
        }

        public string ShowDetails()
        {
            // Dopsat!!!
            return "This method will be implemented soon";
        }

    }
}
