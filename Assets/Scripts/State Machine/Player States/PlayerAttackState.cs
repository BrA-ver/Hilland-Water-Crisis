using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Character character) : base(character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (player.OnGround)
            player.AttackHandler.Attack();
        else
        {
            player.AttackHandler.SpinAttack();
            player.Movement.Dive();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();
        player.Movement.HandleMovement();
    }

    public override void Tick()
    {
        base.Tick();
        player.GroundCheck();
        player.Movement.IsGrounded(player.OnGround);

        player.Movement.Move(Vector3.zero);
    }
}
