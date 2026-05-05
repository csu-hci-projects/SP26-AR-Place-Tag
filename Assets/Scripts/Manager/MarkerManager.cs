using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    public GameObject markerPrefab;
    public Transform cameraTransform;
    public LabelMenuManager labelMenuManager;
    public VoiceLabelManager voiceLabelManager;

    public void SpawnMarker()
    {
        if (markerPrefab == null || cameraTransform == null)
        {
            Debug.LogWarning("Missing references in MarkerManager");
            return;
        }

        Vector3 spawnPosition = cameraTransform.position + cameraTransform.forward * 1.5f;

        GameObject obj = Instantiate(markerPrefab, spawnPosition, Quaternion.identity);

        Debug.Log("Marker Spawned!");

        MarkerLabel markerLabel = obj.GetComponent<MarkerLabel>();

        if (markerLabel == null)
        {
            Debug.LogWarning("MarkerLabel script is missing on spawned prefab root!");
            return;
        }

        // Set this new marker as the active marker for voice labeling
        if (voiceLabelManager != null)
        {
            voiceLabelManager.SetCurrentMarker(markerLabel);
        }

        // Open gesture label menu
        if (labelMenuManager != null)
        {
            labelMenuManager.OpenMenu(markerLabel);
        }
        else
        {
            Debug.LogWarning("LabelMenuManager reference is missing on MarkerManager!");
        }
    }
}