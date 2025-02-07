using UnityEngine;

public class CollectableFood : MonoBehaviour
{
    private ICollectableBehaviour _collectableBehaviour;

    private void Awake()
    {
        _collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _collectableBehaviour.OnCollected(other.gameObject);
            Destroy(gameObject);
        }
    }
}
