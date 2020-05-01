using UnityEngine;
using Pathfinding;

public abstract class CultistAI : HealthEntity
{

    [SerializeField]
    protected Collider2D rangeCollider;

    [SerializeField]
    protected Transform current_target;

    [SerializeField]
    protected Vector2 currentTargetPosition;
        
    [SerializeField]
    protected float attackCooldown = 1f;

    [SerializeField]
    protected float damage = 20f;

    [SerializeField]
    protected float distanceThreshold = 1f;

    [SerializeField]
    protected float movementSpeed = 1f;

    [SerializeField]
    protected float attackCurrentCooldown;

    [SerializeField]
    protected bool touchesTarget;

    [SerializeField]
    protected AIDestinationSetter aIDestinationSetter;

    protected void UpdateCultistAi() {
        base.UpdateHealthEntity();
    }

    protected void Attack()
    {
        HealthEntity enemy = current_target.gameObject.GetComponent<HealthEntity>();
        if (enemy != null && touchesTarget)
        {
            attackCurrentCooldown -= Time.deltaTime;
            Debug.Log("Cooldown is " + attackCurrentCooldown);
            Debug.Log("Time was " + Time.deltaTime);
            if (attackCurrentCooldown <= 0)
            {
                enemy.ReduceHealth(damage);
                attackCurrentCooldown = attackCooldown;
            }
        }
        else
        {
            GoToAttackTarget();
        }
    }



    public override void Die()
    {
        Debug.Log(name + " has died.");
        Destroy(gameObject);
    }


    protected void Idle()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        HealthEntity otherEntity;
        bool isHealthEntity = collision.gameObject.TryGetComponent<HealthEntity>(out otherEntity);
        if (isHealthEntity)
        {
            if (collision.IsTouching(rangeCollider) && !collision.IsTouching(bodyCollider) && otherEntity.HasCollision(collision))
            {
                SawSomething(collision);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        HealthEntity otherEntity;
        bool isHealthEntity = collision.gameObject.TryGetComponent<HealthEntity>(out otherEntity);
        if (collision.otherCollider == bodyCollider && isHealthEntity && otherEntity.bodyCollider == collision.collider)
        {
            TouchedSomething(collision.collider);
        }
    }


    protected void GoToAttackTarget()
    {
        if (!touchesTarget)
        {
            Vector2 direction = (current_target.position - transform.position).normalized;
            transform.position += (Vector3)(direction * movementSpeed * Time.deltaTime);
        }
    }

    protected abstract void SawSomething(Collider2D collision);

    protected abstract void TouchedSomething(Collider2D collision);
}