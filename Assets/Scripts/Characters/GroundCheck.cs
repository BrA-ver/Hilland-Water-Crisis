using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float radius = .2f;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] Vector3 groundCheckOffset;

    public bool showGizmos;
    [SerializeField] Color groundedColor, airborneColor;

    public bool OnGround => Physics.CheckSphere(transform.position + groundCheckOffset, radius, groundLayers);

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        if (OnGround)
            Gizmos.color = groundedColor;
        else
            Gizmos.color = airborneColor;

        Gizmos.DrawWireSphere(transform.position + groundCheckOffset, radius);
    }
}