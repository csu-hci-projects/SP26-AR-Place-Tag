using UnityEngine;

public class LabelMenuManager : MonoBehaviour
{
    public GameObject menuRoot;
    public Transform cameraTransform;

    private MarkerLabel currentMarker;

public void OpenMenu(MarkerLabel marker)
{
    currentMarker = marker;

    // position slightly above marker
    Vector3 offset = new Vector3(0, 0.5f, 0);
    menuRoot.transform.position = marker.transform.position + offset;

    // always face user
    if (cameraTransform != null)
    {
        menuRoot.transform.LookAt(cameraTransform);
        menuRoot.transform.Rotate(0, 180f, 0);
    }

    menuRoot.SetActive(true);
}

    public void ChooseLabel(string label)
    {
        if (currentMarker != null)
            currentMarker.SetLabel(label);

        menuRoot.SetActive(false);
    }

    public bool IsMenuOpen()
    {
        return menuRoot != null && menuRoot.activeSelf;
    }
}