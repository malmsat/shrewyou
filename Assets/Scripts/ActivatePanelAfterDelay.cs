using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class ActivatePanelAfterDelay : MonoBehaviour
{
    public GameObject panel;
    public float delay = 6f;

    void Start()
    {
        StartCoroutine(ActivatePanelCoroutine());
    }

    IEnumerator ActivatePanelCoroutine()
    {
        yield return new WaitForSeconds(delay);
        panel.SetActive(true);

        // Ensure it's interactable
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        // Refresh event system
        EventSystem.current.SetSelectedGameObject(null);
    }
}
