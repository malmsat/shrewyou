using UnityEngine;

public class HealthCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _healthAmount;
    [SerializeField] private float _xpAmount = 10f;
    public void OnCollected(GameObject collector)
    {
        var healthController = collector.GetComponent<HealthController>();
        if (healthController == null)
        {
            Debug.LogError($"HealthController not found on {collector.name}!");
            return;
        }

        healthController.AddHealth(_healthAmount);
        healthController.AddXP(_xpAmount);
    }
}
