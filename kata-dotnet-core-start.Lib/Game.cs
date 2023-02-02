namespace kata_dotnet_core_start.Lib;

public class Game
{
    private List<Player> _players;

    private GameBoard _board;

    private Game()
    {
        _players = new List<Player>();
        _board = new GameBoard();
    }

    public IEnumerable<Player> Players => _players;

    public GameBoard Board => _board;

    public static Game Init()
    {
        return new Game()
            .AddPlayer()
            .CreateBoard();
    }

    private Game CreateBoard()
    {
        var numbers = Enumerable.Range(1, 9);
        _board.AddPositions(numbers);
        return this;
    }

    private Game AddPlayer()
    {
        _players.Add(new Player { Name = "A" });
        _players.Add(new Player { Name = "B" });
        return this;
    }

    public int ChoosePosition(int box)
    {
        return ChoosePosition("X", box);
    }

    public string GetValueAtPosition(int i)
    {
        return Board.Boxes[i];
    }

    public int ChoosePosition(string playerName, int box)
    {
        Board.Boxes[box] = playerName;
        return box;
    }
}