using UnityEngine;

public class EatFood : MonoBehaviour
{
    public AudioSource playerAudioSource;  // Assign player's AudioSource in the Inspector
    public AnimationControlle animationControlle; // Reference to the animation controller
    public GameObject eatParticleEffect; // Assign your particle prefab in the Inspector

    void Start()
    {
        if (animationControlle == null)
        {
            animationControlle = FindObjectOfType<AnimationControlle>(); // Auto-find if not assigned
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))  // Ensure food items have the "Food" tag
        {
            AudioSource foodAudio = other.GetComponent<AudioSource>();
            if (foodAudio != null && foodAudio.clip != null)
            {
                playerAudioSource.PlayOneShot(foodAudio.clip);  // Play the food's specific sound
            }

            if (animationControlle != null)
            {
                animationControlle.TriggerEatAnimation(); // Trigger eating animation
            }

            if (eatParticleEffect != null)
            {
                GameObject particles = Instantiate(eatParticleEffect, other.transform.position, Quaternion.identity);
                ParticleSystem ps = particles.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();  // Ensure particles start playing
                }
                Destroy(particles, ps.main.duration); // Destroy after it finishes
            }


            Destroy(other.gameObject); // Remove food item after eating
        }
    }
}
