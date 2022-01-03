namespace CMD_Game.Model;

public class Hero : Base
{
    public Hero()
    {
        this.Hp = INITIAL_HERO_HP;
        this.Damage = INITIAL_HERO_DAMAGE;
        this.Score = INITIAL_HERO_SCORE;
        this.Row = INITIAL_HERO_ROW;
        this.Column = INITIAL_HERO_COLUMN;
    }
}