using UnityEngine;

public class Sunroof : MonoBehaviour
{
    [SerializeField]
    private Vector2 _openedPosition;

    [SerializeField]
    private float _speed;

    private Vector2 _closedPosition;
    private bool _isOpening;

    private void Awake()
    {
        _closedPosition = transform.position;
    }

    public void Open()
    {
        _isOpening = true;
    }

    public void Close()
    {
        _isOpening = false;
    }

    public void Update()
    {
        if(_isOpening)
            transform.position = Vector2.MoveTowards(transform.position, _openedPosition, _speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, _closedPosition, _speed * Time.deltaTime);
    }
}
