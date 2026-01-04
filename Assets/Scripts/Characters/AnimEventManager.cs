using UnityEngine;

public class AnimEventManager : MonoBehaviour
{
    [SerializeField] Player player;

    public void FinishDodge()// Called by animation event at the end of the dodge animation
    {
        player.FinishDodge();
    }
}
