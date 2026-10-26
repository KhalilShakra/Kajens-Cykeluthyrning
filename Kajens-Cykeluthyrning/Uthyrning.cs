namespace Kajens_Cykeluthyrning;

public class Uthyrning
{
    private const decimal Medlemsrabatt = 0.10m;

    public Kund Kund { get; }
    public Fordon Fordon { get; }
    public int Timmar { get; }

    public Uthyrning(Kund kund, Fordon fordon, int timmar)
    {
        Kund = kund;
        Fordon = fordon;
        Timmar = timmar;
    }

    public decimal Pris()
    {
        return Fordon.BeraknaPris(Timmar);
    }

    public decimal Rabatt()
    {
        if (Kund.ArMedlem)
            return Pris() * Medlemsrabatt;
        return 0;
    }

    public decimal AttBetala()
    {
        return Pris() - Rabatt();
    }
}