using System.Runtime.InteropServices.ComTypes;

Console.Write("Zadej text:");
string text = Console.ReadLine();

//string text = "Hello World 123!";

int pocetZnaku = text.Length;
int malaPismena = 0;
int velkaPismena = 0;
int specialniZnaky = 0;
int pocetCisel = 0;
int pocetBilychZnaku = 0;

Dictionary<string, int> statistiky = new Dictionary<string, int>();

foreach (var character in text)
{
    if (char.IsLower(character))
    {
        malaPismena += 1;
    }
    else if (char.IsUpper(character))
    {
        velkaPismena += 1;
    }
    else if (char.IsDigit(character))
    {
        pocetCisel += 1;
    }
    else if (char.IsWhiteSpace(character)) // tady nejak nechapu, jak se lisi metoda char.IsSeparator(Char)
    {
        pocetBilychZnaku += 1;
    }
    else
    {
        specialniZnaky += 1;
    }
}

statistiky.Add("pocet znaku", pocetZnaku);
statistiky.Add("znaky bez mezer", pocetZnaku - pocetBilychZnaku);
statistiky.Add("mala pismena", malaPismena);
statistiky.Add("velka pismena", velkaPismena);
statistiky.Add("cisla", pocetCisel);
statistiky.Add("specialni znaky", specialniZnaky);


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nSTATISTIKY ZNAKU V TEXTU:");
Console.ResetColor();

foreach (KeyValuePair<string, int> i in statistiky)
{
    Console.WriteLine($"{(i.Key.ToString() + ":"),-20}{(i.Value)}");        // tady to ",-20" mi nabidl Resharper jako zkraceni zapisu misto pouziti metody PadRight() - co presne zapis "-20" znamena a pouziva se to bezne v praxi?
}