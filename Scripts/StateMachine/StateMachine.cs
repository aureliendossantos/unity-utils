using UnityEngine;

/// <summary>
/// Finite State Machine base class.
/// <see href="https://github.com/MinaPecheux/UnityTutorials-FiniteStateMachines"/>
/// <seealso cref="State"/>
/// </summary>
public class StateMachine : MonoBehaviour
{
    /// <summary>
    /// The current state of the State Machine.
    /// </summary>
    public State state;

    /// <summary>
    /// Defines the initial state of the State Machine.
    /// </summary>
    protected virtual State InitialState => null;

    protected virtual void Start()
    {
        state = InitialState;
        state?.Enter();
    }

    protected virtual void Update()
    {
        state?.UpdateLogic();
    }

    protected virtual void LateUpdate()
    {
        state?.UpdatePhysics();
    }

    /// <summary>
    /// Exits the current state and enters a new state, applying eventual transitions.
    /// </summary>
    public void ChangeState(State newState)
    {
        state.Exit();
        state = newState;
        state.Enter();
    }
}
