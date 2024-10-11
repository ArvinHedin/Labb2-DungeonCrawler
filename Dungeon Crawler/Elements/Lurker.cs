
public class Lurker : Enemy
{
    private const int FleeDistance = 3;
    public Lurker(int x, int y) : base(x, y, 'l', ConsoleColor.Magenta, new(3,4,2), new(1,8,5))
    {
        Name = "Lurker";
        HP = 25; 
    }


    public override Position GetNextMove(Position playerPosition)
    {

        if (IsPlayerNearby(playerPosition))
        {
            return MoveAwayFromPlayer(playerPosition);
        }
        
        return Position;
    }

    private bool IsPlayerNearby(Position playerPosition)
    {
        int dx = Math.Abs(Position.X - playerPosition.X);
        int dy = Math.Abs(Position.Y - playerPosition.Y);
        return Math.Max(dx, dy) <= FleeDistance;
    }
    private Position MoveAwayFromPlayer(Position playerposition)
    {
        Position newPosition = new Position(Position);

        if (Position.X < playerposition.X) newPosition.X--;
        else if (Position.X > playerposition.X) newPosition.X++;

        if (Position.Y < playerposition.Y) newPosition.Y--;
        else if (Position.Y > playerposition.Y) newPosition.Y++;

        return newPosition;
    }
}
