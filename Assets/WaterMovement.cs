using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float speed = 0.1f;

    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = Vector2.zero;
    }

    void Update()
    {
        offset.y += speed * Time.deltaTime;
        rend.material.SetTextureOffset("_BaseMap", offset);
    }
}
