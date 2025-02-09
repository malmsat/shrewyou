using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI; // Reference to the pause menu
    public static bool isPaused = false; // Flag to check if the game is paused

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused && PauseMenuUI != null)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (isPaused && PauseMenuUI != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Stop time
        PauseMenuUI.SetActive(true); // Show the pause menu
        isPaused = true; // Set the flag to true
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        PauseMenuUI.SetActive(false); // Hide the pause menu
        isPaused = false; // Set the flag to false
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // Resume time
        isPaused = false; // Set the flag to false
        SceneManager.LoadScene("MainMenu"); // Load the menu scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
