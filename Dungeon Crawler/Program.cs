var mongo = new MongoGameService();

Console.Write("Do you want to load a save? (y/n): ");
if (Console.ReadLine()?.ToLower() == "y")
{
    Console.Write("Playername: ");
    var name = Console.ReadLine();
    var save = await mongo.Load(name);

    if (save != null)
    {
        LevelData lvl = new();
        lvl.Load("C:\\Users\\Arvin\\source\\repos\\Labb 2\\Dungeon Crawler\\Levels\\Level1.txt");
        var gameloop = new GameLoop(lvl);
        gameloop.LoadFromBson(save);
        gameloop.Run();

        await mongo.Save(name, gameloop.ToBson());
        return;
    }
    else
    {
        Console.WriteLine("No save found.");
    }
}


LevelData newLvl = new();
newLvl.Load("C:\\Users\\Arvin\\source\\repos\\Labb 2\\Dungeon Crawler\\Levels\\Level1.txt");
Console.Write("Enter player name: ");
string newName = Console.ReadLine();
newLvl.Player.Name = newName;
var newLoop = new GameLoop(newLvl);
newLoop.Run();

Console.Write("Save game? (y/n): ");
if (Console.ReadLine()?.ToLower() == "y")
{
    await mongo.Save(newLoop.PlayerName, newLoop.ToBson());
    Console.WriteLine("Game saved!");
}
