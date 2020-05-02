using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SacrificeWonder : AbstractWonder
{

    [SerializeField] private float radius;
    [SerializeField] private Texture2D sacrificeCursor;
    [SerializeField] private Texture2D defaultCursor;

    private bool isSelectionActive = false;
    private Sacrificeable highlighted;

    public override void Update()
    {
        base.UpdateWonder();

        if (!isSelectionActive && highlighted != null)
        {
            highlighted.RemoveHighlight();
        }
        if (isSelectionActive)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); 
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log($"found {hit.collider.gameObject}");
                Sacrificeable sacrificeable = hit.collider.gameObject.GetComponent<Sacrificeable>();
                if (sacrificeable != null)
                {
                    if (highlighted != sacrificeable && highlighted != null) {
                        highlighted.RemoveHighlight();
                    }
                    highlighted = sacrificeable;
                    highlighted.Highlight();
                }
            }
        }
    }

    public override void OnWonderButtonClicked()
    {
        Debug.Log("sacrifice start selection");
        StartSelection();
    }


    private void StartSelection()
    {
        isSelectionActive = true;
        Cursor.SetCursor(sacrificeCursor, Vector2.zero, CursorMode.Auto);
    }


    public void AbortSelection(CallbackContext obj)
    {
        isSelectionActive = false;
        if (highlighted != null) {
            highlighted.RemoveHighlight();
        }
        // TODO abort cooldown
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }


    public void ConfirmSelection(CallbackContext obj)
    {
        Debug.Log(highlighted);
        if (isSelectionActive && highlighted != null)
        {
            highlighted.RemoveHighlight();
            base.StartWonder();
            isSelectionActive = false;
        }
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);

    }

    protected override void OnStartWonder()
    {
        highlighted.Sacrifice();
    }

    protected override void OnStartWonderEffect() { }
    protected override void OnEndWonder() { }
    protected override void OnEndWonderEffect() { }

}