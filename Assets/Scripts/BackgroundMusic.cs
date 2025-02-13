using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Audio source component
    private AudioClip currentMusic; // Keeps track of the currently playing music

    public void PlayMusic(AudioClip newMusic)
    {
        if (audioSource.clip != newMusic) // Only switch if different
        {
            audioSource.clip = newMusic;
            audioSource.Play();
            currentMusic = newMusic;
        }
    }
}
