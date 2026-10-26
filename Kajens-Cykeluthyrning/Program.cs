using Kajens_Cykeluthyrning;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Fordon> fordon = new List<Fordon>
{
    new Cykel(1),
    new Cykel(2),
    new Elcykel(3, 80),
    new Elcykel(4, 25)
};

Console.WriteLine("Nr  Typ      Status  Batteri");
foreach (Fordon f in fordon)
{
    Console.WriteLine($"{f.Nummer,-3} {f.Typ,-8} {f.StatusText(),-7} {f.BatteriText()}");


}

