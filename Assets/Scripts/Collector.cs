using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable !=null)
        {
            Debug.Log("collected");
            collectable.Collect();
            other.gameObject.SetActive(false);
        }
    }
}
