public class PlayerState : CharacterState
{
    protected Player player;
    public PlayerState(Character character) : base(character) {}

    public override void Enter()
    {
        player = (Player)character;
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void PhysicsTick()
    {
        
    }
}
