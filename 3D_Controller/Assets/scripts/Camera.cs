using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEditor.Rendering.LookDev;

public class Camera : MonoBehaviour
{
    #region Fields
    [SerializeField] private CinemachineFreeLook _freeLookCamera;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Transform _target;

    [SerializeField] private bool rightMouseButton = false;

    private Vector2 orbitInput;
    #endregion

    private void Start()
    {
        _virtualCamera.enabled = true;
        _freeLookCamera.enabled = false;
    }

    void Update()
    {
        if (rightMouseButton && !_freeLookCamera.enabled)
        {
            return;
        }
    }

    public void OnMouseHold(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {
            rightMouseButton = true;
            _virtualCamera.enabled = false;
            _freeLookCamera.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            rightMouseButton = false;
            _virtualCamera.enabled = true;
            _freeLookCamera.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
