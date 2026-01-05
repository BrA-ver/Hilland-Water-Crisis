using System;
using UnityEngine;

public class Player : Character
{
    Vector2 moveInput;
    Vector3 moveDir;
    PlayerCamera cam;

    private StateMachine stateMachine;

    PlayerAttackHandler attackHandler;

    public PlayerAttackHandler AttackHandler => attackHandler;

    public Vector3 MoveDir => moveDir;
    public bool isDodging;
    public bool isAttacking;

    protected override void Awake()
    {
        base.Awake();
        attackHandler = GetComponent<PlayerAttackHandler>();
        attackHandler.SetAnimator(animator);
        stateMachine = GetComponent<StateMachine>();
    }


    protected override void Start()
    {
        base.Start();
        cam = PlayerCamera.instance;
        cam.SetPlayer(this);

        
        InputHandler.Instance.onDodgePressed += OnDodge;
        InputHandler.Instance.onAttackPressed += OnAttack;

        stateMachine.SwitchState(new PlayerFreeState(this));
    }

    private void OnDisable()
    {
        
        InputHandler.Instance.onDodgePressed -= OnDodge;
        InputHandler.Instance.onAttackPressed -= OnAttack;
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

    private void OnAttack()
    {
        if (isAttacking) return;

        isAttacking = true;
        stateMachine.SwitchState(new PlayerAttackState(this));
    }

    public void FinishAttack()
    {
        isAttacking = false;
        stateMachine.SwitchState(new PlayerFreeState(this));
    }

    public void FinishDodge()
    {
        isDodging = false;
        stateMachine.SwitchState(new PlayerFreeState(this));
    }


}
