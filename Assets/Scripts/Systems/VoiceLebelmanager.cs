using UnityEngine;
using UnityEngine.InputSystem;

public class VoiceLabelManager : MonoBehaviour
{
    private MarkerLabel currentMarker;

    public void SetCurrentMarker(MarkerLabel marker)
    {
        currentMarker = marker;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame) ApplyVoiceLabel("table");
        if (Keyboard.current.digit2Key.wasPressedThisFrame) ApplyVoiceLabel("exit");
        if (Keyboard.current.digit3Key.wasPressedThisFrame) ApplyVoiceLabel("tools");
    }

    public void ApplyVoiceLabel(string spokenCommand)
    {
        if (currentMarker == null)
        {
            Debug.LogWarning("No marker selected for voice label.");
            return;
        }

        string label = NormalizeCommand(spokenCommand);

        if (!string.IsNullOrEmpty(label))
        {
            currentMarker.SetLabel(label);
            Debug.Log("Voice label applied: " + label);
        }
    }

    private string NormalizeCommand(string command)
    {
        command = command.ToLower().Trim();

        if (command.Contains("table")) return "Table";
        if (command.Contains("exit")) return "Exit";
        if (command.Contains("meeting")) return "Meeting Point";
        if (command.Contains("tools")) return "Tools";
        if (command.Contains("group")) return "Group";
        if (command.Contains("safety")) return "Safety";

        return "";
    }
}