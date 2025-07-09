/// <summary>
/// Base class for state machine states. Inherit from this to create custom states.
/// </summary>
public class State
{
    public string name;
    protected StateMachine stateMachine;

    /// <summary>
    /// Initializes a new state with the specified name and state machine.
    /// </summary>
    /// <param name="name">The name of the state.</param>
    /// <param name="stateMachine">The state machine that owns this state.</param>
    public State(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// Runs when the state is entered.
    /// </summary>
    public virtual void Enter() { }

    /// <summary>
    /// Runs during Update().
    /// </summary>
    public virtual void UpdateLogic() { }

    /// <summary>
    /// Runs during LateUpdate().
    /// </summary>
    public virtual void UpdatePhysics() { }

    /// <summary>
    /// Runs when the state is exited.
    /// </summary>
    public virtual void Exit() { }
}
