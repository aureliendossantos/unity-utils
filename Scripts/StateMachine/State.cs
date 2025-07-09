/// <summary>
/// Base class for state machine states. Inherit from this to create custom states.
/// </summary>
/// <remarks>
/// Initializes a new state with the specified name and state machine.
/// </remarks>
/// <param name="name">The name of the state.</param>
/// <param name="stateMachine">The state machine that owns this state.</param>
public class State(string name, StateMachine stateMachine)
{
    public string name = name;
    protected StateMachine stateMachine = stateMachine;

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
