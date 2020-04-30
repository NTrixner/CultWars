﻿using UnityEngine;

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
        attackCurrentCooldown = attackCooldown;
    }

    void Update()
    {
        if (current_target == null && current_task == EvilTask.ATTACK)
        {
            current_task = EvilTask.IDLE;
            touchesEnemy = false;
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
    }

    protected override void SawSomething(Collider2D collision)
    {
        GoodGuyAI goodGuyAI;
        if ((current_task == EvilTask.IDLE) && collision.gameObject.TryGetComponent<GoodGuyAI>(out goodGuyAI))
        {
            current_task = EvilTask.ATTACK;
            current_target = goodGuyAI.transform;
        }
    }

    protected override void TouchedSomething(Collider2D collision)
    {
        GoodGuyAI goodGuyAI;
        if (collision.gameObject.TryGetComponent<GoodGuyAI>(out goodGuyAI))
        {
            touchesEnemy = true;
        }
    }
}