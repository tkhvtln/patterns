using UnityEngine;

public class WalkStrategy : IMoveStrategy
{
    public void Move(Transform transform)
    {
        Debug.Log("Walking...");
    }
}
