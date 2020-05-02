using UnityEngine;
using Pathfinding;
using TMPro;
using System.Collections.Generic;

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

    [SerializeField]
    protected TextMeshProUGUI nametag;

    [SerializeField]
    protected List<AudioClip> deathClips;

    [SerializeField]
    protected List<AudioClip> punchClips;

    [SerializeField]
    protected AudioSource audioSource;

    [SerializeField]
    protected List<GameObject> bloodStains;

    protected void SetNametag()
    {
        if (nametag != null)
        {
            nametag.text = gameObject.name;
        }
    }

    protected void UpdateCultistAi()
    {
        base.UpdateHealthEntity();
    }
    protected abstract float CurrentDamage();

    protected void Attack()
    {
        Debug.Log("Attacking");
        HealthEntity enemy = current_target.gameObject.GetComponent<HealthEntity>();
        if(attackCurrentCooldown < attackCooldown)
        {
            attackCurrentCooldown += Time.deltaTime;
        }
        if (enemy != null && touchesTarget)
        {
            Debug.Log("Cooldown is " + attackCurrentCooldown);
            Debug.Log("Time was " + Time.deltaTime);
            if (attackCurrentCooldown >= attackCooldown)
            {
                enemy.ReduceHealth(CurrentDamage());
                attackCurrentCooldown = 0f;
                AudioClip clip = punchClips[Random.Range(0, punchClips.Count - 1)];
                audioSource.PlayOneShot(clip);
            }
        }
        else
        {
            GoToAttackTarget();
        }
    }

    protected bool IsNearer(Collider2D collision)
    {
        return Vector2.Distance(current_target.position, transform.position) < Vector2.Distance(collision.transform.position, transform.position);
    }

    public override void Die()
    {
        AudioClip clip = deathClips[Random.Range(0, deathClips.Count - 1)];
        audioSource.PlayOneShot(clip);
        Invoke("Death", clip.length * 0.8f);
    }

    void Death()
    {
        GameObject randomBloodStain = bloodStains[Random.Range(0, bloodStains.Count - 1)];
        Instantiate(randomBloodStain, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
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
            if (collision.IsTouching(rangeCollider) && otherEntity.HasCollision(collision))
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