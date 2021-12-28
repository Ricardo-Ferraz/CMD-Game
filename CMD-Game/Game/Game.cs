using CMD_Game.Model;
using CMD_Game.Utils;

namespace CMD_Game.Game;

public class Game
{
    private static readonly int POTION_RECOVERY = 6;
    private static readonly int NUMBER_POTIONS = 8;
    public Board Board { get; set; }
    public Hero Hero { get; set; }

    public Game()
    {
        this.Board = new Board();
        this.Hero = new Hero();
        this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
        InitializatePotion();

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
                    if (this.Board.IsPotion(this.Hero.Row, this.Hero.Column-1))
                    {
                        
                        this.Hero.Hp += POTION_RECOVERY;
                        if (this.Hero.Hp > Hero.INITIAL_HP)
                        {
                            this.Hero.Hp = Hero.INITIAL_HP;
                        }
                    }
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Column -= 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                    this.Hero.Hp--;
                    
                }
                break;
            
            case ConsoleKey.S:
                if (this.Board.HasMove(this.Hero.Row+1, this.Hero.Column))
                {
                    if (this.Board.IsPotion(this.Hero.Row+1, this.Hero.Column))
                    {
                        
                        this.Hero.Hp += POTION_RECOVERY;
                        if (this.Hero.Hp > Hero.INITIAL_HP)
                        {
                            this.Hero.Hp = Hero.INITIAL_HP;
                        }
                    }
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Row += 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                    this.Hero.Hp--;
                    
                }
                break;
            
            case ConsoleKey.D:
                if (this.Board.HasMove(this.Hero.Row, this.Hero.Column + 1))
                {
                    if (this.Board.IsPotion(this.Hero.Row, this.Hero.Column+1))
                    {
                        
                        this.Hero.Hp += POTION_RECOVERY;
                        if (this.Hero.Hp > Hero.INITIAL_HP)
                        {
                            this.Hero.Hp = Hero.INITIAL_HP;
                        }
                    }
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Column += 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                    this.Hero.Hp--;
                    
                }
                break;
            
            case ConsoleKey.W:
                if (this.Board.HasMove(this.Hero.Row-1, this.Hero.Column))
                {
                    if (this.Board.IsPotion(this.Hero.Row-1, this.Hero.Column))
                    {
                        this.Hero.Hp += POTION_RECOVERY;
                        if (this.Hero.Hp > Hero.INITIAL_HP)
                        {
                            this.Hero.Hp = Hero.INITIAL_HP;
                        }
                    }
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Row -= 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                    this.Hero.Hp--;
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
    
    private void DisplayBoard()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("Hero HP: "+this.Hero.Hp+ " Hero Damage: "+this.Hero.Damage+ " Hero Score: "+this.Hero.Score);
        Console.WriteLine("==============================");
        this.Board.DisplayBoard();
        Console.WriteLine();
        Console.WriteLine("==============================");
        Console.WriteLine("[A] to move left.     [D] to move right.");
        Console.WriteLine("[W] to move up.       [S] to move down.");
        Console.WriteLine("[SPACE] to attack.    [ESC] to exit.");
        Console.WriteLine("==============================");
    }

    private void InitializatePotion()
    {
        int count = 0;
        do
        {
            int row = GenerateRandom.GetRandom(2, 17);
            int column= GenerateRandom.GetRandom(2, 17);
            if (this.Board.GetField(row, column).Equals("O"))
            {
                count++;
                this.Board.ChangeField(row, column, "P");
            }
        } while (count < NUMBER_POTIONS);
    }
}