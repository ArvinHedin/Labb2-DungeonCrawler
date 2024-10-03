public class Goblin : Enemy
{
    

    public  Dice AttackDice { get; set; } = new(1, 6, 3);
    public  Dice DefenceDice { get; set; } = new(1, 6, 1);

    public Goblin(int posx, int posy) //:base(posx, posy, 'g', ConsoleColor.DarkGreen, )
    {
        PosX = posx;
        PosY = posy;
        Entity = 'g';
        EntityColor = ConsoleColor.DarkGreen;
        Name = "Goblin";
        HP = 10;
        this.AttackDice = AttackDice;
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }

}