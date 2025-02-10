using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine; // Import Cinemachine

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI; // Reference to the pause menu UI
    public static bool isPaused = false; // Flag to check if the game is paused

    private AudioSource[] allAudioSources; // Array to hold all active AudioSources
    private CinemachineBrain cinemachineBrain; // Reference to Cinemachine Brain

    void Start()
    {
        PauseMenuUI.SetActive(false);
        allAudioSources = FindObjectsOfType<AudioSource>(); // Get all audio sources in the scene
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>(); // Get Cinemachine Brain from Main Camera
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Stop time
        PauseMenuUI.SetActive(true);
        isPaused = true;

        // Pause all audio sources
        foreach (AudioSource audio in allAudioSources)
        {
            audio.Pause();
        }

        // Disable Cinemachine Brain to stop camera movement
        if (cinemachineBrain != null)
        {
            cinemachineBrain.enabled = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        PauseMenuUI.SetActive(false);
        isPaused = false;

        // Resume all audio sources
        foreach (AudioSource audio in allAudioSources)
        {
            audio.UnPause();
        }

        // Re-enable Cinemachine Brain to restore camera movement
        if (cinemachineBrain != null)
        {
            cinemachineBrain.enabled = true;
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
