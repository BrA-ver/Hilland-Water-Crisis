using System;
using UnityEngine;

public class Player : Character
{
    Vector2 moveInput;
    Vector3 moveDir;
    PlayerCamera cam;
    

    protected override void Start()
    {
        base.Start();
        cam = PlayerCamera.instance;
        cam.SetPlayer(this);

        InputHandler.Instance.onJumpPressed += OnJump;
        InputHandler.Instance.onDodgePressed += OnDodge;
        
    }

    private void OnDisable()
    {
        InputHandler.Instance.onJumpPressed -= OnJump;
        InputHandler.Instance.onDodgePressed -= OnDodge;
    }

    

    protected override void Update()
    {
        base.Update();
        movement.IsGrounded(onGround);

        HandleMoveInput();
        movement.Move(moveDir);

        
        
    }

    protected override void FixedUpdate()
    {
        if (!movement.Dashing)
        {
            base.FixedUpdate();
        }
        else
        {
            movement.HandleDash();
        }
    }

    void HandleMoveInput()
    {
        moveInput = InputHandler.Instance.MoveInput;
        moveDir = cam.transform.forward * moveInput.y;
        moveDir += cam.transform.right * moveInput.x;
        moveDir.y = 0f;
        moveDir.Normalize();
    }

    private void OnJump()
    {
        if (onGround)
        {
            movement.Jump();
        }
    }

    private void OnDodge()
    {
        if (!onGround) return;
        if (movement.Dashing) return;

        Vector3 dashDir = moveDir;
        if (moveDir.magnitude < 0.1f)
            dashDir = transform.forward;

        movement.Dash(dashDir);
    }
}
