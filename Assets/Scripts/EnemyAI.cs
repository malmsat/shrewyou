using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    private NavMeshAgent agent;
    private bool isFollowing = false;
    private bool isStunned = false; // Check if the enemy is stunned

    [SerializeField] private float stunDuration = 3f; // How long the enemy stops moving
    [SerializeField] private AudioSource alertSound; // Sound when player is detected

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
            alertSound.Play(); // Play sound when player is detected
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Only stop following if not stunned
            if (!isStunned)
            {
                isFollowing = false;
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
                stinkEffect.Stop(); // Stop in case it's still playing
                stinkEffect.Play(); // Manually play the effect
            }

            // Disable following the player after stink attack
            isFollowing = false;

            Invoke(nameof(RecoverFromStun), stunDuration);
        }
    }
}
