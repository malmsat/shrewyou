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

    void ShowDialogue()
    {
        dialogueUI.SetActive(true);
        dialogueText.text = "Squeak-squeak-SQUEAK! Ch-ch-ch-ch CHRRRP!!";

        // Unlock cursor for UI interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Set button text and actions
        option1Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
        option2Button.GetComponentInChildren<TextMeshProUGUI>().text = "";

        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();

        option1Button.onClick.AddListener(() => ChooseOption(1));
        option2Button.onClick.AddListener(() => ChooseOption(2));
    }

    void HideDialogue()
    {
        dialogueUI.SetActive(false);

        // Lock cursor back when dialogue closes
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
