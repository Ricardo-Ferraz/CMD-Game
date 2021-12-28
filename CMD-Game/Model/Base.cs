namespace CMD_Game.Model;

public abstract class Base
{
    public int Hp { get; set; }

    public int Damage { get; set; }
    
    public int Score { get; set; }

    public int Row { get; set; }
    
    public int Column { get; set; }

    public Base(int hp, int damage, int score, int row, int column)
    {
        this.Hp = hp;
        this.Damage = damage;
        this.Score = score;
        this.Row = row;
        this.Column = column;
    }
}