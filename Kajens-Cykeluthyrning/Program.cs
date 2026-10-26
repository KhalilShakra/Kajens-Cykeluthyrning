using Kajens_Cykeluthyrning;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Uthyrningssystem system = new Uthyrningssystem();
bool kor = true;

while (kor)
{
    VisaMeny();
    int val = LasTal("Val: ");

    switch (val)
    {
        case 1:
            VisaFordon();
            break;
        case 2:
        case 3:
        case 4:
        case 5:
            Console.WriteLine("Inte klart än.");
            break;
        case 6:
            kor = false;
            break;
        default:
            Console.WriteLine("Ogiltigt val. Välj 1–6.");
            break;
    }

    Console.WriteLine();
}

void VisaMeny()
{
    Console.WriteLine("=== Kajens Cykeluthyrning ===");
    Console.WriteLine("1. Visa fordon  2. Registrera kund  3. Hyr ut");
    Console.WriteLine("4. Lämna tillbaka  5. Ladda  6. Avsluta");
}

void VisaFordon()
{
    Console.WriteLine("Nr  Typ      Status  Batteri");
    foreach (Fordon f in system.AllaFordon())
    {
        Console.WriteLine($"{f.Nummer,-3} {f.Typ,-8} {f.StatusText(),-7} {f.BatteriText()}");
    }
}

int LasTal(string fraga)
{
    while (true)
    {
        Console.Write(fraga);
        string? text = Console.ReadLine();
        if (int.TryParse(text, out int tal))
            return tal;
        Console.WriteLine("Skriv ett heltal.");
    }
}