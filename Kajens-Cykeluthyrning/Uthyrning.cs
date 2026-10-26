namespace Kajens_Cykeluthyrning;

using System.Globalization;
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

    public string KvittoText()
    {
        CultureInfo svensk = new CultureInfo("sv-SE");

        string beskrivning = $"{Fordon.Typ}, {Timmar} timmar à {Fordon.Timpris:0} kr";
        string text = "KVITTO\n";
        text += $"{beskrivning,-28}{Pris().ToString("F2", svensk)} kr\n";

        if (Kund.ArMedlem)
            text += $"{"Medlemsrabatt (10 %)",-28}-{Rabatt().ToString("F2", svensk)} kr\n";

        text += $"{"Att betala",-28}{AttBetala().ToString("F2", svensk)} kr";
        return text;
    }
}