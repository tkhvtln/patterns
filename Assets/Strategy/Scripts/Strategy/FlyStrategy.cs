using UnityEngine;

public class FlyStrategy : IMoveStrategy
{
    public void Move(Transform transform)
    {
        Debug.Log("Flies...");
    }
}
