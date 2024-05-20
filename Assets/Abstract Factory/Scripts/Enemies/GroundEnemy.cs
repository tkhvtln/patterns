using EnemyAbstractFactory;
using UnityEngine;

public class GroundEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("Наземный враг атакует!");
    }
}
