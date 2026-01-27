using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xClampRange = 30f;
    [SerializeField] float yClampRange = 20f;

    [SerializeField] float controlRollFactor = 15f;
    [SerializeField] float rotationSpeed = 5f;
    
    Vector2 moveInput;


   
    private void Update()
    {
        ProcessTranslation();
        processRotation();
    }
    
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void processRotation()
    {
        Quaternion targetRotation =Quaternion.Euler(0f, 0f, moveInput.x * -controlRollFactor);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void ProcessTranslation()
    {
        float xOffset = moveInput.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = moveInput.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
}
