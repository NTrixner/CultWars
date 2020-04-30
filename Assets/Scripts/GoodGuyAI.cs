using UnityEngine;

public class GoodGuyAI : CultistAI
{
    enum Task
    {
        IDLE,
        FOLLOW_COMMAND,
        ATTACK
    }

    [SerializeField]
    private Task current_task = Task.IDLE;


    void Start()
    {
        this.name = DataSets.RandomNames[Random.Range(0, DataSets.RandomNames.Count - 1)];
        attackCurrentCooldown = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_target == null && current_task == Task.ATTACK)
        {
            current_task = Task.IDLE;
            touchesEnemy = false;
        }
        switch (current_task)
        {
            case Task.IDLE:
                Idle();
                break;
            case Task.FOLLOW_COMMAND:
                GoToDestination();
                break;
            case Task.ATTACK:
                Attack();
                break;

        }
    }

    public void Command(Vector3 target)
    {
        current_target = null;
        currentTargetPosition = target;
        current_task = Task.FOLLOW_COMMAND;
    }

    protected override void SawSomething(Collider2D collision)
    {
        EnemyAI enemyAI;
        if ((current_task == Task.IDLE || current_task == Task.FOLLOW_COMMAND) && collision.gameObject.TryGetComponent<EnemyAI>(out enemyAI))
        {
            current_task = Task.ATTACK;
            current_target = enemyAI.transform;
        }
    }

    protected override void TouchedSomething(Collider2D collision)
    {
        EnemyAI enemyAI;
        if (collision.gameObject.TryGetComponent<EnemyAI>(out enemyAI))
        {
            touchesEnemy = true;
        }
    }
}
