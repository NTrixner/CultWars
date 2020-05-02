using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healable : MonoBehaviour
{
    [SerializeField]
    private float healingAmount;

    [SerializeField]
    private ParticleSystem healingEffect;

    [SerializeField]
    private HealthEntity healthEntity;

    private bool isHealing;

    void Update()
    {
        if (isHealing) {
            float amount = healingAmount * Time.deltaTime;
            healthEntity.Heal(amount);
        }
    }

    public void StartHealing() {
        Debug.Log("healing starts");
        isHealing = true;
        healingEffect.gameObject.SetActive(true);
        healingEffect.Clear();
        healingEffect.Play();
    }

    public void EndHealing() {
        Debug.Log("healing ends");
        isHealing = false;
    }
}
