using UnityEngine;

public class TapChangeColor : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void OnMouseDown()
    {
        // Random color on tap
        rend.material.color = new Color(
            Random.value,
            Random.value,
            Random.value
        );
    }
}
