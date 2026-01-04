using System;
using UnityEngine;

public class Player : Character
{
    Vector2 moveInput;
    Vector3 moveDir;
    PlayerCamera cam;

    private StateMachine stateMachine;

    public Vector3 MoveDir => moveDir;
    public bool isDodging;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = GetComponent<StateMachine>();
        
    }


    protected override void Start()
    {
        base.Start();
        cam = PlayerCamera.instance;
        cam.SetPlayer(this);

        
        InputHandler.Instance.onDodgePressed += OnDodge;

        stateMachine.SwitchState(new PlayerFreeState(this));
    }

    private void OnDisable()
    {
        
        InputHandler.Instance.onDodgePressed -= OnDodge;
    }

    

    public void HandleMoveInput()
    {
        moveInput = InputHandler.Instance.MoveInput;
        moveDir = cam.transform.forward * moveInput.y;
        moveDir += cam.transform.right * moveInput.x;
        moveDir.y = 0f;
        moveDir.Normalize();
    }

    public void Jump()
    {
        if (onGround)
        {
            movement.Jump();
        }
    }

    private void OnDodge()
    {
        
        Debug.Log("Dash Called");
        if (!onGround || isDodging) return;
        if (movement.Dashing) return;

        isDodging = true;
        stateMachine.SwitchState(new PlayerDodgeState(this));
    }

    public void FinishDodge()
    {
        isDodging = false;
        stateMachine.SwitchState(new PlayerFreeState(this));
    }
}
