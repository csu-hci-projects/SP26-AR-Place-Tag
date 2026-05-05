using UnityEngine;
using UnityEngine.InputSystem;

public class PinchSystem : MonoBehaviour
{
    public InputActionReference pinchAction;
    public MarkerManager markerManager;
    public LabelMenuManager labelMenuManager;

    private void OnEnable()
    {
        pinchAction.action.Enable();
        pinchAction.action.performed += OnPinch;
    }

    private void OnDisable()
    {
        pinchAction.action.performed -= OnPinch;
        pinchAction.action.Disable();
    }

    private void OnPinch(InputAction.CallbackContext context)
    {
        if (labelMenuManager != null && labelMenuManager.IsMenuOpen())
        {
            Debug.Log("Menu is open, not spawning new marker.");
            return;
        }

        if (markerManager != null)
        {
            markerManager.SpawnMarker();
        }
    }
}