using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerUIController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Vector3 playerVelocity;
    [SerializeField]
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private Vector2 movementInput = Vector2.zero;
    private bool interact = false;
    private bool cancel = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Space");
        if (context.performed)
        {
            Debug.Log("true");
            interact = true;
        }
            

        if (context.canceled)
        {
            Debug.Log("false");
            interact = false;
        }
            
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        cancel = context.ReadValue<bool>();
        cancel = context.action.triggered;
    }

    void Update()
    {

        // Horizontal input
        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
        move = Vector3.ClampMagnitude(move, 1f); // Optional: prevents faster diagonal movement


        // Interact
        if (interact)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = screenPoint
            };

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            foreach(var result in results)
            {
                ExecuteEvents.Execute(result.gameObject, pointerData, ExecuteEvents.pointerClickHandler);
                break;
            }

            interact = false;
        }

        // cancel;
        if (cancel)
        {

        }


        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}
