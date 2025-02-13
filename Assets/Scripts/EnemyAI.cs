using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    private NavMeshAgent agent;
    private bool isFollowing = false;
    private bool isStunned = false; // Check if the enemy is stunned
    [SerializeField] private BackgroundMusic backgroundMusicManager; // Reference to BackgroundMusic

    [SerializeField] private float stunDuration = 3f; // How long the enemy stops moving
    [SerializeField] private AudioSource alertSound; // Sound when player is detected
    [SerializeField] private bool hasBeenStunned = false; // Track if stunned before

    // **Serialized fields for stun dialogue**
    [SerializeField] private string[] stunnedDialogue = { "Danger has been successfully averted. For now." };
    [SerializeField] private AudioClip[] stunnedVoiceClips; // Assign in the Inspector

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void StunEnemy()
    {
        isStunned = true;
        agent.isStopped = true;

        Invoke(nameof(RecoverFromStun), stunDuration);
    }

    private void Update()
    {
        // If the enemy is following and not stunned, move toward the player
        if (isFollowing && !isStunned && player != null)
        {
            agent.SetDestination(player.position);
        }

        // Check for player stink attack input (E key) -- you can remove this if handled in the player script
        if (Input.GetKeyDown(KeyCode.E))
        {
            StinkAttack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isStunned)
        {
            isFollowing = true;
            alertSound.Play();

            // Switch to battle music
            if (backgroundMusicManager != null)
            {
                backgroundMusicManager.EnterBattle();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isStunned)
            {
                isFollowing = false;

                // Switch back to background music
                if (backgroundMusicManager != null)
                {
                    backgroundMusicManager.ExitBattle();
                }
            }
        }
    }

    private void RecoverFromStun()
    {
        isStunned = false;
        agent.isStopped = false; // Resume movement
    }

    [SerializeField] private ParticleSystem stinkEffect; // Reference to the stink effect on the player

    // Method to handle stink attack
public void StinkAttack()
{
    if (isFollowing)
    {
        isStunned = true;
        agent.isStopped = true;

        if (stinkEffect != null)
        {
            stinkEffect.Stop();
            stinkEffect.Play();
        }

        isFollowing = false;

        // **Only play stunned dialogue the first time**
        if (!hasBeenStunned)
        {
            hasBeenStunned = true; // Mark as stunned so it doesn’t repeat

            if (stunnedVoiceClips.Length == stunnedDialogue.Length && stunnedVoiceClips.Length > 0)
            {
                DialogueManager.Instance.PlayDialogue(stunnedDialogue, stunnedVoiceClips);
            }
            else
            {
                Debug.LogError("Stunned dialogue and voice clips must have the same length!");
            }
        }

        Invoke(nameof(RecoverFromStun), stunDuration);
    }
}

}
