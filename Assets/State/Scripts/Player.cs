using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Button _buttonPatrol;
    [SerializeField] private Button _buttonAttack;

    private IState _currentState;
    private Dictionary<string, IState> _states;

    private void Start()
    {
        _buttonPatrol.onClick.AddListener(() => StartPatrol());
        _buttonAttack.onClick.AddListener(() => StartAttack());

        _states = new Dictionary<string, IState>()
        {
            { "Patrol", new PatrolState(this) },
            { "Attack", new AttackState(this) }
        };

        SetState("Patrol");
    }

    private void Update()
    {
        _currentState?.Execute();
    }

    private void SetState(string stateName)
    {
        if (_states.ContainsKey(stateName))
        {
            _currentState?.Exit();
            _currentState = _states[stateName];
            _currentState.Enter();
        }
        else
        {
            Debug.LogError($"State {stateName} not found!");
        }
    }

    private void StartPatrol()
    {
        SetState("Patrol");
    }

    private void StartAttack()
    {
        SetState("Attack");
    }
}
