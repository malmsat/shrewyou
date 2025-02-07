using UnityEngine;

public class EatFood : MonoBehaviour
{
    public AudioSource playerAudioSource;  // Assign player's AudioSource in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))  // Ensure food items have the "Food" tag
        {
            AudioSource foodAudio = other.GetComponent<AudioSource>();
            if (foodAudio != null && foodAudio.clip != null)
            {
                playerAudioSource.PlayOneShot(foodAudio.clip);  // Play the food's specific sound
            }
        }
    }
}
