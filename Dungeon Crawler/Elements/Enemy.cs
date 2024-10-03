
public abstract class Enemy : LevelElement
{
    public string Name { get; set; }
    public int HP { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public Enemy(int posx, int posy, char entity, ConsoleColor entitycolor, Dice attackdice, Dice defencedice) : base(posx, posy, entity, entitycolor)
    {
        this.AttackDice = attackdice;
        this.DefenceDice = defencedice; 
    }

    public abstract void Update();

}
