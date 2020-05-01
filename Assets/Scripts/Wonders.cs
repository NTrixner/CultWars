using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonders : MonoBehaviour
{
    [SerializeField]
    Cooldown prayCooldown;
    [SerializeField]
    Cooldown prayEffectCooldown;
    private bool isPraying = false;
    private bool isPrayEffectActive = false;


    void Update()
    {
        if (isPraying && !prayCooldown.IsRunning())
        {
            EndPray();
            StartPrayEffect();
        }
        if (isPrayEffectActive && !prayEffectCooldown.IsRunning())
        {
            EndPrayEffect();
        }
    }
    
    public void PrayPressed()
    {
        StartPray();
    }

    void StartPray()
    {
        Debug.Log("Start praying");
        prayCooldown.ResetCooldown();
        isPraying = true;
        // TODO make good guys pray, i.e. stop and do nothing + animation
    }

    void EndPray()
    {
        Debug.Log("End praying");
        isPraying = false;
        // TODO make good guys pray
    }

    void StartPrayEffect()
    {
        Debug.Log("Start pray effect");
        isPrayEffectActive = true;
        prayEffectCooldown.ResetCooldown();
    }

    void EndPrayEffect()
    {
        Debug.Log("End pray effect");
        isPrayEffectActive = false;
    }
}
