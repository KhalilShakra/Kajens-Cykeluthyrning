public abstract class Fordon
{
    public int Nummer { get; }
    public decimal Timpris { get; }
    public bool ArUthyrd { get; private set; }

    public abstract string Typ { get; }

    protected Fordon(int nummer, decimal timpris)
    {
        Nummer = nummer;
        Timpris = timpris;
        ArUthyrd = false;
    }
}