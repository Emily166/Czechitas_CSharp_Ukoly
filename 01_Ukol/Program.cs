// Zadani 1: Vytvoř pole typu int s těmito hodnotami {3, -4, 0, 21, 3, 16, 7, 0, 1, 3, 4,-2}. Pro kontrolu si obsah pole vypiš.

using System.Reflection;
using System.Runtime.InteropServices.JavaScript;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Zadani 1");
Console.ResetColor();

int[] array1 = new[] { 3, -4, 0, 21, 3, 16, 7, 0, 1, 3, 4, -2 };

foreach (int i in array1)
    Console.Write($"{i} ");



// Zadani 2: Vyhledej záporná čísla a změň je na kladné číslo, zároveň vyhledej nuly a ke každé přičti hodnotu jejího indexu. Výsledné pole si vypiš.
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n\nZadani 2");
Console.ResetColor();

int[] array2 = new[] { 3, -4, 0, 21, 3, 16, 7, 0, 1, 3, 4, -2 };

for (int i = 0; i < array2.Length; i++)
{
    if (array2[i] < 0)
        array2[i] = array2[i] * (-1);

    else if (array2[i] == 0)
        array2[i] = array2[i] + i;
}

foreach (int i in array2)
    Console.Write($"{i} ");

// Zadani 3: Vyhledej největší číslo v poli a vypiš ho.
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n\nZadani 3");
Console.ResetColor();

int nejvetsiCislo = array1[0];

foreach (int i in array1)
{
    if (i > nejvetsiCislo)
        nejvetsiCislo = i;
}

Console.WriteLine($"Nejvetsi cislo je: {nejvetsiCislo}");


// Zadani 4: Seřaď prvky v poli od nejmenšího po největší. Můžeš například využít toho, že už umíš najít největší číslo v poli. Prosím, nepoužívej už hotovou funkci na sortování, jde o to, aby sis takovou funkci zkusila napsat sama.
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n\nZadani 4");
Console.ResetColor();


/// Might not need this biggest number
int biggestNumber = array1[0];

foreach (int i in array1)
{
    if(i > biggestNumber)
        biggestNumber = i;
}
/// ---------------------------------

int[] sortedArray = new int[array1.Length];

for (int i = 0; i <array1.Length; i++)
    sortedArray[i] = array1[i];


bool shallIContinueSorting = true;
do
{
    shallIContinueSorting = false;
    for (int i = 0; i < sortedArray.Length; i++)
    {
        int smallerNum;
        int biggerNum;
        if (i == array1.Length - 1)
            break;
        if (sortedArray[i] > sortedArray[i + 1])
        {
            smallerNum = sortedArray[i + 1];
            biggerNum = sortedArray[i];
            sortedArray[i] = smallerNum;
            sortedArray[i + 1] = biggerNum;

        }
        else if (sortedArray[i] < sortedArray[i + 1])
        {
            continue;
            //smallerNum = sortedArray[i];
            //biggerNum = sortedArray[i + 1];
            //sortedArray[i] = smallerNum;
            //sortedArray[i + 1] = biggerNum;
        }

    }

    for (int i = 0; i < sortedArray.Length; i++)
    {
        if (i == sortedArray.Length - 1)
            break;
        if (sortedArray[i] > sortedArray[i + 1])
        {
            shallIContinueSorting = true;
            break;
        }
    }
} while (shallIContinueSorting);

foreach (int i in sortedArray)
    Console.WriteLine(i);

// BONUSOVE UKOLY

// Bonus 1: Schody - Vypiš zadaný počet schodů (řádků) podle uvedeného příkladu. Napiš program tak, aby uživatel mohl zadat počet schodů, které se mají vypsat.
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n\nBONUS Zadani 1");
Console.ResetColor();


Console.WriteLine("Kolik chces schodu? ");

int pocetSchodu;

while (!int.TryParse(Console.ReadLine(), out pocetSchodu))
{
    Console.WriteLine("Zadal jsi neco jineho nez cislo. Zkus to znovu.");
}

Console.WriteLine("Super. Cislo je ted spravne.");

for (int i = 1; i <= pocetSchodu; i++)
{
    int howManyHashtags;
    for (int j = 0; j < pocetSchodu - i; j++)
    {
        Console.Write(".");
    }
    
    for (int x = 0; x < i; x++)
        Console.Write("#");
    
    Console.WriteLine("\n");
}


//Console.WriteLine(4 * 'a');



// Bonus 2 - Minimální a maximální součet n-1 prvků

//      Zvol si libovolné pole délky n a najdi v něm takovou kombinaci n-1 prvků, které dávají nejnižší a nejvyšší součet. Tyto dva součty vypiš jako výsledek.
//    Příklad: Pole s prvky {3, 1, 9, 7, 5} o délce n = 5. Jde nám o to, vybrat z tohoto pole takovou kombinaci n-1 (tedy čtyř) čísel, která dává nejmenší a největší součet.
//    Správná odpověď  v tomto případě je 1 + 3 + 5 + 7 = 16, což je minimum a 3 + 5 + 7 + 9 = 24, což je maximum.
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n\nBONUS Zadani 2");
Console.ResetColor();

int[] cisla = new[] { 3, 1, 9, 7, 9 };

int nejvetsi = cisla[0];
int nejmensi = cisla[0];

for (int i = 0; i < cisla.Length; i++)
{
    if (cisla[i] > nejvetsi)
        nejvetsi = cisla[i];

    if (cisla[i] < nejmensi)
        nejmensi = cisla[i];
}

int[] kombinaceNejmensi = new int[cisla.Length - 1];
int[] kombinaceNejvetsi = new int[cisla.Length - 1];

int indexatorNejmensi= 0;
for (int i = 0; i < cisla.Length; i++)
{
    if (cisla[i] != nejvetsi)
    {
        kombinaceNejmensi[indexatorNejmensi] = cisla[i];
        indexatorNejmensi++;
    }

    if (i == cisla.Length - 1 && indexatorNejmensi != cisla.Length - 1)
    {
        kombinaceNejmensi[^1] = nejvetsi;
    }
}

int indexatorNejvetsi = 0;
for (int j = 0; j < cisla.Length; j++)
{
    if (cisla[j] != nejmensi)
    {
        kombinaceNejvetsi[indexatorNejvetsi] = cisla[j];
        indexatorNejvetsi++;
    }

    if (j == cisla.Length - 1 && indexatorNejvetsi != cisla.Length - 1)
    {
        kombinaceNejvetsi[^1] = nejmensi;
    }
}

int vysledekNejmensi = 0;
foreach (int i in kombinaceNejmensi)
{
    Console.Write($"{i} ");
    vysledekNejmensi = vysledekNejmensi + i;
}

Console.WriteLine($"\nVysledek rady nejnizsi kombinace je: {vysledekNejmensi}");

int vysledekNejvetsi = 0;
foreach (int j in kombinaceNejvetsi)
{
    Console.Write($"{j} ");
    vysledekNejvetsi = vysledekNejmensi + j;
}

Console.WriteLine($"\nVysledek rady nejvyssi kombinace je: {vysledekNejvetsi}");