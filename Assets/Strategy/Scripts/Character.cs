using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private Button _buttonFly;
    [SerializeField] private Button _buttonWalk;

    private IMoveStrategy _moveStrategy;
    private Dictionary<string, IMoveStrategy> _strategies;

    private void Start()
    {
        _strategies = new Dictionary<string, IMoveStrategy>()
        {
            { "Fly", new FlyStrategy() },
            { "Walk", new WalkStrategy() },
        };       

        _buttonFly.onClick.AddListener(() => SetMoveStrategy("Fly"));
        _buttonWalk.onClick.AddListener(() => SetMoveStrategy("Walk"));

        SetMoveStrategy("Walk");
    }

    private void Update()
    {
        _moveStrategy?.Move(transform);
    }

    public void SetMoveStrategy(string strategyName)
    {
        if (_strategies.ContainsKey(strategyName))
        {
            _moveStrategy = _strategies[strategyName];
            Debug.Log($"Strategy changed to: {strategyName}");
        }
        else
        {
            Debug.LogError($"Strategy with key {strategyName} not found!");
        }
    }
}
