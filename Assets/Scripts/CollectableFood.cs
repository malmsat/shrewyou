using UnityEngine;

public class CollectableFood : MonoBehaviour
{
    private ICollectableBehaviour _collectableBehaviour;

    private void Awake()
    {
        _collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }
    private void OnTriggerEnter(Collider other)// other.gameobject tutoriaalityypillä var player, pitää reference player somehow
    {
        if (other.CompareTag("Player"))
        {  
            _collectableBehaviour.OnCollected(other.gameObject);
            Destroy(gameObject);
        }
    }
}
