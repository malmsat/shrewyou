using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance; // Singleton for easy access

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private AudioSource audioSource;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayDialogue(string text, AudioClip voiceClip)
    {
        dialogueText.text = text; // Display text
        audioSource.clip = voiceClip; 
        audioSource.Play(); // Play narration
    }
}
