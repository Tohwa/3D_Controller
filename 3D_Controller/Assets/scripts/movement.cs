using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float movementSpeed = 5f;    

    private Vector2 movementInput;
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Bewegung
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y) * movementSpeed * Time.deltaTime;
        _rb.MovePosition(transform.position + transform.TransformDirection(movement));        
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
}
