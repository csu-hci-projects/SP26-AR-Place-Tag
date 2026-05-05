using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform cameraTransform;

    void LateUpdate()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (cameraTransform == null) return;

        Vector3 direction = cameraTransform.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(-direction);
        }
    }
}