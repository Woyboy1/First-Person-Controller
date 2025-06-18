using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Scripts")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCameraController playerCameraController;
    [SerializeField] private PlayerInteractionController playerInteractionController;

    public PlayerMovement PlayerMovmenet => playerMovement;
    public PlayerCameraController PlayerCameraController => playerCameraController;
    public PlayerInteractionController PlayerInteractionController => playerInteractionController;
}
