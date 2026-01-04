using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    protected CharacterController controller;

    Vector3 moveDirection;
    Vector3 velocity;
    Vector3 hVelocity;
    Vector3 yVelocity;

    [SerializeField] float speed = 7f;
    [SerializeField] float acceleration = 25f;

    [SerializeField] float rotationSpeed = 15f;

    bool isGrounded;
    [SerializeField] float gravityScale = 1f;
    [SerializeField] float jumpHeight = 1f;
    bool jumping;

    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashTime = 0.1f;
    float dashCounter;
    bool dashing = false;
    Vector3 dashDir; 

    [SerializeField] bool debug;
    [SerializeField] float activeSpeed;
    [SerializeField] Vector3 activeVel;

    #region Properties
    public CharacterController Controller => controller;
    public bool Dashing => dashing;
    #endregion

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public virtual void HandleMovement()
    {
        GroundMovement();
        AirMovement();
        Rotation();

        velocity = hVelocity + yVelocity;
        controller.Move(velocity * Time.deltaTime);

        if (debug)
        {
            activeSpeed = controller.velocity.magnitude;
            activeVel = controller.velocity;
        }
    }

    private void GroundMovement()
    {
        Vector3 targetVelocity = moveDirection * speed;
        Vector3 appliedVelocity = Vector3.MoveTowards(hVelocity, targetVelocity, acceleration * Time.deltaTime);
        hVelocity = appliedVelocity;
    }

    private void AirMovement()
    {
        if (!isGrounded)
        {
            yVelocity.y += Physics.gravity.y * gravityScale * Time.deltaTime;
            jumping = false;
        }
        else if (!jumping)
        {
            yVelocity.y = -0.5f;
        }
    }

    void Rotation() // Rotates the body in the direction of movement
    {
        if (moveDirection.magnitude < 0.1f) return;

        Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
        Quaternion change = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = change;
    }

    public void HandleDash()
    {
        if (!dashing)
            return;

        hVelocity = dashDir * dashSpeed;
        controller.Move(hVelocity * Time.deltaTime);


        dashCounter += Time.deltaTime;
        if (dashCounter >= dashTime)
        {
            dashCounter = 0f;
            dashing = false;
            return;
        }
    }

    // Sets the move direction of the class
    public void Move(Vector3 direction)
    {
        moveDirection = direction;
    }

    public void IsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

    public void Jump()
    {
        jumping = true;
        yVelocity.y = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight * gravityScale);
    }

    public void Dash(Vector3 dashDir)
    {
        Debug.Log(dashDir);
        dashing = true;
        this.dashDir = dashDir;
    }
}
