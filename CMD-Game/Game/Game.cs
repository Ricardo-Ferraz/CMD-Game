using CMD_Game.Model;

namespace CMD_Game.Game;

public class Game
{
    public Board Board { get; set; }
    public Hero Hero { get; set; }

    public Game()
    {
        this.Board = new Board();
        this.Hero = new Hero();
        this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
        
        do
        {
            Console.WriteLine();
            this.DisplayBoard();
            Console.WriteLine();
            this.HeroTurn();
        } while (this.Hero.Hp != 0 && !(this.Board.HeroResearch(this.Hero.Row, this.Hero.Column)));
        Console.WriteLine();
        this.DisplayBoard();
    }

    public void HeroTurn()
    {
        ConsoleKey key;
        do
        {
            key = Console.ReadKey().Key;
        } while ((key != ConsoleKey.A) && (key != ConsoleKey.S) && (key != ConsoleKey.W) && (key != ConsoleKey.D) && (key != ConsoleKey.Enter) && (key != ConsoleKey.Spacebar) && (key != ConsoleKey.Escape));
        this.Decision(key);
    }

    private void Decision(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.A:
                if (this.Board.HasMove(this.Hero.Row, this.Hero.Column - 1))
                {
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Column -= 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                }
                break;
            
            case ConsoleKey.S:
                if (this.Board.HasMove(this.Hero.Row+1, this.Hero.Column))
                {
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Row += 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                }
                break;
            
            case ConsoleKey.D:
                if (this.Board.HasMove(this.Hero.Row, this.Hero.Column + 1))
                {
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Column += 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                }
                break;
            
            case ConsoleKey.W:
                if (this.Board.HasMove(this.Hero.Row-1, this.Hero.Column))
                {
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Row -= 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                }
                break;
            
            case ConsoleKey.Spacebar:

                break;
            
            case ConsoleKey.Escape:
                Console.WriteLine("Obrigado por Jogar!");
                Environment.Exit(0);
                break;
        }
    }
    
    
    public void DisplayBoard()
    {
        this.Board.DisplayBoard();
    }
}