using CMD_Game.Model;
using CMD_Game.Utils;

namespace CMD_Game.Game;

public class Game
{
    private static readonly int POTION_RECOVERY = 6;
    private static readonly int NUMBER_POTIONS = 8;
    private static readonly int EASY_QTD_MONSTER = 6;
    private static readonly int MEDIUM_QTD_MONSTER = 8;
    private static readonly int HARD_QTD_MONSTER = 12;
    private Board Board { get; set; }
    private Base Hero { get; set; }
    
    private Base[] Monsters { get; set; }
    
    private Base Boss { get; set; }
    

    public Game(ConsoleKey k)
    {
        this.Board = new Board();
        this.Hero = new Hero();
        this.Boss = new Boss();
        switch (k)
        {
            case ConsoleKey.F:
                this.Monsters = new Monster[EASY_QTD_MONSTER];
                break;
            
            case ConsoleKey.M:
                this.Monsters = new Monster[MEDIUM_QTD_MONSTER];
                break;
            
            case ConsoleKey.D:
                this.Monsters = new Monster[HARD_QTD_MONSTER];
                break;
        }
        this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
        this.InitializatePotion();
        this.InitializateWeapon();
        this.InitializateMonsters();
        this.InitializateBoss();
        do
        {
            Console.WriteLine();
            this.DisplayBoard();
            this.HeroTurn();
            this.MonstersTurn();
            this.BossTurn();
        } while (this.Hero.Hp != 0 && !(this.Board.HeroResearch(this.Hero.Row, this.Hero.Column)));
        Console.WriteLine();
        this.DisplayBoard();
        if (this.Board.HeroResearch(this.Hero.Row, this.Hero.Column))
        {
            Console.WriteLine("Você encontrou a saída, parabéns!");
        }
        else
        {
            Console.WriteLine("Seu Herói chegou a 0 de vida, você perdeu!");
        }
    }

