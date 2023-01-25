namespace kata_dotnet_core_start.Lib;

public class GameBoard
{
    private List<int> _positions = new List<int>();
    public IEnumerable<int> Positions => _positions;

    public void AddPosition(int number)
    {
        _positions.Add(number);
    }
    
    public void AddPositions(IEnumerable<int> numbers)
    {
        _positions.AddRange(numbers);
    }
}