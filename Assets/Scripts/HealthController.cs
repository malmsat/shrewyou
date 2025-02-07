using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth = 100f;
    [SerializeField]
    private float _hungerDamage = 15f; // Fixed 15 HP per second

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }

    public UnityEvent OnHealthChanged;
    public UnityEvent OnDeath;

    private void Start()
    {
        // Start the hunger system
        StartCoroutine(HungerDamageRoutine());
    }

    private IEnumerator HungerDamageRoutine()
    {
        while (_currentHealth > 0) // Keeps running while the player is alive
        {
            yield return new WaitForSeconds(1f); // Waits 1 second
            TakeDamage(_hungerDamage); // Subtracts a fixed 15 HP
        }
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        _currentHealth -= damage;
        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            OnDeath.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maxHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;
        OnHealthChanged.Invoke();

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}
