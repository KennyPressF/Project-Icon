using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] Transform aimPoint;

    [SerializeField] float gamepadRotateSmoothing = 1000f;
    Vector2 aimDir;
    bool isGamepad;

    PlayerInput playerInput;
    PlayerInputActions inputActions;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        aimDir = inputActions.Player.Aim.ReadValue<Vector2>();
        HandleRotation();
    }

    void HandleRotation()
    {
        if(isGamepad)
        {
            Vector3 lookDir = Vector3.right * aimDir.x + Vector3.up * aimDir.y;

            if(lookDir.sqrMagnitude > 0.0f)
            {
                Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, lookDir);
                aimPoint.rotation = Quaternion.RotateTowards(aimPoint.rotation, newRotation, gamepadRotateSmoothing * Time.deltaTime);
            }
        }
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, aimPoint.position.z - Camera.main.transform.position.z));

            Vector3 lookAtDirection = mousePosition - aimPoint.position;

            float angle = Mathf.Atan2(lookAtDirection.x, lookAtDirection.y) * Mathf.Rad2Deg;

            aimPoint.rotation = Quaternion.Euler(0f, 0f, -angle);
        }
    }

    void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, lookPoint.y, lookPoint.z);
        aimPoint.LookAt(heightCorrectedPoint);
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }
}
