using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FirstPersonController_Woyboy
{
    public class Interactable : MonoBehaviour
    {
        [Header("Interactable - Base Settings")]
        [SerializeField] private bool canInteract = true;
        [SerializeField] private bool displayDebugMessage = false;
        [SerializeField] private UnityEvent OnInteract;

        [Header("Interactable - Base Pickup")]
        [SerializeField] private bool isPickupable = false;
        [SerializeField] private Rigidbody[] pickupRigidbodies;
        [SerializeField] private Collider[] pickupColliders;

        public Rigidbody[] PickupRigidbodies => pickupRigidbodies;
        public bool CanInteract => canInteract;
        public bool IsPickupable => isPickupable;

        public void SetCanInteract(bool canInteract)
        {
            this.canInteract = canInteract;
        }

        public void SetIsPickupable(bool isPickupable)
        {
            this.isPickupable = isPickupable;
        }

        /// <summary>
        /// All classes inheriting the Interactable.cs should be overriding this
        /// specific method if you want to do anything different
        /// </summary>
        public virtual void Interact()
        {
            if (canInteract == false) return;

            if (displayDebugMessage)
                Debug.Log("Interacted with " + gameObject.name);

            OnInteract?.Invoke();
        }

        /// <summary>
        /// Toggling the colliders on the object
        /// </summary>
        /// <param name="toggle"></param>
        public void TogglePickupColliders(bool toggle)
        {
            foreach (var collider in pickupColliders)
            {
                collider.enabled = toggle;
            }
        }

        /// <summary>
        /// Toggling the rigidbodies on the object. This does not use the 'enabled' field on the 
        /// component but instead controls the gravity.
        /// </summary>
        /// <param name="toggle"></param>
        public void ToggleRigidbodies(bool toggle)
        {
            if (toggle == false)
            {
                foreach (var rb in pickupRigidbodies)
                {
                    rb.isKinematic = true;
                    rb.useGravity = false;
                }
            }
            else if (toggle == true)
            {
                foreach (var rb in pickupRigidbodies)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }
            }
        }
    }
}