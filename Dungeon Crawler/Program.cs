LevelData lvl = new();
lvl.Load("C:\\Users\\Arvin\\source\\repos\\Labb 2\\Dungeon Crawler\\Levels\\Level1.txt");


GameLoop gameloop = new GameLoop(lvl);
gameloop.Run();
