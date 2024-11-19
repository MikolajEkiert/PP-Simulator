using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;
public class PointTests
{
    [Fact]
    public void Constructor_SetsCoordinatesCorrectly()
    {
        int x = 5, y = 10;
        var point = new Point(x, y);
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(Direction.Left, -1, 0)]
    [InlineData(Direction.Right, 1, 0)]
    [InlineData(Direction.Up, 0, 1)]
    [InlineData(Direction.Down, 0, -1)]
    [InlineData(Direction.Left, -1, 0)]
    [InlineData(Direction.Right, 1, 0)]
    public void MovePoint_MovesCorrectly(Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(0, 0);
        var result = point.Next(direction);
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(Direction.Left, -1, 1)]
    [InlineData(Direction.Right, 1, -1)]
    [InlineData(Direction.Up, 1, 1)]
    [InlineData(Direction.Down, -1, -1)]
    [InlineData(Direction.Left, -1, 1)]
    [InlineData(Direction.Right, 1, -1)]
    public void MovePointDiagonally_MovesCorrectly(Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(0, 0);
        var result = point.NextDiagonal(direction);
        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Fact]
    public void ToString_ReturnsCorrectFormat()
    {
        var point = new Point(5, 6);
        var result = point.ToString();
        Assert.Equal("(5, 6)", result);
    }
}