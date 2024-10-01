public abstract class Enemy : LevelElement
{
    public abstract string Name { get; set; }
    public abstract int HP { get; set; }
    public abstract Dice AttackDice { get; set; }
    public abstract Dice DefenceDice { get; set; }
    

}
