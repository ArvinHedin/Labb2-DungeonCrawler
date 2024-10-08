public class Goblin : Enemy
{
    public Goblin(int posx, int posy) : base(posx, posy, 'g', ConsoleColor.DarkGreen, new(1,6,3), new(1,6,1) )
    {
        Name = "Goblin";
        HP = 10;
    }

    Random random = new Random();
    

    public override void Update()
    {
        int direction = random.Next(4);

        switch (direction)
        {
            case 0:
                PosX -= 1;
                break;
            case 1:
                PosX += 1;
                break;
            case 2:
                PosY -= 1;
                break;
            case 3:
                PosY += 1;
                break;

        }

        Console.SetCursorPosition(PosX, PosY);
    }

}