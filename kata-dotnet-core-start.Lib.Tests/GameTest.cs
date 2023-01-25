namespace kata_dotnet_core_start.Lib.Tests;

public class GameTest
{
    [Fact]
    public void Game_ShouldHave_TwoPlayers()
    {
        //arrange
        var game = new Game();

        //act
        var players = game.GetPlayers();

        //assert
        Assert.NotNull(players);
        Assert.NotEmpty(players);
        Assert.Equal(2, players.Count);
    }
}