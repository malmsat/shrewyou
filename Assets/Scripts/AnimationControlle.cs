using UnityEngine;

public class AnimationControlle : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer spriteRenderer;
    private StarterAssets.ThirdPersonController playerController;
    private HealthController healthController;
    
    public AudioSource walkAudioSource; // Assign in Inspector

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerController = FindFirstObjectByType<StarterAssets.ThirdPersonController>();
        healthController = GetComponent<HealthController>();

        if (healthController != null)
        {
            healthController.OnDeath.AddListener(HandleDeath);
        }
    }

    void Update()
    {
        if (anim.GetBool("isDead")) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isMoving = horizontalInput != 0 || verticalInput != 0;
        anim.SetBool("isMoving", isMoving);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }

        bool isJumping = playerController != null && !playerController.Grounded;
        anim.SetBool("isJumping", isJumping);

        // 🔹 Walking Sound Logic 🔹
        if (isMoving && !isJumping) 
        {
            if (!walkAudioSource.isPlaying) // Play only if not already playing
            {
                walkAudioSource.Play();
            }
        }
        else
        {
            if (walkAudioSource.isPlaying)
            {
                walkAudioSource.Stop();
            }
        }
    }

    private void HandleDeath()
    {
        anim.SetBool("isDead", true);
        anim.SetTrigger("Death");
        walkAudioSource.Stop(); // Ensure walking sound stops on death
    }

    public void TriggerEatAnimation()
    {
        anim.SetTrigger("Eat");
    }

}
