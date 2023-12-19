
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Channels;
using _08_Ukol_Eshop;
using _08_Ukol_Eshop.Clothes;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("SLOVO NA UVOD");
Console.ResetColor();

Console.WriteLine("Ahoj David,\naz se na tohle budes koukat, mohl bys mi prosim zkritizovat, co se da? Kdyz mi vytknes sebemensi blbost, tak budu rada - at se muzu poucit z chyb.\nDiky moc a mej se hezky!");

Logic logic = new Logic();
logic.ShowMainMenu();


