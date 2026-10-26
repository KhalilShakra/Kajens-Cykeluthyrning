namespace Kajens_Cykeluthyrning;

public class Elcykel : Fordon
{
    private int batteri;

    public int Batteri
    {
        get { return batteri; }
        private set
        {
            if (value < 0)
                batteri = 0;
            else if (value > 100)
                batteri = 100;
            else
                batteri = value;
        }
    }

    public override string Typ => "Elcykel";

    public Elcykel(int nummer, int startBatteri) : base(nummer, 70m)
    {
        Batteri = startBatteri;
    }
}