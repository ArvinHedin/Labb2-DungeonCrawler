public class Goblin : Enemy
{
    public Goblin(int posx, int posy) : base(posx, posy, 'g', ConsoleColor.DarkGreen, new(1,6,3), new(1,6,1) )
    {
        Name = "Goblin";
        HP = 10;
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }

}