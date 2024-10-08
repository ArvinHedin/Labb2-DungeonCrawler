internal class GameLoop
{
    private LevelData _levelData;
    private Player _player;

    public GameLoop(LevelData data, Player player )
    {
        this._levelData = data;
        this._player = player;
    }

    public void Run()
    {
        while(true)
        {
            // vänta på input

            // gör metod för att uppdatera enemies

            // kolliderar elements?

            //



        }
        

    }

    private void UpdateEnemies()
    {
        List<Enemy> enemies = _levelData.Elements.OfType<Enemy>().ToList();

        foreach (Enemy enemy in _levelData.enemy)
        {
            enemy.Draw();
                
        }
    }


}