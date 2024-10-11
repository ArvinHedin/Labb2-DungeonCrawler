public class Dice
{
    public virtual int NumberOfDice { get; set; }
    public virtual int SidesPerDice { get; set; }
    public virtual int Modifier { get; set; }
    private Random random = new Random();

    
    
    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        NumberOfDice = numberOfDice;
        SidesPerDice = sidesPerDice;
        Modifier = modifier;
    }

    public int Throw()
    {
        int totalRoll = 0;
        for (int i = 0; i < NumberOfDice; i++)
        {
            int diceRoll = random.Next(1, SidesPerDice + 1);
            totalRoll += diceRoll;
        }
        int result = totalRoll + Modifier;
        return result;
    }

    public override string ToString()
    {
        return $"{NumberOfDice}d{SidesPerDice}+{Modifier}";
    }
}