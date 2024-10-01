public class Dice
{
    public int NumberOfDice { get; set; }
    public int SidesPerDice { get; set; }
    public int Modifier { get; set; }

    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        NumberOfDice = numberOfDice;
        SidesPerDice = sidesPerDice;
        Modifier = modifier;
    }

}