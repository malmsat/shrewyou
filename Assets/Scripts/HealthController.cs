using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using StarterAssets;
using UnityEngine.SceneManagement;



public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth = 100f;
    [SerializeField]
    private float _hungerDamage = 15f; // Fixed 15 HP per second
    // Add reference to ThirdPersonController
    private ThirdPersonController playerController;




    [SerializeField] private float _currentXP = 0f;
    [SerializeField] private float _maxXP = 100f;
    [SerializeField] private XPBarUI _xpBar;
    public UnityEvent OnXPChanged;

    public float XPPercentage => _currentXP / _maxXP;

    public void AddXP(float amount)
    {
        _currentXP += amount;
        if (_currentXP >= _maxXP)
        {
            _currentXP = _maxXP; // Keep it at max
            LevelUp();
        }
        OnXPChanged.Invoke(); // Notify UI to update XP bar
    }
    [SerializeField] private AudioClip _levelUpSound1;
    [SerializeField] private AudioClip _levelUpSound2;

    private void LevelUp()
    {
        // Play two dialogue lines with corresponding voice clips
        DialogueManager.Instance.PlayDialogue(
            new string[]
            {
                "Looks like the shrew has successfully eaten its fill for the night.",
                "It can now return to the safety of its home burrow."
            },
            new AudioClip[] { _levelUpSound1, _levelUpSound2 }
        );
    }





    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }

    public UnityEvent OnHealthChanged;
    public UnityEvent OnDeath;

    public Animator faceAnimator; // Assign in Inspector
    private bool isHungry = false; // Track hunger state

    private void Start()
    {
        playerController = GetComponent<ThirdPersonController>();
        StartCoroutine(HungerDamageRoutine());
        OnXPChanged.AddListener(() => _xpBar.UpdateXPBar(this));
    }

    private IEnumerator HungerDamageRoutine()
    {
        while (_currentHealth > 0) // Keeps running while the player is alive
        {
            yield return new WaitForSeconds(1f); // Waits 1 second
            TakeDamage(_hungerDamage); // Subtracts a fixed 15 HP
            UpdateFacialExpression(); // Update face when hunger changes
        }
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth == 0) return;

        _currentHealth -= damage;
        OnHealthChanged.Invoke();

        if (_currentHealth < 0) _currentHealth = 0;

        if (_currentHealth == 0)
        {
            OnDeath.Invoke();
            if (playerController != null)
            {
                playerController.enabled = false; // Disables movement
            }

            // Start coroutine to load the Main Menu after 5 seconds
            StartCoroutine(LoadMainMenuAfterDelay(5f));
        }

        UpdateFacialExpression();
    }

    private IEnumerator LoadMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu"); // Ensure your scene name is correct
    }



    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maxHealth) return;

        _currentHealth += amountToAdd;
        OnHealthChanged.Invoke();

        if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;

        UpdateFacialExpression(); // Update face when gaining health
    }

        private void UpdateFacialExpression()
    {
        bool shouldBeHungry = _currentHealth < _maxHealth * 0.5f;

        if (shouldBeHungry && !isHungry)
        {
            // Transition from happy to sad
            faceAnimator.SetTrigger("HappyToSad");
            isHungry = true;
        }
        else if (!shouldBeHungry && isHungry)
        {
            // Transition from sad to happy
            faceAnimator.SetTrigger("SadToHappy");
            isHungry = false;
        }
    }
}
