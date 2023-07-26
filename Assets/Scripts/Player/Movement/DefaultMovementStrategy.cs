using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DefaultMovementStrategy : BaseMovementStrategy
{
    [SerializeField]
    private float _speed = 10f;

    [SerializeField]
    private float _jumpForce = 2f;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private GroundDetection _groundDetection;

    public override void Jump()
    {
        if (_groundDetection.IsGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

    }

    public override void Move(float delta)
    {
        transform.position += new Vector3(delta * _speed, 0);
    }
}
