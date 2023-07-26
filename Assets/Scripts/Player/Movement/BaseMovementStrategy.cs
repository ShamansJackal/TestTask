using UnityEngine;

public abstract class BaseMovementStrategy : MonoBehaviour
{
    public abstract void Move(float tod);

    public abstract void Jump();
}
