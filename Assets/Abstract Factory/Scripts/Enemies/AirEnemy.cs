using EnemyAbstractFactory;
using UnityEngine;

public class AirEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("The air enemy is attacking!");
    }
}
