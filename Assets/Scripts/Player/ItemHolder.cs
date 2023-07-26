using UnityEngine;
using UnityEngine.Events;

public class ItemHolder : MonoBehaviour
{
    public UnityEvent OnItemTake;
    public UnityEvent OnItemRelease;

    [SerializeField]
    private float _range = 2f;

    [SerializeField]
    private LayerMask _itemMask;

    private GameObject? _holdingItem;

    public void Take()
    {
        if (_holdingItem != null)
            return;

        var item = Physics2D.OverlapCircle(transform.position, _range, _itemMask);
        if(item != null)
        {
            _holdingItem = item.gameObject;
            _holdingItem.SetActive(false);
            OnItemTake.Invoke();
        }
    }

    public void Release()
    {
        if (_holdingItem == null)
            return;

        _holdingItem.transform.position = transform.position + new Vector3(0, 2f);
        _holdingItem.SetActive(true);
        _holdingItem = null;
        OnItemRelease.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
