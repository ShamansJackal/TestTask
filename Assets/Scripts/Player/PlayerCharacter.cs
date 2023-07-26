using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private BaseMovementStrategy _movementStrategy;

    [SerializeField]
    private ItemHolder _itemHolder;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private static InputLayout InputActions;

    private InputAction _moveInput;
    private InputAction _interationInput;
    private InputAction _jumpInput;

    private void Awake()
    {
        if (InputActions == null)
            InputActions = new InputLayout();

        _itemHolder.OnItemRelease.AddListener(() => _spriteRenderer.color = Color.white);
        _itemHolder.OnItemTake.AddListener(() => _spriteRenderer.color = Color.red);

        _jumpInput = InputActions.Player.Jump;
        _moveInput = InputActions.Player.Move;
        _interationInput = InputActions.Player.Interact;

        _jumpInput.performed += ctx => _movementStrategy.Jump();
        _interationInput.performed += ctx => _itemHolder.Take();
        _interationInput.canceled += ctx => _itemHolder.Release();
    }

    private void OnEnable()
    {
        _jumpInput.Enable();
        _moveInput.Enable();
        _interationInput.Enable();
    }

    private void OnDisable()
    {
        _jumpInput.Disable();
        _moveInput.Disable();
        _interationInput.Disable();
    }

    private void OnDestroy()
    {
        _moveInput.performed -= ctx => _movementStrategy.Jump();
        _interationInput.performed -= ctx => _itemHolder.Take();
        _interationInput.canceled -= ctx => _itemHolder.Release();
    }

    private void Update()
    {
        var delta = _moveInput.ReadValue<float>();
        _movementStrategy.Move(delta * Time.deltaTime);
    }
}
