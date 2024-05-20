using UnityEngine;

public class AttackState : IState
{
    private readonly Player _player;

    public AttackState(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("Entering Attack State");
    }

    public void Execute()
    {
        Debug.Log("Attacking...");
        // Логика атаки
    }

    public void Exit()
    {
        Debug.Log("Exiting Attack State");
    }
}
