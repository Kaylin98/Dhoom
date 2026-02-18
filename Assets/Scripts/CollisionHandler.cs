using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
     [SerializeField] GameObject explosionVFX;   

    GameSceneManager gameSceneManager;

    void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        gameSceneManager.ReloadLevel();
    }
}
