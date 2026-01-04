using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // We need a state for the current state
    State currentState;

    // In Update call currentState.Tick();
    private void Update()
    {
        currentState?.Tick();
    }

    private void FixedUpdate()
    {
        currentState?.PhysicsTick();
    }

    // Make a public method that switches states
    public void SwitchState(State newState)
    {
        // Exit the current state -> make the new state the current state -> enter the current state
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}