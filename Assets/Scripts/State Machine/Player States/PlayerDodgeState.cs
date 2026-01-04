using UnityEngine;

public class PlayerDodgeState : PlayerState
{
    public PlayerDodgeState(Character character) : base(character)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Vector3 dashDir = player.MoveDir;
        if (Mathf.Abs(player.MoveDir.magnitude) < 0.1f)
            dashDir = player.transform.forward;

        player.Movement.Dash(dashDir);

        player.Animator.PlayAnim("Dodge");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();

        if (player.Movement.Dashing)
        {
            player.Movement.HandleDash();
        }
        else
        {
            player.Movement.HandleMovement();
        }
    }

    public override void Tick()
    {
        base.Tick();
        player.GroundCheck();
        player.Movement.IsGrounded(player.OnGround);
    }
}
