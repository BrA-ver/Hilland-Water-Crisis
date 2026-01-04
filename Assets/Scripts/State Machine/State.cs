// Make the class abstract so it can only be inherited from
public abstract class State
{
	// Make the public methods Enter, Tick and Exit and make them abstract as well
	public abstract void Enter();
	public abstract void Tick(); // no need for delta time since the states can access it themselves
	public abstract void PhysicsTick(); // no need for delta time since the states can access it themselves

	public abstract void Exit();

	// Enter is called when you enter a state, tick is called every frame and exit when you exit a state
}