namespace CMD_Game.Model;

public class Hero
{
    private static readonly int INITIAL_HP = 25;
    private static readonly int INITIAL_DAMAGE = 1;
    private static readonly int INITIAL_SCORE = 0;
    private static readonly int INITIAL_ROW = 0;
    private static readonly int INITIAL_COLUMN = 0;
    
    
    public int Hp { get; set; }

    public int Damage { get; set; }
    
    public int Score { get; set; }

    public int Row { get; set; }
    
    public int Column { get; set; }

    public void IncreaseDamage(int damage)
    {
        this.Damage += damage;
    }

    public void IncreaseScore(int score)
    {
        this.Score += score;
    }

    public void ChangePosition(int row, int column)
    {
        this.Row = row;
        this.Column = column;
    }
    
    public Hero()
    {
        this.Hp = INITIAL_HP;
        this.Damage = INITIAL_DAMAGE;
        this.Score = INITIAL_SCORE;
        this.Row = INITIAL_ROW;
        this.Column = INITIAL_COLUMN;
    }
}