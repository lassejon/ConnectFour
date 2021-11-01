namespace App.Controller;
using Xunit;

public class BoardTests
{
    private readonly Board _sut;
    
    public BoardTests()
    {
        _sut = new Board();
    }

    // Main diagonal tests
    [Fact]
    public void FourOnMainDiagonalRedIsWin()
    {
        _sut.SetPiece("X", 5, 0);
        _sut.SetPiece("X", 6, 1);
        _sut.SetPiece("X", 7, 2);
        _sut.SetPiece("X", 8, 3);

        Assert.True(_sut.IsMainDiagonalWin(7, 2));
    }
    
    [Fact]
    public void FourOnMainDiagonalGreenIsWin()
    {
        _sut.SetPiece("X", 3, 3);
        _sut.SetPiece("X", 4, 4);
        _sut.SetPiece("X", 5, 5);
        _sut.SetPiece("X", 6, 6);

        Assert.True(_sut.IsMainDiagonalWin(4, 4));
    }
    
    [Fact]
    public void ThreeOnMainDiagonalRedIsLoss()
    {
        _sut.SetPiece("X", 5, 0);
        _sut.SetPiece("X", 6, 1);
        _sut.SetPiece("X", 7, 2);
        _sut.SetPiece("Y", 8, 3);

        Assert.False(_sut.IsMainDiagonalWin(5, 0));
    }
    
    [Fact]
    public void ThreeOnMainDiagonalGreenIsLoss()
    {
        _sut.SetPiece("X", 3, 3);
        _sut.SetPiece("X", 4, 4);
        _sut.SetPiece("X", 5, 5);
        _sut.SetPiece("Y", 6, 6);

        Assert.False(_sut.IsMainDiagonalWin(5, 5));
    }
    
    [Fact]
    public void NoneOnMainDiagonalGreenIsLoss()
    {
        Assert.False(_sut.IsMainDiagonalWin(8, 1));
    }
    
    [Fact]
    public void NoneOnMainDiagonalRedIsLoss()
    {
        Assert.False(_sut.IsMainDiagonalWin(1, 8));
    }

    // Anti diagonal tests
    [Fact]
    public void FourOnAntiDiagonalRedIsWin()
    {
        _sut.SetPiece("X", 0, 3);
        _sut.SetPiece("X", 1, 2);
        _sut.SetPiece("X", 2, 1);
        _sut.SetPiece("X", 3, 0);

        Assert.True(_sut.IsAntiDiagonalWin(2, 1));
    }
    
    [Fact]
    public void FourOnAntiDiagonalGreenIsWin()
    {
        _sut.SetPiece("X", 5, 8);
        _sut.SetPiece("X", 6, 7);
        _sut.SetPiece("X", 7, 6);
        _sut.SetPiece("X", 8, 5);

        Assert.True(_sut.IsAntiDiagonalWin(6, 7));
    }
    
    [Fact]
    public void ThreeOnAntiDiagonalRedIsWin()
    {
        _sut.SetPiece("X", 0, 3);
        _sut.SetPiece("X", 1, 2);
        _sut.SetPiece("X", 2, 1);
        _sut.SetPiece("Y", 3, 0);

        Assert.False(_sut.IsAntiDiagonalWin(2, 1));
    }
    
    [Fact]
    public void ThreeOnAntiDiagonalGreenIsWin()
    {
        _sut.SetPiece("X", 5, 8);
        _sut.SetPiece("X", 6, 7);
        _sut.SetPiece("X", 7, 6);
        _sut.SetPiece("Y", 8, 5);

        Assert.False(_sut.IsAntiDiagonalWin(6, 7));
    }
    
    [Fact]
    public void NoneOnAntiDiagonalGreenIsLoss()
    {
        Assert.False(_sut.IsAntiDiagonalWin(7, 8));
    }
    
    [Fact]
    public void NoneOnAntiDiagonalRedIsLoss()
    {
        Assert.False(_sut.IsAntiDiagonalWin(0, 1));
    }
    
    // Row tests
    [Fact]
    public void FourOnRowIsWin()
    {
        _sut.SetPiece("X", 0, 3);
        _sut.SetPiece("X", 1, 3);
        _sut.SetPiece("X", 2, 3);
        _sut.SetPiece("X", 3, 3);

        Assert.True(_sut.IsRowWin(1, 3));
    }
    
    [Fact]
    public void ThreeOnRowIsLoss()
    {
        _sut.SetPiece("X", 0, 3);
        _sut.SetPiece("X", 1, 3);
        _sut.SetPiece("X", 2, 3);
        _sut.SetPiece("Y", 3, 3);

        Assert.False(_sut.IsRowWin(2, 3));
    }
    
    // Column tests
    [Fact]
    public void FourOnColumnIsWin()
    {
        _sut.SetPiece("X", 0, 0);
        _sut.SetPiece("X", 0, 1);
        _sut.SetPiece("X", 0, 2);
        _sut.SetPiece("X", 0, 3);

        Assert.True(_sut.IsColumnWin(0, 2));
    }
    
    [Fact]
    public void ThreeOnColumnIsLoss()
    {
        _sut.SetPiece("X", 0, 0);
        _sut.SetPiece("X", 0, 1);
        _sut.SetPiece("X", 0, 2);
        _sut.SetPiece("Y", 0, 3);

        Assert.False(_sut.IsColumnWin(0, 2));
    }
}