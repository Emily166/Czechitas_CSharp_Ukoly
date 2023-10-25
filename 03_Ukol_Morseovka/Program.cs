string[] morseovyZnaky = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

// aphabet creation
char[] abeceda = new char[26];

for (int i = 0; i < 26; i++)
{
    char pismeno = Convert.ToChar(97 + i);
    abeceda[i] = pismeno;
}


Console.WriteLine("Zadej text, ktery chces prevest na Morseovu abecedu: ");
string input = Console.ReadLine();
//string[] nechceSeMiResitCisla = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

while (String.IsNullOrEmpty(input))
{
    Console.WriteLine("Pro prevedeni na morseovku musis neco napsat.");

    Console.Write("\nZadej znovu text: ");
    input = Console.ReadLine();
}

string slovo = input.ToLower();

string[] zakodovaneSlovo = new string[slovo.Length];
int pocitadlo = 0;

char[] nechtejiSeMiResitCisla = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

for (int i = 0; i < slovo.Length; i++)
{
    if (slovo[i] == ' ' || slovo[i] == '.' || slovo[i] == '?' || slovo[i] == '!' || slovo[i] == '\'' || slovo[i] == '-' || nechtejiSeMiResitCisla.Contains(slovo[i]))
    {
        zakodovaneSlovo[i] = slovo[i].ToString();
        continue;
    }
    int index = Array.IndexOf(abeceda, slovo[i]);
    zakodovaneSlovo[i] = morseovyZnaky[index];
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nPrevod zde:");
Console.ResetColor();
Console.WriteLine(String.Join('|', zakodovaneSlovo));

