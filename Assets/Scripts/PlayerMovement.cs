using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public void OnMove(InputValue value)
    {
        Debug.Log("Move input received: " + value.Get<Vector2>());
    }

    
}
