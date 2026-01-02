using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public void FollowTarget(Vector3 targetPos)
    {
        transform.position = targetPos;
    }
}
