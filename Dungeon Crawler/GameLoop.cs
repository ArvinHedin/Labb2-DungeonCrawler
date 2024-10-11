using System.Diagnostics;

internal class GameLoop
{
    private LevelData _levelData;
    private Player _player;
    private const int StatusRow = 3;
    private const int VisionRadius = 4;
    private int loopCounter = 0;
    public GameLoop(LevelData data)
    {
        this._levelData = data;
        this._player = data.Player;
    }

    public void Run()
    {
        Console.CursorVisible = false;
        while(true)
        {
            loopCounter++;
            Console.Clear();
            DrawStatusBar();
            DrawElements();
            MovePlayer();
            UpdateEnemies();

            

            

            if (_player.HP <= 0)
            {
                Console.WriteLine("You were defeated!\nGAME OVER!");
                Console.ResetColor();
                break;
            }
        }
    }


    private void DrawElements()
    {
        foreach (var wall in _levelData.RevealedWalls)
        {
            Console.SetCursorPosition(wall.Position.X, wall.Position.Y + StatusRow);
            wall.Draw();
        }
        
        foreach (var element in _levelData.Elements)
        {
            if (IsWithinVisionRange(element.Position))
            {
                Console.SetCursorPosition(element.Position.X, element.Position.Y + StatusRow);
                element.Draw();

                if (element is Wall wall)
                {
                    _levelData.RevealWall(wall);
                }
            }
        }

        Console.SetCursorPosition(_player.Position.X, _player.Position.Y + StatusRow);
        _player.Draw();
    }
    private bool IsWithinVisionRange(Position position)
    {
        int dx = position.X - _player.Position.X;
        int dy = position.Y - _player.Position.Y;
        double distance = Math.Sqrt(dx * dx + dy * dy);
        return distance <= VisionRadius;
    }
    private void MovePlayer()
    {
        Position newPosition = _player.GetNextMove();
        if (IsValidMove(newPosition) && !IsOccupiedByEnemy(newPosition))
        {
            _player.UpdatePosition(newPosition);
            AttackEnemy();
        } 
        else if (IsOccupiedByEnemy(newPosition))
        {
            AttackEnemyAt(newPosition);
        }
    }
    private void UpdateEnemies()
    {
        foreach (var element in _levelData.Elements.ToList())
        {
            if (element is Enemy enemy)
            {
                if (enemy.HP <= 0)
                {
                    _levelData.Elements.Remove(enemy);
                    continue;
                }

                Position newPosition = enemy.GetNextMove(_player.Position);
                if (IsValidMove(newPosition) && !IsOccupiedByEnemy(newPosition) && !IsOccupiedByEnemy(newPosition))
                {
                    enemy.UpdatePosition(newPosition);
                }
            }
        }
    }
    private void AttackEnemy()
    {
        List<Position> adjecentPositions = GetAdjecentPositions(_player.Position);

        foreach (var position in adjecentPositions)
        {
            if (IsOccupiedByEnemy(position))
            {
                AttackEnemyAt(position);
                return;
            }
        }
    }
    private void AttackEnemyAt(Position position)
    {
        Enemy enemy = _levelData.Elements.FirstOrDefault(e => e is Enemy && e.Position == position) as Enemy;
        if (enemy != null)
        {
            int playerAttack = _player.AttackDice.Throw();
            int enemyDefense = enemy.DefenceDice.Throw();
            int damage = Math.Max(0, playerAttack - enemyDefense);
            enemy.HP -= damage;
            Console.SetCursorPosition(0, 1);

            if (damage <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You (ATK: {_player.AttackDice} => {_player.AttackDice.Throw()}) attacked the {enemy.Name} (DEF: {enemy.DefenceDice} => {enemy.DefenceDice.Throw()}), but didn't damage it.");
                Console.ResetColor();
            }
            else if (damage <= 5 && damage > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"You (ATK: {_player.AttackDice} => {_player.AttackDice.Throw()}) attacked the {enemy.Name} (DEF: {enemy.DefenceDice} => {enemy.DefenceDice.Throw()}), slightly wounding it.");
                Console.ResetColor();

            }
            else if (damage > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You (ATK: {_player.AttackDice} => {_player.AttackDice.Throw()}) attacked the {enemy.Name} (DEF: {enemy.DefenceDice} => {enemy.DefenceDice.Throw()}), badly wounding it.");
                Console.ResetColor();
            }

            if (enemy.HP <= 0)
            {
                Console.WriteLine($"{enemy.Name} has been defeated!");
                _levelData.Elements.Remove(enemy);
                Console.ReadKey(true);
            }
            else
            {
                int enemyAttack = enemy.AttackDice.Throw();
                int playerDefense = _player.DefenceDice.Throw();
                damage = Math.Max(0, enemyAttack - playerDefense);
                _player.HP -= damage;

                if (damage <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {enemy.AttackDice.Throw()}) attacked you (DEF: {enemy.DefenceDice} => {_player.DefenceDice.Throw()}), but didn't damage it.");
                    Console.ResetColor();
                }
                else if (damage <= 5 && damage > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"The {enemy.Name} (ATK: {_player.AttackDice} => {_player.AttackDice.Throw()}) attacked you (DEF: {enemy.DefenceDice} => {_player.DefenceDice.Throw()}), slightly wounding it.");
                    Console.ResetColor();
                }
                else if (damage > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The {enemy.Name} (ATK: {_player.AttackDice} => {_player.AttackDice.Throw()}) attacked you (DEF: {enemy.DefenceDice} => {_player.DefenceDice.Throw()}), badly wounding it.");
                    Console.ResetColor();
                }

                if (_player.HP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You died!");
                    return;
                }

                Console.ReadKey(true);
            }
        }
    }
    private List<Position> GetAdjecentPositions(Position position)
    {
        return new List<Position>
        {
            new Position(position.X - 1, position.Y),
            new Position(position.X + 1, position.Y),
            new Position(position.X, position.Y - 1),
            new Position(position.X, position.Y + 1)
        };
    }
    private bool IsValidMove(Position newPosition)
    {
        if (newPosition.X < 0 || newPosition.X >= Console.WindowWidth || newPosition.Y < 0 || newPosition.Y >= Console.WindowHeight - StatusRow)
        {
            return false;
        }
        LevelElement elementAtNewPosition = _levelData.GetLevelElementAt(newPosition);
        return elementAtNewPosition == null || elementAtNewPosition is Enemy;
    }
    private bool IsOccupiedByPlayer(Position position)
    {
        return _player.Position.Equals(position);
    }
    private bool IsOccupiedByEnemy(Position position)
    {
        return _levelData.Elements.Any(e => e is Enemy && e.Position == position);
    }
    private void DrawStatusBar()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"Player = {_player.Name}  -  HP = {_player.HP}/100  - Turn = {loopCounter} ");
    }
}