using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealWonder : AbstractWonder
{

    [SerializeField]
    private float healingDistance;

    private List<Healable> healedEntities;
    protected override void OnStartWonder()
    {

    }

    protected override void OnEndWonder()
    {

    }

    protected override void OnStartWonderEffect()
    {
        healedEntities = new List<Healable>();
        foreach (Healable healable in FindObjectsOfType<Healable>())
        {
            float dist = Vector2.Distance(transform.position, healable.transform.position);
            Debug.Log($"distance: {dist}");
            if (dist <= healingDistance)
            {
                healable.StartHealing();
                healedEntities.Add(healable);
            }
        }
    }

    protected override void OnEndWonderEffect()
    {
        Debug.Log("end heal wonder effect");
        foreach (Healable healable in healedEntities)
        {
            healable.EndHealing();
        }
    }
}
