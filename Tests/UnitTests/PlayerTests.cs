using Darkened.Core.Entities;

namespace UnitTests;

public class PlayerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IsGuardedTurnedToTrue()
    {
        // Setup
        Player player = new Player();
        
        // Do
        player.FlipGuarded();
        // Assert
        Assert.True(player.IsGuarded);
    }

    [Test]
    public void IsGuardedTurnedToFalse()
    {
        // Setup
        Player player = new Player();
        player.FlipGuarded();
        
        // Do
        player.FlipGuarded();
        
        // Assert
        Assert.False(player.IsGuarded);
    }
}