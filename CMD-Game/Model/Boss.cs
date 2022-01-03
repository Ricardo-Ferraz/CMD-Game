namespace CMD_Game.Model;

public class Boss : Base
{
    public Boss()
    {
        this.Hp = INITIAL_BOSS_HP;
        this.Damage = INITIAL_BOSS_DAMAGE;
        this.Score = INITIAL_BOSS_SCORE;
    }
}