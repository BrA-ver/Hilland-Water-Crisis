using UnityEngine;
using System;

public class AttackHandler : MonoBehaviour
{
    protected CharacterAnimator animator;

    [SerializeField] protected Attack[] attacks;
    protected Attack currentAttack;
    protected int attackInd;

    public event Action onAttackFinish;

    public void SetAnimator(CharacterAnimator animator)
    {
        this.animator = animator;
    }

    public virtual void Attack()
    {
        currentAttack = attacks[attackInd];
        animator.PlayAnim(currentAttack.AnimName, 0.05f);
    }

    public void FinishAttack() // Called By Anim Events at the end of the attack anim
    {
        onAttackFinish?.Invoke();
    }
}

[System.Serializable]
public class Attack
{
    public string AnimName;
}