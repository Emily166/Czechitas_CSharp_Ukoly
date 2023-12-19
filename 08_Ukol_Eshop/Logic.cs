using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;
using _08_Ukol_Eshop.Clothes;
using _08_Ukol_Eshop.Enums;

namespace _08_Ukol_Eshop
{
    public class Logic
    {
        public List<Clothes.Clothes> eshop = new();

        public Logic()
        {
            ContentLoader.LoadItems(eshop);
        }
        public string ShowEshop(List<Clothes.Clothes> shop)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID".PadRight(10) + "TYPE".PadRight(10) + "SEX".PadRight(10) + "BRAND".PadRight(10) + "SIZE".PadRight(10) + "PRICE".PadRight(10));
            foreach (var item in shop)
            {
                string id = item.ClotheId.PadRight(10);
                sb.Append(id);
                string type = GetType(item).PadRight(10);
                sb.Append(type);
                string sex = item.Sex.ToString().PadRight(10);
                sb.Append(sex);
                string brand = item.Brand.PadRight(10);
                sb.Append(brand);
                string size = GetSize(item).PadRight(10);
                sb.Append(size);
                string price = ((item.Price).ToString() + " CZK").PadRight(10);
                sb.Append(price);
                if (item.QuantityInStock == 0)
                {
                    sb.Append("OUT OF STOCK".PadRight(10));
                }
                else if (0 < item.QuantityInStock && item.QuantityInStock < 3)
                {
                    sb.Append($"Stock up soon! {item.QuantityInStock} items left");
                }
                else
                {
                    sb.Append($"{item.QuantityInStock} in stock");
                }
                
                sb.AppendLine("");
            }
            return sb.ToString();
        }

        private string GetType(Clothes.Clothes item)
        {
            if (item is Shirt shirt)
            {
                return $"{shirt.Type}";

            }
            else if (item is Trousers trousers)
            {
                return $"{trousers.Type}";
            }
            else if (item is Footwear footwear)
            {
                return $"{footwear.Type}";
            }
            else
            {
                throw new Exception("Couldn't get a type of a cloth.");
            }
        }

