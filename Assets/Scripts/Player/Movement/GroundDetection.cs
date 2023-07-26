using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask _groundMask;

    [SerializeField]
    private Vector2 _boxSize;
    
    public bool IsGrounded => Physics2D.OverlapBox(transform.position, _boxSize, 0, _groundMask.value) != null;

    private void OnDrawGizmos()
    {
        if (IsGrounded)
            Gizmos.color = new Color(0, 1, 0, 0.5f);
        else
            Gizmos.color = new Color(1, 0, 0, 0.5f);

        Gizmos.DrawCube(transform.position, _boxSize);
    }
}
