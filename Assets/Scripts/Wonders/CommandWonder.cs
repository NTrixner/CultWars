using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CommandWonder : AbstractWonder
{
    [SerializeField] private Texture2D commandCursor;
    [SerializeField] private Texture2D defaultCursor;

    private bool isSelectionActive = false;

    public override void OnWonderButtonClicked()
    {
        isSelectionActive = true;
        Cursor.SetCursor(commandCursor, Vector2.zero, CursorMode.Auto);
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
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ConfirmPressed(CallbackContext obj)
    {
        if (isSelectionActive)
        {
            isSelectionActive = false;
            base.StartWonder();
        }
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    private void SendCommand(Vector3 mousePosition)
    {
        foreach (GoodGuyAI goodGuy in FindObjectsOfType<GoodGuyAI>())
        {
            goodGuy.Command(mousePosition);
        }

    }
}