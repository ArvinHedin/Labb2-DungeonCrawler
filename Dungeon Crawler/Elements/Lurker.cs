public class Lurker : Enemy
{
    public override int PositionX { get; set; }
    public override int PositionY { get; set; }
    public override char Entity { get; set; } = 'l';
    public override ConsoleColor Color { get; set; } = ConsoleColor.Magenta;
    public override string Name { get; set; } = "Lurker";
    public override int HP { get; set; } = 25;
    public override Dice AttackDice { get; set; } = new(3, 4, 2);
    public override Dice DefenceDice { get; set; } = new(1, 8, 5);
}