namespace Kajens_Cykeluthyrning;

public class Cykel : Fordon
{
    public Cykel(int nummer) : base(nummer, 40m)
    {
    }

    public override string Typ => "Cykel";
    public override int MinimiAlder => 15;
}