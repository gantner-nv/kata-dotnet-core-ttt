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

    [Fact]
    public void Selected_Box_MustBeEmpty()
    {
        //arrange
        var game = Game.Init();

        //act
        var box = game.HasValue(2);

        //assert
        Assert.False(box);
    }
    
    [Theory]
    [InlineData()]
    public void Same_Player_Should_Not_Take_Next_Turn()
    {
        //arrange
        var game = Game.Init();

        //act
        var result = game.ChoosePosition("O", 2);

        //assert
        Assert.True(result);
    }
    
    [Fact]
    public void PlayerTwo_ShouldFill_Box()
    {
        //arrange
        var game = Game.Init();

        //act
        var result = game.ChoosePosition("O", 2);

        //assert
        Assert.True(result);
    }
    
    [Fact]
    public void NextPlayer_WillBe_PlayerTwo()
    {
        //arrange
        var game = Game.Init();
        game.ChoosePosition("X", 2);

        //act
        var result = game.ChoosePosition("O", 3);

        //assert
        Assert.True(result);
    }
    
    [Fact]
    public void GameIsOver_When_AllBoxesFilled_Without_MatchingWinningCriteria()
    {
        //arrange
        var game = Game.Init();
        game.ChoosePosition("X", 1);
        game.ChoosePosition("O", 2);
        game.ChoosePosition("X", 3);
        game.ChoosePosition("O", 6);
        game.ChoosePosition("X", 4);
        game.ChoosePosition("O", 7);
        game.ChoosePosition("X", 5);
        game.ChoosePosition("O", 9);
        game.ChoosePosition("X", 8);

        //act
        var result = game.GameStatus();

        //assert
        Assert.Equal("Game Over", result);
    }
    
    [Fact]
    public void GameIsOver_When_Row_IsMatched()
    {
        //arrange
        var game = Game.Init();
        game.ChoosePosition("X", 1);
        game.ChoosePosition("O", 6);
        game.ChoosePosition("X", 2);
        game.ChoosePosition("O", 7);
        game.ChoosePosition("X", 3);

        //act
        var result = game.GameStatus();

        //assert
        Assert.Equal("Winner is X", result);
    }
    
}