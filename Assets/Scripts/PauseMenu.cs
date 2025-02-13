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


    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        PauseMenuUI.SetActive(true);
        isPaused = true;

        // Pause all valid audio sources
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            if (audio != null && audio.isPlaying) // Check if the AudioSource is valid
            {
                audio.Pause();
            }
        }

        if (cinemachineBrain != null)
        {
            cinemachineBrain.enabled = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        isPaused = false;

        // Resume all valid audio sources
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            if (audio != null) // Check if the AudioSource is valid
            {
                audio.UnPause();
            }
        }

        if (cinemachineBrain != null)
        {
            cinemachineBrain.enabled = true;
        }
    }


public void LoadMenu()
{
    Time.timeScale = 1f; // Ensure time is unpaused
    isPaused = false;
    Cursor.lockState = CursorLockMode.None; // Ensure cursor is unlocked
    Cursor.visible = true;
    SceneManager.LoadScene("MainMenu");
}


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
