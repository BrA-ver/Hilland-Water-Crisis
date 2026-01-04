using UnityEngine;
public class PlayerFreeState : PlayerState
{
    bool onGround;
    public PlayerFreeState(Character character) : base(character)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter Player Free State");

        InputHandler.Instance.onJumpPressed += OnJump;
    }

    public override void Exit()
    {
        base.Exit();
        InputHandler.Instance.onJumpPressed -= OnJump;
    }

    public override void PhysicsTick()
    {
        base.PhysicsTick();
        player.Movement.HandleMovement();
    }

    public override void Tick()
    {
        base.Tick();
        Debug.Log("Player null " + player==null);
        player.GroundCheck();
        player.Movement.IsGrounded(player.OnGround);

        player.HandleMoveInput();
        player.Movement.Move(player.MoveDir);

        player.HandleAnimation();
    }

    private void OnJump()
    {
        player.Jump();
    }
}
