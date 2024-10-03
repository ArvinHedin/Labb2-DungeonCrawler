public abstract class LevelElement
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    protected char Entity { get; set; }
    protected ConsoleColor EntityColor { get; set; }
    
    

    public LevelElement(int posx, int posy, char entity, ConsoleColor entitycolor) 
    {
        PosX = posx;
        PosY = posy;
        Entity = entity;
        EntityColor = entitycolor;
    }

    public virtual void Draw()
    {
        Console.ForegroundColor = EntityColor; 
        Console.SetCursorPosition(PosX, PosY);
        Console.WriteLine(Entity);
        Console.ResetColor();
    }
}
