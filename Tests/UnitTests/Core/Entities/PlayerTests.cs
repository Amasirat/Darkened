using Darkened.Core.Entities;

namespace UnitTests.Core.Entities;

public class PlayerTests
{
    // [SetUp]
    // public void Setup()
    // {
    // }

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

    [Test]
    public void OnDeathIsCalled()
    {
        // Setup
        Player player = new Player();
        int damage = 100;
        player.Death += (o) => Console.WriteLine(player.Health);
        // Do
        player.TakeDamage(damage);
        
        Assert.True(player.Health == 0);
    }
}