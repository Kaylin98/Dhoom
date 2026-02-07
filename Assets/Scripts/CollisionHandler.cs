using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
     [SerializeField] GameObject explosionVFX;   
    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
