/// <summary>
/// <see cref="StateMachine"/>
/// </summary>
public class State
{
    public string name;
    protected StateMachine stateMachine;

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
