using System;
using UnityEngine;

public class Enemy : Character
{
    protected Player target;
    [SerializeField] float stopDistance = 1f;

    [Header("Boids")]
    [SerializeField] float detectionDistance = 1f;

    protected override void Start()
    {
        base.Start();
        target = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        GroundCheck();
        movement.IsGrounded(onGround);

        if (Vector3.Distance(transform.position, target.transform.position) > stopDistance)
            MoveToTarget();
        else
            movement.Move(Vector3.zero);
    }

    private void FixedUpdate()
    {
        movement.HandleMovement();
    }

    private void MoveToTarget()
    {
        var neighbors = GetNeighbors();
        Vector3 moveDir = target.transform.position - transform.position;
        moveDir.y = 0f;
        moveDir.Normalize();

        movement.Move(moveDir);
    }

    private Collider[] GetNeighbors()
    {
        var enemyMask = LayerMask.GetMask("Enemy");
        return Physics.OverlapSphere(transform.position, detectionDistance, enemyMask);
    }
}
