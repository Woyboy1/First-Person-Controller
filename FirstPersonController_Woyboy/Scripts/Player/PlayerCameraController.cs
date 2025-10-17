using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace FirstPersonController_Woyboy
{
    /// <summary>
    /// PlayerCameraController manually controls the rotation of the virtual camera
    /// instead of the POV Aim component. This is because the POV Aim component isn't very
    /// precise and that it quickly falls off in future Unity cinemachine documentation. 
    /// </summary>
    public class PlayerCameraController : MonoBehaviour
    {
        // Camera Settings
        [SerializeField] private CinemachineCamera vcam;
        [SerializeField] private float fov = 60f;
        [SerializeField] private bool invertCamera = false;
        [SerializeField] private bool cameraCanMove = true;
        [SerializeField] private float mouseSensitivity = 2f;
        [SerializeField] private float maxLookAngle = 90f;
        [SerializeField] private bool lockCursor = true;

        // Head Bobbing
        [SerializeField] private CinemachineImpulseSource headBob;

        // Zooming
        [SerializeField] private bool enableZoom = true;
        [SerializeField] private bool holdToZoom = false;
        [SerializeField] private KeyCode zoomKey = KeyCode.Mouse1;
        [SerializeField] private float zoomFOV = 30f;
        [SerializeField] private float zoomStepTime = 5f;

        // Internal
        private Player player;
        private float yaw = 0f;
        private float pitch = 0f;
        private Transform playerBody;
        private Camera vcamCamera;

        public Camera VcamCamera => vcamCamera;
        public CinemachineCamera Vcam => vcam;

        public void SetCameraCanMove(bool canMove)
        {
            this.cameraCanMove = canMove;
        }

        public void SetEnableZoom(bool enableZoom)
        {
            this.enableZoom = enableZoom;
        }

        private void Awake()
        {
            player = GetComponent<Player>();
            playerBody = transform;
            vcam.Lens.FieldOfView = fov;

            if (vcam == null)
                Debug.LogError("Cinemachine Virtual Camera not assigned!");

            if (lockCursor)
                Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            RotateCamera();
            HandleZoom();
        }

        private Vector2 GetMouseInput()
        {
            return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;
        }

        private void RotateCamera()
        {
            if (cameraCanMove == false) return;

            Vector2 mouseInput = GetMouseInput();

            // Update yaw and rotate player body (left/right)
            yaw += mouseInput.x;
            playerBody.localRotation = Quaternion.Euler(0f, yaw, 0f);

            // Update pitch and clamp it (up/down)
            pitch += invertCamera ? mouseInput.y : -mouseInput.y;
            pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

            // Rotate Cinemachine virtual camera up/down
            vcam.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }

        private void HandleZoom()
        {
            if (!enableZoom || vcam == null) return;

            bool zoomInput = holdToZoom ? Input.GetKey(zoomKey) : Input.GetKeyDown(zoomKey);
            bool zoomRelease = !holdToZoom && Input.GetKeyUp(zoomKey);

            float targetFOV = fov;

            if (zoomInput)
                targetFOV = zoomFOV;
            else if (zoomRelease || (holdToZoom && !Input.GetKey(zoomKey)))
                targetFOV = fov;

            vcam.Lens.FieldOfView = Mathf.Lerp(vcam.Lens.FieldOfView, targetFOV, Time.deltaTime * zoomStepTime);
        }

        public void SetCursorLock(bool locked)
        {
            Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public void PlayHeadBob()
        {
            if (headBob != null)
                headBob.GenerateImpulse();
        }
    }
}