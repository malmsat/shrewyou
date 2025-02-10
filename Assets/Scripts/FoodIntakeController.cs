using UnityEngine;
using UnityEngine.Events; // For Unity Events

public class FoodIntakeController : MonoBehaviour
{
    [SerializeField]
    private float _currentfoodIntake;
    [SerializeField]
    private float _maxFoodIntake;

    public UnityEvent OnFoodIntakeChanged;
    public float RemainingFoodPercentage
    {
        get
        {
            return _currentfoodIntake / _maxFoodIntake;
        }
    }


    public void AddFoodIntake(float foodAmount)
    {
        if (_currentfoodIntake == _maxFoodIntake)
        {
            Debug.Log("Food intake is already full!");
            return;
        }

        _currentfoodIntake += foodAmount;

        OnFoodIntakeChanged.Invoke();

        if (_currentfoodIntake > _maxFoodIntake)
        {
            _currentfoodIntake = _maxFoodIntake;
        }
    }

}
