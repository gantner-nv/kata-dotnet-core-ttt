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
        Assert.Equal(9, boards.Boxes.Count());
    }

    [Fact]
    public void GameBoard_ShouldBe_Empty()
    {
        //arrange
        var game = Game.Init();

        //act
        var board = game.Board;

        //assert
        Assert.True(board.Empty());
    }

    public void PlayerOne_ShouldChoose_EmptyBox()
    {
        //arrange
        var game = Game.Init();

        //act
        var box = game.ChoosePosition(2);

        //assert
        Assert.Equal(string.Empty, game.GetValueAtPosition(box));
    }

    [Fact]
    public void PlayerOne_ShouldFill_Box()
    {
        //arrange
        var game = Game.Init();

        //act
        var box = game.ChoosePosition(2);

        //assert
        Assert.Equal("X", game.GetValueAtPosition(box));
    }

    [Fact]
    public void PlayerTwo_ShouldFill_Box()
    {
        //arrange
        var game = Game.Init();

        //act
        var box = game.ChoosePosition("O", 2);

        //assert
        Assert.Equal("O", game.GetValueAtPosition(box));
    }
}