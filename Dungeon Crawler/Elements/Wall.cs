public class Wall : LevelElement
{
    public override int PositionX { get; set; } 
    public override int PositionY { get; set; }
    public override char Entity { get; set; } = '|';
    public override ConsoleColor Color { get; set; } = ConsoleColor.White;

}