using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    private PlayerControls _controls;

    private Vector2 _moveAxis;

    void OnEnable() {
        _controls = new PlayerControls();
        _controls.Priest.Walk.performed += HandleWalk;
        _controls.Priest.Walk.canceled += HandleWalkCancelled;
        _controls.Priest.Walk.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_moveAxis.x * Time.deltaTime * _speed, _moveAxis.y * Time.deltaTime * _speed, 0);
    }

    private void HandleWalk(CallbackContext context) {
        _moveAxis = context.ReadValue<Vector2>();
        Debug.Log($"Move Axis{_moveAxis}");
    }

    private void HandleWalkCancelled(CallbackContext obj)
    {
        _moveAxis.Set(0,0);
        Debug.Log("Handle walk cancelled");
    }
}
