public struct Position
{
    public int PosX { get; set; }
    public int PosY { get; set; }

    public Position(Position position) : this(position.PosX, position.PosY)
    {

    }
    public Position(int posx, int posy) 
    {
        this.PosX = posx;
        this.PosY = posy;
    }

}