    private void HeroTurn()
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
                        if (this.Hero.Hp > Base.INITIAL_HERO_HP)
                        {
                            this.Hero.Hp =  Base.INITIAL_HERO_HP;
                        }
                    }
                    else if (this.Board.IsWeapon(this.Hero.Row, this.Hero.Column - 1))
                    {
                        this.Hero.Damage++;
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
                        if (this.Hero.Hp > Base.INITIAL_HERO_HP)
                        {
                            this.Hero.Hp = Base.INITIAL_HERO_HP;
                        }
                    }
                    else if (this.Board.IsWeapon(this.Hero.Row+1, this.Hero.Column))
                    {
                        this.Hero.Damage++;
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
                        if (this.Hero.Hp > Base.INITIAL_HERO_HP)
                        {
                            this.Hero.Hp = Base.INITIAL_HERO_HP;
                        }
                    }
                    else if (this.Board.IsWeapon(this.Hero.Row, this.Hero.Column+1))
                    {
                        this.Hero.Damage++;
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
                        if (this.Hero.Hp > Base.INITIAL_HERO_HP)
                        {
                            this.Hero.Hp = Base.INITIAL_HERO_HP;
                        }
                    }
                    else if (this.Board.IsWeapon(this.Hero.Row-1, this.Hero.Column))
                    {
                        this.Hero.Damage++;
                    }
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "O");
                    this.Hero.Row -= 1;
                    this.Board.ChangeField(this.Hero.Row, this.Hero.Column, "H");
                    this.Hero.Hp--;
                }
                break;
            
            case ConsoleKey.Spacebar:
                if (this.Board.BossNearby(this.Hero.Row, this.Hero.Column))
                {
                    this.Boss.Hp -= this.Hero.Damage;
                    if (this.Boss.Hp <= 0)
                    {
                        this.Board.ChangeField(this.Boss.Row, this.Boss.Column, "O");
                        Console.WriteLine("Boss Derrotado!");
                    }
                }
                else
                {
                    if (this.Board.MonsterNearby(this.Hero.Row, this.Hero.Column))
                    {
                        foreach (var monster in this.Monsters)
                        {
                            if (monster.Hp > 0)
                            {
                                if (this.Board.HeroNearby(monster.Row, monster.Column))
                                {
                                    monster.Hp -= this.Hero.Damage;
                                    if (monster.Hp <= 0)
                                    {
                                        monster.Hp = 0;
                                        this.Board.ChangeField(monster.Row, monster.Column, "O");
                                    }
                                }   
                            }
                        }
                    }
                }
                
                break;
            
            case ConsoleKey.Escape:
                Console.WriteLine("Obrigado por Jogar!");
                Environment.Exit(0);
                break;
        }
    }
    
    private void DisplayBoard()
    {
        Console.WriteLine("================================================");
        Console.WriteLine("Hero HP: "+this.Hero.Hp+ " Hero Damage: "+this.Hero.Damage+ " Hero Score: "+this.Hero.Score);
        Console.WriteLine("================================================");
        this.Board.DisplayBoard();
        Console.WriteLine();
        Console.WriteLine("================================================");
        Console.WriteLine("[A] to move left.     [D] to move right.");
        Console.WriteLine("[W] to move up.       [S] to move down.");
        Console.WriteLine("[SPACE] to attack.    [ESC] to exit.");
        Console.WriteLine("================================================");
    }

    private void InitializatePotion()
    {
        var count = 0;
        do
        {
            var row = GenerateRandom.GetRandom(2, 17);
            var column= GenerateRandom.GetRandom(2, 17);
            if (this.Board.GetField(row, column).Equals("O"))
            {
                count++;
                this.Board.ChangeField(row, column, "P");
            }
        } while (count < NUMBER_POTIONS);
    }

    private void InitializateWeapon()
    {
        var row = GenerateRandom.GetRandom(0, 20);
        var column = GenerateRandom.GetRandom(0, 20);
        while (!this.Board.GetField(row, column).Equals("O"))
        {
            row = GenerateRandom.GetRandom(0, 20);
            column = GenerateRandom.GetRandom(0, 20);
        }
        this.Board.ChangeField(row, column, "W");
       
    }

    private void InitializateMonsters()
    {
        for (int i = 0; i < this.Monsters.Length; i++)
        {
            this.Monsters[i] = new Monster();
            var row = GenerateRandom.GetRandom(2, 17);
            var column = GenerateRandom.GetRandom(2, 17);
            while (!this.Board.GetField(row, column).Equals("O"))
            {
                row = GenerateRandom.GetRandom(2, 17);
                column = GenerateRandom.GetRandom(2, 17);
            }
            this.Monsters[i].ChangePosition(row, column);
            this.Board.ChangeField(row, column, "M");
        }
    }

    private void InitializateBoss()
    {
        var row = GenerateRandom.GetRandom(2, 17);
        var column = GenerateRandom.GetRandom(2, 17);
        while (!this.Board.GetField(row, column).Equals("O"))
        {
            row = GenerateRandom.GetRandom(0, 20);
            column = GenerateRandom.GetRandom(0, 20);
        }
        this.Boss.ChangePosition(row, column);
        this.Board.ChangeField(row, column, "B");
    }

    private void MonstersTurn()
    {
        foreach (var t in this.Monsters)
        {
            if (this.Board.HeroNearby(t.Row, t.Column))
            {
                Console.WriteLine("Herói sofreu 1 de dano por Monstro!");
                this.Hero.Hp -= t.Damage;
                if (this.Hero.Hp < 0)
                {
                    this.Hero.Hp = 0;
                }
            }
            else
            {
                var row = GenerateRandom.GetRandom(2, 17);
                var column = GenerateRandom.GetRandom(2, 17); 
                while (!this.Board.GetField(row, column).Equals("O"))
                {
                    row = GenerateRandom.GetRandom(2, 17);
                    column = GenerateRandom.GetRandom(2, 17);
                }
                this.Board.ChangeField(t.Row, t.Column, "O");
                t.ChangePosition(row, column);
                this.Board.ChangeField(row, column, "M");
            }
        }
    }

    private void BossTurn()
    {
        if (this.Board.HeroNearby(this.Boss.Row, this.Boss.Column))
        {
            Console.WriteLine("Herói sofreu 2 de dano por Boss!");
            this.Hero.Hp -= this.Boss.Damage;
            if (this.Hero.Hp < 0)
            {
                this.Hero.Hp = 0;
            }
        }
        else
        {
            var row = GenerateRandom.GetRandom(2, 17);
            var column = GenerateRandom.GetRandom(2, 17); 
            while (!this.Board.GetField(row, column).Equals("O"))
            {
                row = GenerateRandom.GetRandom(2, 17);
                column = GenerateRandom.GetRandom(2, 17);
            }
            this.Board.ChangeField(this.Boss.Row, this.Boss.Column, "O");
            this.Boss.ChangePosition(row, column);
            this.Board.ChangeField(row, column, "B");
        }
    }
}