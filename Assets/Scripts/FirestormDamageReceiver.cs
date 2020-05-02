using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirestormDamageReceiver : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    [SerializeField]
    private GameObject fireEffect;
    
    [SerializeField]
    private HealthEntity healthEntity;

    private bool isInflictingDamage;

    void Update()
    {
        if (isInflictingDamage) {
            float amount = damageAmount * Time.deltaTime;
            healthEntity.ReduceHealth(amount);
        }
    }

    public void StartDamage() {
        Debug.Log("damaging starts");
        isInflictingDamage = true;
        fireEffect.SetActive(true);
        // healingEffect.gameObject.SetActive(true);
        // healingEffect.Clear();
        // healingEffect.Play();
    }

    public void EndDamage() {
        Debug.Log("damaging ends");
        isInflictingDamage = false;
        fireEffect.SetActive(false);
    }
}
