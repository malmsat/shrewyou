using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController; // Assuming you're using CharacterController

    private void Start()
    {
        animator = GetComponentInChildren<Animator>(); // Finds Animator on the sprite
        characterController = GetComponent<CharacterController>(); // Gets movement component
    }

    private void Update()
    {
        float speed = characterController.velocity.magnitude; // Get movement speed
        animator.SetFloat("Speed", speed); // Update Animator
    }
}
