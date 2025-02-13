using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject dialogueUI; // Assign in Inspector (Canvas Panel)
    public TextMeshProUGUI dialogueText; // Assign in Inspector
    public Button option1Button; // Assign in Inspector
    public Button option2Button; // Assign in Inspector

    private bool isPlayerInRange = false;

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

private bool isDialogueActive = false;

void ShowDialogue()
{
    dialogueUI.SetActive(true);
    isDialogueActive = true;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}

void HideDialogue()
{
    dialogueUI.SetActive(false);
    isDialogueActive = false;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

void Update()
{
    if (isDialogueActive)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
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
