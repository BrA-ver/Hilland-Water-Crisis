using UnityEngine;
using System.Collections;

public class FlashObj : MonoBehaviour
{
    Material flashMaterial;
    float flashTime;
    Material[] originalMats;
    Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMats = renderer.materials;
    }

    public void Flash(Material flashMaterial, float flashTime)
    {
        this.flashMaterial = flashMaterial;
        this.flashTime = flashTime;
        StartCoroutine(DamgeFlashRoutine());
    }

    public void DoFlash()
    {
        Material[] flashList = new Material[1];
        flashList[0] = flashMaterial;
        renderer.materials = flashList;
        //renderer.materials[0] = flashMaterial;
    }

    public void StopFlash()
    {
        renderer.materials = originalMats;
    }

    IEnumerator DamgeFlashRoutine()
    {
        DoFlash();
        yield return new WaitForSeconds(flashTime);
        StopFlash();
    }
}