namespace kata_dotnet_core_start.Lib;

public class Game
{
    public List<Player> GetPlayers()
    {
        Player p1 = new Player()
        {
            Name = "x"
        };
        
        Player p2 = new Player()
        {
            Name = "o"
        };
         
        return new List<Player>(){p1,p2};
    }
}