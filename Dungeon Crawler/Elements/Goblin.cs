public class Goblin : Enemy
{
    public Goblin(int x, int y) : base(x, y, 'g', ConsoleColor.DarkGreen, new(1,6,3), new(1,6,1))
    {
        Name = "Goblin";
        HP = 10;
    }

    Random random = new Random();
    public override Position GetNextMove(Position playerPosition)
    {
        var newPosition = new Position(Position);
        
        int direction = random.Next(4);

        switch (direction)
        {
            case 0:
                newPosition.X--;
                break;
            case 1:
                newPosition.X++;
                break;
            case 2:
                newPosition.Y--;
                break;
            case 3:
                newPosition.Y++;
                break;
        }
        return newPosition;
    }

}