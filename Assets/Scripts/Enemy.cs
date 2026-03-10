using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip hitSound;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 0;
    
    Scoreboard scoreboard;
    AudioSource audioSource; 

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(hitSound);

        hitPoints--;
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        scoreboard.IncreaseScore(scoreValue);
        
        GameObject vfx = Instantiate(explosionVFX, transform.position, transform.rotation);
        
        Destroy(vfx, 2f); 
        Destroy(gameObject); // Enemy is destroyed here
    }
}