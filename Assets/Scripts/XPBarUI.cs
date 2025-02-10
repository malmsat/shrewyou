using UnityEngine;
using UnityEngine.UI;

public class XPBarUI : MonoBehaviour
{
    [SerializeField] private Image _xpBarForegroundImage;

    public void UpdateXPBar(HealthController healthController)
    {
        _xpBarForegroundImage.fillAmount = healthController.XPPercentage;
    }
}
