using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private bool grounded;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && grounded)
        {
            grounded = false;
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
