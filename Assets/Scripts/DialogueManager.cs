using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance; // Singleton for easy access

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private AudioSource audioSource;

    private Queue<string> dialogueQueue = new Queue<string>(); // Queue for text
    private Queue<AudioClip> audioQueue = new Queue<AudioClip>(); // Queue for audio
    private bool isPlaying = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayDialogue(string[] texts, AudioClip[] voiceClips)
    {
        if (texts.Length != voiceClips.Length) 
        {
            Debug.LogError("Texts and voice clips count do not match!");
            return;
        }

        foreach (string text in texts)
        {
            dialogueQueue.Enqueue(text);
        }

        foreach (AudioClip clip in voiceClips)
        {
            audioQueue.Enqueue(clip);
        }

        if (!isPlaying)
        {
            StartCoroutine(PlayNextDialogue());
        }
    }

    private IEnumerator PlayNextDialogue()
    {
        isPlaying = true;

        while (dialogueQueue.Count > 0)
        {
            dialogueText.text = dialogueQueue.Dequeue();
            AudioClip clip = audioQueue.Dequeue();
            audioSource.clip = clip;
            audioSource.Play();

            yield return new WaitForSeconds(clip.length + 0.5f); // Wait for audio to finish + slight pause
        }

        // Clear text when all dialogues are finished
        dialogueText.text = ""; 

        isPlaying = false;
    }

}
