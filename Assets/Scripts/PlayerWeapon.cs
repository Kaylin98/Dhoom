using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
    }
    
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (var laser in lasers)
        {
            var laserEmission = laser.GetComponent<ParticleSystem>().emission;
            laserEmission.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }
}
