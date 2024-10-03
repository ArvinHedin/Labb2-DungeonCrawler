//using System.IO;

//class LevelData
//{
//    private List<LevelElement>? _elements;
//    public List<LevelElement>? Elements { get { return _elements; } }
//    List<LevelElement> levelElements = new List<LevelElement>(); 

//    String line;
//    public void Load(string filename)
//    {
//        StreamReader sr = new StreamReader("C:\\Users\\Arvin\\source\\repos\\Labb 2\\Dungeon Crawler\\Levels\\Level1.txt");
//        line = sr.ReadLine();

//        while (line != null)
//        {
//            Console.WriteLine(line);
//            line = sr.ReadLine();
//        }

//        sr.Close();
//        Console.ReadLine();
//    }
//}