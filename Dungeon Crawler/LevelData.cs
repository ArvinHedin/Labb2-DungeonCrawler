using System.IO;

class LevelData
{
    private List<LevelElement>? _elements;
    public List<LevelElement>? Elements { get { return _elements; } }

    
    public void Load(string filename)
    {
        _elements = new List<LevelElement>();
        using (StreamReader sr = new StreamReader(filename))
        {
            while (sr.Peek() >= 0)
            {
                char c = (char)sr.Read();
            }
        }
        Console.WriteLine();

        //foreach (var element in Elements)
        //{
        //    element.Draw();
        //}


    }
}