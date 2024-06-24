using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Animator animator;

    private static readonly int Smack = Animator.StringToHash("Smack");
    private const float SMACK_DELAY = 0.5f;
    private float _nextSmackAllowedTime;
    private Vector2 _moveInput;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context) => _moveInput = context.ReadValue<Vector2>();

    public void OnSmack()
    {
        if (_nextSmackAllowedTime <= Time.time)
        {
            _nextSmackAllowedTime = Time.time + SMACK_DELAY;
            animator.SetTrigger(Smack);
        }
    }

    private void Update()
    {
        var move = new Vector3(_moveInput.x, _moveInput.y, 0) * (moveSpeed * Time.deltaTime);
        transform.position += move;
    }
}
