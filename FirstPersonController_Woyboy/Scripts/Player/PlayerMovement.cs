using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonController_Woyboy
{
    /// <summary>
    /// Base class of the PlayerMovement. This controls the players movement and it does so
    /// using the CharacterController component. So any physics based calculations should be avoided
    /// when it comes to using CharacterControllers.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        // Movement Settings
        [SerializeField] private bool playerCanMove = true;
        [SerializeField] private bool playerCanJump = true;
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float jumpHeight = 1.5f;

        // Sprinting
        [SerializeField] private bool canSprint = true;
        [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
        [SerializeField] private float sprintSpeed = 7.0f;

        // Groundcheck
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;

        // Step Interval
        [SerializeField] private float stepInterval = 0.5f;

        // Internal
        private Player player;
        private CharacterController characterController;
        private Vector3 velocity;
        private bool isGrounded;
        private bool isSprinting;
        private float stepTimer;

        public void SetPlayerCanMove(bool playerCanMove)
        {
            this.playerCanMove = playerCanMove;
        }

        public void SetPlayerCanJump(bool playerCanJump)
        {
            this.playerCanJump = playerCanJump;
        }

        public void SetPlayerCanSprint(bool playerCanSprint)
        {
            this.canSprint = playerCanSprint;
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            player = GetComponent<Player>();
        }

        private void Update()
        {
            CheckGround();

            if (playerCanMove)
            {
                Movement();
                Jump();
            }
        }

        private void CheckGround()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Keeps player grounded
            }
        }

        private void Jump()
        {
            if (isGrounded && Input.GetButtonDown("Jump") && playerCanJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        private void Movement()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized;

            // Sprinting logic
            if (canSprint)
            {
                isSprinting = Input.GetKey(sprintKey) && moveZ > 0; // Only forward sprinting
            }

            float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

            characterController.Move(move * currentSpeed * Time.deltaTime);

            // Headbob
            if (isGrounded && move.magnitude > 0.1f)
            {
                float interval = isSprinting ? stepInterval * 0.6f : stepInterval; // faster steps when sprinting

                if (Time.time - stepTimer >= interval)
                {
                    stepTimer = Time.time;
                    player.PlayerCameraController.PlayHeadBob();
                }
            }

            // Gravity
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}