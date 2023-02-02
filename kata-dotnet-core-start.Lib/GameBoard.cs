namespace kata_dotnet_core_start.Lib;

public class GameBoard
{
    private IDictionary<int, string> _boxes = new Dictionary<int, string>();
    public IDictionary<int, string> Boxes => _boxes;
    
    public void AddPositions(IEnumerable<int> numbers)
    {
        foreach (var number in numbers)
            _boxes.Add(number, string.Empty);
    }

    public bool Empty()
    {
        return _boxes.Any(s => _boxes.Values.All(string.IsNullOrEmpty));
    }
}