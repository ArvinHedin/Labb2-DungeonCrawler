public abstract class LevelElement
{
    public abstract int PositionX { get; set; }
    public abstract int PositionY { get; set; }
    public abstract char Entity { get; set; }
    public abstract ConsoleColor Color { get; set; }

    public virtual void Draw()
    {

    }
}
