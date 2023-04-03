using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// tao ra 1 Custom Input tu InputSystem
/// ActionMaps:Player =>Actions :Movement =>ActionType :Value ,ControlType Vector2
/// Xoa di Binding
/// Nhan vao dau cong o Movement(Actions) chon Add Up,Down,Left,Right
/// Roi tuy chinh cac nut theo gamepad hoac KeyBoard
/// Genarate ra 1 file C#
/// </summary>
public class PlayerController : MonoBehaviour
{
    private CustomInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 10f;
    private void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerfomed;
        input.Player.Movement.canceled +=OnMovementCanceled;
        input.Player.Movement.started += OnMovementStarted;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerfomed;
        input.Player.Movement.canceled -= OnMovementCanceled;   
        input.Player.Movement.started -= OnMovementStarted;
    }
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }
    private void OnMovementPerfomed(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>().normalized;
    }    

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        moveVector = Vector2.zero;
    }

    private void OnMovementStarted(InputAction.CallbackContext context)
    {
        
    }
}
