public class Player : LevelElement
{

    public string Name { get; set; } = "Entro";
    public int HP { get; set; } = 100;
    protected Dice AttackDice { get; set; } = new Dice(2, 6, 2);
    protected Dice DefenceDice { get; set; } = new Dice(2, 6, 0);

    public Player(int posx, int posy) : base(posx, posy, '@', ConsoleColor.DarkYellow)
    {
        
    }

    public void Update()
    {

    }
}