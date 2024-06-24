using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 _moveInput;

    public void OnMove(InputAction.CallbackContext context) => _moveInput = context.ReadValue<Vector2>();

    private void Update()
    {
        var move = new Vector3(_moveInput.x, _moveInput.y, 0) * (moveSpeed * Time.deltaTime);
        transform.position += move;
    }
}
