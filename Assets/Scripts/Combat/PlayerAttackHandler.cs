using UnityEngine;

public class PlayerAttackHandler : AttackHandler
{
    [SerializeField] Attack spinAttack;

    public override void Attack()
    {
        base.Attack();

        attackInd++;
        if (attackInd >= attacks.Length)
            attackInd = 0;
    }

    public void SpinAttack()
    {
        animator.PlayAnim(spinAttack.AnimName, 0.05f);
    }
}
