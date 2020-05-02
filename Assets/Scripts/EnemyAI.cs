using UnityEngine;
using Pathfinding;

public class EnemyAI : CultistAI
{
    enum EvilTask
    {
        ATTACK,
        IDLE
    }

    [SerializeField]
    private EvilTask current_task = EvilTask.IDLE;

    void Start()
    {
        this.name = "Evil " + DataSets.RandomNames[Random.Range(0, DataSets.RandomNames.Count - 1)];
        base.SetNametag();
        attackCurrentCooldown = attackCooldown;
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    void Update()
    {
        if (current_target == null && current_task == EvilTask.ATTACK)
        {
            current_task = EvilTask.IDLE;
        }
        switch (current_task)
        {
            case EvilTask.IDLE:
                Idle();
                break;
            case EvilTask.ATTACK:
                Attack();
                break;
        }
        base.UpdateCultistAi();
        touchesTarget = false;
    }

    protected override void SawSomething(Collider2D collision)
    {
        PlayerController player;
        if ((current_task == EvilTask.IDLE || (!touchesTarget && current_task == EvilTask.ATTACK && IsNearer(collision))) && collision.gameObject.TryGetComponent<PlayerController>(out player))
        {
            current_task = EvilTask.ATTACK;
            current_target = player.transform;
            aIDestinationSetter.target = current_target;
        }
        GoodGuyAI goodGuyAI;
        if ((current_task == EvilTask.IDLE || (!touchesTarget && current_task == EvilTask.ATTACK && IsNearer(collision))) && collision.gameObject.TryGetComponent<GoodGuyAI>(out goodGuyAI))
        {
            current_task = EvilTask.ATTACK;
            current_target = goodGuyAI.transform;
            aIDestinationSetter.target = current_target;
        }
    }

    protected override void TouchedSomething(Collider2D collision)
    {
        PlayerController player;
        if (collision.gameObject.TryGetComponent<PlayerController>(out player))
        {
            if(collision.transform == current_target)
            {
                touchesTarget = true;
                aIDestinationSetter.target = null;
            }
            else
            {
                current_target = collision.transform;
                aIDestinationSetter.target = null;
            }
        }
        GoodGuyAI goodGuyAI;
        if (collision.gameObject.TryGetComponent<GoodGuyAI>(out goodGuyAI))
        {
            if(collision.transform == current_target)
            {
                touchesTarget = true;
                aIDestinationSetter.target = null;
            }
            else
            {
                current_target = collision.transform;
                aIDestinationSetter.target = null;
            }
        }
    }

    protected override float CurrentDamage()
    {
        float cur_damage = damage;
        // No multipliers for now
        return cur_damage;
    }
}
