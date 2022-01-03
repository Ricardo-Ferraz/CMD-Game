namespace CMD_Game;

public class Program
{
    public static void Main(String[] args)
    {
        ConsoleKey key;
        do
        {
            Console.WriteLine("F - Facíl | M - Médio | D - Difícil");
           key = Console.ReadKey().Key;
        } while ((key != ConsoleKey.F) && (key != ConsoleKey.M) && (key != ConsoleKey.D));
        Game.Game game = new Game.Game(key);
      
    }
}