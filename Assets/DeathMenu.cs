using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public GameObject DeathMenuUI; // Reference to the pause menu UI
    public static bool isPaused = false; // Flag to check if the game is paused

    private AudioSource[] allAudioSources; // Array to hold all active AudioSources
    private CinemachineBrain cinemachineBrain; // Reference to Cinemachine Brain
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeathMenuUI.SetActive(false);
        allAudioSources = FindObjectsOfType<AudioSource>(); // Get all audio sources in the scene
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>(); // Get Cinemachine Brain from Main Camera
    }

    // Update is called once per frame
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
