using UnityEngine;
using TMPro;

public class MarkerLabel : MonoBehaviour
{
    public TextMeshPro text;

    void Awake()
    {
        if (text == null)
            text = GetComponentInChildren<TextMeshPro>();
    }

  public void SetLabel(string newLabel)
        {
            if (text != null)
            {
                text.text = newLabel;

                // Set color based on label
                switch (newLabel)
                {
                    case "Table":
                        text.color = Color.blue;
                        break;

                    case "Exit":
                        text.color = Color.red;
                        break;

                    case "Meeting Point":
                        text.color = Color.green;
                        break;

                    case "Tools":
                        text.color = new Color(1f, 0.5f, 0f); // orange
                        break;

                    case "Group":
                        text.color = new Color(0.6f, 0.2f, 0.8f); // purple
                        break;

                    case "Safety":
                        text.color = Color.yellow;
                        break;

                    default:
                        text.color = Color.white;
                        break;
                }
            }
        }
}