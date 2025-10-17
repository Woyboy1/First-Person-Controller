using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonController_Woyboy
{
    public class PlayerInteractionController : MonoBehaviour
    {
        // Raycast Settings
        [SerializeField] private bool playerCanInteract = true;
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float interactDistance = 3f;
        [SerializeField] private float dropIntensity = 2.0f;
        [SerializeField] private LayerMask interactableMask;
        [SerializeField] private KeyCode interactKey = KeyCode.E;
        [SerializeField] private KeyCode dropKey = KeyCode.G;
        [SerializeField] private Transform playerHand;

        // Internal
        private Player player;
        private Interactable currentInteractable;
        private Interactable heldItem;
        private bool isHoldingItem = false;

        public Interactable CurrentInteractable => currentInteractable;
        public float DropIntensity => dropIntensity;
        public bool PlayerCanInteract => playerCanInteract;
        public bool IsHoldingItem => isHoldingItem;

        public void SetPlayerCanInteract(bool playerCanInteract)
        {
            this.playerCanInteract = playerCanInteract;
        }

        public void SetPlayerDropIntensity(float dropIntensity)
        {
            this.dropIntensity = dropIntensity;
        }

        private void Awake()
        {
            player = GetComponent<Player>();
        }

        private void Update()
        {
            if (playerCanInteract == false) { return; }
            RaycastInteractables();
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(interactKey) && currentInteractable != null)
            {
                InteractWithCurrentInteractable();
            }
            if (Input.GetKeyDown(dropKey) && isHoldingItem)
            {
                Drop();
            }
        }

        /// <summary>
        /// A simple raycast method attached to the camera searching for interactables in the
        /// interactable layer mask. This also controls the local UI on the player, in this case is
        /// the crosshairs.
        /// </summary>
        private void RaycastInteractables()
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

            if (Physics.Raycast(ray, out hit, interactDistance, interactableMask))
            {
                player.PlayerRuntimeUIManager.ToggleInteractableCrosshair(true); // Interactable UI
                currentInteractable = hit.collider.GetComponent<Interactable>();
            }
            else
            {
                player.PlayerRuntimeUIManager.ToggleInteractableCrosshair(false); // Interactable UI
                currentInteractable = null;
            }
        }

        /// <summary>
        /// Interacting with the currentInteractable class and checking conditions. All main functions
        /// of interacting with something is done here.
        /// </summary>
        private void InteractWithCurrentInteractable()
        {
            if (currentInteractable.CanInteract == false) return;
            if (currentInteractable.IsPickupable == true)
            {
                Pickup();
                return;
            }

            currentInteractable.Interact();
        }

        /// <summary>
        /// Picking up disables the rigidbodies and colliders and sets the
        /// currentInteractable gameobject to the playerHand gameobject. 
        /// </summary>
        private void Pickup()
        {
            heldItem = currentInteractable;

            heldItem.TogglePickupColliders(false);
            heldItem.ToggleRigidbodies(false);
            heldItem.SetCanInteract(false);
            isHoldingItem = true;

            heldItem.transform.position = playerHand.transform.position;
            heldItem.transform.rotation = playerHand.transform.rotation;
            heldItem.transform.SetParent(playerHand);
        }

        /// <summary>
        /// Same thing with Pickup() but the complete opposite. Re-enablign the
        /// rigidbodies, colliders, and removing the parent. But this time we are
        /// using Rigidbody.AddForce() to simulate a more realistic drop.
        /// </summary>
        private void Drop()
        {
            heldItem.TogglePickupColliders(true);
            heldItem.ToggleRigidbodies(true);
            heldItem.SetCanInteract(true);
            isHoldingItem = false;

            Vector3 dropDirection = playerCamera.transform.forward;

            // Addforce
            foreach (Rigidbody rb in heldItem.PickupRigidbodies)
            {
                rb?.AddForce(dropDirection * dropIntensity, ForceMode.Impulse);
            }

            heldItem.transform.SetParent(null);

            heldItem = null;
        }
    }
}