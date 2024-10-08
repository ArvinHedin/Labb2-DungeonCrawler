LevelData lvl = new();
lvl.Load("Levels\\Level1.txt");
var player = new Player(lvl., lvl.y);
GameLoop gameloop = new GameLoop(lvl, player);
gameloop.Run();









Console.WriteLine();


