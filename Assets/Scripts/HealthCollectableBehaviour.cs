using UnityEngine;

public class HealthCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _healthAmount;
    
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); // Ensure your player GameObject has the "Player" tag
    }

    public void OnCollected(GameObject collector)
    {
        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the player has the correct tag.");
            return;
        }

        player.GetComponent<HealthController>().AddHealth(_healthAmount);
    }
}
