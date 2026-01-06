using UnityEngine;

[RequireComponent(typeof(Movement), typeof(CharacterAnimator), typeof(Health))]
public class Character : MonoBehaviour
{
    protected Movement movement;
    protected CharacterAnimator animator;
    protected GroundCheck ground;
    protected Health health;
    protected bool onGround;


    public Movement Movement => movement;
    public CharacterAnimator Animator => animator;
    public Health Health => health;
    public bool OnGround => onGround;

    protected virtual void Awake()
    {
        movement = GetComponent<Movement>();
        ground = GetComponent<GroundCheck>();
        animator = GetComponent<CharacterAnimator>();
        health = GetComponent<Health>();
    }

    protected virtual void Start()
    {
        
    }

    public virtual void HandleAnimation()
    {
        Vector3 hVelocity = movement.Controller.velocity;
        hVelocity.y = 0f;
        bool moving = hVelocity.magnitude > 0.1f;

        animator.AnimateMovement(moving);

        animator.AnimateAirState(onGround);
    }

    public void GroundCheck()
    {
        onGround = ground.OnGround;
    }
}
