using UnityEngine;

public class FoodIntakeUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _foodIntakeForegroundImage;

    public void UpdateFoodIntakeUI(FoodIntakeController foodIntakeController)
    {
        _foodIntakeForegroundImage.fillAmount = foodIntakeController.RemainingFoodPercentage;
    }
}
