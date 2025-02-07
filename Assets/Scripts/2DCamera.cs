using UnityEngine;

public class Camera2D : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;

    private void Awake()
    {
        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }
    }

    private void LateUpdate()
    {
        if (_mainCamera == null) return;

        Vector3 cameraPosition = _mainCamera.transform.position;
        cameraPosition.y = transform.position.y;
        
        transform.LookAt(cameraPosition);
        transform.Rotate(0f, 180f, 0f);
    }
}
