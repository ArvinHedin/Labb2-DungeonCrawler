public class Lurker : Enemy
{

    public  string Name { get; set; } = "Lurker";
    public  int HP { get; set; } = 25;
    public  Dice AttackDice { get; set; } = new(3, 4, 2);
    public  Dice DefenceDice { get; set; } = new(1, 8, 5);

    public override void Update()
    {
        throw new NotImplementedException();
    }
}