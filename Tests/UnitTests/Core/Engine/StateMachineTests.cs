using Darkened.Core.Engine;
using SFML.Graphics;
using Moq;
namespace UnitTests.Core.Engine;

public class StateMachineTests
{
    [Test]
    public void NewStateGotPushed()
    {
        // Arrange 
        var mockState = new Mock<IState>();
        var stateMachine = new StateMachine(mockState.Object);
        // mockState.Setup(state => Console.WriteLine("Exited State"));
        // var newMockState = new Mock<IState>();
        // newMockState.Setup(state => Console.WriteLine("Exited State"));
        // Act
        // stateMachine.PushState(newMockState.Object);
        // Assert
        // Assert.That(stateMachine.CurrentState(), Is.SameAs(newMockState.Object));
    }

    [Test]
    public void NewStateWasPoppedOff()
    {
        
    }

    [Test]
    public void StoppedRunningAfterPoppingLastState()
    {
        
    }

    [Test]
    public void ReturnedCorrectState()
    {
        
    }

    [Test]
    public void ReturnedPreviousStateAfterPoppingLastState()
    {
        
    }

    [Test]
    public void ReturnedNullIfNotRunning()
    {
        
    }
}