using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    bool isFiring = false;

    void Update()
    {
        ProcessFiring();
    }
    
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
        Debug.Log("Fire button pressed!");
    }

    void ProcessFiring()
    {
        var laserEmission = laser.GetComponent<ParticleSystem>().emission;
        laserEmission.enabled = isFiring;
    }
}
