using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveDir;

    private void Update()
    {
        moveDir = InputManager.inputActions.Player.Move.ReadValue<Vector2>();
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
