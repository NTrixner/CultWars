using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class SacrificeWonder : AbstractWonder
{

    [SerializeField] private float radius;

    private bool isSelectionActive = false;
    private Sacrificeable highlighted;

    public void Update()
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
    }


    public void AbortSelection(CallbackContext obj)
    {
        isSelectionActive = false;
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

    }

    protected override void OnStartWonder()
    {
        highlighted.Sacrifice();
    }

    protected override void OnStartWonderEffect() { }
    protected override void OnEndWonder() { }
    protected override void OnEndWonderEffect() { }

}