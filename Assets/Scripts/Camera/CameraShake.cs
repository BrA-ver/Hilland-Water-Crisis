using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeTime = .5f;
    [SerializeField] float intensity = 10f;
    float shakeCounter = 0f;
    bool shake = false;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        if (shake)
            HandleShake();
    }

    private void HandleShake()
    {
        shakeCounter += Time.deltaTime;
        if (shakeCounter >= shakeTime)
        {
            shake = false;
            transform.localPosition = startPos;
            shakeCounter = 0f;
            return;
        }

        Vector2 random = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * intensity;
        transform.localPosition = startPos + new Vector3(random.x, random.y, 0f);
    }

    public void Shake()
    {
        shake = true;
    }
}
