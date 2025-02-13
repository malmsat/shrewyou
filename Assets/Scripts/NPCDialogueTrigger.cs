using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject dialogueUI; // Assign in Inspector (Canvas Panel)
    public TextMeshProUGUI dialogueText; // Assign in Inspector
    public Button option1Button; // Assign in Inspector
    public Button option2Button; // Assign in Inspector
    public AudioSource audioSource; // Assign in Inspector
    public AudioClip enterSound; // Assign a sound effect in the Inspector

    private bool isPlayerInRange = false;
    private bool isDialogueActive = false;

    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            ShowDialogue();

            // Play sound when player enters
            if (audioSource != null && enterSound != null)
            {
                audioSource.PlayOneShot(enterSound);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            HideDialogue();
        }
    }

    void ShowDialogue()
    {
        dialogueUI.SetActive(true);
        isDialogueActive = true;
    }

    void HideDialogue()
    {
        dialogueUI.SetActive(false);
        isDialogueActive = false;
    }

    void ChooseOption(int option)
    {
        if (option == 1)
        {
            dialogueText.text = "TSSSSK! TSSSK! CHRP!";
        }
        else if (option == 2)
        {
            dialogueText.text = "EEEEEEEEEE!!";
        }

        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);

        Invoke("HideDialogue", 2f);
    }
}
