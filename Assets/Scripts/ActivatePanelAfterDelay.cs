using UnityEngine;

public class ActivatePanelAfterDelay : MonoBehaviour
{
    public GameObject panel; // Assign your panel in the inspector
    public float delay = 6f; // Time in seconds before activating the panel

    void Start()
    {
        if (panel != null)
        {
            Invoke(nameof(ActivatePanel), delay);
        }
    }

    void ActivatePanel()
    {
        panel.SetActive(true);
    }
}
