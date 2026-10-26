namespace Kajens_Cykeluthyrning;

public class Elcykel : Fordon
{

    private const int ForbrukningPerTimme = 10;
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
    public override int MinimiAlder => 18;
    public Elcykel(int nummer, int startBatteri) : base(nummer, 70m)
    {
        Batteri = startBatteri;
    }

    public override string BatteriText()
    {
        return $"{Batteri} %";
    }

    // Batteriet dras vid återlämning, när det är klart hur många timmar cykeln användes
    public override void LamnaTillbaka(int timmar)
    {
        base.LamnaTillbaka(timmar);
        Batteri -= timmar * ForbrukningPerTimme;
    }
}