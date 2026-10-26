using Kajens_Cykeluthyrning;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Uthyrningssystem system = new Uthyrningssystem();

Console.WriteLine("Nr  Typ  Status  Batteri");
foreach (Fordon f in system.AllaFordon())
{
    Console.WriteLine($"{f.Nummer,-3} {f.Typ,-8} {f.StatusText(),-7} {f.BatteriText()}");
}