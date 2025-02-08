using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private string[] dialogueTexts; // Array for multiple lines
    [SerializeField] private AudioClip[] voiceClips; // Array for multiple voice lines

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player")) 
        {
            DialogueManager.Instance.PlayDialogue(dialogueTexts, voiceClips);
            hasTriggered = true; // Prevent future triggers
        }
    }
}
