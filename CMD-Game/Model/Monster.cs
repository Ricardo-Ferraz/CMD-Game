namespace CMD_Game.Model;

public class Monster : Base
{
    public Monster()
    {
        this.Hp = INITIAL_MONSTER_HP;
        this.Damage = INITIAL_MONSTER_DAMAGE;
        this.Score = INITIAL_MONSTER_SCORE;
    }
}