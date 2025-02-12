using UnityEngine;
using UnityEngine.UI;

public class CharacterMovementUI : MonoBehaviour
{
    public RectTransform characterTransform; 
    public float speed = 100f; // Adjust based on your UI scale
    public float moveDistance = 300f; // How far it moves
    private Vector2 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = characterTransform.anchoredPosition;
    }

public Image characterImage; // Assign the Image component in Inspector

void Update()
{
    float moveStep = speed * Time.deltaTime;

    if (movingRight)
    {
        characterTransform.anchoredPosition += new Vector2(moveStep, 0);
        characterImage.rectTransform.localScale = new Vector3(1, 1, 1);
    }
    else
    {
        characterTransform.anchoredPosition -= new Vector2(moveStep, 0);
        characterImage.rectTransform.localScale = new Vector3(-1, 1, 1);
    }

    if (Mathf.Abs(characterTransform.anchoredPosition.x - startPos.x) >= moveDistance)
        movingRight = !movingRight;
}

}
