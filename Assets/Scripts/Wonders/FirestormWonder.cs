using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class FirestormWonder : AbstractWonder
{


    [SerializeField] private float damageRadius;
    [SerializeField] private float damage;

    [SerializeField] private GameObject visualEffect;
    [SerializeField] private Texture2D fireCursor;
    [SerializeField] private Texture2D defaultCursor;

    private bool isSelectionActive = false;

    private Vector2 wonderPosition;

    private List<FirestormDamageReceiver> affectedEntities;

    public override void OnWonderButtonClicked()
    {
        Debug.Log("firestorm start selection");
        StartSelection();
    }


    private void StartSelection()
    {
        isSelectionActive = true;
        Cursor.SetCursor(fireCursor, Vector2.zero, CursorMode.Auto);
    }


    public void AbortSelection(CallbackContext obj)
    {
        isSelectionActive = false;
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }


    public void ConfirmSelection(CallbackContext obj)
    {
        if (isSelectionActive)
        {
            wonderPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            base.StartWonder();
            isSelectionActive = false;
        }
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    protected override void OnStartWonder()
    {
        if (visualEffect != null)
        {
            visualEffect.SetActive(true);
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