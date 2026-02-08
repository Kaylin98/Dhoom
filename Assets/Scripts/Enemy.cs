using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;
    
    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    
    void OnParticleCollision(GameObject other)
    {
        KillEnemy();
    }

    private void KillEnemy()
    {

        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

}
