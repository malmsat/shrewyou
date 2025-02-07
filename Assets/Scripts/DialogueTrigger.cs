using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private string dialogueText;
    [SerializeField] private AudioClip voiceClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers it
        {
            DialogueManager.Instance.PlayDialogue(dialogueText, voiceClip);
        }
    }
}
