
public abstract class Enemy : LevelElement
{
    public string Name { get; set; }
    public int HP { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public Enemy(int x, int y, char entity, ConsoleColor entitycolor, Dice attackdice, Dice defencedice) 
        : base(x, y, entity, entitycolor)
    {
        this.AttackDice = attackdice;
        this.DefenceDice = defencedice;
        
    }

    public abstract Position GetNextMove(Position playerPosition);

    public void UpdatePosition(Position newPosition)
    {
        Position = newPosition;
    }

}
