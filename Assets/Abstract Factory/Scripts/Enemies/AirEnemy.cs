using EnemyAbstractFactory;
using UnityEngine;

public class AirEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("Воздушный враг атакует!");
    }
}
