using EnemyFactoryMethod;
using EnemyTypeFactoryMethod;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] 
    private List<EnemyType> _enemyList;
    private Dictionary<string, Enemy> _enemyDictionary;

    private void Awake()
    {
        InitializedDictionary();
    }

    private void InitializedDictionary()
    {
        _enemyDictionary = new Dictionary<string, Enemy>();

        foreach (var enemy in _enemyList)
            _enemyDictionary.Add(enemy.name, enemy.prefab);
    }

    public Enemy CreateEnemy(string enemyType)
    {
        if (_enemyDictionary.ContainsKey(enemyType))
        {
            Enemy _enemy = _enemyDictionary[enemyType];
            return Instantiate(_enemy);
        }
        else
        {
            Debug.LogError($"Неизвестный тип врага: {enemyType}");
            return null;
        }
    }
}
