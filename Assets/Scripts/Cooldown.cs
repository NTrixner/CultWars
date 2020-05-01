using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField]
    float seconds = 5.0f;
    
    private bool isRunning = false;
    private float currentSeconds = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (currentSeconds > 0.0f)
        {
            currentSeconds -= Time.deltaTime;
        }
        else if (isRunning)
        {
            isRunning = false;
        }
    }

    public void ResetCooldown()
    {
        isRunning = true;
        currentSeconds = seconds;
    }

    public bool IsRunning()
    {
        return isRunning;
    }
}
