using UnityEngine;

namespace FirstPersonController_Woyboy
{
    /// <summary>
    /// A canvas is attached to the player object to simply display
    /// the crosshair and other elements you wish to add. I would not
    /// recommend using this canvas and this script to managing all your
    /// UI. Just so that you can avoid having to redraw the canvas everytime.
    /// </summary>
    public class PlayerRuntimeUIManager : MonoBehaviour
    {
        // Crosshair Settings
        [SerializeField] private GameObject crosshairObj;
        [SerializeField] private GameObject interactableCrosshairObj;

        // Internal
        private Player player;

        private void Awake()
        {
            player = GetComponent<Player>();
        }

        public void ToggleCrosshair(bool toggle)
        {
            crosshairObj.SetActive(toggle);
        }

        public void ToggleInteractableCrosshair(bool toggle)
        {
            interactableCrosshairObj.SetActive(toggle);
        }
    }
}