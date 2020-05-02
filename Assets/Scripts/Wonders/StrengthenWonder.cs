using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthenWonder : AbstractWonder
{
    private bool isPraying = false;
    private bool isPrayEffectActive = false;
    public override void Update()
    {
        base.UpdateWonder();
    }

    protected override void OnStartWonder()
    {
    }

    protected override void OnEndWonder()
    {
    }

    protected override void OnStartWonderEffect()
    {
        Debug.Log("Start strengthen");
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.StartStrengthen();
        }
    }

    protected override void OnEndWonderEffect()
    {
        Debug.Log("End strengthen");
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.EndStrengthen();
        }
    }
}
