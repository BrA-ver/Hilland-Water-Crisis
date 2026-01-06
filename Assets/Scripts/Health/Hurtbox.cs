using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hurtbox : MonoBehaviour
{
    [SerializeField] int damage = 2;
    [field: SerializeField] public HitboxType TargetType { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Hitbox hitbox))
        {
            if (hitbox.Type == TargetType)
            {
                hitbox.TakeDamage(damage);
            }
        }
    }
}
