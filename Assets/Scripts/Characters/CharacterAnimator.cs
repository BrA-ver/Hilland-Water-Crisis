using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void AnimateMovement(bool ismoving)
    {
        animator.SetBool("moving", ismoving);
    }

    public void AnimateAirState(bool onGround)
    {
        animator.SetBool("onGround", onGround);
    }

    public void PlayAnim(string animName, float transitionTime = 0.1f)
    {
        animator.CrossFade(animName, transitionTime);
    }
}
