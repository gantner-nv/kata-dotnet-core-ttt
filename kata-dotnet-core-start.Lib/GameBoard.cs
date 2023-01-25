namespace kata_dotnet_core_start.Lib;

public class GameBoard
{
    private List<int> _positions = new List<int>();
    public IEnumerable<int> Positions => _positions;
    public Dictionary<int, string> Boxes = new Dictionary<int, string>();

    public void AddPositions(IEnumerable<int> numbers)
    {
        _positions.AddRange(numbers);
        Boxes = numbers.Select(x => new KeyValuePair(x, string.Empty));
    }
}