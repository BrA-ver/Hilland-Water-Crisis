using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] float flashTime = 0.25f;
    [SerializeField] Material flashMaterial;

    [SerializeField] FlashObj[] flashObjs;

    public void Flash()
    {
        foreach (FlashObj flashObj in flashObjs)
        {
            flashObj.Flash(flashMaterial, flashTime);
        }
    }
}