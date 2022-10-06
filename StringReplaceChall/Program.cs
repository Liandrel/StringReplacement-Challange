
using StringReplaceChall;

StringReplaceProcessor srp = new();

Console.Write("Write text to search for: ");
string oldText = Console.ReadLine();

Console.Write("Write text to replace old text: ");
string newText = Console.ReadLine();

srp.ReplaceText(oldText, newText, "primary.txt");

