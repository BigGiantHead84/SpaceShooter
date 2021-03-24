using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerController : MonoBehaviour
{
    [Header("Input")] public float movementSpeed = 1f;
    public int controlType;
    public float verticalFingerOffset;

    private Vector3 _direction;
    private PlayerControls _controls;
    private Vector2 _move;
    private Vector2 _targetPos;
    private float _distance;
    private bool _firstPos;
    private float _moveSpeed;

    private void Awake()
    {
        _firstPos = true;
        _moveSpeed = movementSpeed;
        _controls = new PlayerControls();
        _controls.PlayerController.Move.performed += OnMove;
        //_controls.PlayerController.Move.performed += ctx => WarpTo(ctx.ReadValue<Vector2>());
    }

    private void FixedUpdate()
    {
        _distance = Vector2.Distance(transform.position, _targetPos);
        if (_firstPos) return;
        if (!(_distance > 0)) return;
        movementSpeed = _distance + _moveSpeed; 
        var step = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, step);
    }

    private void OnEnable()
    {
        _controls.PlayerController.Enable();
    }

    private void OnDisable()
    {
        _controls.PlayerController.Disable();
    }
    

    private void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("OnMove Called");
        _firstPos = false;
        Vector2 touchPos = context.ReadValue<Vector2>();
        touchPos.y = touchPos.y + verticalFingerOffset;
        movementSpeed = _moveSpeed;
        _targetPos = Utilities.CalculateScreenToWorld(touchPos);
        _distance = Vector2.Distance(transform.position, touchPos);
    }
}