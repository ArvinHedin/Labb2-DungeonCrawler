using System.IO;

class LevelData
{
    private List<LevelElement>? _elements;
    public List<LevelElement>? Elements { get { return _elements; } }
    public List<RevealedWall> RevealedWalls { get; private set; }
    public Player Player { get; private set; }

    public int x = 0;
    public int y = 0;
   
    public LevelData()
    {
        RevealedWalls = new List<RevealedWall>();
    }
    public void Load(string filename)
    {
        _elements = new List<LevelElement>();
        using (StreamReader sr = new StreamReader(filename))
        {
            while (sr.Peek() >= 0)
            {
                char c = (char)sr.Read();
                x++;
                
                if (c == '\n')
                {
                    y++;
                    x = 0;
                }
                if (c == '|')
                {
                    _elements.Add(new Wall(x, y));
                }
                else if (c == 'g')
                {
                    _elements.Add(new Goblin(x, y));   
                }
                else if (c == 'l')
                {
                    _elements.Add(new Lurker(x, y));
                }
                else if (c == '@')
                {
                    Player = new Player(x, y);
                }
            }
            
        }
    }

    public LevelElement GetLevelElementAt(Position position)
    {
        return Elements.FirstOrDefault(e => e.Position == position);
    }
    public void RevealWall(Wall wall)
    {
        if (!RevealedWalls.Any(rw => rw.Position == wall.Position))
        {
            RevealedWalls.Add(new RevealedWall(wall.Position.X, wall.Position.Y));
        }
    }
}