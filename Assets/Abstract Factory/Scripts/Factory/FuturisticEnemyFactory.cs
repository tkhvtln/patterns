using System.Collections.Generic;
using UnityEngine;

public class FuturisticEnemyFactory : MonoBehaviour, IEnemyFactory
{
    [System.Serializable]
    public class EnemyType
    {
        public string name;
        public GameObject prefab;
    }

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
        return InstantiateEnemy("Air");
    }

    public GameObject CreateGroundEnemy()
    {
        return InstantiateEnemy("Ground");
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
