namespace CMD_Game.Model;

public abstract class Base
{
    public static readonly int INITIAL_HERO_HP = 25;
    public static readonly int INITIAL_MONSTER_HP = 5;
    public static readonly int INITIAL_BOSS_HP = 10;
    
    protected static readonly int INITIAL_HERO_DAMAGE = 1;
    protected static readonly int INITIAL_MONSTER_DAMAGE = 1;
    protected static readonly int INITIAL_BOSS_DAMAGE = 2;
    
    protected static readonly int INITIAL_HERO_SCORE = 0;
    protected static readonly int INITIAL_MONSTER_SCORE = 5;
    protected static readonly int INITIAL_BOSS_SCORE = 15;
    
    protected static readonly int INITIAL_HERO_ROW = 0;
    protected static readonly int INITIAL_HERO_COLUMN = 0;
    
    public int Hp { get; set; }

    public int Damage { get; set; }
    
    public int Score { get; set; }

    public int Row { get; set; }
    
    public int Column { get; set; }

    public void ChangePosition(int row, int column)
    {
        this.Row = row;
        this.Column = column;
    }
}