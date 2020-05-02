using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class FirestormWonder : AbstractWonder
{


    [SerializeField] private float damageRadius;
    [SerializeField] private float damage;

    [SerializeField] private ParticleSystem visualEffect;

    private bool isSelectionActive = false;

    private Vector2 wonderPosition;

    private List<FirestormDamageReceiver> affectedEntities;

    public void Update()
    {
        base.UpdateWonder();
    }

    public override void OnWonderButtonClicked()
    {
        Debug.Log("firestorm start selection");
        StartSelection();
    }


    private void StartSelection()
    {
        isSelectionActive = true;
    }


    public void AbortSelection(CallbackContext obj)
    {
        isSelectionActive = false;
    }


    public void ConfirmSelection(CallbackContext obj)
    {
        if (isSelectionActive)
        {
            wonderPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            base.StartWonder();
            isSelectionActive = false;
        }
    }

    protected override void OnStartWonder()
    {
        if (visualEffect != null)
        {
            visualEffect.Clear();
            visualEffect.Play();
        }
    }

    protected override void OnStartWonderEffect()
    {
        affectedEntities = new List<FirestormDamageReceiver>();
        foreach (FirestormDamageReceiver damageReceiver in FindObjectsOfType<FirestormDamageReceiver>())
        {
            float dist = Vector2.Distance(wonderPosition, damageReceiver.transform.position);
            Debug.Log($"distance: {dist}");
            if (dist <= damageRadius)
            {
                damageReceiver.StartDamage();
                affectedEntities.Add(damageReceiver);
            }
        }

    }
    protected override void OnEndWonder() { }
    protected override void OnEndWonderEffect()
    {
        foreach (FirestormDamageReceiver damageReceiver in affectedEntities)
        {
            damageReceiver.EndDamage();
        }

    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}