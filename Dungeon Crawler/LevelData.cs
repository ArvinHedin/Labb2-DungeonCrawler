using System.IO;

class LevelData
{
    private List<LevelElement>? _elements;
    public List<LevelElement>? Elements { get { return _elements; } }

    String line;
    public void Load(string filename)
    {
        StreamReader sr = new StreamReader(filename);
        line = sr.ReadLine();

        while (line != null)
        {
            if(line == "g") { 
                Goblin goblin = new Goblin();
                _elements.Add(goblin);
                
            }
            else if(line == "l") { Lurker lurker = new Lurker(); _elements.Add(lurker);}
            else if(line == "|") { Wall wall = new Wall(); _elements.Add(wall); }

            Console.WriteLine(line);
            line = sr.ReadLine();
        }

        sr.Close();
        Console.ReadLine();
    }
}