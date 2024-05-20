using UnityEngine;

interface IEnemyFactory 
{
    GameObject CreateAirEnemy();
    GameObject CreateGroundEnemy();
}
