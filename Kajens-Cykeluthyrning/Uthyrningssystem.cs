namespace Kajens_Cykeluthyrning;

public class Uthyrningssystem
{
    private List<Fordon> fordon = new List<Fordon>();
    private List<Kund> kunder = new List<Kund>();
    private List<Uthyrning> uthyrningar = new List<Uthyrning>();

    public Uthyrningssystem()
    {
        fordon.Add(new Cykel(1));
        fordon.Add(new Cykel(2));
        fordon.Add(new Elcykel(3, 80));
        fordon.Add(new Elcykel(4, 25));
    }

    public List<Fordon> AllaFordon()
    {
        return fordon;
    }
    public Kund RegistreraKund(string namn, int alder, bool arMedlem)
    {
        Kund kund = new Kund(namn, alder, arMedlem);
        kunder.Add(kund);
        return kund;
    }

    public Kund? HittaKund(string namn)
    {
        return kunder.FirstOrDefault(k => k.Namn.ToLower() == namn.Trim().ToLower());
    }

    public Fordon? HittaFordon(int nummer)
    {
        return fordon.FirstOrDefault(f => f.Nummer == nummer);
    }

    public string? KontrolleraUthyrning(string kundnamn, int nummer)
    {
        Kund? kund = HittaKund(kundnamn);
        if (kund == null)
            return "Kunden finns inte.";

        Fordon? fordon = HittaFordon(nummer);
        if (fordon == null)
            return "Fordonet finns inte.";

        if (kund.Alder < fordon.MinimiAlder)
            return $"{kund.Namn} måste vara minst {fordon.MinimiAlder} år för att hyra en {fordon.Typ.ToLower()}.";

        if (fordon.ArUthyrd)
            return $"{fordon.Typ} {fordon.Nummer} är redan uthyrd.";

        if (fordon.BehoverLaddas())
            return $"{fordon.Typ} {fordon.Nummer} har för lite batteri ({fordon.BatteriText()}). Ladda den först.";

        return null;
    }

    public string HyrUt(string kundnamn, int nummer, int timmar)
    {
        string? fel = KontrolleraUthyrning(kundnamn, nummer);
        if (fel != null)
            return fel;

        if (timmar < 1)
            return "Antal timmar måste vara minst 1.";

        Kund? kund = HittaKund(kundnamn);
        Fordon? fordon = HittaFordon(nummer);

        fordon!.HyrUt();
        uthyrningar.Add(new Uthyrning(kund!, fordon, timmar));
        return $"{kund!.Namn} hyr {fordon.Typ} {fordon.Nummer} i {timmar} timmar.";
    }
    public string LamnaTillbaka(int nummer)
    {
        Fordon? fordon = HittaFordon(nummer);
        if (fordon == null)
            return "Fordonet finns inte.";

        Uthyrning? uthyrning = uthyrningar.FirstOrDefault(u => u.Fordon.Nummer == nummer);
        if (uthyrning == null)
            return "Fordonet är inte uthyrt.";

        fordon.LamnaTillbaka(uthyrning.Timmar);
        uthyrningar.Remove(uthyrning);
        return uthyrning.KvittoText();
    }
}