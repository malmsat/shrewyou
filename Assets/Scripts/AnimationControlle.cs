using UnityEngine;

public class AnimationControlle : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer spriteRenderer;
    private StarterAssets.ThirdPersonController playerController;
    private HealthController healthController;

    void Start()
    {
        // Get the SpriteRenderer from the child object
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); 

        // Find the ThirdPersonController script on the player
        playerController = FindFirstObjectByType<StarterAssets.ThirdPersonController>();

        // Get the HealthController on the same GameObject
        healthController = GetComponent<HealthController>();

        // Subscribe to the OnDeath event
        if (healthController != null)
        {
            healthController.OnDeath.AddListener(HandleDeath);
        }
    }

    void Update()
    {
        if (anim.GetBool("isDead")) return; // Prevent updates after death

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set isMoving based on movement input
        anim.SetBool("isMoving", horizontalInput != 0 || verticalInput != 0);

        // Flip sprite based on movement direction
        if (horizontalInput > 0) 
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }

        // Check if the player is jumping
        if (playerController != null)
        {
            bool isJumping = !playerController.Grounded; // If not grounded, player is in the air
            anim.SetBool("isJumping", isJumping);
        }
    }

    private void HandleDeath()
    {
        anim.SetBool("isDead", true);
        anim.SetTrigger("Death"); // Trigger the death animation
    }
}
