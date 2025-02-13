using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Reference to the AudioSource
    [SerializeField] private AudioClip backgroundMusic; // Assign in Inspector
    [SerializeField] private AudioClip battleMusic; // Assign in Inspector
    [SerializeField] private float startTime = 16f; // Start music at 16s

    private bool hasStarted = false; // Ensure we only seek once
    private bool isInBattle = false; // Track if battle music is playing

    private void Start()
    {
        if (!hasStarted)
        {
            audioSource.time = startTime; // Start at specified time
            PlayMusic(backgroundMusic); // Play background music
            hasStarted = true;
        }
    }

    private void Update()
    {
        // Restart from the beginning when it reaches the end
        if (!audioSource.isPlaying && hasStarted)
        {
            audioSource.time = 0f; // Reset to the beginning
            audioSource.Play();
        }
    }

    public void PlayMusic(AudioClip musicClip)
    {
        if (audioSource.clip != musicClip)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
        }
    }

    public void EnterBattle()
    {
        if (!isInBattle)
        {
            isInBattle = true;
            PlayMusic(battleMusic);
        }
    }

    public void ExitBattle()
    {
        if (isInBattle)
        {
            isInBattle = false;
            PlayMusic(backgroundMusic);
        }
    }
}
