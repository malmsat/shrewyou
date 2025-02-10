using UnityEngine;

public class FoodIntakeCollectibleBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _foodAmount;

    public void OnCollected(GameObject collector)
    {
        var foodIntakeController = collector.GetComponent<FoodIntakeController>();
        if (foodIntakeController == null)
        {
            Debug.LogError($"FoodIntakeController not found on {collector.name}!");
            return;
        }

        foodIntakeController.AddFoodIntake(_foodAmount);
    }
}
