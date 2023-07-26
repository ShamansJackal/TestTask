using UnityEngine;
using UnityEngine.Events;

public class Button2D : MonoBehaviour
{
    public UnityEvent OnPressed;
    public UnityEvent OnRelease;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private bool _isPressed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isPressed) return;

        _isPressed = true;
        _spriteRenderer.color = Color.red;
        OnPressed.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_isPressed) return;

        _isPressed = false;
        _spriteRenderer.color = Color.green;
        OnRelease.Invoke();
    }
}
