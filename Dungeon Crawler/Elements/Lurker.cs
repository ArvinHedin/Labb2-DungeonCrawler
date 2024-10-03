public class Lurker : Enemy
{
    public Lurker(int posx, int posy) : base(posx, posy, 'l', ConsoleColor.Magenta, new(3,4,2), new(1,8,5))
    {
        Name = "Lurker";
        HP = 25;
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}