using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float jumpForce = 5f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && _rb.velocity.y == 0)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
