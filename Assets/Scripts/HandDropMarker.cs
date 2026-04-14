using UnityEngine;
using UnityEngine.XR;

public class HandDropMarker : MonoBehaviour
{
    public GameObject markerPrefab;
    public Camera xrCamera;

    bool wasPinchingLastFrame = false;

    void Update()
    {
        bool isPinchingNow = IsPinching(XRNode.RightHand) || IsPinching(XRNode.LeftHand);

        // Detect "drop" = was pinching, now not pinching
        if (wasPinchingLastFrame && !isPinchingNow)
        {
            DropMarker();
        }

        wasPinchingLastFrame = isPinchingNow;
    }

    bool IsPinching(XRNode hand)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(hand);

        if (device.TryGetFeatureValue(CommonUsages.trigger, out float pinchValue))
        {
            return pinchValue > 0.8f; 
        }

        return false;
    }

    void DropMarker()
    {
        Ray ray = new Ray(xrCamera.transform.position, xrCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 5f))
        {
            Instantiate(markerPrefab, hit.point, Quaternion.identity);
        }
    }
}
