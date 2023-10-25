// !!!!!!!!!!!!!!!!!!!!!!!!!
// PROGRAM JESTE NENI HOTOVY 
// !!!!!!!!!!!!!!!!!!!!!!!!!



using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;


Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine(new string('.', 24));
Console.WriteLine("Welcome to File Manager!");
Console.WriteLine(new string('.', 24));
Console.ResetColor();

// Path - change this as you wish
string path = @"C:\Users\Emilie.Kratochvilova\Desktop\MyStuff\Czechitas\Podklady";

string input;

do
{
    input = Logic.Opener();

    switch (input)
    {
        case "1":
            Console.WriteLine("1 was selected");
            Logic.SeeFilesInDirectory(path);
            break;
        case "2":
            Console.WriteLine("2 was selected");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCREATE A FILE");
            Console.ResetColor();
            Logic.AddNewFile(path);
            break;
        case "3":
            Console.WriteLine("3 was selected");
            break;
        case "4":
            Console.WriteLine("4 selected");
            break;
        case "5":
            Console.WriteLine("5 selected");
            break;
        case "6":
            Console.WriteLine("6 selected");
            break;
    }

} while (input != "6");

Console.WriteLine("Closing the application...");

public class Logic
{
    public static string Opener()
    {
        // All options user can do
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nChoose your action");
        Console.ResetColor();
        Console.WriteLine("1. See all existing files");
        Console.WriteLine("2. Create a new file");
        Console.WriteLine("3. Read a file");
        Console.WriteLine("4. Edit a file");
        Console.WriteLine("5. Read a file");
        Console.WriteLine("6. CLOSE the program");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\nYour selection: ");
        Console.ResetColor();
        var usersInput = Console.ReadLine();

        string[] validSelection = new[] { "1", "2", "3", "4", "5", "6" };
        while (String.IsNullOrEmpty(usersInput) || !validSelection.Contains(usersInput))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("WARNING.");
            Console.ResetColor();
            Console.WriteLine("\nYou have entered invalid value.\nNote that only valid numbers can be entered.\nPlease try again.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nYour selection: ");
            Console.ResetColor();
            usersInput = Console.ReadLine();
        }

        return usersInput;
    }
    
    public static void SeeFilesInDirectory(string lookupDirectory)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nEXISTING FILES");
        Console.ResetColor();

        string[] existingFilesArray = Directory.GetFiles(lookupDirectory);
        string[] cleanExistingFilesArray = new string[existingFilesArray.Length];

        if (existingFilesArray.Length > 0)
        {
            for (int i = 0; i < existingFilesArray.Length; i++)
            {
                var searchedIdex = existingFilesArray[i].LastIndexOf('\\');
                cleanExistingFilesArray[i] = existingFilesArray[i].Substring(searchedIdex + 1);
            }
        }

        string existingFiles = existingFilesArray.Length != 0 ? String.Join("\n", cleanExistingFilesArray) : "The directory is empty.";
        Console.WriteLine(existingFiles);
    }
    
    public static string UserInputCheck(string userInput)
    {
        string text;
        while (String.IsNullOrWhiteSpace(userInput))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("You must enter something. Please, try again: ");
            Console.ResetColor();

            userInput = Console.ReadLine();
        }

        text = userInput.Trim();

        return text;
    }

    public static string UserInputDateCheck(string userDateInput)
    {
        string regex =
            @"(((0[1-9])|([12][0-9])|(3[01]))\/((0[0-9])|(1[012]))\/((20[012]\d|19\d\d)|(1\d|2[0123])))";

        string date = null;
        bool repeat = true;
        string inputDate = Logic.UserInputCheck(userDateInput);

        while (repeat)
        {
            //string inputDate = Logic.UserInputCheck(Console.ReadLine());
            //string inputDate = Logic.UserInputCheck(userDateInput);
            var match = Regex.Match(inputDate, regex);
            if (match.Success)
            {
                repeat = false;
                date = inputDate;
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You have entered a date in invalid format.\nPlease add a date in 'dd/mm/yyyy' format: "); Console.ResetColor();
                inputDate = Logic.UserInputCheck(Console.ReadLine());
            }
        }
        return date;
    }

    //public static string ReadFile(string path)
    //{

    //}
    
    public static void AddNewFile(string pathForFile)
    {
        // NEED TO MAKE THE TEXT FIRST
        Console.WriteLine("Our system stores customer's following information:\n\t- Surname \n\t- First name \n\t- Date of birth \n\t- Date of registration");
        Console.WriteLine("\nLet's start adding people...\n");

        bool addMorePeople = true;

        List<string> listOfPeople = new List<string>();

        do
        {
            StringBuilder sb = new StringBuilder();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Surname:\t\t\t"); Console.ResetColor();
            string surname = Logic.UserInputCheck(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("First name:\t\t\t"); Console.ResetColor();
            string firstName = Logic.UserInputCheck(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Date of birth ('dd/mm/yyyy'):\t"); Console.ResetColor();
            string dateOfBirth = Logic.UserInputDateCheck(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Registration date ('dd/mm/yyyy'):"); Console.ResetColor();
            string dateOfRegistration = Logic.UserInputDateCheck(Console.ReadLine());

            sb
                .Append(surname)
                .Append(',')
                .Append(firstName)
                .Append(",")
                .Append(dateOfBirth)
                .Append(",")
                .Append(dateOfRegistration);

            string person = sb.ToString();
            listOfPeople.Add(person);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPerson successfully created."); Console.ResetColor();

            Console.Write("Do you wish to add another person? (type: yes/no): ");
            string addMoreInput = Logic.UserInputCheck(Console.ReadLine().ToLower());

            while (!(addMoreInput == "yes" || addMoreInput == "no"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid selection. Please try again: "); Console.ResetColor();
                addMoreInput = Logic.UserInputCheck(Console.ReadLine().ToLower());
            }
            if (addMoreInput == "yes")
            {
                addMorePeople = true;
            }
            else if (addMoreInput == "no")
            {
                addMorePeople = false;
            }

        } while (addMorePeople);

        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\nName your file: ");
        Console.ResetColor();
        string fileName = Console.ReadLine() + ".txt";
        //Console.WriteLine(String.Join('\\', pathForFile, fileName));
        if (!File.Exists(String.Join('/', pathForFile, fileName)))
        {
            File.AppendAllLines((pathForFile + '/' + fileName), listOfPeople);
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine($"File {fileName} was successful created"); Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("WARNING! "); Console.ResetColor();
            Console.Write($"File named \"{fileName}\" already exists.\nDo you with to add people to existing file? (type: yes/no): ");

            string appendPeople = Logic.UserInputCheck(Console.ReadLine()).ToLower();

            while (!(appendPeople == "yes" || appendPeople == "no"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid selection. Please try again: "); Console.ResetColor();
                appendPeople = Logic.UserInputCheck(Console.ReadLine().ToLower());
            }

            if (appendPeople == "yes")
            {
                File.AppendAllLines((pathForFile + '/' + fileName), listOfPeople);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPeople were added to existing file."); Console.ResetColor();
            }
            else if (appendPeople == "no")
            {
                Console.WriteLine("\nAdded people were discarded.");
                Console.WriteLine("Byla jsem moc lina dopsat kod, co by vytvoril novy soubor. Za to pujdu do pekla! :) ");
            }
        }

    }
}




