public class Goblin : Enemy
{
    public override int PositionX { get; set; }
    public override int PositionY { get; set; }
    public override char Entity { get; set; } = 'g';
    public override ConsoleColor Color { get; set; } = ConsoleColor.Green;
    public override string Name { get; set; } = "Goblin";
    public override int HP { get; set; } = 10;
    public override Dice AttackDice { get; set; } = new(1, 6, 3);
    public override Dice DefenceDice { get; set; } = new(1, 6, 1);
    


}