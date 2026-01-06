using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 10;
    [SerializeField] protected int currentHealth;

    [SerializeField] public HealthEvents Events;

    public float HealthRatio { get { return (float)currentHealth / (float)maxHealth; } }

    protected void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Events.InvokeTookDamage();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Events.InvokeDied();
        }

        Events.InvokeHealthChanged();
    }
}

[System.Serializable]
public class HealthEvents
{
    public UnityEvent OnTookDamage;
    public UnityEvent OnDied;
    public UnityEvent OnHealthChanged;

    public void InvokeTookDamage() { OnTookDamage?.Invoke(); }
    public void InvokeDied() { OnDied?.Invoke(); }
    public void InvokeHealthChanged() { OnHealthChanged?.Invoke(); }
}
