using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth = 100f;
    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }

    public UnityEvent OnHealthChanged;


    public UnityEvent OnDeath;


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
