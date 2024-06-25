using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Animator animator;

    private static readonly int Smack = Animator.StringToHash("Smack");

    private CooldownExecutor _smashExecutor;
    private Vector2 _moveInput;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _smashExecutor = new(0.5f, () => animator.SetTrigger(Smack));
    }

    public void OnMove(InputAction.CallbackContext context) => _moveInput = context.ReadValue<Vector2>();

    public void OnSmack() => _smashExecutor.Execute();

    private void Update()
    {
        var move = new Vector3(_moveInput.x, _moveInput.y, 0) * (moveSpeed * Time.deltaTime);
        transform.position += move;
    }
}