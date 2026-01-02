using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputHandler : Singleton<InputHandler>, PlayerControls.IPlayerActions
{
    PlayerControls controls;

    public Vector2 MoveInput;

    public event Action onJumpPressed;
    public event Action onDodgePressed;

    protected override void Awake()
    {
        base.Awake();
        controls = new PlayerControls();
        controls.Player.SetCallbacks(this);
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed)
            onDodgePressed?.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            onJumpPressed?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}
