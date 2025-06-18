using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    // Raycast Settings
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    // Internal
    private Player player;
    private Interactable currentInteractable;

    public Interactable CurrentInteractable => currentInteractable;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        RaycastInteractables();
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(interactKey) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    private void RaycastInteractables()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

        if (Physics.Raycast(ray, out hit, interactDistance, interactableMask))
        {
            currentInteractable = hit.collider.GetComponent<Interactable>();
        }
        else
        {
            currentInteractable = null;
        }
    }
}
