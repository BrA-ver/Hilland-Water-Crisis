using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Movement))]
public class Character : MonoBehaviour
{
    protected Movement movement;
    protected GroundCheck ground;
    protected bool onGround;


    public Movement Movement => movement;

    protected virtual void Awake()
    {
        movement = GetComponent<Movement>();
        ground = GetComponent<GroundCheck>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        onGround = ground.OnGround;
    }

    protected virtual void FixedUpdate()
    {
        movement.HandleMovement();
    }
}
