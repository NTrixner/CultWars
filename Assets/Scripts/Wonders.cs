using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wonders : MonoBehaviour
{
    [SerializeField]
    Button prayButton; 
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
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.StartPray();
        }
        prayButton.interactable = false;
    }

    void EndPray()
    {
        Debug.Log("End praying");
        isPraying = false;
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.EndPray();
        }
    }

    void StartPrayEffect()
    {
        Debug.Log("Start pray effect");
        isPrayEffectActive = true;
        prayEffectCooldown.ResetCooldown();
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.StartPrayEffect();
        }
    }

    void EndPrayEffect()
    {
        Debug.Log("End pray effect");
        isPrayEffectActive = false;
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.EndPrayEffect();
        prayButton.interactable = true;
        }
    }
}
