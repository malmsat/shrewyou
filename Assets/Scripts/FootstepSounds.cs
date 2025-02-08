using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public AudioClip[] footstepSounds;  // Assign different footstep sounds
    public float stepInterval = 0.5f;  // Time between steps

    private CharacterController characterController;
    private float stepTimer;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length > 0)
        {
            footstepAudioSource.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
        }
    }
}
