public abstract class LevelElement
{
    protected char Entity { get; set; }
    protected ConsoleColor EntityColor { get; set; }
    public Position Position { get; set; }
    private const int StatusRow = 3;


    public LevelElement(int x, int y, char entity, ConsoleColor entitycolor) 
    {
        Position = new Position(x, y);
        Entity = entity;
        EntityColor = entitycolor;
        
    }

    public virtual void Draw()
    {
        Console.ForegroundColor = EntityColor;
        Console.SetCursorPosition(Position.X, Position.Y + StatusRow);
        Console.Write(Entity);
        Console.ResetColor();
    }
}
