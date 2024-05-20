using EnemyFactoryMethod;
using UnityEngine;
using UnityEngine.UI;

namespace SpawnerFactoryMethod
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;

        [Space]
        [SerializeField] private Button _buttonElf;
        [SerializeField] private Button _buttonOrk;

        private void Start()
        {
            _buttonElf.onClick.AddListener(() => SpawnEnemy("Elf"));
            _buttonOrk.onClick.AddListener(() => SpawnEnemy("Ork"));
        }

        private void SpawnEnemy(string enemyType)
        {
            Enemy enemy = _enemyFactory.CreateEnemy(enemyType);

            if (enemy != null)
                enemy.Attack();
        }
    }
}
