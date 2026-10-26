namespace Kajens_Cykeluthyrning;

public abstract class Fordon
{
    public int Nummer { get; }
    public decimal Timpris { get; }
    public bool ArUthyrd { get; private set; }
    public abstract string Typ { get; }
    public abstract int MinimiAlder { get; }

    protected Fordon(int nummer, decimal timpris)
    {
        Nummer = nummer;
        Timpris = timpris;
        ArUthyrd = false;
    }

    public decimal BeraknaPris(int timmar)
    {
        return Timpris * timmar;
    }
    public string StatusText()
    {
        if (ArUthyrd)
            return "uthyrd";
        return "ledig";
    }

    public virtual string BatteriText()
    {
        return "";
    }
}