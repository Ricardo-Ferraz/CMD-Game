namespace CMD_Game.Game;

public class Board
{
    private static readonly int GRID= 20;
    private static readonly String CHARACTER_DISPLAY = "O";

    private String[,] fields;

    public Board()
    {
        this.fields= new String[GRID, GRID];
        this.InitializateFields();
    }

    private void InitializateFields()
    {
        for (int i = 0; i < this.fields.GetLength(0); i++)
        {
            for (int j = 0; j < this.fields.GetLength(0); j++)
            {
                this.fields[i, j] = CHARACTER_DISPLAY;
            }
        }
    }

    public void ChangeField(int row, int column, String change)
    {
        this.fields[row, column] = change;
    }

    public void DisplayBoard()
    {
        for (int i = 0; i < this.fields.GetLength(0); i++)
        {
            for (int j = 0; j < this.fields.GetLength(0); j++)
            {
                switch (this.fields[i,j])
                {
                    case "H":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    
                    case "B":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    
                    case "M":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    
                    case "P":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    
                    case "D":
                        Console.ForegroundColor = ConsoleColor.Blue; 
                        break;
                }
                Console.Write(this.fields[i,j]+ " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    public bool HasMove(int row, int column)
    {
        try
        {
            string a= this.fields[row, column];
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

}