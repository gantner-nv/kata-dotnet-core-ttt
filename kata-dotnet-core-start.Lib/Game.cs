﻿namespace kata_dotnet_core_start.Lib;

public class Game
{
    private List<Player> _players;
    private GameBoard _board;
    private IList<int> rowStartNumber = new List<int> { 1, 4, 7 };
    private IList<int> columnStartNumber = new List<int> { 1, 2, 3 };
    public string _winner;

    private Game()
    {
        _players = new List<Player>();
        _board = new GameBoard();
    }

    public IEnumerable<Player> Players => _players;

    public GameBoard Board => _board;

    public string CurrentPlayer { get; private set; }

    public static Game Init(string player = "X")
    {
        return new Game()
            .AddPlayer()
            .CreateBoard()
            .SwitchPlayer(player);
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

    public bool ChoosePosition(int box)
        => ChoosePosition("X", box);

    public bool ChoosePosition(string playerName, int box)
    {
        if (!ValidPlayer(playerName))
            throw new InvalidOperationException("Its not your turn.");
        if (HasValue(box))
            return false;

        Board.Boxes[box] = playerName;
        SwitchPlayer(playerName == "X" ? "O" : "X");
        return true;
    }

    public bool HasValue(int box)
    {
        return !string.IsNullOrEmpty(Board.Boxes[box]);
    }

    public Game SwitchPlayer(string player)
    {
        CurrentPlayer = player;
        return this;
    }

    private bool ValidPlayer(string player)
    {
        return CurrentPlayer != player;
    }

    public string GameStatus()
    {
        if (IsRowMatched())
            return $"Winner is {_winner}";
        if (!IsRowMatched() && !IsColumnMatched())
            return "Game Over";

        return string.Empty;
    }

    private bool IsRowMatched()
    {
        return rowStartNumber.Count(CheckRow) > 0;
    }

    private bool CheckRow(int start)
    {
        var range = Board.Boxes.Where(x => x.Key >= start && x.Key <= start + 2);
        var isWin = range.Select(x => x.Value).Distinct().Count() == 1;
        if (isWin)
            _winner = range.Select(x => x.Value).First();
        return isWin;
    }

    private bool IsColumnMatched()
    {
        return columnStartNumber.Count(CheckColumn) == rowStartNumber.Count;
    }

    private bool CheckColumn(int start)
    {
        var range = Board.Boxes.Where(x =>
            x.Key == start || x.Key == start + 3 || x.Key == start + 6);
        return range.Select(x => x.Value).Distinct().Count() == 1;
    }
}