        private string GetSize(Clothes.Clothes item)
        {
            if (item is Footwear shoes)
            {
                return $"size: {shoes.Size}";
            }
            else if (item is Trousers trousers)
            {
                return $"size: {trousers.Size}";

            }
            else if (item is Shirt shirt)
            {
                return $"size: {shirt.Size}";
            }
            else
            {
                throw new Exception("Couldn't get a size of an item");
            }
        }
        public void ShowMainMenu()
        {
            string userInput;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n******************");
                Console.WriteLine("*     E-SHOP     *");
                Console.WriteLine("******************");
                Console.ResetColor();

                Console.WriteLine("1. Show all items in e-shop");
                Console.WriteLine("2. Sell item");
                Console.WriteLine("3. Stock up item");
                Console.WriteLine("4. Show revenue");
                Console.WriteLine("5. Add new type of item");
                Console.WriteLine("0. Quit program");

                string[] validInput = new[] { "1", "2", "3", "4", "5", "0" };
                Console.WriteLine("");
                Console.Write("Your selection: ");
                userInput = Console.ReadLine().Trim();

                while (String.IsNullOrEmpty(userInput) || !validInput.Contains(userInput))
                {
                    Console.WriteLine("You have entered an invalid input. Please try again.");
                    Console.Write("Your selection: ");
                    userInput = Console.ReadLine().Trim();
                }

                switch (userInput)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SHOW E-SHOP ");
                        Console.ResetColor();
                        Console.WriteLine(ShowEshop(eshop));
                        break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SELL ITEM");
                        Console.ResetColor();

                        if (IsEshopEmpty()) 
                            break;
                        
                        var InputIDSell = SelectIdInStock();

                        Console.Write("How many pieces do you want to sell?: ");
                        var inputAmountStr = Console.ReadLine().Trim();

                        int inputAmountInt;
                        try
                        {
                            Int32.TryParse(inputAmountStr, out inputAmountInt);
                            
                            // Calling the sell method
                            Console.WriteLine(SellItem(InputIDSell, inputAmountInt));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("You didn't enter a number.");
                        }

                        Console.WriteLine("All good");
                        break;

                    case "3":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("STOCK UP ITEM");
                        Console.ResetColor();

                        if (IsEshopEmpty())
                            break;

                        var inputIDstockUp = SelectAllId();

                        Console.Write("How many pieces do you want to stock up?: ");
                        var amoutToStockUpStr = Console.ReadLine().Trim();

                        int amountToStockUpInt;
                        try
                        {
                            Int32.TryParse(amoutToStockUpStr, out amountToStockUpInt);
                            // Calling the stock up method
                            Console.WriteLine(StockUpItem(inputIDstockUp, amountToStockUpInt));

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("You didn't enter a number");
                        }

                        Console.WriteLine("All good");
                        break;


                    case "4":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SHOW REVENUE:");
                        Console.ResetColor();

                        var revenue = GetRevenue(eshop);
                        if (revenue == 0)
                        {
                            Console.WriteLine("First you need to sell some item to raise some money.");
                            break;
                        }

                        Console.WriteLine($"Total revenue of you e-shop is: {revenue} CZK");
                        break;

                    case "5":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ADD NEW TYPE OF ITEM");
                        Console.ResetColor();

                        ShowAddItemOption();
                        break;

                    case "0":
                        Console.WriteLine("Exiting program...");
                        break;
                }
            } while (userInput != "0");
        }

        private bool IsEshopEmpty()
        {
            if (eshop == null)
            {
                Console.WriteLine("E-shop is empty");
                return true;
            }
            else
            {
                return false;
            }
        }

        private string SelectIdInStock()
        {
            Console.WriteLine("Items in stock:");

            // Show only items in stock
            List<Clothes.Clothes> itemsInStock = eshop.Where(item => item.QuantityInStock > 0).ToList();
            Console.WriteLine(ShowEshop(itemsInStock));

            // Making sure user picks only items that are in stock
            Console.Write("What items would you like to sell (Item ID): ");
            var inputID = Console.ReadLine();

            List<string> validSelection = new List<string>();
            foreach (var cloth in itemsInStock)
            {
                validSelection.Add(cloth.ClotheId.ToString());
            }

            int triesLeft = 5;

            while (String.IsNullOrEmpty(inputID) || !validSelection.Contains(inputID))
            {
                if (triesLeft == 0)
                {
                    Console.WriteLine(
                        "You've enter too many invalid inputs. I kicking you out! You must be a bloody BOT!");
                    break;
                }

                else if (String.IsNullOrWhiteSpace(inputID))
                {
                    Console.WriteLine("You have entered invalid input. Please try again");
                }

                else if (!validSelection.Contains(inputID) && !String.IsNullOrWhiteSpace(inputID))
                {
                    Console.WriteLine("ID you selected is out of stock. Please enter a different ID");
                }

                triesLeft--;
                Console.Write("Your selection: ");
                inputID = Console.ReadLine().Trim();
            }

            return inputID;
        }

        private string SelectAllId()
        {
            Console.WriteLine("Items in e-shop:");
            Console.WriteLine(ShowEshop(eshop));
            //// Show only items in stock
            //List<Clothes.Clothes> itemsToStock = eshop.Where(item => item.ClotheId).ToList();
            //Console.WriteLine(ShowEshop(itemsInStock));

            // Making sure user picks only items that are in stock
            Console.Write("What items would you like to stock up (Item ID): ");
            var inputID = Console.ReadLine();

            List<string> validSelection = new List<string>();
            foreach (var cloth in eshop)
            {
                validSelection.Add(cloth.ClotheId.ToString());
            }

            int triesLeft = 5;

            while (String.IsNullOrEmpty(inputID) || !validSelection.Contains(inputID))
            {
                if (triesLeft == 0)
                {
                    Console.WriteLine(
                        "You've enter too many invalid inputs. I kicking you out! You must be a bloody BOT!");
                    break;
                }

                else if (String.IsNullOrWhiteSpace(inputID))
                {
                    Console.WriteLine("You have entered invalid input. Please try again");
                }

                else if (!validSelection.Contains(inputID) && !String.IsNullOrWhiteSpace(inputID))
                {
                    Console.WriteLine("ID you selected is out of stock. Please enter a different ID");
                }

                triesLeft--;
                Console.Write("Your selection: ");
                inputID = Console.ReadLine().Trim();
            }

            return inputID;
        }

        // OTAZKA: Slo by v pripade metod SellItem() a StockUpItem() pouzit Generics a nahradit tak tyhle dve metody jednou univerzalni? Moje predpoved - ne.
        private string SellItem(string id, int amount)
        {
            // OTAZKA: je tu neco, co by mi vratilo jen objekt, ktery hledam do promenne itemToSell a mohla bych se tak vyhnout tvorbe listu?
            var itemToSell = eshop.Where(item => item.ClotheId == id).ToList();
            foreach (var item in itemToSell)
            {
                return item.Sell(amount);
            }

            return $"Item was sold";
        }

        private string StockUpItem(string id, int amount)
        {
            var itemToSell = eshop.Where(item => item.ClotheId == id).ToList();
            
            foreach (var item in itemToSell)
            {
                return item.StockUp(amount);
            }

            return $"Item was stocked up";
        }

        private double GetRevenue(List<Clothes.Clothes> shop)
        {
            double totalRevenue = 0.00;
            foreach (var item in shop)
            {
                totalRevenue += item.CalculateRevenue();
            }

            return totalRevenue;
        }

        public void ShowAddItemOption()
        {
            Console.WriteLine("Select of what type will be the added item from the option below");
            Console.WriteLine("1. Shirt");
            Console.WriteLine("2. Trousers");
            Console.WriteLine("3. Footwear");
            Console.Write("Your selection: ");
            var userInput = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(userInput) || (userInput != "1" && userInput != "2" && userInput != "3"))
            {
                Console.WriteLine("You have entered an invalid input. Please try again.");
                Console.Write("Your selection: ");
                userInput = Console.ReadLine().Trim();
            }

            switch (userInput)
            {
                case "1":
                    AddNewShirt();
                    break;
                case "2":
                    AddNewTrousers();
                    break;
                case "3":
                    AddNewFootwear();
                    break;
            }
        }
        
        protected void AddNewShirt()
        {
            // POZN: dole by mi asi mohlo udeat bordel, kdyz bych mela u enums jinak definovane cislovani - VYRESIT!!!!
            //var typeOfShirt = Enum.GetNames(typeof(Upperwear));
            //for (int i = 0; i < typeOfShirt.Length; i++)
            //{
            //    Console.WriteLine($"{i} - {typeOfShirt[i]}");
            //}

            Console.WriteLine("What type of the upperwear do you want to add? (select number)");
            var typesOfShirt = GetValuesInEnum<Upperwear>();
            Console.Write("Your selection:");
            var inputShirt = Console.ReadLine().Trim();
            var upperwearType = UserInputCheck(typesOfShirt, inputShirt);
            List<Object> values = GetValuesForObjectCreation();

            values.Insert(0, upperwearType);
            Upperwear shirtType = (Upperwear)Enum.Parse(typeof(Upperwear), values[0].ToString());
            Sizes size = (Sizes)Enum.Parse(typeof(Sizes), values[1].ToString());
            Sex sex = (Sex)Enum.Parse(typeof(Sex), values[2].ToString());
            Color color = (Color)Enum.Parse(typeof(Color), values[3].ToString());
            var prize = Int32.Parse(values[4].ToString());
            var brand = values[5].ToString();
            var count = Int32.Parse(values[6].ToString());

            // Now let's decide how detailed the object will be.
            Console.WriteLine("Do you want to add additional information about this item? (type \"yes\" or \"no\"");
            var answer = Console.ReadLine().Trim().ToLower();

            if (answer == "yes")
            {
                bool longSleeves = false;
                bool hasHood = false;
                bool hasZip = false;
                
                Console.Write("Does the shirt have long sleeves? (yes/no): ");
                string longSleevesStr = Console.ReadLine().Trim();
                while (longSleevesStr != "yes" || longSleevesStr != "no")
                {
                    Console.Write("Wrong input, try again: ");
                    longSleevesStr = Console.ReadLine();
                }

                if (longSleevesStr == "yes")
                    longSleeves = true;
                


                Console.Write("Does the shirt have hood? (yes/no): ");
                string hasHoodStr = Console.ReadLine().Trim();
                while (hasHoodStr != "yes" || hasHoodStr != "no")
                {
                    Console.Write("Wrong input, try again: ");
                    hasHoodStr = Console.ReadLine();
                }

                if (hasHoodStr == "yes")
                    longSleeves = true;

                Console.Write("Does the shirt have zipper? (yes/no): ");
                string hasZipStr = Console.ReadLine().Trim();
                while (hasZipStr != "yes" || hasZipStr != "no")
                {
                    Console.Write("Wrong input, try again: ");
                    hasZipStr = Console.ReadLine();
                }

                if (hasZipStr == "yes")
                    hasZip = true;

                // New detailed object creation:
                eshop.Add(new Shirt(shirtType, size, sex, color, prize, brand, count, longSleeves, hasZip, hasHood));
            }
            else if (answer == "no")
            {
                // make a plain instance of a class clothes, without additional info
                eshop.Add(new Shirt(shirtType, size, sex, color, prize, brand, count));
            }
            else
            {
                // set up a basic object
                Console.WriteLine("Wrong input. Only basic item without additional information was set because of that.");
                eshop.Add(new Shirt(shirtType, size, sex, color, prize, brand, count));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nSUMMARY: ");
            Console.ResetColor();
            Console.WriteLine($"{shirtType} | {size} | {sex} | {color} | {prize} | {brand} | {count}");
            Console.WriteLine("Item successfully created.");

        }

        protected void AddNewTrousers()
        {
            Console.WriteLine("What type of the trousers do you want to add? (select number)");
            var typesOfTrousers = GetValuesInEnum<TrousersType>();
            Console.Write("Your selection:");
            var inputTrousers = Console.ReadLine().Trim();
            var trousesType = UserInputCheck(typesOfTrousers, inputTrousers);

            List<Object> values = GetValuesForObjectCreation();

            values.Insert(0, trousesType);
            TrousersType trousersType = (TrousersType)Enum.Parse(typeof(TrousersType), values[0].ToString());
            Sizes size = (Sizes)Enum.Parse(typeof(Sizes), values[1].ToString());
            Sex sex = (Sex)Enum.Parse(typeof(Sex), values[2].ToString());
            Color color = (Color)Enum.Parse(typeof(Color), values[3].ToString());
            var prize = Int32.Parse(values[4].ToString());
            var brand = values[5].ToString();
            var count = Int32.Parse(values[6].ToString());

            // I'll be a little lazy here and will let trousers to be set only as the general type without any details.
            eshop.Add(new Trousers(trousersType, size, sex, color, prize, brand, count));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nSUMMARY: ");
            Console.ResetColor();
            Console.WriteLine($"{trousersType} | {size} | {sex} | {color} | {prize} | {brand} | {count}");
            Console.WriteLine("Item successfully created.");
        }

        protected void AddNewFootwear()
        {

            Console.WriteLine("What type of the shoes do you want to add? (select number)");
            var typesOfShoes = GetValuesInEnum<FootwearType>();
            Console.Write("Your selection:");
            var inputShoes = Console.ReadLine().Trim();
            var shoesType = UserInputCheck(typesOfShoes, inputShoes);

            List<Object> values = GetValuesForObjectCreation();

            values.Insert(0, shoesType);
            FootwearType footwearType = (FootwearType)Enum.Parse(typeof(FootwearType), values[0].ToString());
            int size;
            
            Console.Write("Size (NOTE: our e-shop supports only sized from 34 to 49): ");
            string sizeStr = Console.ReadLine().Trim();
            bool repeat = Int32.TryParse(sizeStr, out size);
            while (!repeat)
            {
                Console.Write("Wrong input, please try again: ");
                sizeStr = Console.ReadLine();
                repeat = Int32.TryParse(sizeStr, out size);
            }

            Sex sex = (Sex)Enum.Parse(typeof(Sex), values[2].ToString());
            Color color = (Color)Enum.Parse(typeof(Color), values[3].ToString());
            var prize = Int32.Parse(values[4].ToString());
            var brand = values[5].ToString();
            var count = Int32.Parse(values[6].ToString());

            // I'll be again lazy and make the new instance just general without details
            eshop.Add(new Footwear(footwearType, size, sex, color, prize, brand, count));
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nSUMMARY: ");
            Console.ResetColor();
            Console.WriteLine($"{footwearType} | {size} | {sex} | {color} | {prize} | {brand} | {count}");
            Console.WriteLine("Item successfully created.");

        }

        // Method that will get general values for a new object that will be created. This will be reused for Shirt, Trousers and Footwear
        protected List<Object> GetValuesForObjectCreation()
        {
            List<Object> values = new List<Object>();
            
            //Console.WriteLine("What type of the cloth do you want to add? (select number)");
            //var typesOfShirt = GetValuesInEnum<Upperwear>();
            //Console.Write("Your selection:");
            //var inputShirt = Console.ReadLine().Trim();
            //var shirtType = UserInputCheck(typesOfShirt, inputShirt);
            //values.Add(shirtType);

            Console.WriteLine("What size is the item?");
            var typesOfSizes = GetValuesInEnum<Sizes>();
            Console.Write("Your selection: ");
            var inputSize = Console.ReadLine().Trim();
            var size = UserInputCheck(typesOfSizes, inputSize);
            values.Add(size);

            Console.WriteLine("What sex is it for?");
            var typesOfSex = GetValuesInEnum<Sex>();
            Console.Write("Your selection: ");
            var inputSex = Console.ReadLine().Trim();
            var sex = UserInputCheck(typesOfSex, inputSex);
            values.Add(sex);

            Console.WriteLine("What color is the item?");
            var typesOfColor = GetValuesInEnum<Color>();
            Console.Write("Your selection: ");
            var inputColor = Console.ReadLine().Trim();
            var color = UserInputCheck(typesOfColor, inputColor);
            values.Add(color);

            Console.Write("What will be the price of the item?: ");
            string prizeStr = Console.ReadLine().Trim();
            int prize;
            bool repeat = Int32.TryParse(prizeStr, out prize);
            while (!repeat)
            {
                Console.Write("Wrong input, please try again: ");
                prizeStr = Console.ReadLine();
                repeat = Int32.TryParse(prizeStr, out prize);
            }
            values.Add(prize);

            Console.Write("What brand is the item?: ");
            var brand = Console.ReadLine().Trim();
            values.Add(brand);

            Console.Write("How many pieces of the do you was to add?: ");
            string countStr = Console.ReadLine().Trim();
            int count;
            bool repeat2 = Int32.TryParse(countStr, out count);
            while (!repeat2)
            {
                Console.Write("Wrong input, please try again: ");
                countStr = Console.ReadLine();
                repeat2 = Int32.TryParse(countStr, out count);
            }
            values.Add(count);

            return values;
        }

        private string UserInputCheck(Dictionary<string, string> types, string userInput)
        {
            var verifiedInput = userInput;
            
            while (!types.ContainsKey(verifiedInput))
            {
                Console.WriteLine("Invalid selection, please try again.");
                Console.Write("Your selection: ");
                verifiedInput = Console.ReadLine().Trim();
            }

            var returnedType = types[verifiedInput];
            return returnedType;
        }

        // Let's try some generics here
        private Dictionary<string, string> GetValuesInEnum<T>() where T : Enum
        {
            var values = Enum.GetNames(typeof(T));
            var valuesWithKey = new Dictionary<string, string>();

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"{i} - {values[i]}");
                valuesWithKey.Add(i.ToString(), values[i]);
            }

            return valuesWithKey;
        }

        
    }
}
