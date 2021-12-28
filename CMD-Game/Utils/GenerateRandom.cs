namespace CMD_Game.Utils;

public abstract class GenerateRandom
{
    public static Random random;

    public static int GetRandom(int min, int max)
    {
        random = new Random();
        return (int) (Math.Floor(random.NextDouble() * (max - min )) + min);
    }
}