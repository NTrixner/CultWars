using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthEntity : MonoBehaviour
{
    [SerializeField]
    private float Health = 100f;

    [SerializeField]
    private float MaxHealth = 100f;

    [SerializeField]
    protected Collider2D bodyCollider;

    public void ReduceHealth(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Die();
        }
    }

    public void Heal(float regain)
    {
        Health += regain;
        if(Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public abstract void Die();
}
