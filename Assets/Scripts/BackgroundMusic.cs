using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Reference to the AudioSource
    [SerializeField] private float startTime = 16f; // Start music at 15s

    private bool hasStarted = false; // Ensure we only seek once

    private void Start()
    {
        if (!hasStarted) 
        {
            audioSource.time = startTime; // Start at 15s
            audioSource.Play(); 
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
}
