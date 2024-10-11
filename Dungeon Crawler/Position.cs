using System.Diagnostics.CodeAnalysis;

public struct Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
    public Position(Position position) : this(position.X, position.Y)
    {
    }

    public static Position operator +(Position a, Position b)
    {
        return new Position(a.X + b.X, a.Y + b.Y);
    }
    public bool Equals(Position other)
    {
        return X == other.X && Y == other.Y;
    }
    public override bool Equals(object obj)
    {
        return obj is Position other && Equals(other);
    }
    public override int GetHashCode()
    {
       return HashCode.Combine(X, Y);
    }
    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }
    public static bool operator !=(Position left, Position right)
    {
        return !(left == right);
    }
}
