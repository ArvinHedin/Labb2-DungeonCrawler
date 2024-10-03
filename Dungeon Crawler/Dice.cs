
public class Dice
{
    public virtual int NumberOfDice { get; set; }
    public virtual int SidesPerDice { get; set; }
    public virtual int Modifier { get; set; }

    public int diceRoll;
    public Random random = new Random();
    
    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        NumberOfDice = numberOfDice;
        SidesPerDice = sidesPerDice;
        Modifier = modifier;
        diceRoll = random.Next(1, SidesPerDice + 1);
    }

    public int Throw()
    {
        return NumberOfDice * diceRoll + Modifier;
    }

    public override string ToString()
    {
        return $"{NumberOfDice}d{SidesPerDice}+{Modifier}";
    }
}