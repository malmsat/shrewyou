using UnityEngine;

public class AreaMusicTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip areaMusic; // Music for this area
    private BackgroundMusic musicManager;

    private void Start()
    {
        // Find the BackgroundMusic script in the scene
        musicManager = FindObjectOfType<BackgroundMusic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && musicManager != null)
        {
            musicManager.PlayMusic(areaMusic);
        }
    }
}
