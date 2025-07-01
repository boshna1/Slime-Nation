using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    [SerializeField] Transform parent;
    [SerializeField] CharacterSelectCounter confirm;

    private Vector2 movementInput = Vector2.zero;
    private bool interact = false;
    private bool cancel = false;
    private bool isReady = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        confirm = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<CharacterSelectCounter>();
        transform.SetParent(GameObject.FindGameObjectWithTag("PlayerManager").transform);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log("moving");
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
        if (context.performed)
        {
            Debug.Log("true");
            cancel = true;
        }


        if (context.canceled)
        {
            Debug.Log("false");
            cancel = false;
        }
    }

    void Update()
    {

        // Horizontal input
        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
        move = Vector3.ClampMagnitude(move, 1f); // Optional: prevents faster diagonal movement


        // Interact
        if (interact)
        {
            if (!isReady)
            {
                Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

                PointerEventData pointerData = new PointerEventData(EventSystem.current)
                {
                    position = screenPoint
                };

                var results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, results);
                foreach (var result in results)
                {
                    transform.name = result.gameObject.name;
                    if (result.gameObject.name == "Lord" || result.gameObject.name == "John" || result.gameObject.name == "Sarah" || result.gameObject.name == "Door" )
                    {
                        confirm.AddReady();
                        isReady = true;
                    }
                    ExecuteEvents.Execute(result.gameObject, pointerData, ExecuteEvents.pointerClickHandler);
                }
            }
            

            interact = false;
        }

        // cancel;
        if (cancel)
        {
            if (isReady && confirm.GetIsConfirm())
            {
                confirm.SetIsConfirm(false);
                isReady = false;
                confirm.SubReady();
                transform.name = "Not Selected";
            }
            else if (isReady && !confirm.GetIsConfirm()) 
            {
                confirm.SubReady();
                isReady = false;
                transform.name = "Not Selected";
            }
            else if (!isReady)
            {
                confirm.RemovePlayerCount();
            }
            cancel = false;
        }


        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}
