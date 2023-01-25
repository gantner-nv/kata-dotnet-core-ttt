namespace kata_dotnet_core_start.Lib.Tests;

public class GameTest
{
    [Fact]
    public void Game_ShouldHave_TwoPlayers()
    {
        //arrange
        var game = Game.Init();

        //act
        var players = game.Players;

        //assert
        Assert.NotNull(players);
        Assert.Equal(2, players.Count());
    }

    [Fact]
    public void GameBoard_ShouldHave_9_Position()
    {
        //arrange
        var game = Game.Init();

        //act
        var boards = game.Board;

        //assert
        Assert.NotNull(boards);
        Assert.Equal(9, boards.Positions.Count());
    }

    [Fact]
    public void PlayerOne_ShouldChoose_OnePosition()
    {
        //arrange
        var game = Game.Init();

        //act
        var position = game.ChoosePosition(2);

        //assert
        Assert.Equal("x", game.GetValueAtPosition(2));
    }
}