using EnemyTypeAbstractFactory;
using System.Collections.Generic;
using UnityEngine;

public class FantasyEnemyFactory : MonoBehaviour, IEnemyFactory
{
    [SerializeField]
    private List<EnemyType> _enemyList;
    private Dictionary<string, GameObject> _enemyDictionary;

    private void Awake()
    {
        InitializedDictionary();
    }

    private void InitializedDictionary()
    {
        _enemyDictionary = new Dictionary<string, GameObject>();

        foreach (var enemy in _enemyList)
            _enemyDictionary.Add(enemy.name, enemy.prefab);
    }

    public GameObject CreateAirEnemy()
    {
        return InstantiateEnemy("air");
    }

    public GameObject CreateGroundEnemy()
    {
        return InstantiateEnemy("ground");
    }

    private GameObject InstantiateEnemy(string enemyType)
    {
        if (_enemyDictionary.ContainsKey(enemyType))
        {
            GameObject enemyObject = _enemyDictionary[enemyType];
            return Instantiate(enemyObject);
        }
        else
        {
            Debug.LogError($"Неизвестный тип врага: {enemyType}");
            return null;
        }
    }
}
