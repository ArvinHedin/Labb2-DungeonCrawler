using System.IO;

class LevelData
{
    private static List<LevelElement>? _elements;
    public static List<LevelElement>? Elements { get { return _elements; } }

    public int x = 0;
    public int y = 0;
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
                    _elements.Add(new Player(x, y));
                    int playerx = x;
                    int playery = y;
                }
            }
        }
    }

    public LevelElement GetLevelElementAt(Position position)
    {
        

        foreach (LevelElement element in Elements)
        {
            if (element.Position.Equals(position))
            {
                return element;
            }
        }
        return null;
    }
}