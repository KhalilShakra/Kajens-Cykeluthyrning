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
}