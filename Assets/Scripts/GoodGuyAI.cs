using Pathfinding;
using UnityEngine;

public class GoodGuyAI : CultistAI
{
    enum Task
    {
        IDLE,
        FOLLOW_COMMAND,
        ATTACK,
        PRAY
    }

    [SerializeField]
    private Task current_task = Task.IDLE;

    [SerializeField]
    private float prayEffectDamageMultiplier = 2.0f;
    private bool prayEffectActive = false;

    void Start()
    {
        this.name = DataSets.RandomNames[Random.Range(0, DataSets.RandomNames.Count - 1)];
        base.SetNametag();
        attackCurrentCooldown = attackCooldown;
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_target == null && current_task == Task.ATTACK)
        {
            current_task = Task.IDLE;
            touchesTarget = false;
        }
        switch (current_task)
        {
            case Task.IDLE:
                Idle();
                break;
            case Task.FOLLOW_COMMAND:
                break;
            case Task.ATTACK:
                Attack();
                break;
            case Task.PRAY:
                break;
        }
        base.UpdateCultistAi();
    }

    public void Command(Vector3 target)
    {
        GetComponent<AIPath>().destination = target;
        current_target = null;
        currentTargetPosition = target;
        current_task = Task.FOLLOW_COMMAND;
    }

    public void StartPray()
    {
        Debug.Log("Good guys StartPray");
        current_task = Task.PRAY;
        // TODO set animation/play sound for praying
    }

    public void EndPray()
    {
        Debug.Log("Good guys EndPray");
        current_task = Task.IDLE;
        current_target = null;
    }

    public void StartPrayEffect()
    {
        Debug.Log("Good guys StartPrayEffect");
        // TODO set animation/play sound for pray effect
        prayEffectActive = true;
    }

    public void EndPrayEffect()
    {
        Debug.Log("Good guys EndPrayEffect");
        // TODO end animation/play sound for pray effect
        prayEffectActive = false;
    }

    protected override void SawSomething(Collider2D collision)
    {
        EnemyAI targetEnemy;
        if ((current_task == Task.IDLE || current_task == Task.FOLLOW_COMMAND) && collision.gameObject.TryGetComponent<EnemyAI>(out targetEnemy))
        {
            current_task = Task.ATTACK;
            current_target = targetEnemy.transform;
            aIDestinationSetter.target = current_target;
        }
        Cage targetCage;
        if ((current_task == Task.IDLE || current_task == Task.FOLLOW_COMMAND) && collision.gameObject.TryGetComponent<Cage>(out targetCage))
        {
            current_task = Task.ATTACK;
            current_target = targetCage.transform;
            aIDestinationSetter.target = current_target;
        }
    }

    protected override void TouchedSomething(Collider2D collision)
    {
        EnemyAI targetEnemy;
        if (collision.gameObject.TryGetComponent<EnemyAI>(out targetEnemy))
        {
            touchesTarget = true;
            aIDestinationSetter.target = null;
        }
        Cage targetCage;
        if (collision.gameObject.TryGetComponent<Cage>(out targetCage))
        {
            touchesTarget = true;
            aIDestinationSetter.target = null;
        }
    }

    protected override float CurrentDamage()
    {
        float curDamage = damage;
        if (prayEffectActive)
        {
            curDamage *= prayEffectDamageMultiplier;
        }

        return curDamage;
    }
}
