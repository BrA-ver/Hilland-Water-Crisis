using UnityEngine;

[RequireComponent(typeof(FollowCamera), typeof(LookAtCamera))]
public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera instance;

    private FollowCamera followCam;
    private LookAtCamera lookCam;

    Player player;

    private void Awake()
    {
        instance = this;
        followCam = GetComponent<FollowCamera>();
        lookCam = GetComponent<LookAtCamera>();
    }

    private void FixedUpdate()
    {
        if (followCam == null || player == null) return;

        followCam.FollowTarget(player.transform.position);
    }

    private void LateUpdate()
    {
        lookCam.HandleRotation();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
