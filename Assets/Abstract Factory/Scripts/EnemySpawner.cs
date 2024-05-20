using EnemyAbstractFactory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpawnerAbstractFactory
{
    public class EnemySpawnerAbstract : MonoBehaviour
    {
        [SerializeField] private FantasyEnemyFactory _fantasyEnemyFactory;
        [SerializeField] private FuturisticEnemyFactory _futuristicEnemyFactory;

        [Space]
        [SerializeField] private Button _buttonAir;
        [SerializeField] private Button _buttonGround;

        [Space]
        [SerializeField] private TMP_Dropdown _dropdownEnemy;

        private void Start()
        {
            _buttonAir.onClick.AddListener(() => SpawnEnemy("Air"));
            _buttonGround.onClick.AddListener(() => SpawnEnemy("Ground"));
        }

        private void SpawnEnemy(string name)
        {
            GameObject enemyObject = null;
            IEnemyFactory selectedFactory = GetSelectedFactory();

            if (selectedFactory == null)
            {
                Debug.LogError("Фабрика не выбрана!");
                return;
            }

            switch (name)
            {
                case "Air":
                    enemyObject = selectedFactory.CreateAirEnemy();
                    break;
                case "Ground":
                    enemyObject = selectedFactory.CreateGroundEnemy();
                    break;
            }

            if (enemyObject != null)
            {
                if (enemyObject.TryGetComponent(out Enemy enemy))
                    enemy.Attack();
                else
                    Debug.LogError("Компонент Enemy не найден на созданном объекте!");
            }
            else
            {
                Debug.LogError("Не удалось создать врага!");
            }
        }

        private IEnemyFactory GetSelectedFactory()
        {
            string selectedOption = _dropdownEnemy.options[_dropdownEnemy.value].text;

            switch (selectedOption)
            {
                case "Fantasy":
                    return _fantasyEnemyFactory;
                case "Futuristic":
                    return _futuristicEnemyFactory;
                default:
                    return null;
            }
        }
    }
}
