public class Player : LevelElement
{

    public string Name { get; set; } = "Entro";
    public int HP { get; set; } = 100;
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }
    public int VisionRange { get; set; } = 4;

    public Player(int x, int y) : base(x, y, '@', ConsoleColor.DarkYellow)
    {
        AttackDice = new Dice(2, 6, 2);
        DefenceDice = new Dice(2, 6, 0);
    }

    public Position GetNextMove()
    {
        Position newPosition = new Position(Position);
        var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    newPosition.Y--;
                    break;
                case ConsoleKey.S:
                    newPosition.Y++;
                    break;
                case ConsoleKey.A:
                    newPosition.X--;
                    break;
                case ConsoleKey.D:
                    newPosition.X++;
                    break;
            case ConsoleKey.Spacebar:
                break;
            }
        return newPosition;
    }

    public override void Draw()
    {
        Console.ForegroundColor = EntityColor;
        Console.Write(Entity);
        Console.ResetColor();
    }

    public void UpdatePosition(Position newposition)
    {
        Position = newposition;
    }
}
