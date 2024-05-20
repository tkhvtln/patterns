using EnemyFactoryMethod;
using UnityEngine;

public class Ork : Enemy
{
    public override void Attack()
    {
        Debug.Log("Орк атакует!");
    }
}
