using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonController_Woyboy
{
    /// <summary>
    /// Grand parent of the PlayerController. This helps organize all the scripts into one
    /// script, making it easier to adapt multiplayer implementation. 
    /// 
    /// This also has some additional methods such as Teleporting the player or fixed methods 
    /// to controlling the controls of the PlayerController.
    /// </summary>
    public class Player : MonoBehaviour
    {
        [Header("Player Scripts")]
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerCameraController playerCameraController;
        [SerializeField] private PlayerInteractionController playerInteractionController;
        [SerializeField] private PlayerRuntimeUIManager playerRuntimeUIManager;

        public PlayerMovement PlayerMovement => playerMovement;
        public PlayerCameraController PlayerCameraController => playerCameraController;
        public PlayerInteractionController PlayerInteractionController => playerInteractionController;
        public PlayerRuntimeUIManager PlayerRuntimeUIManager => playerRuntimeUIManager;

        /// <summary>
        /// Teleports player to a location
        /// </summary>
        /// <param name="location"></param>
        public void TeleportPlayer(Transform location)
        {
            gameObject.transform.position = location.position;
        }

        /// <summary>
        /// Completely locks the player of moving their camera, movement,
        /// and interaction
        /// </summary>
        public void LockPlayer()
        {
            PlayerCameraController.SetCameraCanMove(false);
            PlayerInteractionController.SetPlayerCanInteract(false);
            PlayerMovement.SetPlayerCanMove(false);
            PlayerMovement.SetPlayerCanSprint(false);
            PlayerMovement.SetPlayerCanJump(false);
        }

        /// <summary>
        /// Completely unlocks the player of moving their camera, movement,
        /// and interaction
        /// </summary>
        public void UnlockPlayer()
        {
            PlayerCameraController.SetCameraCanMove(true);
            PlayerInteractionController.SetPlayerCanInteract(true);
            PlayerMovement.SetPlayerCanMove(true);
            PlayerMovement.SetPlayerCanSprint(true);
            PlayerMovement.SetPlayerCanJump(true);
        }
    }
}