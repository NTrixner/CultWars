using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CommandWonder : AbstractWonder
{

    private bool isSelectionActive = false;

    public override void OnWonderButtonClicked()
    {
        isSelectionActive = true;
    }

    protected override void OnStartWonder()
    {
        SendCommand(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
    }

    protected override void OnEndWonder()
    {

    }

    public void CancelPressed(CallbackContext obj)
    {
        if (isSelectionActive)
        {
            isSelectionActive = false;
        }
    }

    public void ConfirmPressed(CallbackContext obj)
    {
        if (isSelectionActive)
        {
            isSelectionActive = false;
            base.StartWonder();
        }
    }

    private void SendCommand(Vector3 mousePosition)
    {
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.Command(mousePosition);
        }

    }
}