using UnityEngine;

/// <summary>
/// Finite State Machine base class.
/// <see href="https://github.com/MinaPecheux/UnityTutorials-FiniteStateMachines"/>
/// <seealso cref="BaseState"/>
/// </summary>
public class StateMachine : MonoBehaviour
{
    public State currentState;

    /// <summary>
    /// Defines the initial state of the State Machine.
    /// </summary>
    protected virtual State InitialState => null;

    protected void Start()
    {
        currentState = InitialState;
        currentState?.Enter();
    }

    protected virtual void Update()
    {
        currentState?.UpdateLogic();
    }

    void LateUpdate()
    {
        currentState?.UpdatePhysics();
    }

    /// <summary>
    /// Exits the current state and enters a new state, applying eventual transitions.
    /// </summary>
    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
