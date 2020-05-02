using UnityEngine;

public class PrayWonder : AbstractWonder
{

    private bool isPraying = false;
    private bool isPrayEffectActive = false;
    void Update()
    {
        base.UpdateWonder();
    }

    protected override void OnStartWonder()
    {
        Debug.Log("Start praying");
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.StartPray();
        }
    }

    protected override void OnEndWonder()
    {
        Debug.Log("End praying");
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.EndPray();
        }
    }

    protected override void OnStartWonderEffect()
    {
        Debug.Log("Start pray effect");
        
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.StartPrayEffect();
        }
    }

    protected override void OnEndWonderEffect()
    {
        Debug.Log("End pray effect");
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.EndPrayEffect();
        }
    }
}